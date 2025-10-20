using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceAction;

[JsiiClass(typeof(DataAzapiResourceActionTimeoutsOutputReference), "azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeoutsOutputReference",
    "[{\"docs\":{\"summary\":\"The parent resource.\"},\"name\":\"terraformResource\",\"type\":{\"fqn\":\"cdktf.IInterpolatingParent\"}},{\"docs\":{\"summary\":\"The attribute on the parent resource this class is referencing.\"},\"name\":\"terraformAttribute\",\"type\":{\"primitive\":\"string\"}}]")]
public class DataAzapiResourceActionTimeoutsOutputReference : ComplexObject
{
    /// <param name="terraformResource">The parent resource.</param>
    /// <param name="terraformAttribute">The attribute on the parent resource this class is referencing.</param>
    public DataAzapiResourceActionTimeoutsOutputReference(IInterpolatingParent terraformResource, string terraformAttribute) : base(_MakeDeputyProps(terraformResource,
        terraformAttribute))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceActionTimeoutsOutputReference(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceActionTimeoutsOutputReference(DeputyProps props) : base(props)
    {
    }

    [JsiiOptional]
    [JsiiProperty("readInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ReadInput => GetInstanceProperty<string?>();

    [JsiiProperty("read", "{\"primitive\":\"string\"}")]
    public virtual string Read
    {
        get => GetInstanceProperty<string>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("internalValue", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}]}}", true)]
    public virtual object? InternalValue
    {
        get => GetInstanceProperty<object?>();
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case IResolvable cast_cd4240:
                        break;
                    case IDataAzapiResourceActionTimeouts cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, {typeof(IDataAzapiResourceActionTimeouts).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(IInterpolatingParent terraformResource, string terraformAttribute)
    {
        return new DeputyProps(new object?[] { terraformResource, terraformAttribute });
    }

    [JsiiMethod("resetRead")]
    public virtual void ResetRead()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }
}