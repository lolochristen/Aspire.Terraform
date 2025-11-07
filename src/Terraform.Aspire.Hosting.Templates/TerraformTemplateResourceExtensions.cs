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
    /// Gets the reference to a terraform template output.
    /// </summary>
    /// <param name="builder">The terraform template resource builder.</param>
    /// <param name="name">Output name.</param>
    /// <returns>The reference expression.</returns>
    public static TerraformOutputReference GetOutput(this IResourceBuilder<TerraformTemplateResource> builder, string name)
    {
        builder.Resource.AddOutput(name);
        return new TerraformOutputReference(name, builder.Resource);
    }

    /// <summary>
    /// Gets the reference to a terraform template output.
    /// </summary>
    /// <param name="builder">The terraform template resource builder.</param>
    /// <param name="name">Output name.</param>
    /// <returns>The reference expression.</returns>
    public static TerraformSecretOutputReference GetSecretOutput(this IResourceBuilder<TerraformTemplateResource> builder, string name)
    {
        builder.Resource.AddOutput(name);
        return new TerraformSecretOutputReference(name, builder.Resource);
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
