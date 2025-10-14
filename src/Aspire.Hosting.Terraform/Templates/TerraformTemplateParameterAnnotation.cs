using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public class TerraformTemplateParameterAnnotation : IResourceAnnotation
{
    public required string Name { get; set; }
    public object? Value { get; set; }
}