//using System.Text.RegularExpressions;
//using Aspire.Hosting.ApplicationModel;
//using Aspire.Hosting.Terraform.Templates.Models;
//using Microsoft.Extensions.Logging;

//namespace Aspire.Hosting.Terraform.Templates;

//public class TerraformTemplateWriter(
//    TerraformTemplateProcessor processor
//)
//{
//    public ILogger Logger { get; set; }
//    public string OutputPath { get; set; }
//    public string TemplatePath { get; set; }
//    public string[] BaseFiles { get; set; }

//    protected Dictionary<string, TemplateResource> ModelResources = new();

//    public async Task PrepareResources(IList<IResource> resources)
//    {
//        // build annotations
//        foreach (var resource in resources)
//        {
//            await PrepareResource(resource);
//            ExpandTerraformParameters(resource);
//        }
//    }

//    public async Task WriteTerraform(IList<ITerraformTemplateAnnotation> terraformAnnotations /*IList<IResource> resources*/)
//    {
//        processor.Logger = Logger;

//        // clear target files
//        //var terraformAnnotations = resources.SelectMany(p => p.Annotations.OfType<ITerraformTemplateAnnotation>()).ToList();
//        var modelResources = terraformAnnotations.ToDictionary(p => p.GetTemplateResource().Name, p => p.GetTemplateResource());

//        foreach (var outputFile in terraformAnnotations.Where(p => p.AppendFile && !string.IsNullOrEmpty(p.OutputFileName)).Select(p => p.OutputFileName).Distinct())
//            processor.ClearOutputFile(outputFile!);

//        // copy base files
//        foreach (var file in BaseFiles) processor.CopyTemplateFile(file.Trim());

//        // invoke templates
//        foreach (var terraformTemplateAnnotation in terraformAnnotations)
//        {
//            var resource = terraformTemplateAnnotation.GetTemplateResource();

//            if (resource is TemplateResourceWithConnectionString resourceWithConnectionString &&
//                !string.IsNullOrEmpty(resourceWithConnectionString.ConnectionString))
//                resourceWithConnectionString.ConnectionString = processor.InvokeStringTemplate(resourceWithConnectionString.ConnectionString, modelResources, true);

//            if (resource is ContainerTemplateResource containerResource) // include projects, a bit dirty, interfaces should be used
//            {
//                for (var i = 0; i < containerResource.Args.Length; i++) containerResource.Args[i] = processor.InvokeStringTemplate(containerResource.Args[i], modelResources, true);

//                foreach (var environmentValue in containerResource.Env)
//                    containerResource.Env[environmentValue.Key] = processor.InvokeStringTemplate(environmentValue.Value, modelResources, true);
//            }

//            await processor.InvokeTemplate(terraformTemplateAnnotation.TemplatePath,
//                terraformTemplateAnnotation.OutputFileName ?? resource.Name + ".tf",
//                resource.Name + "tmpl.tf",
//                resource,
//                terraformTemplateAnnotation.AppendFile);
//        }

//    }

//    //public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
//    //{
//    //    await progressReporter.CreateStepAsync("Create Terraform files from templates", cancellationToken);

//    //    processor.OutputPath = publishingOptions.Value.OutputPath;
//    //    processor.TemplateBasePath = terraformPublishingOptions.Value.TemplatesPath ?? "./templates"; //   @"d:\lolochristen\Aspire.Terraform\templates";

//    //    // prepare
//    //    var modelResources = new Dictionary<string, TemplateResource>();

//    //    // build annotations
//    //    foreach (var resource in model.Resources)
//    //    {
//    //        await PrepareResource(resource, modelResources);
//    //        ExpandTerraformParameters(resource);
//    //    }

//    //    // clear target files
//    //    var terraformAnnotations = model.Resources.SelectMany(p => p.Annotations.OfType<ITerraformTemplateAnnotation>()).ToList();
//    //    modelResources = terraformAnnotations.ToDictionary(p => p.GetTemplateResource().Name, p => p.GetTemplateResource());

