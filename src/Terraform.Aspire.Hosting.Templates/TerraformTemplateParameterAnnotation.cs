using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Annotation that adds custom parameters to resource templates for Terraform generation.
/// </summary>
public class TerraformTemplateParameterAnnotation : IResourceAnnotation
{
    /// <summary>
    /// Gets or sets the parameter name accessible in templates.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the parameter value passed to templates.
    /// </summary>
    public object? Value { get; set; }
}