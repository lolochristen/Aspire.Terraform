using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Terraform.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public static class TerraformResourceExtensions
{
    public static IResourceBuilder<ProjectResource> WithTerraformTemplate(this IResourceBuilder<ProjectResource> resource, string templatePath, string? outputFileName = null,
        bool appendFile = false)
    {
        resource.WithAnnotation(new TerraformTemplateAnnotation<ProjectTemplateResource>
        {
            TemplatePath = templatePath,
            OutputFileName = outputFileName ?? resource.Resource.Name + ".tf",
            AppendFile = appendFile
        });
        return resource;
    }

    public static IResourceBuilder<ContainerResource> WithTerraformTemplate(this IResourceBuilder<ContainerResource> resource, string templatePath, string? outputFileName = null,
        bool appendFile = false)
    {
        resource.WithAnnotation(new TerraformTemplateAnnotation<ContainerTemplateResource>
        {
            TemplatePath = templatePath,
            OutputFileName = outputFileName ?? resource.Resource.Name + ".tf",
            AppendFile = appendFile
        });
        return resource;
    }

    public static IResourceBuilder<IResource> WithTerraformTemplateParameter(this IResourceBuilder<IResource> resource, string parameterName, object? value)
    {
        resource.WithAnnotation(new TerraformTemplateParameterAnnotation
        {
            Name = parameterName,
            Value = value
        });
        return resource;
    }
}