//    //    foreach (var outputFile in terraformAnnotations.Where(p => p.AppendFile && !string.IsNullOrEmpty(p.OutputFileName)).Select(p => p.OutputFileName).Distinct())
//    //        processor.ClearOutputFile(outputFile!);

//    //    // copy base files
//    //    var files = terraformPublishingOptions.Value.BaseFiles.Split(';');
//    //    foreach (var file in files) processor.CopyTemplateFile(file.Trim());

//    //    // invoke templates
//    //    foreach (var terraformTemplateAnnotation in terraformAnnotations)
//    //    {
//    //        var resource = terraformTemplateAnnotation.GetTemplateResource();

//    //        if (resource is TemplateResourceWithConnectionString resourceWithConnectionString &&
//    //            !string.IsNullOrEmpty(resourceWithConnectionString.ConnectionString))
//    //            resourceWithConnectionString.ConnectionString = processor.InvokeStringTemplate(resourceWithConnectionString.ConnectionString, modelResources, true);

//    //        if (resource is ContainerTemplateResource containerResource) // include projects, a bit dirty, interfaces should be used
//    //        {
//    //            for (var i = 0; i < containerResource.Args.Length; i++) containerResource.Args[i] = processor.InvokeStringTemplate(containerResource.Args[i], modelResources, true);

//    //            foreach (var environmentValue in containerResource.Env)
//    //                containerResource.Env[environmentValue.Key] = processor.InvokeStringTemplate(environmentValue.Value, modelResources, true);
//    //        }

//    //        await processor.InvokeTemplate(terraformTemplateAnnotation.TemplatePath,
//    //            terraformTemplateAnnotation.OutputFileName ?? resource.Name + ".tf",
//    //            resource.Name + "tmpl.tf",
//    //            resource,
//    //            terraformTemplateAnnotation.AppendFile);
//    //    }

//    //    await progressReporter.CompletePublishAsync("Terraform created", CompletionState.Completed, false, cancellationToken);
//    //}

//    private async Task BuildProjectResourceAnnotations(ProjectResource projectResource, Dictionary<string, TemplateResource> modelResources, string name)
//    {
//        var annotations = SetupAnnotations<ProjectTemplateResource>(projectResource, "container-app.tmpl.tf");

//        var environmentValues = await projectResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
//        var argumentValues = await projectResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
//        var bindings = BuildBindings(projectResource);
//        // var deploymenTarget = projectResource.GetDeploymentTargetAnnotation();
//        projectResource.TryGetContainerImageName(out var imageName);

//        foreach (var annotation in annotations)
//        {
//            annotation.TemplateResource = new ProjectTemplateResource
//            {
//                Resource = projectResource,
//                Name = projectResource.Name,
//                Args = argumentValues,
//                Env = environmentValues,
//                Bindings = bindings,
//                Replicas = projectResource.GetReplicaCount(),
//                Image = imageName ?? projectResource.Name
//            };

//            SetupResourceConnectionString(projectResource, annotation.TemplateResource, name);
//            SetupResourceParent(projectResource, annotation.TemplateResource, modelResources);

//            //todo check multiple
//            modelResources.Add(projectResource.Name, annotation.TemplateResource);
//        }
//    }

//    private async Task BuildContainerResourceAnnotations(ContainerResource containerResource, Dictionary<string, TemplateResource> modelResources,
//        string name)
//    {
//        var annotations = SetupAnnotations<ContainerTemplateResource>(containerResource, "container-app.tmpl.tf");

//        var environmentValues = await containerResource.GetEnvironmentVariableValuesAsync(DistributedApplicationOperation.Publish);
//        var argumentValues = await containerResource.GetArgumentValuesAsync(DistributedApplicationOperation.Publish);
//        // var deploymenTarget = containerResource.GetDeploymentTargetAnnotation();
//        containerResource.TryGetContainerImageName(out var imageName);
//        containerResource.TryGetContainerMounts(out var volumeMounts); // TODO volume nane and handling

