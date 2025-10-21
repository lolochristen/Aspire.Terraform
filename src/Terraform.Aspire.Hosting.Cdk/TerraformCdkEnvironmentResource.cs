using Aspire.Hosting.ApplicationModel;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Represents a Terraform CDK environment that contains multiple stacks for deployment.
/// </summary>
public sealed class TerraformCdkEnvironmentResource : Resource //, IComputeEnvironmentResource
{
    private readonly List<TerraformStackResource> _stacks = new();

    /// <summary>
    /// Initializes a new Terraform CDK environment resource.
    /// </summary>
    /// <param name="name">The name of the environment.</param>
    public TerraformCdkEnvironmentResource(string name) : base(name)
    {
    }

    /// <summary>
    /// Gets the collection of Terraform stacks in this environment.
    /// </summary>
    public IReadOnlyList<TerraformStackResource> Stacks => _stacks;

    /// <summary>
    /// Adds a Terraform stack to this environment.
    /// </summary>
    /// <param name="stackResource">The stack resource to add.</param>
    public void AddStack(TerraformStackResource stackResource)
    {
        _stacks.Add(stackResource);
    }
}