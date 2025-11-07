namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Template resource for value-based resources.
/// </summary>
public class ValueTemplateResource : TemplateResourceWithConnectionString
{
    public string Value { get;set; }
}