using System.Text.RegularExpressions;
using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Terraform.Aspire.Hosting.Templates.Models;
using ContainerResource = Aspire.Hosting.ApplicationModel.ContainerResource;
using ParameterResource = Aspire.Hosting.ApplicationModel.ParameterResource;
using ProjectResource = Aspire.Hosting.ApplicationModel.ProjectResource;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Templates;

/// <summary>
/// A distributed application publisher that generates Terraform infrastructure-as-code files 
/// from an Aspire application model using Handlebars templates. This publisher processes 
/// various resource types (containers, projects, parameters) and converts them into 
/// corresponding Terraform configurations for cloud deployment.
/// </summary>
/// <param name="logger">Logger for tracking the publishing process and debugging.</param>
/// <param name="progressReporter">Reports publishing progress to the Aspire tooling.</param>
/// <param name="executionContext">Provides context about the current distributed application execution.</param>
/// <param name="publishingOptions">General publishing configuration options including output paths.</param>
/// <param name="terraformPublishingOptions">Terraform-specific publishing options such as template paths and base files.</param>
/// <param name="processor">The template processor that handles Handlebars template rendering and file operations.</param>
public class TerraformTemplatePublisher(
    ILogger<TerraformTemplatePublisher> logger,
    IPublishingActivityReporter progressReporter,
    DistributedApplicationExecutionContext executionContext,
    IOptions<PublishingOptions> publishingOptions,
    IOptions<TerraformTemplatePublishingOptions> terraformPublishingOptions,
    TerraformTemplateProcessor processor) : IDistributedApplicationPublisher
{
    /// <summary>
    /// Publish model.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
    {
        await progressReporter.CreateStepAsync("Create Terraform files from templates", cancellationToken);

        processor.OutputPath = publishingOptions.Value.OutputPath ?? "./.terraform";
        processor.TemplateBasePath = terraformPublishingOptions.Value.TemplatesPath ?? "./.templates";
        processor.Logger = logger;

        if (!Directory.Exists(processor.OutputPath))
        {
            Directory.CreateDirectory(processor.OutputPath);
        }

        // prepare
        logger.LogInformation("Prepare Resources for Terraform");

        var modelResources = new Dictionary<string, TemplateResource>();

        // build annotations
        foreach (var resource in model.Resources)
        {
            await PrepareResource(resource, modelResources);
            ExpandTerraformParameters(resource);
        }

        var terraformAnnotations = model.Resources.SelectMany(p => p.Annotations.OfType<ITerraformTemplateAnnotation>()).ToList();
        modelResources.Clear();
        var allTemplateResources = terraformAnnotations.Select(p => p.GetTemplateResource()).ToList();
        foreach (var templateResource in allTemplateResources)
        {
            AppendModelResource(modelResources, templateResource);
        }

        // build/set references
        foreach (var resource in modelResources.Values)
        {
            resource.References = resource.Resource.Annotations.OfType<ResourceRelationshipAnnotation>()
                .Select(p => p.Resource.Name).Distinct()
                .Select(p => modelResources[p])
                .ToList();

            resource.ReferencedBy =
                modelResources.Values.Where(p => p.Resource.Annotations.OfType<ResourceRelationshipAnnotation>()
                        .Any(p => p.Resource == resource.Resource))
                    .Select(p => p.Name)
                    .Distinct()
                    .Select(p => modelResources[p])
                    .ToList();
        }

        // clear target files
        foreach (var outputFile in terraformAnnotations.Where(p => p.AppendFile && !string.IsNullOrEmpty(p.OutputFileName)).Select(p => p.OutputFileName).Distinct())
            processor.ClearOutputFile(outputFile!);

        // copy base files
        var files = terraformPublishingOptions.Value.BaseFiles.Split(';');
        foreach (var file in files)
        {
            if (Path.GetExtension(file) == TerraformTemplateProcessor.TEMPLATE_EXTENSION)
            {
                var target = Path.GetFileNameWithoutExtension(file);
                if (Path.GetExtension(target) != TerraformTemplateProcessor.TF_EXTENSION)
                {
                    target += TerraformTemplateProcessor.TF_EXTENSION;
                }
                await processor.InvokeTemplate(file, target, file, modelResources);
            }
            else
            {
                await processor.CopySourceFile(file.Trim());
            }
        }

        // invoke templates
        foreach (var terraformTemplateAnnotation in terraformAnnotations)
        {
            var resource = terraformTemplateAnnotation.GetTemplateResource();

            if (resource is TemplateResourceWithConnectionString resourceWithConnectionString &&
                !string.IsNullOrEmpty(resourceWithConnectionString.ConnectionString))
                resourceWithConnectionString.ConnectionString = processor.InvokeStringTemplate(resourceWithConnectionString.ConnectionString, modelResources, true);

            if (resource is ContainerTemplateResource containerResource) // include projects, a bit dirty, interfaces should be used
            {
                for (var i = 0; i < containerResource.Args.Length; i++)
                    containerResource.Args[i] = processor.InvokeStringTemplate(containerResource.Args[i], modelResources, true);

                if (containerResource.Env != null)
                    foreach (var environmentValue in containerResource.Env)
                        containerResource.Env[environmentValue.Key] = processor.InvokeStringTemplate(environmentValue.Value, modelResources, true);

                if (containerResource.SecretEnv != null)
                    foreach (var environmentValue in containerResource.SecretEnv)
                        containerResource.SecretEnv[environmentValue.Key] = processor.InvokeStringTemplate(environmentValue.Value, modelResources, true);
            }

            await processor.InvokeTemplate(terraformTemplateAnnotation.TemplatePath,
                terraformTemplateAnnotation.OutputFileName ?? resource.Name + ".tf",
                resource.Name + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION,
                resource,
                terraformTemplateAnnotation.AppendFile);
        }

        await progressReporter.CompletePublishAsync("Terraform created", CompletionState.Completed, false, cancellationToken);
    }

    /// <summary>
    /// Appends a model resource to a collection.
    /// </summary>
    /// <param name="modelResources"></param>
    /// <param name="resource"></param>
    protected static void AppendModelResource(Dictionary<string, TemplateResource> modelResources, TemplateResource resource)
    {
        var count = modelResources.Count(p => p.Key == resource.Name);
        modelResources.Add(resource.Name + (count == 0 ? "" : "." + count), resource);
    }

    /// <summary>
    /// Prepares a child resource with a parent for template processing.
    /// </summary>
    /// <param name="resourceWithParent"></param>
    /// <param name="modelResources"></param>
    /// <returns></returns>
    protected virtual bool PrepareChildResource(IResourceWithParent resourceWithParent, Dictionary<string, TemplateResource> modelResources)
    {
        return false;
    }

    /// <summary>
    /// Prepares a resource for template processing by building appropriate annotations based on its type.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="modelResources"></param>
    /// <returns></returns>
    protected virtual async Task PrepareResource(IResource resource, Dictionary<string, TemplateResource> modelResources)
    {
        var name = resource.Name;

        switch (resource)
        {
            case ProjectResource projectResource:
                await BuildProjectResourceAnnotations(projectResource, modelResources, name);
                break;
            case ContainerResource containerResource:
                await BuildContainerResourceAnnotations(containerResource, modelResources, name);
                break;
            case ParameterResource parameterResource:
                BuildParameterResourceAnnotations(parameterResource, modelResources, name);
                break;
            case IResourceWithParent resourceWithParent:
                PrepareChildResource(resourceWithParent, modelResources);
                break;
            case IResourceWithConnectionString resourceWithConnectionString:
                BuildValueResourceAnnotations(resourceWithConnectionString, modelResources);
                break;
        }
    }

    /// <summary>
    /// Sets up Terraform template annotations for a given resource.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resource"></param>
    /// <param name="templatePath"></param>
    /// <returns></returns>
    protected static IEnumerable<TerraformTemplateAnnotation<T>> SetupAnnotations<T>(IResource resource, string templatePath) where T : TemplateResource, new()
    {
        var annotations = resource.Annotations.OfType<TerraformTemplateAnnotation<T>>().ToList();
        if (annotations.Count == 0)
        {
            var annotation = new TerraformTemplateAnnotation<T>
            {
                TemplatePath = templatePath,
                TemplateResource = new T()
            };
            annotations.Add(annotation);
            resource.Annotations.Add(annotation);
        }

        return annotations;
    }

    /// <summary>
    /// Normalizes a type name to a kebab-case format suitable for Terraform resource types.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string NormalizeTypeName(string input)
    {
        if (input.EndsWith("resource", StringComparison.OrdinalIgnoreCase))
        {
            input = input.Substring(0, input.Length - 8);
        }
        var kebab = Regex.Replace(input, "(?<!^)([A-Z])", "-$1");
        return kebab.ToLower();
    }

    private async Task BuildProjectResourceAnnotations(ProjectResource projectResource, Dictionary<string, TemplateResource> modelResources, string name)
    {
        var annotations = SetupAnnotations<ProjectTemplateResource>(projectResource, "container-app" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        var environmentValues = await projectResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
        var argumentValues = await projectResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
        var bindings = BuildBindings(projectResource);
        projectResource.TryGetContainerImageName(out var imageName);

        var secretEnv = new Dictionary<string, string>();
        foreach (var env in environmentValues)
        {
            var parameterResource = modelResources.Values.OfType<ParameterTemplateResource>()
                .Where(p => p.Resource is ParameterResource)
                .Select(p => (ParameterResource)p.Resource)
                .FirstOrDefault(p => env.Value.Contains(p.ValueExpression));

            if ((parameterResource != null && (parameterResource.Secret || parameterResource.IsConnectionString))
                || env.Key.StartsWith("ConnectionStrings"))
            {
                secretEnv.Add(env.Key, env.Value);
                environmentValues.Remove(env.Key);
            }
        }

        foreach (var annotation in annotations)
        {
            annotation.TemplateResource = new ProjectTemplateResource
            {
                Resource = projectResource,
                Name = projectResource.Name,
                Args = argumentValues,
                Env = environmentValues,
                Bindings = bindings,
                Replicas = projectResource.GetReplicaCount(),
                Image = imageName,
                SecretEnv = secretEnv
            };

            SetupResourceConnectionString(projectResource, annotation.TemplateResource, name);
            SetupResourceParent(projectResource, annotation.TemplateResource, modelResources);

            AppendModelResource(modelResources, annotation.TemplateResource);
        }
    }

    private async Task BuildContainerResourceAnnotations(ContainerResource containerResource, Dictionary<string, TemplateResource> modelResources,
        string name)
    {
        var annotations = SetupAnnotations<ContainerTemplateResource>(containerResource, "container-app" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        var environmentValues = await containerResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
        var argumentValues = await containerResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
        containerResource.TryGetContainerImageName(out var imageName);
        containerResource.TryGetContainerMounts(out var mounts); // TODO volume nane and handling
        var bindings = BuildBindings(containerResource);

        var secretEnv = new Dictionary<string, string>();
        foreach (var env in environmentValues)
        {
            var parameterResource = modelResources.Values.OfType<ParameterTemplateResource>()
                .Where(p => p.Resource is ParameterResource)
                .Select(p => (ParameterResource)p.Resource)
                .FirstOrDefault(p => env.Value.Contains(p.ValueExpression));

            if ((parameterResource != null && (parameterResource.Secret || parameterResource.IsConnectionString))
                || env.Key.StartsWith("ConnectionStrings"))
            {
                secretEnv.Add(env.Key, env.Value);
                environmentValues.Remove(env.Key);
            }
        }

        foreach (var annotation in annotations)
        {
            var volIndex = 0;
            annotation.TemplateResource = new ContainerTemplateResource
            {
                Resource = containerResource,
                Name = containerResource.Name,
                Args = argumentValues,
                Env = environmentValues,
                Bindings = bindings,
                Entrypoint = containerResource.Entrypoint,
                Replicas = containerResource.GetReplicaCount(),
                Image = imageName ?? containerResource.Name,
                Volumes = mounts?.Select(p => new Volumes
                    {
                        Name = p.Type == ContainerMountType.BindMount || p.Source is null
                            ? containerResource.Name + "-mount" + volIndex++
                            : containerResource.Name + "-" + p.Source,
                        Source = p.Type == ContainerMountType.BindMount ? p.Source : null,
                        Target = p.Target, IsReadOnly = p.IsReadOnly
                    })
                    .ToList() ?? [],
                SecretEnv = secretEnv
            };

            SetupResourceConnectionString(containerResource, annotation.TemplateResource, name);
            SetupResourceParent(containerResource, annotation.TemplateResource, modelResources);

            AppendModelResource(modelResources, annotation.TemplateResource);
        }
    }

    private void BuildParameterResourceAnnotations(ParameterResource parameterResource, Dictionary<string, TemplateResource> modelResources, string name)
    {
        var annotations = SetupAnnotations<ParameterTemplateResource>(parameterResource, "variable" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        foreach (var annotation in annotations)
        {
            // append to variables if it is not a secret
            annotation.AppendFile = !parameterResource.Secret;
            annotation.OutputFileName = !parameterResource.Secret ? "variables.tf" : null;
            annotation.TemplateResource = new ParameterTemplateResource
            {
                Resource = parameterResource,
                Name = parameterResource.Name,
                Value = !parameterResource.Secret ? "${var." + name + "}" : "${azurerm_key_vault_secret." + name + "_secret.value}",
                Secret = parameterResource.Secret,
                Description = parameterResource.Description,
                Default = !parameterResource.Secret ? parameterResource.GetValueAsync(CancellationToken.None).Result : null
            };

            SetupResourceConnectionString(parameterResource, annotation.TemplateResource, name);

            AppendModelResource(modelResources, annotation.TemplateResource);
        }
    }

    private void BuildValueResourceAnnotations(IResourceWithConnectionString resourceWithConnectionString,
        Dictionary<string, TemplateResource> modelResources)
    {
        var annotations = SetupAnnotations<ValueTemplateResource>(resourceWithConnectionString, "value" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        foreach (var annotation in annotations)
        {
            annotation.TemplateResource = new ValueTemplateResource
            {
                Resource = resourceWithConnectionString,
                Name = resourceWithConnectionString.Name,
                ConnectionString = resourceWithConnectionString.ValueExpression
            };
            AppendModelResource(modelResources, annotation.TemplateResource);
        }
    }

    private static void SetupResourceConnectionString(IResource resource, TemplateResourceWithConnectionString templateResource, string name)
    {
        if (resource is IResourceWithConnectionString resourceWithConnectionString)
        {
            templateResource.ConnectionString = resourceWithConnectionString.ValueExpression;
            templateResource.Outputs.Add("connectionString", "${local." + name + ".connectionString}");
        }
    }

    private static void SetupResourceParent(IResource resource, TemplateResource templateResource,
        Dictionary<string, TemplateResource> modelResources)
    {
        if (resource is IResourceWithParent resourceWithParent && resourceWithParent.Parent != null) templateResource.Parent = modelResources[resourceWithParent.Parent.Name];
    }

    internal Dictionary<string, Bindings> BuildBindings(IResource resource)
    {
        var bindings = new Dictionary<string, Bindings>();
        if (resource.TryGetEndpoints(out var endpoints))
            foreach (var endpoint in endpoints)
                bindings.Add(endpoint.Name, new Bindings
                {
                    External = endpoint.IsExternal,
                    Scheme = endpoint.UriScheme,
                    Transport = endpoint.Transport,
                    Port = endpoint.Port ?? (endpoint.UriScheme == Uri.UriSchemeHttps ? 443 : 80),
                    TargetPort = endpoint.TargetPort ?? 8080,
                    Protocol = endpoint.Protocol.ToString(),
                    Host = $"${{local.{resource.Name}.name}}.internal.${{local.{resource.Name}.fqdn}}", // $"{{local.{resource.Name}.name}}",
                    Url = $"{endpoint.UriScheme}://${{local.{resource.Name}.name}}.internal.${{local.{resource.Name}.fqdn}}"
                });

        return bindings;
    }

    private static void ExpandTerraformParameters(IResource resource)
    {
        foreach (var templateParameterAnnotation in resource.Annotations.OfType<TerraformTemplateParameterAnnotation>())
        {
            foreach (var templateAnnotation in resource.Annotations.OfType<ITerraformTemplateAnnotation>())
            {
                var templateResource = templateAnnotation.GetTemplateResource();
                if (!templateResource.Parameters.ContainsKey(templateParameterAnnotation.Name))
                    templateResource.Parameters.Add(templateParameterAnnotation.Name, templateParameterAnnotation.Value);
            }
        }
    }
}
