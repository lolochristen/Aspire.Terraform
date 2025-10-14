using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public class TerraformCdkResourceAnnotation : IResourceAnnotation
{
    public TerraformCdkResourceAnnotation(Action<TerraformAspireStack> buildAction)
    {
        BuildAction = buildAction;
    }

    public Action<TerraformAspireStack> BuildAction { get; }
}