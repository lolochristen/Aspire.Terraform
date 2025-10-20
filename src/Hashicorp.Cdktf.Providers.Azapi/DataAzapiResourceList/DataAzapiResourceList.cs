using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceList;

/// <summary>
///     Represents a {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list
///     azapi_resource_list}.
/// </summary>
[JsiiClass(typeof(DataAzapiResourceList), "azapi.dataAzapiResourceList.DataAzapiResourceList",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListConfig\"}}]")]
public class DataAzapiResourceList : TerraformDataSource
{
    /// <summary>
    ///     Create a new {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list
    ///     azapi_resource_list} Data Source.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public DataAzapiResourceList(Construct scope, string id, IDataAzapiResourceListConfig config) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceList(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceList(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(DataAzapiResourceList))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("output", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap Output => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListRetryOutputReference\"}")]
    public virtual DataAzapiResourceListRetryOutputReference Retry => GetInstanceProperty<DataAzapiResourceListRetryOutputReference>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListTimeoutsOutputReference\"}")]
    public virtual DataAzapiResourceListTimeoutsOutputReference Timeouts => GetInstanceProperty<DataAzapiResourceListTimeoutsOutputReference>()!;

    [JsiiOptional]
    [JsiiProperty("headersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? HeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("parentIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ParentIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("queryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? QueryParametersInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("responseExportValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? ResponseExportValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("retryInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListRetry\"}]}}", true)]
    public virtual object? RetryInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("typeInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TypeInput => GetInstanceProperty<string?>();

    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> Headers
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("parentId", "{\"primitive\":\"string\"}")]
    public virtual string ParentId
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("queryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}")]
    public virtual object QueryParameters
    {
        get => GetInstanceProperty<object>()!;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case IResolvable cast_cd4240:
                        break;
                    case IDictionary<string, string[]> cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received null",
                            nameof(value));
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> ResponseExportValues
    {
        get => GetInstanceProperty<IDictionary<string, object>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    public virtual string Type
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IDataAzapiResourceListConfig config)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>
    ///     Generates CDKTF code for importing a DataAzapiResourceList resource upon running "cdktf plan &lt;stack-name
    ///     &gt;".
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the DataAzapiResourceList to import.</param>
    /// <param name="importFromId">The id of the existing DataAzapiResourceList that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the DataAzapiResourceList to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the DataAzapiResourceList to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing DataAzapiResourceList that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the DataAzapiResourceList to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(DataAzapiResourceList), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putRetry", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListRetry\"}}]")]
    public virtual void PutRetry(IDataAzapiResourceListRetry value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiResourceListRetry) }, new object[] { value });
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListTimeouts\"}}]")]
    public virtual void PutTimeouts(IDataAzapiResourceListTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiResourceListTimeouts) }, new object[] { value });
    }

    [JsiiMethod("resetHeaders")]
    public virtual void ResetHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetQueryParameters")]
    public virtual void ResetQueryParameters()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetResponseExportValues")]
    public virtual void ResetResponseExportValues()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetRetry")]
    public virtual void ResetRetry()
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