using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.Unicode;
using Aspire.Terraform.Models;
using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;
using HandlebarsDotNet.Helpers.IO;
using Microsoft.Extensions.Logging;

namespace Aspire.Terraform;

public class TerraformTemplateProcessor
{
    private readonly ILogger<TerraformTemplateProcessor> _logger;
    private readonly IHandlebars _handlebarsContext;

    private readonly Dictionary<string, string> _bicepResourceTypeMap = new()
    {
        { "sql.module.bicep", "sqlserver" },
        { "aspire.hosting.azure.bicep.sql.bicep", "sqlserver" },
        { "sqlserver.module.bicep", "sqlserver" },
        { "storage.module.bicep", "storage" },
        { "aspire.hosting.azure.bicep.storage.bicep", "storage" },
        { "cosmos.module.bicep", "cosmos" },
        { "aspire.hosting.azure.bicep.cosmos.bicep", "cosmos" },
        { "postgres.module.bicep", "postgres" },
        { "aspire.hosting.azure.bicep.postgres.bicep", "postgres" },
        { "servicebus.module.bicep", "servicebus" },
        { "aspire.hosting.azure.bicep.servicebus.bicep", "servicebus" },
        { "ai.module.bicep", "appinsights" },
        { "appinsights.module.bicep", "appinsights" },
        { "aspire.hosting.azure.bicep.appinsights.bicep", "appinsights" },
        { "test.bicep", "test" },
        { "aspire.hosting.azure.bicep.test.bicep", "test" },
        { "cache.module.bicep", "cache" },
        { "secrets.module.bicep", "keyvault" },
    };

    public TerraformTemplateProcessor(ILogger<TerraformTemplateProcessor> logger)
    {
        _logger = logger;
        _handlebarsContext = Handlebars.Create(new HandlebarsConfiguration() { TextEncoder = new PassthroughTextEncoder() }); // no encoding
        HandlebarsHelpers.Register(_handlebarsContext, options => { options.UseCategoryPrefix = false; });
        _handlebarsContext.RegisterHelper("TfEscape", EscapeTerraformString);
    }

    public string ManifestPath { get; set; }
    public string TargetDirectory { get; set; }
    public string? TemplateDirectory { get; set; }

