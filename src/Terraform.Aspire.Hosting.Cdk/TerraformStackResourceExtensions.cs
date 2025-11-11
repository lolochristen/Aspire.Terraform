using Aspire.Hosting.ApplicationModel;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable ASPIREPUBLISHERS001

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring Terraform stack resources with custom infrastructure code.
/// </summary>
public static class TerraformStackResourceExtensions
{
    /// <summary>
    /// Adds custom Terraform resource creation logic to a stack through a build action.
    /// </summary>
    /// <param name="builder">The Terraform stack resource builder.</param>
    /// <param name="buildAction">Action that defines infrastructure resources to create in the stack.</param>
    /// <returns>The stack resource builder for method chaining.</returns>
    /// <remarks>
    /// The build action is executed during stack synthesis and receives the TerraformAspireStack
    /// instance for adding custom infrastructure resources programmatically.
    /// </remarks>
    public static IResourceBuilder<TerraformStackResource> WithTerraformResource(this IResourceBuilder<TerraformStackResource> builder, Action<TerraformAspireStack> buildAction)
    {
        builder.WithAnnotation(new TerraformCdkResourceAnnotation(buildAction));
        return builder;
    }

    /// <summary>
    /// Adds a Terraform HCL module to the stack with the specified configuration.
    /// </summary>
    /// <param name="builder">The Terraform stack resource builder.</param>
    /// <param name="name">The name of the module instance.</param>
    /// <param name="source">The source path or URL of the Terraform module.</param>
    /// <param name="variables">Optional variables to pass to the module.</param>
    /// <param name="providers">Optional providers to pass to the module.</param>
    /// <returns>The stack resource builder for method chaining.</returns>
    /// <remarks>
    /// This method creates a TerraformHclModule that references existing Terraform modules,
    /// allowing reuse of community or custom modules within the CDK infrastructure.
    /// The source path is converted to a full path for proper module resolution.
    /// </remarks>
    public static IResourceBuilder<TerraformStackResource> WithModule(this IResourceBuilder<TerraformStackResource> builder, string name, string source,
        Dictionary<string, object>? variables = null, object[]? providers = null)
    {
        builder.WithAnnotation(new TerraformCdkResourceAnnotation(stack =>
        {
            new TerraformHclModule(stack, name, new TerraformHclModuleConfig
            {
                Source = Path.GetFullPath(source),
                Providers = providers ?? [],
                Variables = variables ?? []
            });
        }));
        return builder;
    }

    public static IResourceBuilder<TerraformStackResource> WithBackend(this IResourceBuilder<TerraformStackResource> builder, Func<Construct,TerraformBackend> configureBackend)
    {
        builder.WithTerraformResource(stack =>
        {
            configureBackend(stack);
        });
        return builder;
    }
}