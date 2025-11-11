using Constructs;
using HashiCorp.Cdktf;
using Resource = Aspire.Hosting.ApplicationModel.Resource;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Represents a strongly-typed Terraform stack resource with a specific stack implementation.
/// </summary>
/// <typeparam name="TStack">The type of the Terraform stack implementation.</typeparam>
public class TerraformStackResource<TStack> : TerraformStackResource where TStack : TerraformStack
{
    /// <summary>
    /// Initializes a new strongly-typed Terraform stack resource.
    /// </summary>
    /// <param name="name">The name of the stack.</param>
    /// <param name="parent">The parent environment resource.</param>
    public TerraformStackResource(string name, TerraformCdkEnvironmentResource parent) : base(name, parent, typeof(TStack))
    {
    }
}

/// <summary>
/// Represents a Terraform stack resource that can be deployed within a CDK environment.
/// </summary>
/// <param name="name">The name of the stack.</param>
/// <param name="parent">The parent environment resource.</param>
/// <param name="stackType">The type of the Terraform stack implementation.</param>
public class TerraformStackResource(string name, TerraformCdkEnvironmentResource parent, Type stackType) : Resource(name)
{
    /// <summary>
    /// Gets the type of the Terraform stack implementation.
    /// </summary>
    public Type StackType => stackType;

    /// <summary>
    /// Creates an instance of the Terraform stack using the specified CDK app.
    /// </summary>
    /// <param name="tfApp">The CDK app to create the stack within.</param>
    /// <returns>The created Terraform stack instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack cannot be created.</exception>
    public TerraformStack CreateInstance(App tfApp)
    {
        var instance = Activator.CreateInstance(StackType, tfApp, Name) as TerraformStack;

        if (instance == null) throw new InvalidOperationException($"Could not create stack {StackType}");

        return instance;
    }
}