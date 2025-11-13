// ReSharper disable once CheckNamespace

namespace Aspire.Hosting;

/// <summary>
/// Configuration options for Terraform CDK publishing functionality.
/// </summary>
public class TerraformCdkPublishingOptions
{
    /// <summary>
    /// Gets or sets default tags to apply to all generated resources.
    /// </summary>
    public Dictionary<string, string> Tags { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the delimiter used in resource names. Defaults to "-".
    /// </summary>
    public string NameDelimiter { get; set; } = "-";
    
    /// <summary>
    /// Gets or sets the prefix for generated resource names.
    /// </summary>
    public string? NamePrefix { get; set; }
    
    /// <summary>
    /// Gets or sets the postfix for generated resource names.
    /// </summary>
    public string? NamePostfix { get; set; }
    
    /// <summary>
    /// Gets or sets the base name used for resource naming. Defaults to "aspire".
    /// </summary>
    public string BaseName { get; set; } = "aspire";

    /// <summary>
    /// Gets or sets the container image tag to use for projects.
    /// </summary>
    public string ImageTag { get; set; } = "latest";
}