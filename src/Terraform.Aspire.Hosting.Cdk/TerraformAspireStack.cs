using System.Runtime.ExceptionServices;
using Aspire.Hosting.ApplicationModel;
using Constructs;
using HashiCorp.Cdktf;
using Microsoft.Extensions.Logging.Abstractions;
using Terraform.Aspire.Hosting.Cdk;
using IResource = Aspire.Hosting.ApplicationModel.IResource;
using Resource = Aspire.Hosting.ApplicationModel.Resource;

// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

/// <summary>
/// Base class for Terraform CDK stacks in Aspire applications, providing common infrastructure patterns.
/// </summary>
public class TerraformAspireStack : TerraformStack
{
    /// <summary>
    /// Initializes a new Terraform Aspire stack.
    /// </summary>
    /// <param name="scope">The CDK construct scope.</param>
    /// <param name="id">The stack identifier.</param>
    public TerraformAspireStack(Construct scope, string id) : base(scope, id)
    {
        if (TerraformCdkPublishingContext.Current == null)
            throw new InvalidOperationException("Context missing");
        
        Context = TerraformCdkPublishingContext.Current;

        Initialize();
        BuildCoreResources();
        BuildResources();
        Finialize();
    }

    /// <summary>
    /// Gets the collection of Terraform resources created by this stack.
    /// </summary>
    protected List<TerraformResource> TerraformResources { get; } = new();

    /// <summary>
    /// Gets the variable substitutions for value expressions.
    /// </summary>
    protected Dictionary<string, string> Substitutions { get; } = new();

    /// <summary>
    /// Gets the Terraform CDK publishing context.
    /// </summary>
    protected TerraformCdkPublishingContext Context { get; }

    /// <summary>
    /// Substitutes variables in value expressions using the provided or default substitutions.
    /// </summary>
    /// <param name="valueExpression">The expression containing variables to substitute.</param>
    /// <param name="substitutions">Optional custom substitutions, defaults to stack substitutions.</param>
    /// <returns>The expression with variables substituted.</returns>
    protected string SubstituteValueExpressions(string valueExpression, Dictionary<string, string>? substitutions = null)
    {
        foreach (var substitution in substitutions ?? Substitutions) valueExpression = valueExpression.Replace("{" + substitution.Key + "}", substitution.Value);

        return valueExpression;
    }

    /// <summary>
    /// Gets environment variable values for a resource with processing results.
    /// </summary>
    /// <param name="context">The execution context.</param>
    /// <param name="resource">The resource to get environment variables for.</param>
    /// <returns>Dictionary of environment variables with unprocessed and processed values.</returns>
    protected Dictionary<string, (object, string)> GetResourceEnvironmentValues(DistributedApplicationExecutionContext context, IResource resource)
    {
        var resourceEnv = new Dictionary<string, (object, string)>();
        var envTask = resource.ProcessEnvironmentVariableValuesAsync(context, (key, unprocessed, processed, ex) =>
        {
            if (ex is not null) ExceptionDispatchInfo.Throw(ex);

            if (unprocessed is not null && processed is not null) resourceEnv[key] = (unprocessed, processed);
        }, NullLogger.Instance);

        envTask.GetAwaiter().GetResult();
        return resourceEnv;
    }

    /// <summary>
    /// Override to perform initialization before resource creation.
    /// </summary>
    protected virtual void Initialize()
    {
    }

    /// <summary>
    /// Override to build core infrastructure resources.
    /// </summary>
    protected virtual void BuildCoreResources()
    {
    }

    /// <summary>
    /// Gets a previously created Terraform resource by alias and type.
    /// </summary>
    /// <typeparam name="T">The type of Terraform resource.</typeparam>
    /// <param name="alias">The alias used when creating the resource.</param>
    /// <returns>The Terraform resource instance.</returns>
    protected T GetTerraformResource<T>(string alias) where T : TerraformResource
    {
        var name = BuildResourceName<T>(alias);
        return TerraformResources.OfType<T>().First(p => p.FriendlyUniqueId == name);
    }

    /// <summary>
    /// Override to perform finalization after all resources are built.
    /// </summary>
    protected virtual void Finialize()
    {
    }

    /// <summary>
    /// Override to build application-specific resources.
    /// </summary>
    protected virtual void BuildResources()
    {
    }

    /// <summary>
    /// Builds a standardized resource name based on type and options.
    /// </summary>
    /// <typeparam name="T">The type of Terraform resource.</typeparam>
    /// <param name="name">The base name for the resource.</param>
    /// <returns>The formatted resource name.</returns>
    protected string BuildResourceName<T>(string name)
    {
        var resourceTypeName = typeof(T).Name;
        var alias = new string(resourceTypeName.Where(c => c >= 'A' && c <= 'Z').ToArray()).ToLowerInvariant();

        if (string.IsNullOrEmpty(alias))
            alias = name.Substring(0, 3).ToLowerInvariant();

        return
            $"{Context.Options.NamePrefix}{(string.IsNullOrEmpty(Context.Options.NamePrefix) ? "" : Context.Options.NameDelimiter)}{alias}{Context.Options.NameDelimiter}{name.ToLowerInvariant()}{(string.IsNullOrEmpty(Context.Options.NamePostfix) ? "" : Context.Options.NameDelimiter)}{Context.Options.NamePostfix}";
    }

    /// <summary>
    /// Raises the TerraformResourceCreated event when a new resource is added.
    /// </summary>
    /// <param name="terraformResource">The created Terraform resource.</param>
    protected void OnTerraformResourceCreated(TerraformResource terraformResource)
    {
        if (TerraformResourceCreated != null) TerraformResourceCreated(this, new TerraformResourceCreatedEventArgs(terraformResource));
    }

    /// <summary>
    /// Event raised when a Terraform resource is created in this stack.
    /// </summary>
    public event EventHandler<TerraformResourceCreatedEventArgs> TerraformResourceCreated;

    /// <summary>
    /// Adds a Terraform resource to the stack with standardized naming.
    /// </summary>
    /// <typeparam name="T">The type of Terraform resource.</typeparam>
    /// <param name="alias">The alias for the resource.</param>
    /// <param name="factory">Factory function to create the resource.</param>
    /// <returns>The created Terraform resource.</returns>
    protected T AddTerraformResource<T>(string alias, Func<string, T> factory) where T : TerraformResource
    {
        var name = BuildResourceName<T>(alias);
        var resource = factory(name);
        TerraformResources.Add(resource);
        OnTerraformResourceCreated(resource);
        return resource;
    }
}

/// <summary>
/// Event arguments for Terraform resource creation events.
/// </summary>
/// <param name="resource">The created Terraform resource.</param>
public class TerraformResourceCreatedEventArgs(TerraformResource resource) : EventArgs
{
    /// <summary>
    /// Gets the created Terraform resource.
    /// </summary>
    public TerraformResource Resource => resource;
}

/// <summary>
/// Represents a resource used for Terraform provisioning operations.
/// </summary>
public class TerraformProvisioningResource : Resource
{
    /// <summary>
    /// Initializes a new Terraform provisioning resource.
    /// </summary>
    /// <param name="name">The resource name.</param>
    public TerraformProvisioningResource(string name) : base(name)
    {
    }
}