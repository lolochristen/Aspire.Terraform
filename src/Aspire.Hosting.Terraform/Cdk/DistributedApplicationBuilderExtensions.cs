using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Lifecycle;
using Aspire.Hosting.Publishing;
using Aspire.Hosting.Terraform.Cdk;
using Aspire.Hosting.Terraform.Templates;
using HashiCorp.Cdktf;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;


// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static partial class DistributedApplicationBuilderExtensions
{

    public static IDistributedApplicationBuilder AddTerraformCdkPublishing(this IDistributedApplicationBuilder builder, string name = "terraform",
        Action<TerraformCdkPublishingOptions>? configureOptions = null)
    {
        var configuration = builder.Configuration.GetSection("Terraform:Cdk");
        var optionsBuilder = builder.Services.AddOptions<TerraformCdkPublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddKeyedSingleton<IDistributedApplicationPublisher, TerraformCdkPublisher>(name);
        return builder;
    }

    [Experimental("ASPIREPUBLISHERS001")]
    public static IDistributedApplicationBuilder AddTerraformCdkProvisioning(this IDistributedApplicationBuilder builder)
    {
        builder.Services.TryAddLifecycleHook<TerraformCdkProvisioner>();

        // Attempt to read azure configuration from configuration
        //builder.Services.AddOptions<TerraformProvisionerOptions>()
        //    .BindConfiguration("Terraform")
        //    .ValidateDataAnnotations()
        //    .ValidateOnStart();

        return builder;
    }

    public static IResourceBuilder<TerraformCdkEnvironmentResource> AddTerraformCdkEnvironment(this IDistributedApplicationBuilder builder, string name = "terraform")
    {
        var resource = new TerraformCdkEnvironmentResource(name);
        if (builder.ExecutionContext.IsRunMode)
        {
            return builder.CreateResourceBuilder(resource);
        }
        return builder.AddResource(resource);
    }

    //[Experimental("ASPIREPUBLISHERS001")]
    public static IResourceBuilder<TerraformStackResource<TStack>> AddStack<TStack>(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string name) where TStack : TerraformStack
    {
        var tfStackResource = new TerraformStackResource<TStack>(name, builder.Resource);
        builder.Resource.AddStack(tfStackResource);
        return builder.ApplicationBuilder.AddResource(tfStackResource)
            .WithParentRelationship(builder);
    }

    //[Experimental("ASPIREPUBLISHERS001")]
    public static IResourceBuilder<TerraformStackResource> AddStack(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string name)
    {
        var tfStackResource = new TerraformStackResource(name, builder.Resource, typeof(TerraformAspireStack));
        builder.Resource.AddStack(tfStackResource);
        return builder.ApplicationBuilder.AddResource(tfStackResource)
            .WithParentRelationship(builder);
    }
}