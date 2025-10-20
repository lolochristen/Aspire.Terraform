using System;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiClientConfig;

[JsiiByValue("azapi.dataAzapiClientConfig.DataAzapiClientConfigConfig")]
public class DataAzapiClientConfigConfig : IDataAzapiClientConfigConfig
{
    private object? _connection;

    private object? _count;

    private object[]? _provisioners;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/client_config#timeouts
    ///     DataAzapiClientConfig#timeouts}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiClientConfig.DataAzapiClientConfigTimeouts\"}", true)]
    public IDataAzapiClientConfigTimeouts? Timeouts { get; set; }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("connection", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.SSHProvisionerConnection\"},{\"fqn\":\"cdktf.WinrmProvisionerConnection\"}]}}", true)]
    public object? Connection
    {
        get => _connection;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case ISSHProvisionerConnection cast_cd4240:
                        break;
                    case IWinrmProvisionerConnection cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(ISSHProvisionerConnection).FullName}, {typeof(IWinrmProvisionerConnection).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            _connection = value;
        }
    }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("count", "{\"union\":{\"types\":[{\"primitive\":\"number\"},{\"fqn\":\"cdktf.TerraformCount\"}]}}", true)]
    public object? Count
    {
        get => _count;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case double cast_cd4240:
                        break;
                    case byte cast_cd4240:
                        break;
                    case decimal cast_cd4240:
                        break;
                    case float cast_cd4240:
                        break;
                    case int cast_cd4240:
                        break;
                    case long cast_cd4240:
                        break;
                    case sbyte cast_cd4240:
                        break;
                    case short cast_cd4240:
                        break;
                    case uint cast_cd4240:
                        break;
                    case ulong cast_cd4240:
                        break;
                    case ushort cast_cd4240:
                        break;
                    case TerraformCount cast_cd4240:
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: double, {typeof(TerraformCount).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            _count = value;
        }
    }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("dependsOn", "{\"collection\":{\"elementtype\":{\"fqn\":\"cdktf.ITerraformDependable\"},\"kind\":\"array\"}}", true)]
    public ITerraformDependable[]? DependsOn { get; set; }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("forEach", "{\"fqn\":\"cdktf.ITerraformIterator\"}", true)]
    public ITerraformIterator? ForEach { get; set; }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("lifecycle", "{\"fqn\":\"cdktf.TerraformResourceLifecycle\"}", true)]
    public ITerraformResourceLifecycle? Lifecycle { get; set; }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("provider", "{\"fqn\":\"cdktf.TerraformProvider\"}", true)]
    public TerraformProvider? Provider { get; set; }

    /// <remarks>
    ///     <strong>Stability</strong>: Experimental
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("provisioners",
        "{\"collection\":{\"elementtype\":{\"union\":{\"types\":[{\"fqn\":\"cdktf.FileProvisioner\"},{\"fqn\":\"cdktf.LocalExecProvisioner\"},{\"fqn\":\"cdktf.RemoteExecProvisioner\"}]}},\"kind\":\"array\"}}",
        true)]
    public object[]? Provisioners
    {
        get => _provisioners;
        set
        {
            if (Configuration.RuntimeTypeChecking)
                for (var __idx_cd4240 = 0; __idx_cd4240 < value.Length; __idx_cd4240++)
                    switch (value[__idx_cd4240])
                    {
                        case IFileProvisioner cast_e9c63e:
                            break;
                        case ILocalExecProvisioner cast_e9c63e:
                            break;
                        case IRemoteExecProvisioner cast_e9c63e:
                            break;
                        case AnonymousObject cast_e9c63e:
                            // Not enough information to type-check...
                            break;
                        case null:
                            throw new ArgumentException(
                                $"Expected {nameof(value)}[{__idx_cd4240}] to be one of: {typeof(IFileProvisioner).FullName}, {typeof(ILocalExecProvisioner).FullName}, {typeof(IRemoteExecProvisioner).FullName}; received null",
                                nameof(value));
                        default:
                            throw new ArgumentException(
                                $"Expected {nameof(value)}[{__idx_cd4240}] to be one of: {typeof(IFileProvisioner).FullName}, {typeof(ILocalExecProvisioner).FullName}, {typeof(IRemoteExecProvisioner).FullName}; received {value[__idx_cd4240].GetType().FullName}",
                                nameof(value));
                    }

            _provisioners = value;
        }
    }
}