    public async Task Generate()
    {
        if (string.IsNullOrWhiteSpace(TemplateDirectory))
            TemplateDirectory = Path.Combine(TargetDirectory, ".templates");

        try
        {
            await using var manifestStream = File.OpenRead(ManifestPath);
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web) { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };
            var manifest = await JsonSerializer.DeserializeAsync<AppHostManifest>(manifestStream, options);

            // remove existing variables-app.tf file
            if (File.Exists(Path.Combine(TargetDirectory, "variables-app.tf")))
                File.Delete(Path.Combine(TargetDirectory, "variables-app.tf"));

            foreach (var resource in manifest.Resources)
            {
                resource.Value.Key = resource.Key;

                if (resource.Value is AzureBicepResource azureBicepResource)
                {
                    switch (_bicepResourceTypeMap[azureBicepResource.Path])
                    {
                        case "cache":
                            resource.Value.Outputs.Add("connectionString", "${local." + resource.Key + ".connectionString}");
                            break;
                        case "sqlserver":
                            resource.Value.Outputs.Add("sqlServerFqdn", "${local." + resource.Key + ".sqlServerFqdn}");
                            break;
                        case "storage":
                            resource.Value.Outputs.Add("tableEndpoint", "${local." + resource.Key + ".tableEndpoint}");
                            resource.Value.Outputs.Add("blobEndpoint", "${local." + resource.Key + ".blobEndpoint}");
                            resource.Value.Outputs.Add("queueEndpoint", "${local." + resource.Key + ".queueEndpoint}");
                            resource.Value.Outputs.Add("fileEndpoint", "${local." + resource.Key + ".fileEndpoint}");
                            break;
                        case "keyvault":
                            resource.Value.Outputs.Add("vaultUri", "${local." + resource.Key + ".vaultUri}");
                            break;
                        case "appinsights":
                            resource.Value.Outputs.Add("connectionString", "${local." + resource.Key + ".connectionString}");
                            resource.Value.Outputs.Add("appInsightsConnectionString", "${local." + resource.Key + ".connectionString}");
                            break;
                    }

                    if (azureBicepResource.ConnectionString != null)
                        azureBicepResource.ConnectionString = InvokeStringTemplate(azureBicepResource.ConnectionString, manifest.Resources, true);
                }
                else if (resource.Value is ParameterResource parameterResource)
                {
                    parameterResource.Value = "${var." + resource.Key + "}";
                }
                else if (resource.Value is ContainerResource containerResource)
                {
                    containerResource.Outputs.Add("fqdn", "${local.\" + resource.Key + \".fqdn}");

                    if (containerResource.Bindings != null)
                    {
                        foreach (var binding in containerResource.Bindings)
                        {
                            binding.Value.Host = $"{{local.{resource.Key}.name}}";
                            binding.Value.Url = $"{binding.Value.Scheme}://${{local.{resource.Key}.name}}.internal.${{local.{resource.Key}.fqdn}}";
                        }
                    }

                    if (containerResource.ConnectionString != null)
                        containerResource.ConnectionString = InvokeStringTemplate(containerResource.ConnectionString, manifest.Resources, true);
                }
                else if (resource.Value is ValueResource valueResource)
                {
                    if (valueResource.ConnectionString != null)
                        valueResource.ConnectionString = InvokeStringTemplate(valueResource.ConnectionString, manifest.Resources, true);
                }
            }

            foreach (var resource in manifest.Resources)
            {
                _logger.LogDebug($"Resource: {resource.Key} Type: {resource.Value.GetType().Name}");

                if (resource.Value is ValueResource valueResource)
                {
                    valueResource.ConnectionString = InvokeStringTemplate(valueResource.ConnectionString, manifest.Resources, true);
                }
                else if (resource.Value is ParameterResource parameterResource)
                {
                    InvokeTemplate("variable.tmpl.tf", "variables-app.tf", parameterResource, true);
                }
                else if (resource.Value is AzureBicepResource azureBicepResource)
                {
                    _logger.LogDebug($" Path: {azureBicepResource.Path}");

                    if (!string.IsNullOrWhiteSpace(azureBicepResource.ConnectionString))
                        azureBicepResource.ConnectionString = InvokeStringTemplate(azureBicepResource.ConnectionString, manifest.Resources, true);

                    var resourceType = _bicepResourceTypeMap[azureBicepResource.Path];

                    InvokeTemplate($"main-{resourceType}.tmpl.tf", $"main-{resource.Key}.tf", azureBicepResource);

                    switch (resourceType)
                    {
                        case "sqlserver":
                            foreach (var dbResource in manifest.Resources.Values.OfType<ValueResource>()
                                         .Where(p => p.ConnectionString.Contains($"{{{azureBicepResource.Key}.connectionString}}")))
                            {
                                dbResource.Parent = azureBicepResource;
                                //if (!string.IsNullOrWhiteSpace(dbResource.ConnectionString))
                                //    dbResource.ConnectionString = InvokeStringTemplate(dbResource.ConnectionString, manifest.Resources, true);
                                InvokeTemplate($"main-{resourceType}-db.tmpl.tf", $"main-{resource.Key}.tf", dbResource, true);
                            }

                            break;
                        case "storage":
                            foreach (var childResource in manifest.Resources.Values.OfType<ValueResource>()
                                         .Where(p => p.ConnectionString.Contains($"{{{azureBicepResource.Key}.outputs.tableEndpoint}}")))
                            {
                                childResource.Parent = azureBicepResource;
                                InvokeTemplate($"main-{resourceType}-table.tmpl.tf", $"main-{resource.Key}.tf", childResource, true);
                            }

                            foreach (var childResource in manifest.Resources.Values.OfType<ValueResource>()
                                         .Where(p => p.ConnectionString.Contains($"{{{azureBicepResource.Key}.outputs.blobEndpoint}}")))
                            {
                                childResource.Parent = azureBicepResource;
                                InvokeTemplate($"main-{resourceType}-blob.tmpl.tf", $"main-{resource.Key}.tf", childResource, true);
                            }

                            foreach (var childResource in manifest.Resources.Values.OfType<ValueResource>()
                                         .Where(p => p.ConnectionString.Contains($"{{{azureBicepResource.Key}.outputs.queueEndpoint}}")))
                            {
                                childResource.Parent = azureBicepResource;
                                InvokeTemplate($"main-{resourceType}-queue.tmpl.tf", $"main-{resource.Key}.tf", childResource, true);
                            }

                            break;
                    }
                }
                else if (resource.Value is ContainerResource containerResource)
                {
                    // container app
                    _logger.LogDebug($" Container Image: {containerResource.Image}");

                    if (containerResource is ProjectResource projectResource)
                    {
                        _logger.LogDebug($" Project: {projectResource.Path}");
                        projectResource.Image = "${azurerm_container_registry.app.login_server}/" + projectResource.Key + ":latest";
                    }

                    if (containerResource.Bindings != null)
                        foreach (var containerResourceBinding in containerResource.Bindings)
                        {
                            containerResourceBinding.Value.Host = containerResource.Key;
                            if (containerResourceBinding.Value.Port == null || containerResourceBinding.Value.Port == 0)
                                containerResourceBinding.Value.Port = containerResourceBinding.Value.TargetPort;
                        }

                    if (!string.IsNullOrWhiteSpace(containerResource.ConnectionString))
                        containerResource.ConnectionString = InvokeStringTemplate(containerResource.ConnectionString, manifest.Resources, true);

                    if (containerResource.Env != null)
                        foreach (var env in containerResource.Env)
                        {
                            containerResource.Env[env.Key] = InvokeStringTemplate(env.Value, manifest.Resources, true);
                        }

                    if (containerResource.Args != null)
                    {
                        for (var i = 0; i < containerResource.Args.Count; i++)
                            containerResource.Args[i] = InvokeStringTemplate(containerResource.Args[i], manifest.Resources, true);
                    }

                    InvokeTemplate("main-app.tmpl.tf", $"main-{resource.Key}.tf", containerResource);
                }
                else if (resource.Value is DockerFileResource dockerFileResource)
                {
                    // container app
                    _logger.LogDebug($"DockerFile Path: {dockerFileResource.Path}");

                    if (dockerFileResource.Env != null)
                        foreach (var env in dockerFileResource.Env)
                            dockerFileResource.Env[env.Key] = InvokeStringTemplate(env.Value, manifest.Resources, true);

                    if (dockerFileResource.Args != null)
                    {
                        for (var i = 0; i < dockerFileResource.Args.Count; i++)
                            dockerFileResource.Args[i] = InvokeStringTemplate(dockerFileResource.Args[i], manifest.Resources, true);
                    }

                    InvokeTemplate("main-app.tmpl.tf", $"main-{resource.Key}.tf", dockerFileResource);
                }
            }
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error generating tf files");
            throw;
        }
    }
    public void InvokeTemplate(string templateFile, string targetFile, object data, bool append = false)
    {
        _logger.LogInformation("Write {targetFile} ({templateFile})", targetFile, templateFile);
        using var templateReader = new StreamReader(File.OpenRead(Path.Combine(TemplateDirectory, templateFile)));
        var template = _handlebarsContext.Compile(templateReader);
        using var writer = new StreamWriter(Path.Combine(TargetDirectory, targetFile),
            new FileStreamOptions { Mode = append ? FileMode.Append : FileMode.Create, Access = FileAccess.Write });
        template(writer, data);
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
        {
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
        }
        output.Write(sb);
    }
}
