using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Terraform.Templates.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Aspire.Hosting.Azure;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static class TerraformResourceExtensions
{
    [Experimental("ASPIREPUBLISHERS001")]
    public static IResourceBuilder<TerraformStackResource<AzureContainerAppsTerraformStack>> AddAzureContainerAppStack(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, string? name = null, Action<TerraformCdkAzurePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.ApplicationBuilder.Configuration.GetSection("Terraform:CdkAzure");
        var optionsBuilder = builder.ApplicationBuilder.Services.AddOptions<TerraformCdkAzurePublishingOptions>(name)
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        name ??= builder.Resource.Name + "-azure";
        return builder.AddStack<AzureContainerAppsTerraformStack>(name);
    }

    public static IResourceBuilder<T> WithTerraformTemplate<T>(this IResourceBuilder<T> resource, string templatePath, string? outputFileName = null,
        bool appendFile = false) where T : AzureBicepResource
    {
        resource.WithAnnotation(new TerraformTemplateAnnotation<AzureTemplateResource>
        {
            TemplatePath = templatePath,
            OutputFileName = outputFileName ?? resource.Resource.Name + ".tf",
            AppendFile = appendFile
        });
        return resource;
    }

}