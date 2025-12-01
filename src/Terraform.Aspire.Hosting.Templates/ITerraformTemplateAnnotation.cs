using Aspire.Hosting.ApplicationModel;
using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Interface for annotations that associate Terraform templates with resources.
/// </summary>
public interface ITerraformTemplateAnnotation : IResourceAnnotation
{
    /// <summary>
    /// Gets or sets the path to the Handlebars template file.
    /// </summary>
    string? TemplateFile { get; set; }

    /// <summary>
    /// Gets or sets the template string used for formatting or generating output.
    /// </summary>
    string? TemplateString { get; set; }

    /// <summary>
    /// Gets or sets the output file name for generated Terraform configuration.
    /// </summary>
    string? OutputFile { get; set; }
    
    /// <summary>
    /// Gets or sets whether to append output to an existing file.
    /// </summary>
    bool AppendFile { get; set; }

    /// <summary>
    /// Gets or sets a collection of named parameters associated with the current instance.
    /// </summary>
    public Dictionary<string, object?>? Parameters { get; set; }
    
    /// <summary>
    /// Gets the template resource model for processing.
    /// </summary>
    /// <returns>The template resource containing data for template processing.</returns>
    public TemplateResource GetTemplateResource();
}