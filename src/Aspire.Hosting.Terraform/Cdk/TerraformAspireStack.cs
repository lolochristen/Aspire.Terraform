using System.Runtime.ExceptionServices;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Terraform.Cdk;
using Constructs;
using HashiCorp.Cdktf;
using Microsoft.Extensions.Logging.Abstractions;
using IResource = Aspire.Hosting.ApplicationModel.IResource;
using Resource = Aspire.Hosting.ApplicationModel.Resource;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public class TerraformAspireStack : TerraformStack
{
    public TerraformAspireStack(Construct scope, string id) : base(scope, id)
    {
        Context = TerraformCdkPublishingContext.Current;

        Initialize();
        BuildCoreResources();
        BuildResources();
        Finialize();
    }

    protected List<TerraformResource> TerraformResources { get; } = new();

    protected Dictionary<string, string> Substitutions { get; } = new();

    protected TerraformCdkPublishingContext Context { get; }

    protected string SubstituteValueExpressions(string valueExpression, Dictionary<string, string>? substitutions = null)
    {
        foreach (var substitution in substitutions ?? Substitutions) valueExpression = valueExpression.Replace("{" + substitution.Key + "}", substitution.Value);

        return valueExpression;
    }

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

    protected virtual void Initialize()
    {
    }

    protected virtual void BuildCoreResources()
    {
    }

    protected T GetTerraformResource<T>(string alias) where T : TerraformResource
    {
        var name = BuildResourceName<T>(alias);
        return TerraformResources.OfType<T>().First(p => p.FriendlyUniqueId == name);
    }

    protected virtual void Finialize()
    {
    }

    protected virtual void BuildResources()
    {
    }

    protected string BuildResourceName<T>(string name)
    {
        var resourceTypeName = typeof(T).Name;
        var alias = new string(resourceTypeName.Where(c => c >= 'A' && c <= 'Z').ToArray()).ToLowerInvariant();

        if (string.IsNullOrEmpty(alias))
            alias = name.Substring(0, 3).ToLowerInvariant();

        return
            $"{Context.Options.NamePrefix}{(string.IsNullOrEmpty(Context.Options.NamePrefix) ? "" : Context.Options.NameDelimiter)}{alias}{Context.Options.NameDelimiter}{name.ToLowerInvariant()}{(string.IsNullOrEmpty(Context.Options.NamePostfix) ? "" : Context.Options.NameDelimiter)}{Context.Options.NamePostfix}";
    }

    protected void OnTerraformResourceCreated(TerraformResource terraformResource)
    {
        if (TerraformResourceCreated != null) TerraformResourceCreated(this, new TerraformResourceCreatedEventArgs(terraformResource));
    }

    public event EventHandler<TerraformResourceCreatedEventArgs> TerraformResourceCreated;

    protected T AddTerraformResource<T>(string alias, Func<string, T> factory) where T : TerraformResource
    {
        var name = BuildResourceName<T>(alias);
        var resource = factory(name);
        TerraformResources.Add(resource);
        OnTerraformResourceCreated(resource);
        return resource;
    }
}

public class TerraformResourceCreatedEventArgs(TerraformResource resource) : EventArgs
{
    public TerraformResource Resource => resource;
}

public class TerraformProvisioningResource : Resource
{
    public TerraformProvisioningResource(string name) : base(name)
    {
    }
}