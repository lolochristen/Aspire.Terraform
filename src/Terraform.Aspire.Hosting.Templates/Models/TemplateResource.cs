using System.IO.Pipes;
using Aspire.Hosting.ApplicationModel;

namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Base class for template resource models used in Terraform generation.
/// </summary>
public class TemplateResource
{
    /// <summary>
    /// Gets or sets the original Aspire resource.
    /// </summary>
    public IResource Resource { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the resource name.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the Terraform outputs for this resource.
    /// </summary>
    public Dictionary<string, string> Outputs { get; set; } = new();

    /// <summary>
    /// Gets or sets the Terraform outputs for this resource.
    /// </summary>
    public Dictionary<string, string> Secrets { get; set; } = new();

    /// <summary>
    /// Gets or sets the parent resource if this is a child resource.
    /// </summary>
    public TemplateResource? Parent { get; set; }
    
    /// <summary>
    /// Gets or sets custom parameters for template processing.
    /// </summary>
    public Dictionary<string, object?> Parameters { get; set; } = new();

    /// <summary>
    /// Gets all references of this resource.
    /// </summary>
    public List<TemplateResource> References { get; set; } = new();

    /// <summary>
    /// Gets all resources referencing this resource.
    /// </summary>
    public List<TemplateResource> ReferencedBy { get; set; } = new();

    /// <summary>
    /// Gets type name of the resource.
    /// </summary>
    public string Type => TerraformTemplatePublisher.NormalizeTypeName(Resource.GetType().Name);
    
    /// <summary>
    /// Info
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Name} ({Resource})";
}