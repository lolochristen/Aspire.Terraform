using HashiCorp.Cdktf;

namespace Aspire.Hosting;

/// <summary>
/// Event arguments for Terraform resource creation events.
/// </summary>
/// <param name="resource">The created Terraform resource.</param>
public class TerraformResourceCreatedEventArgs(TerraformResource resource) : EventArgs
{
    /// <summary>
    /// Gets the created Terraform resource.
    /// </summary>
    public TerraformResource Resource => resource;
}