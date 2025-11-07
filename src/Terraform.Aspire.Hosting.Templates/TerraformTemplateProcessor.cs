using HandlebarsDotNet;
using HandlebarsDotNet.Extension.Json;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.Enums;
using HandlebarsDotNet.Helpers.IO;
using HandlebarsDotNet.Helpers.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text;
using HandlebarsDotNet.PathStructure;

namespace Terraform.Aspire.Hosting.Templates;

/// <summary>
/// Provides Handlebars-based processing for Terraform template files (compile, render, copy, and cleanup).
/// </summary>
public class TerraformTemplateProcessor
{
    private readonly IHandlebars _handlebarsContext;

    /// <summary>
    /// Initializes a new instance configuring Handlebars helpers and a passthrough encoder.
    /// </summary>
    public TerraformTemplateProcessor()
    {
        Logger = new NullLogger<TerraformTemplateProcessor>();
        _handlebarsContext = Handlebars.Create(new HandlebarsConfiguration { TextEncoder = new PassthroughTextEncoder() }); // no encoding
        _handlebarsContext.Configuration.UseJson();
        HandlebarsHelpers.Register(_handlebarsContext, options => { options.UseCategoryPrefix = false; });
        HandlebarsHelpers.Register(_handlebarsContext, options =>
        {
            options.Categories = [Category.DynamicLinq];
            options.UseCategoryPrefix = false;
            options.DynamicLinqHelperOptions = new HandlebarsDynamicLinqHelperOptions { AllowEqualsAndToStringMethodsOnObject = true };
        });
        _handlebarsContext.RegisterHelper("TfEscape", EscapeTerraformString);
        _handlebarsContext.RegisterHelper("TfRemoveBraces", RemoveBracesTerraformString);
    }

    public const string TEMPLATE_EXTENSION = ".hbs";
    public const string TF_TEMPLATE_EXTENSION = ".tf.hbs";
    public const string TF_EXTENSION = ".tf";

    public required ILogger Logger { get; set; }
    public string OutputPath { get; set; } = "./.terraform";
    public string TemplateBasePath { get; set; } = "./templates";
    public bool SkipExistingFile { get; set; }

    /// <summary>
    /// Compiles a template file and writes the rendered output to a target file, optionally appending.
    /// </summary>
    /// <param name="templateFile">Template file name relative to <see cref="TemplateBasePath"/>.</param>
    /// <param name="targetFile">Output file name relative to <see cref="OutputPath"/>.</param>
    /// <param name="targetTemplateFile">Override template file name searched in the output directory.</param>
    /// <param name="data">Model passed to the template.</param>
    /// <param name="append">Whether to append instead of overwrite.</param>
    public async Task InvokeTemplate(string templateFile, string targetFile, string targetTemplateFile, object data, bool append = false)
    {
        var templatePath = Path.Combine(TemplateBasePath, templateFile);
        var targetPath = Path.Combine(OutputPath, targetFile);
        var targetTemplatePath1 = Path.Combine(OutputPath, targetTemplateFile); // template of the resource at output path
        var targetTemplatePath2 = Path.Combine(OutputPath, templateFile); // template at output path

        templatePath = templatePath.Replace('\\', '/');
        targetPath = targetPath.Replace('\\', '/');
        targetTemplatePath1 = targetTemplatePath1.Replace('\\', '/');
        targetTemplatePath2 = targetTemplatePath2.Replace('\\', '/');

        if (SkipExistingFile && File.Exists(targetPath))
        {
            Logger.LogInformation("Skip {target} ({template})", targetFile, templateFile);
            return;
        }

        if (File.Exists(targetTemplatePath1))
        {
            templatePath = targetTemplatePath1;
        }
        else if (File.Exists(targetTemplatePath2))
        {
            templatePath = targetTemplatePath2;
        }

        Logger.LogInformation("Write {target} ({template})", targetFile, templatePath);

        Stream stream;
        if (templatePath.StartsWith("https://") || templatePath.StartsWith("http://"))
        {
            using var httpClient = new HttpClient();
            stream = await httpClient.GetStreamAsync(templatePath);
        }
        else
        {
            if (File.Exists(templatePath))
            {
                stream = File.OpenRead(templatePath);
            }
            else
            {
                throw new FileNotFoundException("Template file not found", templatePath);
            }
        }

        using var templateReader = new StreamReader(stream);

        await using var writer = new StreamWriter(targetPath,
            new FileStreamOptions { Mode = append ? FileMode.Append : FileMode.Create, Access = FileAccess.Write });

        var template = _handlebarsContext.Compile(templateReader);
        template(writer, data);
        stream.Close();
    }

    /// <summary>
    /// Renders a string template with the provided model, optionally escaping single braces.
    /// </summary>
    /// <param name="template">Handlebars template string.</param>
    /// <param name="data">Model passed to the template.</param>
    /// <param name="replaceSingleBraces">If true replaces single braces with escaped versions.</param>
    /// <returns>Rendered template string.</returns>
    public string InvokeStringTemplate(string template, object data, bool replaceSingleBraces = false)
    {
        //return template;
        if (replaceSingleBraces)
            template = template.Replace("{", "{{").Replace("}", "}}");
        return _handlebarsContext.Compile(template)(data);
    }

    private static void EscapeTerraformString(EncodedTextWriter output, Context context, Arguments arguments)
    {
        var sb = new StringBuilder();
        foreach (var c in arguments[0].ToString())
            if (c == '\r')
                sb.Append("\\r");
            else if (c == '\n')
                sb.Append("\\n");
            else if (c == '"')
                sb.Append("\\\"");
            else if (c == '\t')
                sb.Append("\\t");
            else if (c == '\\')
                sb.Append("\\\\");
            else if (c > 127)
                sb.Append("\\u").Append(((int)c).ToString("X4"));
            else
                sb.Append(c);
        output.Write(sb);
    }

    private static void RemoveBracesTerraformString(EncodedTextWriter output, Context context, Arguments arguments)
    {
        output.Write(arguments[0].ToString().Replace("${", "").Replace("}", ""));
    }

    /// <summary>
    /// Deletes an output file if it exists.
    /// </summary>
    /// <param name="outputFile">File name relative to <see cref="OutputPath"/>.</param>
    public void ClearOutputFile(string outputFile)
    {
        var path = Path.Combine(OutputPath, outputFile);
        if (File.Exists(path)) File.Delete(path);
    }

    /// <summary>
    /// Copies a source file from the template base path (or URL) to the output path.
    /// </summary>
    /// <param name="filename">File name to copy.</param>
    public async Task CopySourceFile(string filename)
    {
        Stream? sourceStream = null;

        try
        {
            var sourcePath = Path.Combine(TemplateBasePath, filename);
            var targetPath = Path.Combine(OutputPath, filename);

            if (sourcePath.StartsWith("https://") || sourcePath.StartsWith("http://"))
            {
                using var httpClient = new HttpClient();
                sourceStream = await httpClient.GetStreamAsync(sourcePath);
            }
            else
            {
                sourceStream = File.OpenRead(sourcePath);
            }

            Logger.LogInformation("Copy file {File}", filename);

            await using var targetStream = File.Create(targetPath);
            await sourceStream.CopyToAsync(targetStream);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error copying file {File}", filename);
            throw;
        }
        finally
        {
            if (sourceStream != null)
            {
                await sourceStream.DisposeAsync();
            }
        }
    }
}