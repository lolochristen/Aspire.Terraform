namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Template resource for value-based resources.
/// </summary>
public class ValueTemplateResource : TemplateResourceWithConnectionString
{
    /// <summary>
    /// Gets or sets value.
    /// </summary>
    public string Value { get; set; } = null!;
}