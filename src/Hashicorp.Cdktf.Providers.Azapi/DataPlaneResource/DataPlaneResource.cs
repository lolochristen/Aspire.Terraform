using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataPlaneResource;

/// <summary>
///     Represents a {@link
///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource
///     azapi_data_plane_resource}.
/// </summary>
[JsiiClass(typeof(DataPlaneResource), "azapi.dataPlaneResource.DataPlaneResource",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"type\":{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceConfig\"}}]")]
public class DataPlaneResource : TerraformResource
{
    /// <summary>
    ///     Create a new {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource
    ///     azapi_data_plane_resource} Resource.
    /// </summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public DataPlaneResource(Construct scope, string id, IDataPlaneResourceConfig config) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataPlaneResource(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataPlaneResource(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(DataPlaneResource))!;

    [JsiiProperty("id", "{\"primitive\":\"string\"}")]
    public virtual string Id => GetInstanceProperty<string>()!;

    [JsiiProperty("output", "{\"fqn\":\"cdktf.AnyMap\"}")]
    public virtual AnyMap Output => GetInstanceProperty<AnyMap>()!;

    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceRetryOutputReference\"}")]
    public virtual DataPlaneResourceRetryOutputReference Retry => GetInstanceProperty<DataPlaneResourceRetryOutputReference>()!;

    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceTimeoutsOutputReference\"}")]
    public virtual DataPlaneResourceTimeoutsOutputReference Timeouts => GetInstanceProperty<DataPlaneResourceTimeoutsOutputReference>()!;

    [JsiiOptional]
    [JsiiProperty("bodyInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? BodyInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("createHeadersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? CreateHeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("createQueryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? CreateQueryParametersInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("deleteHeadersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? DeleteHeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("deleteQueryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? DeleteQueryParametersInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("ignoreCasingInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? IgnoreCasingInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("ignoreMissingPropertyInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? IgnoreMissingPropertyInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("locksInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? LocksInput => GetInstanceProperty<string[]?>();

    [JsiiOptional]
    [JsiiProperty("nameInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? NameInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("parentIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ParentIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("readHeadersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? ReadHeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("readQueryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? ReadQueryParametersInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("replaceTriggersExternalValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? ReplaceTriggersExternalValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("replaceTriggersRefsInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? ReplaceTriggersRefsInput => GetInstanceProperty<string[]?>();

    [JsiiOptional]
    [JsiiProperty("responseExportValuesInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, object>? ResponseExportValuesInput => GetInstanceProperty<IDictionary<string, object>?>();

    [JsiiOptional]
    [JsiiProperty("retryInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceRetry\"}]}}", true)]
    public virtual object? RetryInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("timeoutsInput", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceTimeouts\"}]}}", true)]
    public virtual object? TimeoutsInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("typeInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TypeInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("updateHeadersInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? UpdateHeadersInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("updateQueryParametersInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public virtual object? UpdateQueryParametersInput => GetInstanceProperty<object?>();

    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> Body
    {
        get => GetInstanceProperty<IDictionary<string, object>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("createHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> CreateHeaders
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("createQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}")]
    public virtual object CreateQueryParameters
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

    [JsiiProperty("deleteHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> DeleteHeaders
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("deleteQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}")]
    public virtual object DeleteQueryParameters
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

    [JsiiProperty("ignoreCasing", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}")]
    public virtual object IgnoreCasing
    {
        get => GetInstanceProperty<object>()!;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case bool cast_cd4240:
                        break;
                    case IResolvable cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received null", nameof(value));
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiProperty("ignoreMissingProperty", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}")]
    public virtual object IgnoreMissingProperty
    {
        get => GetInstanceProperty<object>()!;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case bool cast_cd4240:
                        break;
                    case IResolvable cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received null", nameof(value));
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public virtual string[] Locks
    {
        get => GetInstanceProperty<string[]>()!;
        set => SetInstanceProperty(value);
    }

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

    [JsiiProperty("readHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> ReadHeaders
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("readQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}")]
    public virtual object ReadQueryParameters
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

    [JsiiProperty("replaceTriggersExternalValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, object> ReplaceTriggersExternalValues
    {
        get => GetInstanceProperty<IDictionary<string, object>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("replaceTriggersRefs", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public virtual string[] ReplaceTriggersRefs
    {
        get => GetInstanceProperty<string[]>()!;
        set => SetInstanceProperty(value);
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

    [JsiiProperty("updateHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}")]
    public virtual IDictionary<string, string> UpdateHeaders
    {
        get => GetInstanceProperty<IDictionary<string, string>>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("updateQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}")]
    public virtual object UpdateQueryParameters
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IDataPlaneResourceConfig config)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>Generates CDKTF code for importing a DataPlaneResource resource upon running "cdktf plan &lt;stack-name&gt;".</summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the DataPlaneResource to import.</param>
    /// <param name="importFromId">The id of the existing DataPlaneResource that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the DataPlaneResource to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the DataPlaneResource to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing DataPlaneResource that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the DataPlaneResource to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(DataPlaneResource), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("putRetry", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceRetry\"}}]")]
    public virtual void PutRetry(IDataPlaneResourceRetry value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataPlaneResourceRetry) }, new object[] { value });
    }

    [JsiiMethod("putTimeouts", parametersJson: "[{\"name\":\"value\",\"type\":{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceTimeouts\"}}]")]
    public virtual void PutTimeouts(IDataPlaneResourceTimeouts value)
    {
        InvokeInstanceVoidMethod(new[] { typeof(IDataPlaneResourceTimeouts) }, new object[] { value });
    }

    [JsiiMethod("resetBody")]
    public virtual void ResetBody()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetCreateHeaders")]
    public virtual void ResetCreateHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetCreateQueryParameters")]
    public virtual void ResetCreateQueryParameters()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDeleteHeaders")]
    public virtual void ResetDeleteHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDeleteQueryParameters")]
    public virtual void ResetDeleteQueryParameters()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetIgnoreCasing")]
    public virtual void ResetIgnoreCasing()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetIgnoreMissingProperty")]
    public virtual void ResetIgnoreMissingProperty()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetLocks")]
    public virtual void ResetLocks()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetReadHeaders")]
    public virtual void ResetReadHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetReadQueryParameters")]
    public virtual void ResetReadQueryParameters()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetReplaceTriggersExternalValues")]
    public virtual void ResetReplaceTriggersExternalValues()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetReplaceTriggersRefs")]
    public virtual void ResetReplaceTriggersRefs()
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

    [JsiiMethod("resetUpdateHeaders")]
    public virtual void ResetUpdateHeaders()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetUpdateQueryParameters")]
    public virtual void ResetUpdateQueryParameters()
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