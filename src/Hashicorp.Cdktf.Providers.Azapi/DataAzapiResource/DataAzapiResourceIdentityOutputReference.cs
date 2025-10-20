using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResource;

[JsiiClass(typeof(DataAzapiResourceIdentityOutputReference), "azapi.dataAzapiResource.DataAzapiResourceIdentityOutputReference",
    "[{\"docs\":{\"summary\":\"The parent resource.\"},\"name\":\"terraformResource\",\"type\":{\"fqn\":\"cdktf.IInterpolatingParent\"}},{\"docs\":{\"summary\":\"The attribute on the parent resource this class is referencing.\"},\"name\":\"terraformAttribute\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"the index of this item in the list.\"},\"name\":\"complexObjectIndex\",\"type\":{\"primitive\":\"number\"}},{\"docs\":{\"summary\":\"whether the list is wrapping a set (will add tolist() to be able to access an item via an index).\"},\"name\":\"complexObjectIsFromSet\",\"type\":{\"primitive\":\"boolean\"}}]")]
public class DataAzapiResourceIdentityOutputReference : ComplexObject
{
    /// <param name="terraformResource">The parent resource.</param>
    /// <param name="terraformAttribute">The attribute on the parent resource this class is referencing.</param>
    /// <param name="complexObjectIndex">the index of this item in the list.</param>
    /// <param name="complexObjectIsFromSet">
    ///     whether the list is wrapping a set (will add tolist() to be able to access an item
    ///     via an index).
    /// </param>
    public DataAzapiResourceIdentityOutputReference(IInterpolatingParent terraformResource, string terraformAttribute, double complexObjectIndex, bool complexObjectIsFromSet) :
        base(_MakeDeputyProps(terraformResource, terraformAttribute, complexObjectIndex, complexObjectIsFromSet))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceIdentityOutputReference(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceIdentityOutputReference(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("identityIds", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public virtual string[] IdentityIds => GetInstanceProperty<string[]>()!;

    [JsiiProperty("principalId", "{\"primitive\":\"string\"}")]
    public virtual string PrincipalId => GetInstanceProperty<string>()!;

    [JsiiProperty("tenantId", "{\"primitive\":\"string\"}")]
    public virtual string TenantId => GetInstanceProperty<string>()!;

    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    public virtual string Type => GetInstanceProperty<string>()!;

    [JsiiOptional]
    [JsiiProperty("internalValue", "{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceIdentity\"}", true)]
    public virtual IDataAzapiResourceIdentity? InternalValue
    {
        get => GetInstanceProperty<IDataAzapiResourceIdentity?>();
        set => SetInstanceProperty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(IInterpolatingParent terraformResource, string terraformAttribute, double complexObjectIndex, bool complexObjectIsFromSet)
    {
        return new DeputyProps(new object?[] { terraformResource, terraformAttribute, complexObjectIndex, complexObjectIsFromSet });
    }
}