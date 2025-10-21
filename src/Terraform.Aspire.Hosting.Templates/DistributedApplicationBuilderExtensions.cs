using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Terraform.Aspire.Hosting.Templates;


// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring Terraform template-based publishing in Aspire hosting applications.
/// </summary>
public static class DistributedApplicationBuilderExtensions
{
    /// <summary>
    /// Adds Terraform template publishing capabilities to the distributed application builder.
    /// This enables generating Terraform configuration files from Handlebars templates for infrastructure deployment.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <param name="name">The name identifier for the publisher service. Defaults to "terraform".</param>
    /// <param name="configureOptions">Optional action to configure publishing options such as templates path and base files.</param>
    /// <returns>The distributed application builder for method chaining.</returns>
    /// <remarks>
    /// This method registers the TerraformTemplatePublisher as a keyed service and configures it to process
    /// Handlebars templates that generate Terraform configuration files. The configuration section
    /// "Terraform:Templates" is automatically bound to the options.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddTerraformTemplatePublishing("terraform", options =>
    /// {
    ///     options.TemplatesPath = "./templates/azure";
    ///     options.BaseFiles = "main.tf;variables.tf;outputs.tf";
    /// });
    /// </code>
    /// </example>
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