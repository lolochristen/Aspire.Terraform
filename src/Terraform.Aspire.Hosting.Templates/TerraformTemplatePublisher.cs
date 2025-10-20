using System.Text.RegularExpressions;
using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Terraform.Aspire.Hosting.Templates.Models;
using ContainerResource = Aspire.Hosting.ApplicationModel.ContainerResource;
using ParameterResource = Aspire.Hosting.ApplicationModel.ParameterResource;
using ProjectResource = Aspire.Hosting.ApplicationModel.ProjectResource;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Templates;

public class TerraformTemplatePublisher(
    ILogger<TerraformTemplatePublisher> logger,
    IPublishingActivityReporter progressReporter,
    DistributedApplicationExecutionContext executionContext,
    IOptions<PublishingOptions> publishingOptions,
    IOptions<TerraformTemplatePublishingOptions> terraformPublishingOptions,
    TerraformTemplateProcessor processor) : IDistributedApplicationPublisher
{
    public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
    {
        await progressReporter.CreateStepAsync("Create Terraform files from templates", cancellationToken);

        processor.OutputPath = publishingOptions.Value.OutputPath;
        processor.TemplateBasePath = terraformPublishingOptions.Value.TemplatesPath ?? "./.templates";
        processor.Logger = logger;

        // prepare
        logger.LogInformation("Prepare Resources for Terraform");

        var modelResources = new Dictionary<string, TemplateResource>();

        // build annotations
        foreach (var resource in model.Resources)
        {
            await PrepareResource(resource, modelResources);
            ExpandTerraformParameters(resource);
        }

        // clear target files
        var terraformAnnotations = model.Resources.SelectMany(p => p.Annotations.OfType<ITerraformTemplateAnnotation>()).ToList();
        modelResources = terraformAnnotations.ToDictionary(p => p.GetTemplateResource().Name, p => p.GetTemplateResource());

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
                processor.CopyTemplateFile(file.Trim());
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
                for (var i = 0; i < containerResource.Args.Length; i++) containerResource.Args[i] = processor.InvokeStringTemplate(containerResource.Args[i], modelResources, true);

                foreach (var environmentValue in containerResource.Env)
                    containerResource.Env[environmentValue.Key] = processor.InvokeStringTemplate(environmentValue.Value, modelResources, true);
            }

            await processor.InvokeTemplate(terraformTemplateAnnotation.TemplatePath,
                terraformTemplateAnnotation.OutputFileName ?? resource.Name + ".tf",
                resource.Name + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION,
                resource,
                terraformTemplateAnnotation.AppendFile);
        }

        await progressReporter.CompletePublishAsync("Terraform created", CompletionState.Completed, false, cancellationToken);
    }

    private async Task BuildProjectResourceAnnotations(ProjectResource projectResource, Dictionary<string, TemplateResource> modelResources, string name)
    {
        var annotations = SetupAnnotations<ProjectTemplateResource>(projectResource, "container-app" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        var environmentValues = await projectResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
        var argumentValues = await projectResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
        var bindings = BuildBindings(projectResource);
        // var deploymenTarget = projectResource.GetDeploymentTargetAnnotation();
        projectResource.TryGetContainerImageName(out var imageName);

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
                Image = imageName
            };

            SetupResourceConnectionString(projectResource, annotation.TemplateResource, name);
            SetupResourceParent(projectResource, annotation.TemplateResource, modelResources);

            //todo check multiple
            modelResources.Add(projectResource.Name, annotation.TemplateResource);
        }
    }

    private async Task BuildContainerResourceAnnotations(ContainerResource containerResource, Dictionary<string, TemplateResource> modelResources,
        string name)
    {
        var annotations = SetupAnnotations<ContainerTemplateResource>(containerResource, "container-app" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        var environmentValues = await containerResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
        var argumentValues = await containerResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
        // var deploymenTarget = containerResource.GetDeploymentTargetAnnotation();
        containerResource.TryGetContainerImageName(out var imageName);
        containerResource.TryGetContainerMounts(out var mounts); // TODO volume nane and handling

        var bindings = BuildBindings(containerResource);

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
                    .ToList() ?? []
            };

            SetupResourceConnectionString(containerResource, annotation.TemplateResource, name);
            SetupResourceParent(containerResource, annotation.TemplateResource, modelResources);

            modelResources.Add(containerResource.Name, annotation.TemplateResource);
        }
    }

    private void BuildParameterResourceAnnotations(ParameterResource parameterResource, Dictionary<string, TemplateResource> modelResources, string name)
    {
        var annotations = SetupAnnotations<ParameterTemplateResource>(parameterResource, "variable" + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

        foreach (var annotation in annotations)
        {
            annotation.AppendFile = true;
            annotation.OutputFileName = "variables.tf";
            annotation.TemplateResource = new ParameterTemplateResource
            {
                Resource = parameterResource,
                Name = parameterResource.Name,
                Value = parameterResource.ValueExpression
            };

            SetupResourceConnectionString(parameterResource, annotation.TemplateResource, name);

            modelResources.Add(parameterResource.Name, annotation.TemplateResource);
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
            modelResources.Add(resourceWithConnectionString.Name, annotation.TemplateResource);
        }
    }

    private void SetupResourceConnectionString(IResource resource, TemplateResourceWithConnectionString templateResource, string name)
    {
        if (resource is IResourceWithConnectionString resourceWithConnectionString)
        {
            templateResource.ConnectionString = resourceWithConnectionString.ValueExpression;
            templateResource.Outputs.Add("connectionString", "${local." + name + ".connectionString}");
        }
    }

    private void SetupResourceParent(IResource resource, TemplateResource templateResource,
        Dictionary<string, TemplateResource> modelResources)
    {
        if (resource is IResourceWithParent resourceWithParent && resourceWithParent.Parent != null) templateResource.Parent = modelResources[resourceWithParent.Parent.Name];
    }

    protected virtual bool PrepareChildResource(IResourceWithParent resourceWithParent, Dictionary<string, TemplateResource> modelResources)
    {
        return false;
    }

    protected virtual async Task PrepareResource(IResource resource, Dictionary<string, TemplateResource> modelResources)
    {
        var name = resource.Name; // todo normalize

        if (resource is ProjectResource projectResource)
            await BuildProjectResourceAnnotations(projectResource, modelResources, name);
        else if (resource is ContainerResource containerResource)
            await BuildContainerResourceAnnotations(containerResource, modelResources, name);
        else if (resource is ParameterResource parameterResource)
            BuildParameterResourceAnnotations(parameterResource, modelResources, name);
        else if (resource is IResourceWithParent resourceWithParent)
            PrepareChildResource(resourceWithParent, modelResources);
        else if (resource is IResourceWithConnectionString resourceWithConnectionString) BuildValueResourceAnnotations(resourceWithConnectionString, modelResources);
    }

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

    protected static string NormalizeTypeName(string input)
    {
        if (input.EndsWith("resource", StringComparison.OrdinalIgnoreCase)) input = input.Substring(0, input.Length - 8);

        var kebab = Regex.Replace(input, "(?<!^)([A-Z])", "-$1");
        return kebab.ToLower();
    }

    private void ExpandTerraformParameters(IResource resource)
    {
        foreach (var templateParameterAnnotation in resource.Annotations.OfType<TerraformTemplateParameterAnnotation>())
        foreach (var templateAnnotation in resource.Annotations.OfType<ITerraformTemplateAnnotation>())
        {
            var templateResource = templateAnnotation.GetTemplateResource();
            if (!templateResource.Parameters.ContainsKey(templateParameterAnnotation.Name))
                templateResource.Parameters.Add(templateParameterAnnotation.Name, templateParameterAnnotation.Value);
        }
    }
}