namespace Aspire.Hosting;

/// <summary>
/// Configuration options specific to Azure resources for Terraform CDK publishing.
/// </summary>
public class TerraformCdkAzurePublishingOptions
{
    /// <summary>
    /// Gets or sets the Azure subscription ID for resource deployment.
    /// </summary>
    public string? SubscriptionId { get; set; }
    
    /// <summary>
    /// Gets or sets the Azure region/location for resource deployment.
    /// </summary>
    public string? Location { get; set; }
    
    /// <summary>
    /// Gets or sets the Azure tenant ID for authentication.
    /// </summary>
    public string? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the container image tag to use for projects.
    /// </summary>
    public string ImageTag { get; set; } = "latest";
}