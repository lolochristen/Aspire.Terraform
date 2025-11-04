using Aspire.Hosting.ApplicationModel;
using Terraform.Aspire.Hosting.Templates.Models;

#pragma warning disable IDE0130
namespace Aspire.Hosting;
#pragma warning restore IDE0130

/// <summary>
/// Extension methods for working with <see cref="TerraformTemplateResource"/> builders.
/// </summary>
public static class TerraformTemplateResourceExtensions
{
    /// <summary>
    /// Defines an output of the terraform template.
    /// </summary>
    /// <param name="builder">The terraform template resource builder.</param>
    /// <param name="output">Output name.</param>
    /// <returns>The builder for chaining.</returns>
    public static IResourceBuilder<TerraformTemplateResource> WithOutput(this IResourceBuilder<TerraformTemplateResource> builder, string output)
    {
        builder.Resource.AddOutput(output);
        return builder;
    }

    /// <summary>
    /// Gets the reference to a terraform template output.
    /// </summary>
    /// <param name="builder">The terraform template resource builder.</param>
    /// <param name="output">Output name.</param>
    /// <returns>The reference expression.</returns>
    public static string GetOutput(this IResourceBuilder<TerraformTemplateResource> builder, string output)
    {
        return builder.Resource.GetOutput(output);
    }

    /// <summary>
    /// Adds a parameter to use inside the template.
    /// </summary>
    /// <param name="builder">The terraform template resource builder.</param>
    /// <param name="parameterName">Parameter name.</param>
    /// <param name="value">Parameter value.</param>
    /// <returns>The builder for chaining.</returns>
    public static IResourceBuilder<TerraformTemplateResource> WithParameter(this IResourceBuilder<TerraformTemplateResource> builder, string parameterName, object? value)
    {
        builder.WithTerraformTemplateParameter(parameterName, value);
        return builder;
    }
}
