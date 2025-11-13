using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Represents an annotation that associates a Terraform template with a specific resource type.
/// This annotation defines how a resource should be transformed into Terraform configuration
/// using Handlebars templates.
/// </summary>
/// <typeparam name="T">The type of template resource model that extends TemplateResource.</typeparam>
/// <remarks>
/// This annotation is typically applied to Aspire resources (containers, projects, etc.) to specify
/// which Handlebars template should be used to generate their corresponding Terraform configuration.
/// The template receives the resource's data model for processing.
/// </remarks>
/// <example>
/// <code>
/// var annotation = new TerraformTemplateAnnotation&lt;ContainerTemplateResource&gt;
/// {
///     TemplatePath = "container-app.tf.hbs",
///     OutputFileName = "my-container.tf",
///     AppendFile = false
/// };
/// </code>
/// </example>
public sealed class TerraformTemplateAnnotation<T> : ITerraformTemplateAnnotation where T : TemplateResource
{
    /// <summary>
    /// Gets or sets the template resource model that contains the data to be passed to the Handlebars template.
    /// This model is populated with resource-specific information during the publishing process.
    /// </summary>
    /// <value>
    /// An instance of the template resource model containing resource configuration data.
    /// </value>
    public T TemplateResource { get; set; } = null!;

    /// <summary>
    /// Gets or sets the path to the Handlebars template file, relative to the templates base directory.
    /// The template file should have a .hbs extension and contain Handlebars syntax for generating Terraform configuration.
    /// </summary>
    /// <value>
    /// The relative path to the template file, such as "container-app.tf.hbs" or "database/postgres.tf.hbs".
    /// </value>
    /// <example>
    /// <code>
    /// TemplatePath = "container-app.tf.hbs";
    /// TemplatePath = "azure/storage-account.tf.hbs";
    /// </code>
    /// </example>
    public string TemplatePath { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the name of the output Terraform file to generate.
    /// If not specified, defaults to the resource name with a .tf extension.
    /// </summary>
    /// <value>
    /// The output file name, such as "my-resource.tf" or "infrastructure/database.tf".
    /// Can be null to use the default naming convention.
    /// </value>
    /// <example>
    /// <code>
    /// OutputFileName = "my-container.tf";
    /// OutputFileName = "infrastructure/database.tf";
    /// OutputFileName = null; // Uses resource name + ".tf"
    /// </code>
    /// </example>
    public string? OutputFileName { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the template output should be appended to an existing file
    /// rather than creating a new file or overwriting an existing one.
    /// </summary>
    /// <value>
    /// <c>true</c> to append the template output to an existing file; <c>false</c> to create a new file or overwrite.
    /// Defaults to <c>false</c>.
    /// </value>
    /// <remarks>
    /// This is useful for generating multiple resources in a single Terraform file, such as multiple variables
    /// in a variables.tf file or multiple outputs in an outputs.tf file.
    /// </remarks>
    /// <example>
    /// <code>
    /// // Append multiple variables to variables.tf
    /// AppendFile = true;
    /// OutputFileName = "variables.tf";
    /// </code>
    /// </example>
    public bool AppendFile { get; set; }

    /// <summary>
    /// Gets the template resource model as the base TemplateResource type.
    /// This method is used by the template processing infrastructure to access the model generically.
    /// </summary>
    /// <returns>The template resource model cast to the base TemplateResource type.</returns>
    public TemplateResource GetTemplateResource()
    {
        return TemplateResource;
    }
}