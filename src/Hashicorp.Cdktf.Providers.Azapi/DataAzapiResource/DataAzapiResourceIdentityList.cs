using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResource;

[JsiiClass(typeof(DataAzapiResourceIdentityList), "azapi.dataAzapiResource.DataAzapiResourceIdentityList",
    "[{\"docs\":{\"summary\":\"The parent resource.\"},\"name\":\"terraformResource\",\"type\":{\"fqn\":\"cdktf.IInterpolatingParent\"}},{\"docs\":{\"summary\":\"The attribute on the parent resource this class is referencing.\"},\"name\":\"terraformAttribute\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"whether the list is wrapping a set (will add tolist() to be able to access an item via an index).\"},\"name\":\"wrapsSet\",\"type\":{\"primitive\":\"boolean\"}}]")]
public class DataAzapiResourceIdentityList : ComplexList
{
    /// <param name="terraformResource">The parent resource.</param>
    /// <param name="terraformAttribute">The attribute on the parent resource this class is referencing.</param>
    /// <param name="wrapsSet">
    ///     whether the list is wrapping a set (will add tolist() to be able to access an item via an
    ///     index).
    /// </param>
    public DataAzapiResourceIdentityList(IInterpolatingParent terraformResource, string terraformAttribute, bool wrapsSet) : base(_MakeDeputyProps(terraformResource,
        terraformAttribute, wrapsSet))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceIdentityList(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceIdentityList(DeputyProps props) : base(props)
    {
    }

    /// <summary>The attribute on the parent resource this class is referencing.</summary>
    [JsiiProperty("terraformAttribute", "{\"primitive\":\"string\"}")]
    protected override string TerraformAttribute
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    /// <summary>The parent resource.</summary>
    [JsiiProperty("terraformResource", "{\"fqn\":\"cdktf.IInterpolatingParent\"}")]
    protected override IInterpolatingParent TerraformResource
    {
        get => GetInstanceProperty<IInterpolatingParent>()!;
        set => SetInstanceProperty(value);
    }

    /// <summary>whether the list is wrapping a set (will add tolist() to be able to access an item via an index).</summary>
    [JsiiProperty("wrapsSet", "{\"primitive\":\"boolean\"}")]
    protected override bool WrapsSet
    {
        get => GetInstanceProperty<bool>()!;
        set => SetInstanceProperty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(IInterpolatingParent terraformResource, string terraformAttribute, bool wrapsSet)
    {
        return new DeputyProps(new object?[] { terraformResource, terraformAttribute, wrapsSet });
    }

    /// <param name="index">the index of the item to return.</param>
    [JsiiMethod("get", "{\"type\":{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceIdentityOutputReference\"}}",
        "[{\"docs\":{\"summary\":\"the index of the item to return.\"},\"name\":\"index\",\"type\":{\"primitive\":\"number\"}}]")]
    public virtual DataAzapiResourceIdentityOutputReference Get(double index)
    {
        return InvokeInstanceMethod<DataAzapiResourceIdentityOutputReference>(new[] { typeof(double) }, new object[] { index })!;
    }
}