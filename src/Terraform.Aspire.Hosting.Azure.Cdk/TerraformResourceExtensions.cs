using Aspire.Hosting.ApplicationModel;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static class TerraformResourceExtensions
{
    public static IResourceBuilder<TerraformStackResource<AzureContainerAppsTerraformStack>> AddAzureContainerAppStack(
        this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string? name = null, Action<TerraformCdkAzurePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.ApplicationBuilder.Configuration.GetSection("Terraform:CdkAzure");
        var optionsBuilder = builder.ApplicationBuilder.Services.AddOptions<TerraformCdkAzurePublishingOptions>(name)
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        name ??= builder.Resource.Name + "-azure";
        return builder.AddStack<AzureContainerAppsTerraformStack>(name);
    }
}