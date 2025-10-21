using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Annotation that defines custom build actions for Terraform CDK stack construction.
/// </summary>
public class TerraformCdkResourceAnnotation : IResourceAnnotation
{
    /// <summary>
    /// Initializes a new CDK resource annotation with the specified build action.
    /// </summary>
    /// <param name="buildAction">Action to execute during stack construction.</param>
    public TerraformCdkResourceAnnotation(Action<TerraformAspireStack> buildAction)
    {
        BuildAction = buildAction;
    }

    /// <summary>
    /// Gets the action to execute during Terraform stack construction.
    /// </summary>
    public Action<TerraformAspireStack> BuildAction { get; }
}