using Aspire.Hosting.ApplicationModel;
using Microsoft.AspNetCore.Http.HttpResults;

#pragma warning disable IDE0130
namespace Aspire.Hosting;
#pragma warning restore IDE0130

/// <summary>
/// Represents a Terraform template resource that exposes generated outputs (e.g. connection strings) to Aspire.
/// </summary>
public class TerraformTemplateResource : Resource, IResourceWithConnectionString
{
    private TerraformOutputReference ConnectionStringOutput => new("connectionString", this);

    /// <summary>
    /// Collection of output name to Terraform reference expression mappings.
    /// </summary>
    public Dictionary<string, string> Outputs { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Manifest expression resolving to the connection string output.
    /// </summary>
    public ReferenceExpression ConnectionStringExpression => ReferenceExpression.Create($"{ConnectionStringOutput}");

    /// <summary>
    /// Raw value expression for the connection string.
    /// </summary>
    public string ValueExpression => ConnectionStringExpression.ValueExpression;

    /// <summary>
    /// Creates a new Terraform template resource with the given name and registers a default connection string output.
    /// </summary>
    /// <param name="name">Unique resource name.</param>
    public TerraformTemplateResource(string name) : base(name)
    {
        AddOutput("connectionString");
    }

    /// <summary>
    /// Adds an output with a default local reference (${local.{Name}.{output}}).
    /// </summary>
    /// <param name="output">Output name.</param>
    public void AddOutput(string output) => AddOutput(output, "${local." + Name + "." + output + "}");

    /// <summary>
    /// Adds an output with a custom Terraform reference expression.
    /// </summary>
    /// <param name="output">Output name.</param>
    /// <param name="reference">Terraform reference expression.</param>
    public void AddOutput(string output, string reference)
    {
        Outputs.TryAdd(output, reference);
    }
}