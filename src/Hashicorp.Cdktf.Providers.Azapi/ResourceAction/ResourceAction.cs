using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.ResourceAction;

/// <summary>
///     Represents a {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action
///     azapi_resource_action}.
/// </summary>
[JsiiClass(typeof(ResourceAction), "azapi.resourceAction.ResourceAction",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"type\":{\"fqn\":\"azapi.resourceAction.ResourceActionConfig\"}}]")]
public class ResourceAction : TerraformResource
{
    /// <summary>
    ///     Create a new {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action
    ///     azapi_resource_action} Resource.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public ResourceAction(Construct scope, string id, IResourceActionConfig config) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected ResourceAction(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected ResourceAction(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(ResourceAction))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("output", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap Output => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("retry", "{\"fqn\":\"azapi.resourceAction.ResourceActionRetryOutputReference\"}")]
    public virtual ResourceActionRetryOutputReference Retry => GetInstanceProperty<ResourceActionRetryOutputReference>()!;

    [JsiiProperty("sensitiveOutput", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap SensitiveOutput => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resourceAction.ResourceActionTimeoutsOutputReference\"}")]
    public virtual ResourceActionTimeoutsOutputReference Timeouts => GetInstanceProperty<ResourceActionTimeoutsOutputReference>()!;

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
    [JsiiProperty("locksInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? LocksInput => GetInstanceProperty<string[]?>();

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
    [JsiiProperty("retryInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.resourceAction.ResourceActionRetry\"}]}}", true)]
    public virtual object? RetryInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("sensitiveResponseExportValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? SensitiveResponseExportValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.resourceAction.ResourceActionTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("typeInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TypeInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("whenInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? WhenInput => GetInstanceProperty<string?>();

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

    [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public virtual string[] Locks
    {
        get => GetInstanceProperty<string[]>()!;
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

    [JsiiProperty("when", "{\"primitive\":\"string\"}")]
    public virtual string When
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IResourceActionConfig config)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>Generates CDKTF code for importing a ResourceAction resource upon running "cdktf plan &lt;stack-name&gt;".</summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the ResourceAction to import.</param>
    /// <param name="importFromId">The id of the existing ResourceAction that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the ResourceAction to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the ResourceAction to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing ResourceAction that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the ResourceAction to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(ResourceAction), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putRetry", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.resourceAction.ResourceActionRetry\"}}]")]
    public virtual void PutRetry(IResourceActionRetry value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IResourceActionRetry) }, new object[] { value });
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.resourceAction.ResourceActionTimeouts\"}}]")]
    public virtual void PutTimeouts(IResourceActionTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IResourceActionTimeouts) }, new object[] { value });
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

    [JsiiMethod("resetLocks")]
    public virtual void ResetLocks()
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

    [JsiiMethod("resetWhen")]
    public virtual void ResetWhen()
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