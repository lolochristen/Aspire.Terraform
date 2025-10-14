// ReSharper disable once CheckNamespace

namespace Aspire.Hosting;

public class TerraformCdkPublishingOptions
{
    public Dictionary<string, string> Tags { get; set; } = new();
    public string NameDelimiter { get; set; } = "-";
    public string? NamePrefix { get; set; }
    public string? NamePostfix { get; set; }
    public string BaseName { get; set; } = "aspire";
}