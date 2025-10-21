using Aspire.Hosting.ApplicationModel;
using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for associating Terraform templates with Aspire resources.
/// These extensions enable resources to specify custom Handlebars templates for generating
/// their corresponding Terraform infrastructure configuration.
/// </summary>
public static class TerraformResourceExtensions
{
    /// <summary>
    /// Associates a Handlebars template with a project resource for Terraform configuration generation.
    /// </summary>
    /// <param name="resource">The project resource builder to configure.</param>
    /// <param name="templatePath">The path to the Handlebars template file, relative to the templates base directory.</param>
    /// <param name="outputFileName">The name of the output Terraform file. Defaults to "{resource-name}.tf" if not specified.</param>
    /// <param name="appendFile">Whether to append the template output to an existing file instead of creating a new file.</param>
    /// <returns>The project resource builder for method chaining.</returns>
    /// <remarks>
    /// The template receives a ProjectTemplateResource model that includes project metadata,
    /// environment variables, command-line arguments, network bindings, replica count,
    /// and container image information.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.WebApi&gt;("webapi")
    ///     .WithTerraformTemplate("azure/container-app.tf.hbs", "webapi-infrastructure.tf");
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithTerraformTemplate(this IResourceBuilder<ProjectResource> resource, string templatePath, string? outputFileName = null,
        bool appendFile = false)
    {
        resource.WithAnnotation(new TerraformTemplateAnnotation<ProjectTemplateResource>
        {
            TemplatePath = templatePath,
            OutputFileName = outputFileName ?? resource.Resource.Name + ".tf",
            AppendFile = appendFile
        });
        return resource;
    }

    /// <summary>
    /// Associates a Handlebars template with a container resource for Terraform configuration generation.
    /// </summary>
    /// <param name="resource">The container resource builder to configure.</param>
    /// <param name="templatePath">The path to the Handlebars template file, relative to the templates base directory.</param>
    /// <param name="outputFileName">The name of the output Terraform file. Defaults to "{resource-name}.tf" if not specified.</param>
    /// <param name="appendFile">Whether to append the template output to an existing file instead of creating a new file.</param>
    /// <returns>The container resource builder for method chaining.</returns>
    /// <remarks>
    /// The template receives a ContainerTemplateResource model that includes container metadata,
    /// image name, environment variables, command-line arguments, network bindings, volume mounts,
    /// entrypoint configuration, and replica count.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddContainer("redis", "redis:7-alpine")
    ///     .WithTerraformTemplate("azure/redis-cache.tf.hbs", "redis-cache.tf");
    /// </code>
    /// </example>
    public static IResourceBuilder<ContainerResource> WithTerraformTemplate(this IResourceBuilder<ContainerResource> resource, string templatePath, string? outputFileName = null,
        bool appendFile = false)
    {
        resource.WithAnnotation(new TerraformTemplateAnnotation<ContainerTemplateResource>
        {
            TemplatePath = templatePath,
            OutputFileName = outputFileName ?? resource.Resource.Name + ".tf",
            AppendFile = appendFile
        });
        return resource;
    }

    /// <summary>
    /// Adds a custom parameter to a resource that will be available in its Terraform template context.
    /// </summary>
    /// <param name="resource">The resource builder to configure.</param>
    /// <param name="parameterName">The name of the parameter that will be accessible in the template.</param>
    /// <param name="value">The value of the parameter, which can be any serializable object.</param>
    /// <returns>The resource builder for method chaining.</returns>
    /// <remarks>
    /// Template parameters are added to the Parameters dictionary of the template resource model
    /// and can be accessed in Handlebars templates using dot notation or helper functions.
    /// Parameters support complex objects that will be serialized appropriately for template usage.
    /// </remarks>
    public static IResourceBuilder<IResource> WithTerraformTemplateParameter(this IResourceBuilder<IResource> resource, string parameterName, object? value)
    {
        resource.WithAnnotation(new TerraformTemplateParameterAnnotation
        {
            Name = parameterName,
            Value = value
        });
        return resource;
    }
}