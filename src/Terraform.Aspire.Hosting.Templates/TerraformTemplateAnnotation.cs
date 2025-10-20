using Terraform.Aspire.Hosting.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public sealed class TerraformTemplateAnnotation<T> : ITerraformTemplateAnnotation where T : TemplateResource
{
    public T TemplateResource { get; set; }
    public string TemplatePath { get; set; }
    public string? OutputFileName { get; set; }
    public bool AppendFile { get; set; }

    public TemplateResource GetTemplateResource()
    {
        return TemplateResource;
    }
}