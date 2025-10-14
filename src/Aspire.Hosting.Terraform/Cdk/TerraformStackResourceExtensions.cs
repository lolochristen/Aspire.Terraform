using Aspire.Hosting.ApplicationModel;
using HashiCorp.Cdktf;

#pragma warning disable ASPIREPUBLISHERS001

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static class TerraformStackResourceExtensions
{
    public static IResourceBuilder<TerraformStackResource> WithTerraformResource(this IResourceBuilder<TerraformStackResource> builder, Action<TerraformAspireStack> buildAction)
    {
        builder.WithAnnotation(new TerraformCdkResourceAnnotation(buildAction));
        return builder;
    }

    public static IResourceBuilder<TerraformStackResource> WithModule(this IResourceBuilder<TerraformStackResource> builder, string name, string source,
        Dictionary<string, object> variables = null, object[] providers = null)
    {
        builder.WithAnnotation(new TerraformCdkResourceAnnotation(stack =>
        {
            new TerraformHclModule(stack, name, new TerraformHclModuleConfig
            {
                Source = Path.GetFullPath(source),
                Providers = providers ?? [],
                Variables = variables ?? []
            });
        }));
        return builder;
    }
}