//        var bindings = BuildBindings(containerResource);

//        foreach (var annotation in annotations)
//        {
//            annotation.TemplateResource = new ContainerTemplateResource
//            {
//                Resource = containerResource,
//                Name = containerResource.Name,
//                Args = argumentValues,
//                Env = environmentValues,
//                Bindings = bindings,
//                Entrypoint = containerResource.Entrypoint,
//                Replicas = containerResource.GetReplicaCount(),
//                Image = imageName ?? containerResource.Name,
//                Volumes = volumeMounts != null ? volumeMounts.Select(p => new Volumes { Target = p.Target, IsReadOnly = p.IsReadOnly }).ToList() : new List<Volumes>()
//            };

//            SetupResourceConnectionString(containerResource, annotation.TemplateResource, name);
//            SetupResourceParent(containerResource, annotation.TemplateResource, modelResources);

//            modelResources.Add(containerResource.Name, annotation.TemplateResource);
//        }
//    }

//    private void BuildParameterResourceAnnotations(ParameterResource parameterResource, Dictionary<string, TemplateResource> modelResources, string name)
//    {
//        var annotations = SetupAnnotations<ParameterTemplateResource>(parameterResource, "variable.tmpl.tf");

//        foreach (var annotation in annotations)
//        {
//            annotation.AppendFile = true;
//            annotation.OutputFileName = "variables.tf";
//            annotation.TemplateResource = new ParameterTemplateResource
//            {
//                Resource = parameterResource,
//                Name = parameterResource.Name,
//                Value = parameterResource.ValueExpression
//            };

//            SetupResourceConnectionString(parameterResource, annotation.TemplateResource, name);

//            modelResources.Add(parameterResource.Name, annotation.TemplateResource);
//        }
//    }

//    private void BuildValueResourceAnnotations(IResourceWithConnectionString resourceWithConnectionString)
//    {
//        var annotations = SetupAnnotations<ValueTemplateResource>(resourceWithConnectionString, "value.tmpl.tf");

//        foreach (var annotation in annotations)
//        {
//            annotation.TemplateResource = new ValueTemplateResource
//            {
//                Resource = resourceWithConnectionString,
//                Name = resourceWithConnectionString.Name,
//                ConnectionString = resourceWithConnectionString.ValueExpression
//            };
//            ModelResources.Add(resourceWithConnectionString.Name, annotation.TemplateResource);
//        }
//    }

//    private void SetupResourceConnectionString(IResource resource, TemplateResourceWithConnectionString templateResource, string name)
//    {
//        if (resource is IResourceWithConnectionString resourceWithConnectionString)
//        {
//            templateResource.ConnectionString = resourceWithConnectionString.ValueExpression;
//            templateResource.Outputs.Add("connectionString", "${local." + name + ".connectionString}");
//        }
//    }

//    private void SetupResourceParent(IResource resource, TemplateResource templateResource,
//        Dictionary<string, TemplateResource> modelResources)
//    {
//        if (resource is IResourceWithParent resourceWithParent && resourceWithParent.Parent != null) templateResource.Parent = modelResources[resourceWithParent.Parent.Name];
//    }

//    protected virtual bool PrepareChildResource(IResourceWithParent resourceWithParent, Dictionary<string, TemplateResource> modelResources)
//    {
//        return false;
//    }

//    protected virtual async Task PrepareResource(IResource resource)
//    {
//        var name = resource.Name; // todo normalize

//        if (resource is ProjectResource projectResource)
//            await BuildProjectResourceAnnotations(projectResource, ModelResources, name);
//        else if (resource is ContainerResource containerResource)
//            await BuildContainerResourceAnnotations(containerResource, ModelResources, name);
//        else if (resource is ParameterResource parameterResource)
//            BuildParameterResourceAnnotations(parameterResource, ModelResources, name);
//        else if (resource is IResourceWithParent resourceWithParent)
//            PrepareChildResource(resourceWithParent, ModelResources);
//        else if (resource is IResourceWithConnectionString resourceWithConnectionString) BuildValueResourceAnnotations(resourceWithConnectionString);
//    }

