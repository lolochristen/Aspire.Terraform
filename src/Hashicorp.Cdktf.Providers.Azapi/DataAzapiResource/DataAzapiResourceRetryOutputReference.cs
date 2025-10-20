using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResource;

[JsiiClass(typeof(DataAzapiResourceRetryOutputReference), "azapi.dataAzapiResource.DataAzapiResourceRetryOutputReference",
    "[{\"docs\":{\"summary\":\"The parent resource.\"},\"name\":\"terraformResource\",\"type\":{\"fqn\":\"cdktf.IInterpolatingParent\"}},{\"docs\":{\"summary\":\"The attribute on the parent resource this class is referencing.\"},\"name\":\"terraformAttribute\",\"type\":{\"primitive\":\"string\"}}]")]
public class DataAzapiResourceRetryOutputReference : ComplexObject
{
    /// <param name="terraformResource">The parent resource.</param>
    /// <param name="terraformAttribute">The attribute on the parent resource this class is referencing.</param>
    public DataAzapiResourceRetryOutputReference(IInterpolatingParent terraformResource, string terraformAttribute) : base(_MakeDeputyProps(terraformResource, terraformAttribute))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceRetryOutputReference(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected DataAzapiResourceRetryOutputReference(DeputyProps props) : base(props)
    {
    }

    [JsiiOptional]
    [JsiiProperty("errorMessageRegexInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? ErrorMessageRegexInput => GetInstanceProperty<string[]?>();

    [JsiiOptional]
    [JsiiProperty("intervalSecondsInput", "{\"primitive\":\"number\"}", true)]
    public virtual double? IntervalSecondsInput => GetInstanceProperty<double?>();

    [JsiiOptional]
    [JsiiProperty("maxIntervalSecondsInput", "{\"primitive\":\"number\"}", true)]
    public virtual double? MaxIntervalSecondsInput => GetInstanceProperty<double?>();

    [JsiiOptional]
    [JsiiProperty("multiplierInput", "{\"primitive\":\"number\"}", true)]
    public virtual double? MultiplierInput => GetInstanceProperty<double?>();

    [JsiiOptional]
    [JsiiProperty("randomizationFactorInput", "{\"primitive\":\"number\"}", true)]
    public virtual double? RandomizationFactorInput => GetInstanceProperty<double?>();

    [JsiiProperty("errorMessageRegex", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public virtual string[] ErrorMessageRegex
    {
        get => GetInstanceProperty<string[]>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("intervalSeconds", "{\"primitive\":\"number\"}")]
    public virtual double IntervalSeconds
    {
        get => GetInstanceProperty<double>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("maxIntervalSeconds", "{\"primitive\":\"number\"}")]
    public virtual double MaxIntervalSeconds
    {
        get => GetInstanceProperty<double>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("multiplier", "{\"primitive\":\"number\"}")]
    public virtual double Multiplier
    {
        get => GetInstanceProperty<double>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiProperty("randomizationFactor", "{\"primitive\":\"number\"}")]
    public virtual double RandomizationFactor
    {
        get => GetInstanceProperty<double>()!;
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("internalValue", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceRetry\"}]}}", true)]
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
                    case IDataAzapiResourceRetry cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, {typeof(IDataAzapiResourceRetry).FullName}; received {value.GetType().FullName}",
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

    [JsiiMethod("resetIntervalSeconds")]
    public virtual void ResetIntervalSeconds()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetMaxIntervalSeconds")]
    public virtual void ResetMaxIntervalSeconds()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetMultiplier")]
    public virtual void ResetMultiplier()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetRandomizationFactor")]
    public virtual void ResetRandomizationFactor()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }
}