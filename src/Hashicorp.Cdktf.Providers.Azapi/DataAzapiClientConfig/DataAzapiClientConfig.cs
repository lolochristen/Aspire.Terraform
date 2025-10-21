using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiClientConfig;

/// <summary>
///     Represents a {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/client_config
///     azapi_client_config}.
/// </summary>
[JsiiClass(typeof(DataAzapiClientConfig), "azapi.dataAzapiClientConfig.DataAzapiClientConfig",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"optional\":true,\"type\":{\"fqn\":\"azapi.dataAzapiClientConfig.DataAzapiClientConfigConfig\"}}]")]
public class DataAzapiClientConfig : TerraformDataSource
{
    /// <summary>
    ///     Create a new {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/client_config
    ///     azapi_client_config} Data Source.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public DataAzapiClientConfig(Construct scope, string id, IDataAzapiClientConfigConfig? config = null) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiClientConfig(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiClientConfig(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(DataAzapiClientConfig))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("objectId", "{\"primitive\":\"string\"}")]
    public virtual string ObjectId => GetInstanceProperty<string>()!;

    [JsiiProperty("subscriptionId", "{\"primitive\":\"string\"}")]
    public virtual string SubscriptionId => GetInstanceProperty<string>()!;

    [JsiiProperty("subscriptionResourceId", "{\"primitive\":\"string\"}")]
    public virtual string SubscriptionResourceId => GetInstanceProperty<string>()!;

    [JsiiProperty("tenantId", "{\"primitive\":\"string\"}")]
    public virtual string TenantId => GetInstanceProperty<string>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiClientConfig.DataAzapiClientConfigTimeoutsOutputReference\"}")]
    public virtual DataAzapiClientConfigTimeoutsOutputReference Timeouts => GetInstanceProperty<DataAzapiClientConfigTimeoutsOutputReference>()!;

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiClientConfig.DataAzapiClientConfigTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IDataAzapiClientConfigConfig? config = null)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>
    ///     Generates CDKTF code for importing a DataAzapiClientConfig resource upon running "cdktf plan &lt;stack-name
    ///     &gt;".
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the DataAzapiClientConfig to import.</param>
    /// <param name="importFromId">The id of the existing DataAzapiClientConfig that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the DataAzapiClientConfig to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the DataAzapiClientConfig to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/client_config#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing DataAzapiClientConfig that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the DataAzapiClientConfig to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(DataAzapiClientConfig), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiClientConfig.DataAzapiClientConfigTimeouts\"}}]")]
    public virtual void PutTimeouts(IDataAzapiClientConfigTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiClientConfigTimeouts) }, new object[] { value });
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