//    protected static IEnumerable<TerraformTemplateAnnotation<T>> SetupAnnotations<T>(IResource resource, string templatePath) where T : TemplateResource, new()
//    {
//        var annotations = resource.Annotations.OfType<TerraformTemplateAnnotation<T>>().ToList();
//        if (annotations.Count == 0)
//        {
//            var annotation = new TerraformTemplateAnnotation<T>
//            {
//                TemplatePath = templatePath,
//                TemplateResource = new T()
//            };
//            annotations.Add(annotation);
//            resource.Annotations.Add(annotation);
//        }

//        return annotations;
//    }

//    internal Dictionary<string, Bindings> BuildBindings(IResource resource)
//    {
//        var bindings = new Dictionary<string, Bindings>();
//        if (resource.TryGetEndpoints(out var endpoints))
//            foreach (var endpoint in endpoints)
//                bindings.Add(endpoint.Name, new Bindings
//                {
//                    External = endpoint.IsExternal,
//                    Scheme = endpoint.UriScheme,
//                    Transport = endpoint.Transport,
//                    Port = endpoint.Port ?? (endpoint.UriScheme == Uri.UriSchemeHttps ? 443 : 80),
//                    TargetPort = endpoint.TargetPort ?? 8080,
//                    Protocol = endpoint.Protocol.ToString(),
//                    Host = $"${{local.{resource.Name}.name}}.internal.${{local.{resource.Name}.fqdn}}", // $"{{local.{resource.Name}.name}}",
//                    Url = $"{endpoint.UriScheme}://${{local.{resource.Name}.name}}.internal.${{local.{resource.Name}.fqdn}}"
//                });

//        return bindings;
//    }

//    protected static string NormalizeTypeName(string input)
//    {
//        if (input.EndsWith("resource", StringComparison.OrdinalIgnoreCase)) input = input.Substring(0, input.Length - 8);

//        var kebab = Regex.Replace(input, "(?<!^)([A-Z])", "-$1");
//        return kebab.ToLower();
//    }

//    private void ExpandTerraformParameters(IResource resource)
//    {
//        foreach (var templateParameterAnnotation in resource.Annotations.OfType<TerraformTemplateParameterAnnotation>())
//        foreach (var templateAnnotation in resource.Annotations.OfType<ITerraformTemplateAnnotation>())
//        {
//            var templateResource = templateAnnotation.GetTemplateResource();
//            if (!templateResource.Parameters.ContainsKey(templateParameterAnnotation.Name))
//                templateResource.Parameters.Add(templateParameterAnnotation.Name, templateParameterAnnotation.Value);
//        }
//    }

//}

//public class TerraformPublisher(
//    ILogger<TerraformPublisher> logger,
//    IPublishingActivityReporter progressReporter,
//    DistributedApplicationExecutionContext executionContext,
//    IOptions<PublishingOptions> publishingOptions,
//    IOptions<TerraformTemplatePublishingOptions> terraformPublishingOptions,
//    TerraformTemplateWriter templateWriter) : IDistributedApplicationPublisher
//{
//    public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
//    {
//        templateWriter.Logger = logger;
//        templateWriter.OutputPath = publishingOptions.Value.OutputPath ?? "./infra";
//        templateWriter.TemplatePath = terraformPublishingOptions.Value.TemplatesPath ?? "./templates";
//        templateWriter.BaseFiles = terraformPublishingOptions.Value.BaseFiles.Split(';');

//        await progressReporter.CreateStepAsync("Create Terraform files from templates", cancellationToken);
        
//        await templateWriter.PrepareResources(model.Resources);

//        var terraformAnnotations = model.Resources.SelectMany(p => p.Annotations.OfType<ITerraformTemplateAnnotation>()).ToList();

//        await templateWriter.WriteTerraform(terraformAnnotations);

//        await progressReporter.CompletePublishAsync("Terraform created", CompletionState.Completed, false, cancellationToken);
//    }
//}