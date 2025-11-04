using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using Terraform.Aspire.Hosting.Templates;
using Terraform.Aspire.Hosting.Templates.Models;


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

    /// <summary>
    /// Adds a specific Terraform template resource to the distributed application builder.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <param name="templatePath"></param>
    /// <param name="outputFileName"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Defines an output of the terraform template.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static IResourceBuilder<TerraformTemplateResource> WithOutput(this IResourceBuilder<TerraformTemplateResource> builder, string output)
    {
        builder.Resource.AddOutput(output);
        return builder;
    }

    /// <summary>
    /// Gets the reference to the terraform template output.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    public static string GetOutput(this IResourceBuilder<TerraformTemplateResource> builder, string output)
    {
        return builder.Resource.GetOutput(output);
    }
}