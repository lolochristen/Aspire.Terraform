using Aspire.Hosting.ApplicationModel;

#pragma warning disable IDE0130
namespace Aspire.Hosting;
#pragma warning restore IDE0130

/// <summary>
/// A reference to an output from a terraform template.
/// </summary>
/// <param name="name"></param>
/// <param name="resource"></param>
public sealed class TerraformOutputReference(string name, TerraformTemplateResource resource) : IManifestExpressionProvider, IValueProvider, IValueWithReferences, IEquatable<TerraformOutputReference>
{
    /// <summary>
    /// Name of the output.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// The instance of the bicep resource.
    /// </summary>
    public TerraformTemplateResource Resource { get; } = resource;

    IEnumerable<object> IValueWithReferences.References => [Resource];

    /// <summary>
    /// The value of the output.
    /// </summary>
    /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    public async ValueTask<string?> GetValueAsync(CancellationToken cancellationToken = default)
    {
        return Value;
    }

    /// <summary>
    /// The value of the output.
    /// </summary>
    public string? Value
    {
        get
        {
            if (!Resource.Outputs.TryGetValue(Name, out var value))
            {
                throw new InvalidOperationException($"No output for {Name}");
            }

            return value?.ToString();
        }
    }

    /// <summary>
    /// The expression used in the manifest to reference the value of the output.
    /// </summary>
    public string ValueExpression => $"{{{Resource.Name}.outputs.{Name}}}";

    bool IEquatable<TerraformOutputReference>.Equals(TerraformOutputReference? other) =>
        other is not null &&
        other.Resource == Resource &&
        other.Name == Name;

    /// <inheritdoc/>
    public override int GetHashCode() =>
        HashCode.Combine(Resource, Name);
}