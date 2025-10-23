using Aspire.Hosting.ApplicationModel;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Azure CDK extension methods for adding an Azure Container Apps Terraform stack.
/// </summary>
public static class TerraformResourceExtensions
{
    /// <summary>
    /// Adds an <see cref="AzureContainerAppsTerraformStack"/> to the Terraform CDK environment and configures Azure publishing options.
    /// </summary>
    /// <param name="builder">The Terraform CDK environment resource builder.</param>
    /// <param name="name">Optional stack name. Defaults to "{environment-name}-azure".</param>
    /// <param name="configureOptions">Optional action to configure <see cref="TerraformCdkAzurePublishingOptions"/>.</param>
    /// <returns>The stack resource builder.</returns>
    public static IResourceBuilder<TerraformStackResource<AzureContainerAppsTerraformStack>> AddAzureContainerAppStack(
        this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string? name = null, Action<TerraformCdkAzurePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.ApplicationBuilder.Configuration.GetSection("Terraform:CdkAzure");
        var optionsBuilder = builder.ApplicationBuilder.Services.AddOptions<TerraformCdkAzurePublishingOptions>(name)
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        name ??= builder.Resource.Name + "-azure";
        return builder.AddStack<AzureContainerAppsTerraformStack>(name);
    }
}