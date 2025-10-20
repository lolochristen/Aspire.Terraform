using Aspire.Hosting.ApplicationModel;
using Terraform.Aspire.Hosting.Templates.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Aspire.Hosting.Azure;

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