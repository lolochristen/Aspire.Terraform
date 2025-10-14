using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Lifecycle;
using Aspire.Hosting.Publishing;
using Aspire.Hosting.Terraform.Templates;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;


// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static partial class DistributedApplicationBuilderExtensions
{
    //public static IResourceBuilder<TerraformTemplateEnvironmentResource> AddTerraformTemplateEnvironment(this IDistributedApplicationBuilder builder, string name,
    //    Action<TerraformTemplatePublishingOptions>? configureOptions = null)
    //{
    //    builder.AddTerraformTemplateProvisioning();
    //    builder.AddTerraformTemplatePublishing(name, configureOptions);

    //    var resource = new TerraformTemplateEnvironmentResource(name);

    //    //if (builder.ExecutionContext.IsRunMode)
    //    //{
    //    //    // Return a builder that isn't added to the top-level application builder
    //    //    // so it doesn't surface as a resource.
    //    //    return builder.CreateResourceBuilder(resource);
    //    //}

    //    // In publish mode, add the resource to the application model
    //    // but exclude it from the manifest so that it is not treated
    //    // as a publishable resource by components that process the manifest
    //    // for elements.
    //    return builder.AddResource(resource)
    //        .ExcludeFromManifest();
    //}

    //public static IDistributedApplicationBuilder AddTerraformTemplateProvisioning(this IDistributedApplicationBuilder builder)
    //{
    //    builder.Services.TryAddLifecycleHook<TerraformTemplateProvisioner>();
    //    return builder;
    //}

    public static IDistributedApplicationBuilder AddTerraformTemplatePublishing(this IDistributedApplicationBuilder builder, string name = "terraform",
        Action<TerraformTemplatePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.Configuration.GetSection("Terraform:Templates");
        var optionsBuilder = builder.Services.AddOptions<TerraformTemplatePublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddKeyedSingleton<IDistributedApplicationPublisher, TerraformTemplatePublisher>(name);
        builder.Services.AddTransient<TerraformTemplateProcessor>();
        return builder;
    }
}