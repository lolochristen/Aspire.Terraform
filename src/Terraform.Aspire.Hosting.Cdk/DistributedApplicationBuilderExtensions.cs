using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Lifecycle;
using Aspire.Hosting.Publishing;
using Constructs;
using HashiCorp.Cdktf;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Terraform.Aspire.Hosting.Cdk;


// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring Terraform CDK (Cloud Development Kit) integration in Aspire hosting applications.
/// </summary>
public static class DistributedApplicationBuilderExtensions
{
    /// <summary>
    /// Adds Terraform CDK publishing capabilities to the distributed application builder.
    /// This enables generating Terraform configuration using the CDK's type-safe programmatic approach.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <param name="name">The name identifier for the publisher service. Defaults to "terraform".</param>
    /// <param name="configureOptions">Optional action to configure CDK publishing options.</param>
    /// <returns>The distributed application builder for method chaining.</returns>
    /// <remarks>
    /// This method registers the TerraformCdkPublisher as a keyed service. The configuration section
    /// "Terraform:Cdk" is automatically bound to the options.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddTerraformCdkPublishing("terraform", options =>
    /// {
    ///     options.BaseName = "myapp";
    ///     options.NamePrefix = "dev";
    ///     options.Tags.Add("Environment", "Development");
    /// });
    /// </code>
    /// </example>
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

    /// <summary>
    /// Adds Terraform CDK provisioning capabilities to the distributed application builder.
    /// This enables automatic provisioning of infrastructure during application lifecycle events.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <returns>The distributed application builder for method chaining.</returns>
    /// <remarks>
    /// This is an experimental feature that enables automatic Terraform provisioning during application startup.
    /// Use with caution in production environments. Only applies in run mode, not during publishing.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddTerraformCdkProvisioning();
    /// </code>
    /// </example>
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

    /// <summary>
    /// Adds a Terraform CDK environment resource to the distributed application.
    /// An environment represents a collection of Terraform stacks that can be deployed together.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <param name="name">The name of the Terraform environment. Defaults to "terraform".</param>
    /// <returns>A resource builder for the Terraform CDK environment resource.</returns>
    /// <remarks>
    /// In run mode, this method returns a resource builder without adding the resource to enable
    /// local development without Terraform dependencies. In publish mode, the resource is properly registered.
    /// </remarks>
    /// <example>
    /// <code>
    /// var terraform = builder.AddTerraformCdkEnvironment("production");
    /// var stack = terraform.AddStack&lt;MyInfrastructureStack&gt;("infrastructure");
    /// </code>
    /// </example>
    public static IResourceBuilder<TerraformCdkEnvironmentResource> AddTerraformCdkEnvironment(this IDistributedApplicationBuilder builder, string name = "terraform")
    {
        var resource = new TerraformCdkEnvironmentResource(name);
        if (builder.ExecutionContext.IsRunMode) return builder.CreateResourceBuilder(resource);
        return builder.AddResource(resource);
    }

    /// <summary>
    /// Adds a strongly-typed Terraform stack to the CDK environment.
    /// The stack type must inherit from TerraformStack and will be instantiated during deployment.
    /// </summary>
    /// <typeparam name="TStack">The type of the Terraform stack, must inherit from TerraformStack.</typeparam>
    /// <param name="builder">The Terraform CDK environment resource builder.</param>
    /// <param name="name">The name of the stack instance.</param>
    /// <returns>A resource builder for the Terraform stack resource.</returns>
    /// <remarks>
    /// The stack will be registered with the environment and instantiated during the publishing process.
    /// Each stack represents a logical grouping of infrastructure resources and is created with a parent
    /// relationship to the environment resource.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class DatabaseStack : TerraformStack
    /// {
    ///     public DatabaseStack(Construct scope, string id) : base(scope, id) 
    ///     {
    ///         // Define your infrastructure resources here
    ///     }
    /// }
    /// 
    /// var stack = terraform.AddStack&lt;DatabaseStack&gt;("database");
    /// </code>
    /// </example>
    public static IResourceBuilder<TerraformStackResource<TStack>> AddStack<TStack>(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string name)
        where TStack : TerraformStack
    {
        var tfStackResource = new TerraformStackResource<TStack>(name, builder.Resource);
        builder.Resource.AddStack(tfStackResource);
        return builder.ApplicationBuilder.AddResource(tfStackResource)
            .WithParentRelationship(builder);
    }

    /// <summary>
    /// Adds a generic Terraform stack to the CDK environment using the default TerraformAspireStack implementation.
    /// This provides a convenient way to add infrastructure without defining a custom stack class.
    /// </summary>
    /// <param name="builder">The Terraform CDK environment resource builder.</param>
    /// <param name="name">The name of the stack instance.</param>
    /// <returns>A resource builder for the Terraform stack resource.</returns>
    /// <remarks>
    /// This method uses the default TerraformAspireStack implementation which provides basic
    /// infrastructure patterns for Aspire applications. The stack is created with a parent
    /// relationship to the environment resource.
    /// </remarks>
    /// <example>
    /// <code>
    /// var stack = terraform.AddStack("default-infrastructure");
    /// 
    /// // You can then add custom build actions to the stack
    /// stack.WithAnnotation(new TerraformCdkResourceAnnotation(stack =>
    /// {
    ///     // Custom infrastructure code here
    /// }));
    /// </code>
    /// </example>
    public static IResourceBuilder<TerraformStackResource> AddStack(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string name)
    {
        var tfStackResource = new TerraformStackResource(name, builder.Resource, typeof(TerraformAspireStack));
        builder.Resource.AddStack(tfStackResource);
        return builder.ApplicationBuilder.AddResource(tfStackResource)
            .WithParentRelationship(builder);
    }
}