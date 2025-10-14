using System.Diagnostics.CodeAnalysis;
using HashiCorp.Cdktf;
using Resource = Aspire.Hosting.ApplicationModel.Resource;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

//[Experimental("ASPIREPUBLISHERS001")]
public class TerraformStackResource<TStack> : TerraformStackResource where TStack : TerraformStack
{
    public TerraformStackResource(string name, TerraformCdkEnvironmentResource parent) : base(name, parent, typeof(TStack))
    {
    }
}

//[Experimental("ASPIREPUBLISHERS001")]
public class TerraformStackResource(string name, TerraformCdkEnvironmentResource parent, Type stackType) : Resource(name)
{
    public Type StackType => stackType;

    public TerraformStack CreateInstance(App tfApp)
    {
        var instance = Activator.CreateInstance(StackType, tfApp, Name) as TerraformStack;

        if (instance == null) throw new InvalidOperationException($"Could not create stack {StackType}");

        return instance;
    }
}