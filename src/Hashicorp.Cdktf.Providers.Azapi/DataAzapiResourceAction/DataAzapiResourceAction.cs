using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceAction;

/// <summary>
///     Represents a {@link
///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action azapi_resource_action}.
/// </summary>
[JsiiClass(typeof(DataAzapiResourceAction), "azapi.dataAzapiResourceAction.DataAzapiResourceAction",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionConfig\"}}]")]
public class DataAzapiResourceAction : TerraformDataSource
{
    /// <summary>
    ///     Create a new {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action azapi_resource_action}
    ///     Data Source.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public DataAzapiResourceAction(Construct scope, string id, IDataAzapiResourceActionConfig config) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceAction(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceAction(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(DataAzapiResourceAction))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("output", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap Output => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetryOutputReference\"}")]
    public virtual DataAzapiResourceActionRetryOutputReference Retry => GetInstanceProperty<DataAzapiResourceActionRetryOutputReference>()!;

    [JsiiProperty("sensitiveOutput", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap SensitiveOutput => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeoutsOutputReference\"}")]
    public virtual DataAzapiResourceActionTimeoutsOutputReference Timeouts => GetInstanceProperty<DataAzapiResourceActionTimeoutsOutputReference>()!;

    [JsiiOptional]
    [JsiiProperty("actionInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ActionInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("bodyInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? BodyInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("headersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? HeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("methodInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? MethodInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("queryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? QueryParametersInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("resourceIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ResourceIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("responseExportValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? ResponseExportValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("retryInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}]}}", true)]
    public virtual object? RetryInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("sensitiveResponseExportValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? SensitiveResponseExportValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("typeInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TypeInput => GetInstanceProperty<string?>();

    [JsiiProperty("action", "{\"primitive\":\"string\"}")]
    public virtual string Action
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> Body
    {
        get => GetInstanceProperty<IDictionary<string, object>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> Headers
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("method", "{\"primitive\":\"string\"}")]
    public virtual string Method
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

    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}")]
    public virtual string ResourceId
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> ResponseExportValues
    {
        get => GetInstanceProperty<IDictionary<string, object>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("sensitiveResponseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> SensitiveResponseExportValues
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
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IDataAzapiResourceActionConfig config)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>
    ///     Generates CDKTF code for importing a DataAzapiResourceAction resource upon running "cdktf plan &lt;stack-name
    ///     &gt;".
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the DataAzapiResourceAction to import.</param>
    /// <param name="importFromId">The id of the existing DataAzapiResourceAction that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the DataAzapiResourceAction to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the DataAzapiResourceAction to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing DataAzapiResourceAction that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the DataAzapiResourceAction to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(DataAzapiResourceAction), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putRetry", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}}]")]
    public virtual void PutRetry(IDataAzapiResourceActionRetry value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiResourceActionRetry) }, new object[] { value });
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}}]")]
    public virtual void PutTimeouts(IDataAzapiResourceActionTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataAzapiResourceActionTimeouts) }, new object[] { value });
    }

    [JsiiMethod("resetAction")]
    public virtual void ResetAction()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetBody")]
    public virtual void ResetBody()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetHeaders")]
    public virtual void ResetHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetMethod")]
    public virtual void ResetMethod()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetQueryParameters")]
    public virtual void ResetQueryParameters()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetResourceId")]
    public virtual void ResetResourceId()
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

    [JsiiMethod("resetSensitiveResponseExportValues")]
    public virtual void ResetSensitiveResponseExportValues()
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