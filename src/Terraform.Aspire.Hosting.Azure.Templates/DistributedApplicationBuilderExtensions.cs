using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Terraform.Aspire.Hosting.Azure.Templates;
using Terraform.Aspire.Hosting.Templates;

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring Azure-specific Terraform template publishing.
/// </summary>
public static class DistributedApplicationBuilderExtensions
{
    /// <summary>
    /// Adds Azure-specific Terraform template publishing capabilities with enhanced Azure resource support.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <param name="name">The name identifier for the publisher service. Defaults to "terraform".</param>
    /// <param name="configureOptions">Optional action to configure publishing options.</param>
    /// <param name="disableBicepAzureProvisioner">Whether to disable the default Bicep Azure provisioner. Defaults to true.</param>
    /// <returns>The distributed application builder for method chaining.</returns>
    /// <remarks>
    /// This method extends the base Terraform template functionality with Azure-specific features
    /// and optionally disables the built-in Bicep provisioner to avoid conflicts.
    /// </remarks>
    public static IDistributedApplicationBuilder AddTerraformAzureTemplatePublishing(this IDistributedApplicationBuilder builder, string name = "terraform",
        Action<TerraformTemplatePublishingOptions>? configureOptions = null, bool disableBicepAzureProvisioner = true)
    {
        if (disableBicepAzureProvisioner)
        {
            // disable azure provisioner
            var service = builder.Services.FirstOrDefault(p => p.ImplementationType != null && p.ImplementationType.Name.Contains("AzureProvisioner"));
            if (service != null)
                builder.Services.Remove(service);
            service = builder.Services.FirstOrDefault(p => p.ImplementationType != null && p.ImplementationType.Name.Contains("AzureResourcePreparer"));
            if (service != null)
                builder.Services.Remove(service);
        }

        var configuration = builder.Configuration.GetSection("Terraform:Templates");

        var optionsBuilder = builder.Services.AddOptions<TerraformTemplatePublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddKeyedSingleton<IDistributedApplicationPublisher, TerraformAzureTemplatePublisher>(name);
        builder.Services.AddTransient<TerraformTemplateProcessor>();
        return builder;
    }
}