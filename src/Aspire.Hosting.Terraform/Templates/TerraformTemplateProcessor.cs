using System.Text;
using HandlebarsDotNet;
using HandlebarsDotNet.Extension.Json;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.Enums;
using HandlebarsDotNet.Helpers.IO;
using HandlebarsDotNet.Helpers.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Aspire.Hosting.Terraform.Templates;

public class TerraformTemplateProcessor
{
    private readonly IHandlebars _handlebarsContext;
    //private readonly ILogger _logger;

    public ILogger Logger { get; set; }

    public TerraformTemplateProcessor(/*ILogger<TerraformTemplateProcessor> logger*/)
    {
        Logger = new NullLogger<TerraformTemplateProcessor>();
        //_logger = logger;
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
    }

    public string OutputPath { get; set; } = "./infra";
    public string TemplateBasePath { get; set; } = "./templates";
    public bool SkipExistingFile { get; set; }

    public async Task InvokeTemplate(string templateFile, string targetFile, string targetTemplateFile, object data, bool append = false)
    {
        var templatePath = Path.Combine(TemplateBasePath, templateFile);
        var targetPath = Path.Combine(OutputPath, targetFile);
        var targetTemplatePath = Path.Combine(OutputPath, targetTemplateFile);

        templatePath = templatePath.Replace('\\', '/');
        targetPath = targetPath.Replace('\\', '/');
        targetTemplatePath = targetTemplatePath.Replace('\\', '/');

        if (SkipExistingFile && File.Exists(targetPath))
        {
            Logger.LogInformation("Skip {target} ({template})", targetFile, templateFile);
            return;
        }

        if (File.Exists(targetTemplatePath)) templatePath = targetTemplatePath; // use template from output path if exists

        Logger.LogInformation("Write {target} ({template})", targetFile, templatePath);

        Stream stream;
        if (templatePath.StartsWith("https://") || templatePath.StartsWith("http://"))
        {
            using var httpClient = new HttpClient();
            stream = await httpClient.GetStreamAsync(templatePath);
        }
        else
        {
            stream = File.OpenRead(templatePath);
        }

        using var templateReader = new StreamReader(stream);

        await using var writer = new StreamWriter(targetPath,
            new FileStreamOptions { Mode = append ? FileMode.Append : FileMode.Create, Access = FileAccess.Write });

        var template = _handlebarsContext.Compile(templateReader);
        template(writer, data);
        stream.Close();
    }

    public string InvokeStringTemplate(string template, object data, bool replaceSingleBrackets = false)
    {
        if (replaceSingleBrackets)
            template = template.Replace("{", "{{").Replace("}", "}}");
        return _handlebarsContext.Compile(template)(data);
    }

    private void EscapeTerraformString(EncodedTextWriter output, Context context, Arguments arguments)
    {
        var sb = new StringBuilder();
        foreach (var c in context.Value.ToString())
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

    public void ClearOutputFile(string outputFile)
    {
        var path = Path.Combine(OutputPath, outputFile);
        if (File.Exists(path)) File.Delete(path);
    }

    public void CopyTemplateFile(string filename)
    {
        var sourcePath = Path.Combine(TemplateBasePath, filename);
        var targetPath = Path.Combine(OutputPath, filename);

        if (File.Exists(sourcePath))
        {
            Logger.LogInformation("Copy file {File}", filename);
            File.Copy(sourcePath, targetPath, true);
        }
    }
}