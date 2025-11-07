namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Represents volume mount configuration for containers.
/// </summary>
public class Volumes
{
    /// <summary>
    /// Gets or sets the volume name.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the volume source path.
    /// </summary>
    public string? Source { get; set; }
    
    /// <summary>
    /// Gets or sets the target mount path in the container.
    /// </summary>
    public required string Target { get; set; }
    
    /// <summary>
    /// Gets or sets whether the volume is read-only.
    /// </summary>
    public bool IsReadOnly { get; set; }
}