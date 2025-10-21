using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Represents a resource used for Terraform provisioning operations.
/// </summary>
public class TerraformProvisioningResource : Resource
{
    /// <summary>
    /// Initializes a new Terraform provisioning resource.
    /// </summary>
    /// <param name="name">The resource name.</param>
    public TerraformProvisioningResource(string name) : base(name)
    {
    }
}