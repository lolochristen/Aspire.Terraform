using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Terraform.Templates.Models;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public interface ITerraformTemplateAnnotation : IResourceAnnotation
{
    string TemplatePath { get; set; }
    string? OutputFileName { get; set; }
    bool AppendFile { get; set; }
    public TemplateResource GetTemplateResource();
}