// ReSharper disable once CheckNamespace

namespace Aspire.Hosting;

public class TerraformTemplatePublishingOptions
{
    public string? TemplatesPath { get; set; }
    public string BaseFiles { get; set; } = "main.tf;providers.tf;variables.tf;outputs.tf;backend.tf;versions.tf";
}