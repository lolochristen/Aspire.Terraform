namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Template resource for parameter resources.
/// </summary>
public class ParameterTemplateResource : TemplateResourceWithConnectionString
{
    /// <summary>
    /// Gets or sets the parameter value.
    /// </summary>
    public string Value { get; set; } = null!;

    /// <summary>
    /// Gets or set if it is a secret.
    /// </summary>
    public bool Secret { get; set; }

    /// <summary>
    /// Gets or sets description of parameter.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the default value.
    /// </summary>
    public string? Default { get; set; }
}