namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Template resource for .NET project resources.
/// </summary>
public class ProjectTemplateResource : ContainerTemplateResource
{
    /// <summary>
    /// Gets or sets the project file path.
    /// </summary>
    public string? Path { get; set; }
}