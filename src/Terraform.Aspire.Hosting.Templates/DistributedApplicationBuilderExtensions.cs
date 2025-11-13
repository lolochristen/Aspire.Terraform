using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using Terraform.Aspire.Hosting.Templates;
using Terraform.Aspire.Hosting.Templates.Models;

#pragma warning disable ASPIREPIPELINES001
#pragma warning disable IDE0130

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
    public static IDistributedApplicationBuilder AddTerraformTemplatePublishing(this IDistributedApplicationBuilder builder, Action<TerraformTemplatePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.Configuration.GetSection("Terraform:Templates");
        var optionsBuilder = builder.Services.AddOptions<TerraformTemplatePublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddSingleton<ITerraformTemplatePublisher, TerraformTemplatePublisher>();
        builder.Services.AddTransient<TerraformTemplateProcessor>();
        builder.Pipeline.AddTerraformTemplatePublishing();

        return builder;
    }

    /// <summary>
    /// Adds a specific Terraform template resource to the distributed application builder.
    /// </summary>
    /// <param name="builder">The distributed application builder.</param>
    /// <param name="name">Resource name.</param>
    /// <param name="templatePath">Path to the template file.</param>
    /// <param name="outputFileName">Optional output file name.</param>
    /// <returns>The resource builder for chaining.</returns>
    public static IResourceBuilder<TerraformTemplateResource> AddTerraformTemplate(this IDistributedApplicationBuilder builder, string name, string templatePath, string? outputFileName = null)
    {
        var resource = new TerraformTemplateResource(name);
        if (builder.ExecutionContext.IsRunMode)
        {
            return builder.CreateResourceBuilder(resource);
        }

        return builder.AddResource(resource)
            .WithAnnotation(new TerraformTemplateAnnotation<ValueTemplateResource>
            {
                TemplatePath = templatePath,
                OutputFileName = outputFileName,
                AppendFile = false,
                TemplateResource = new ValueTemplateResource() { Name = name, Resource = resource, Outputs = resource.Outputs },
            })
            .ExcludeFromManifest();
    }
}
