using HandlebarsDotNet;
using HandlebarsDotNet.Extension.Json;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.Enums;
using HandlebarsDotNet.Helpers.IO;
using HandlebarsDotNet.Helpers.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text;
using System.Text.RegularExpressions;

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

    /// <summary>Default Handlebars template extension.</summary>
    public const string TEMPLATE_EXTENSION = ".hbs";
    /// <summary>Extension for Terraform Handlebars templates.</summary>
    public const string TF_TEMPLATE_EXTENSION = ".tf.hbs";
    /// <summary>Extension for generated Terraform files.</summary>
    public const string TF_EXTENSION = ".tf";

    /// <summary>Logger used for template processing.</summary>
    public required ILogger Logger { get; set; }
    /// <summary>Directory where generated files are written.</summary>
    public string OutputPath { get; set; } = "./.terraform";
    /// <summary>Base directory or URL root for template files.</summary>
    public string TemplateBasePath { get; set; } = "./templates";
    /// <summary>If true skips overwriting files that already exist.</summary>
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
        var targetTemplatePath1 = Path.Combine(OutputPath, targetTemplateFile); // template of the resource at output path
        var targetTemplatePath2 = Path.Combine(OutputPath, templateFile); // template at output path

        templatePath = templatePath.Replace('\\', '/');
        targetTemplatePath1 = targetTemplatePath1.Replace('\\', '/');
        targetTemplatePath2 = targetTemplatePath2.Replace('\\', '/');

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

        await InvokeTemplate(stream, targetFile, targetTemplateFile, data, append);

        //using var templateReader = new StreamReader(stream);

        //await using var writer = new StreamWriter(targetPath,
        //    new FileStreamOptions { Mode = append ? FileMode.Append : FileMode.Create, Access = FileAccess.Write });

        //var template = _handlebarsContext.Compile(templateReader);
        //template(writer, data);
        stream.Close();
    }

    /// <summary>
    /// Processes a Handlebars template from the specified stream and writes the rendered output to a target file.
    /// </summary>
    /// <remarks>If the target file already exists and skipping existing files is enabled, the method does not
    /// overwrite the file. The method uses the provided data object as the context for template rendering. The target
    /// file path uses forward slashes regardless of the operating system.</remarks>
    /// <param name="templateStream">A stream containing the Handlebars template to be processed. The stream must be readable and positioned at the
    /// start of the template content.</param>
    /// <param name="targetFile">The relative path of the file to which the rendered output will be written. The path is combined with the output
    /// directory.</param>
    /// <param name="targetTemplateFile">The name or path of the template file being processed. Used for logging or reference purposes.</param>
    /// <param name="data">An object containing the data context to be used when rendering the template. The properties of this object are
    /// accessible within the template.</param>
    /// <param name="append">true to append the rendered output to the target file if it exists; otherwise, false to overwrite the file.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task InvokeTemplate(Stream templateStream, string targetFile, string targetTemplateFile, object data, bool append = false)
    {
        var targetPath = Path.Combine(OutputPath, targetFile);
        targetPath = targetPath.Replace('\\', '/');

        if (SkipExistingFile && File.Exists(targetPath))
        {
            Logger.LogInformation("Skip {target}", targetFile);
            return;
        }

        using var templateReader = new StreamReader(templateStream);

        await using var writer = new StreamWriter(targetPath,
            new FileStreamOptions { Mode = append ? FileMode.Append : FileMode.Create, Access = FileAccess.Write });

        var template = _handlebarsContext.Compile(templateReader);
        template(writer, data);
    }

    /// <summary>
    /// Renders a string template with the provided model, optionally escaping single braces.
    /// </summary>
    /// <param name="template">Handlebars template string.</param>
    /// <param name="data">Model passed to the template.</param>
    /// <param name="replaceSingleBraces">If true replaces single braces with escaped versions.</param>
    /// <returns>Rendered template string.</returns>
    public string InvokeStringTemplate(string template, object data, bool replaceSingleBraces = true)
    {
        if (replaceSingleBraces)
        {
            // add double braces but only when it is not an terraform string ${}
            var sb = new StringBuilder();
            var c = 0;
            for (int i = 0; i < template.Length; i++)
            {
                sb.Append(template[i]);
                if (template[i] == '{')
                {
                    if (i == 0 || template[i - 1] != '$')
                    {
                        sb.Append(template[i]);
                        c++;
                    }
                }

                if (template[i] == '}' && c > 0)
                {
                    sb.Append(template[i]);
                    c--;
                }
            }
            template = sb.ToString();
        }

        return _handlebarsContext.Compile(template)(data);
    }

    private static void EscapeTerraformString(EncodedTextWriter output, Context context, Arguments arguments)
    {
        if (arguments.Length == 0)
            return;

        var sb = new StringBuilder();
        foreach (var c in arguments[0].ToString()!)
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

    private static readonly Regex _tfInterpolationRegex = new(@"\$\{([^}]*)\}", RegexOptions.Compiled);

    private static void RemoveBracesTerraformString(EncodedTextWriter output, Context context, Arguments arguments)
    {
        // Regex replaces each ${...} with the inner content (group 1), ensuring only the matching closing } is removed.
        if (arguments.Length == 0)
        {
            return;
        }

        var input = arguments[0]?.ToString();
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        var result = _tfInterpolationRegex.Replace(input, static m => m.Groups[1].Value);
        output.Write(result);
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