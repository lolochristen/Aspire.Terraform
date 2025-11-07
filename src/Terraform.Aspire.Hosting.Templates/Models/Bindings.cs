namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Represents network binding configuration for containers.
/// </summary>
public class Bindings
{
    /// <summary>
    /// Gets or sets the URI scheme (http, https).
    /// </summary>
    public required string Scheme { get; set; }
    
    /// <summary>
    /// Gets or sets the network protocol.
    /// </summary>
    public required string Protocol { get; set; }
    
    /// <summary>
    /// Gets or sets the transport protocol.
    /// </summary>
    public required string Transport { get; set; }

    /// <summary>
    /// Gets or sets whether the binding is externally accessible.
    /// </summary>
    public bool External { get; set; }
    
    /// <summary>
    /// Gets or sets the target port inside the container.
    /// </summary>
    public int? TargetPort { get; set; } = 8080;
    
    /// <summary>
    /// Gets or sets the external port.
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    /// Gets or sets the hostname for the binding.
    /// </summary>
    public string Host { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the full URL for the binding.
    /// </summary>
    public string Url { get; set; } = string.Empty;
}