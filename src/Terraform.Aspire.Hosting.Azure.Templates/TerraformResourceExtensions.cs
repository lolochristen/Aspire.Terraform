using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Provides Azure-specific extension methods for associating Terraform templates with Azure Bicep resources.
/// </summary>
public static class TerraformResourceExtensions
{
    /// <summary>
    /// Associates a Handlebars template with an Azure Bicep resource for Terraform configuration generation.
    /// </summary>
    /// <typeparam name="T">The type of Azure Bicep resource.</typeparam>
    /// <param name="resource">The Azure Bicep resource builder to configure.</param>
    /// <param name="templatePath">The path to the Handlebars template file.</param>
    /// <param name="outputFileName">The output file name. Defaults to "{resource-name}.tf" if not specified.</param>
    /// <param name="appendFile">Whether to append output to an existing file.</param>
    /// <returns>The resource builder for method chaining.</returns>
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