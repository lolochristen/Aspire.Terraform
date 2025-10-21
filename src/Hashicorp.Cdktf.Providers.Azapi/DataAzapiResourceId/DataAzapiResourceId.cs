using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceId;

/// <summary>
///     Represents a {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id
///     azapi_resource_id}.
/// </summary>
[JsiiClass(typeof(DataAzapiResourceId), "azapi.dataAzapiResourceId.DataAzapiResourceId",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdConfig\"}}]")]
public class DataAzapiResourceId : TerraformDataSource
{
    /// <summary>
    ///     Create a new {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id
    ///     azapi_resource_id} Data Source.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public DataAzapiResourceId(Construct scope, string id, IDataAzapiResourceIdConfig config) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceId(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceId(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(DataAzapiResourceId))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("parts", "{\"fqn\":\"cdktf.StringMap\"}")]
    public virtual StringMap Parts => GetInstanceProperty<StringMap>()!;

    [JsiiProperty("providerNamespace", "{\"primitive\":\"string\"}")]
    public virtual string ProviderNamespace => GetInstanceProperty<string>()!;

    [JsiiProperty("resourceGroupName", "{\"primitive\":\"string\"}")]
    public virtual string ResourceGroupName => GetInstanceProperty<string>()!;

    [JsiiProperty("subscriptionId", "{\"primitive\":\"string\"}")]
    public virtual string SubscriptionId => GetInstanceProperty<string>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeoutsOutputReference\"}")]
    public virtual DataAzapiResourceIdTimeoutsOutputReference Timeouts => GetInstanceProperty<DataAzapiResourceIdTimeoutsOutputReference>()!;

    [JsiiOptional]
    [JsiiProperty("nameInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? NameInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("parentIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ParentIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("resourceIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ResourceIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("typeInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TypeInput => GetInstanceProperty<string?>();

    [JsiiProperty("name", "{\"primitive\":\"string\"}")]
    public virtual string Name
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("parentId", "{\"primitive\":\"string\"}")]
    public virtual string ParentId
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}")]
    public virtual string ResourceId
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    public virtual string Type
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IDataAzapiResourceIdConfig config)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>
    ///     Generates CDKTF code for importing a DataAzapiResourceId resource upon running "cdktf plan &lt;stack-name&gt;
    ///     ".
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the DataAzapiResourceId to import.</param>
    /// <param name="importFromId">The id of the existing DataAzapiResourceId that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the DataAzapiResourceId to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the DataAzapiResourceId to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing DataAzapiResourceId that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the DataAzapiResourceId to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(DataAzapiResourceId), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeouts\"}}]")]
    public virtual void PutTimeouts(IDataAzapiResourceIdTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiResourceIdTimeouts) }, new object[] { value });
    }

    [JsiiMethod("resetName")]
    public virtual void ResetName()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetParentId")]
    public virtual void ResetParentId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetResourceId")]
    public virtual void ResetResourceId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetTimeouts")]
    public virtual void ResetTimeouts()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("synthesizeAttributes", "{\"type\":{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}}")]
    protected override IDictionary<string, object> SynthesizeAttributes()
    {
        return InvokeInstanceMethod<IDictionary<string, object>>(new Type[] { }, new object[] { })!;
    }

    [JsiiMethod("synthesizeHclAttributes", "{\"type\":{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}}")]
    protected override IDictionary<string, object> SynthesizeHclAttributes()
    {
        return InvokeInstanceMethod<IDictionary<string, object>>(new Type[] { }, new object[] { })!;
    }
}