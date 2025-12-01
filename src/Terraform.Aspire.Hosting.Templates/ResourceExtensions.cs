using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for creating Terraform reference expressions related to resources, such as references to
/// local variables and outputs.
/// </summary>
public static class ResourceExtensions
{
    /// <summary>
    /// Creates a reference expression for a Terraform local variable associated with the specified resource and local
    /// name.
    /// </summary>
    /// <param name="name">The name of the local variable to reference. Cannot be null or empty.</param>
    /// <param name="resource">The resource for which the local variable reference is being created. Cannot be null.</param>
    /// <returns>A <see cref="ReferenceExpression"/> representing the Terraform local variable reference for the specified
    /// resource and name.</returns>
    public static ReferenceExpression GetTerraformLocal(this IResource resource, string name)
    {
        return ReferenceExpression.Create($"${{local.{resource.Name}.{name}}}");
    }

    /// <summary>
    /// Creates a reference expression for a Terraform output associated with the specified resource and output name.
    /// </summary>
    /// <param name="name">The name of the Terraform output to reference. Cannot be null or empty.</param>
    /// <param name="resource">The resource for which the local variable reference is being created. Cannot be null.</param>
    /// <returns>A reference expression representing the specified Terraform output for the given resource.</returns>
    public static ReferenceExpression GetTerraformOutput(this IResource resource, string name)
    {
        return ReferenceExpression.Create($"${{output.{resource.Name}.{name}}}");
    }
}