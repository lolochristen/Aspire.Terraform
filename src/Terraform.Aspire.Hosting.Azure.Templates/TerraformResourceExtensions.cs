using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static class TerraformResourceExtensions
{
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