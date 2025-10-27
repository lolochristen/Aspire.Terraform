// ReSharper disable once CheckNamespace

namespace Aspire.Hosting;

/// <summary>
/// Options that control how Terraform templates are published.
/// </summary>
/// <remarks>
/// Configure the source <see cref="TemplatesPath"/>, the semicolon separated list of mandatory base template files
/// in <see cref="BaseFiles"/>, and an optional <see cref="FilePrefix"/> applied to generated files.
/// </remarks>
public class TerraformTemplatePublishingOptions
{
    /// <summary>
    /// Optional path that contains the Terraform template files to publish. If null, a default path ./.templates is used.
    /// </summary>
    public string? TemplatesPath { get; set; }

    /// <summary>
    /// Semicolon separated list of base Terraform files that should always be included when publishing.
    /// </summary>
    public string BaseFiles { get; set; } = "main.tf;providers.tf;variables.tf;outputs.tf;backend.tf;versions.tf";

    /// <summary>
    /// Optional prefix applied to generated or copied template file names (e.g. "aspire-").
    /// </summary>
    public string? FilePrefix { get; set; } = "aspire-";
}