using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Provider;

/// <summary>Represents a {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs azapi}.</summary>
[JsiiClass(typeof(AzapiProvider), "azapi.provider.AzapiProvider",
    "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"remarks\":\"Must be unique amongst siblings in the same scope\",\"summary\":\"The scoped construct ID.\"},\"name\":\"id\",\"type\":{\"primitive\":\"string\"}},{\"name\":\"config\",\"optional\":true,\"type\":{\"fqn\":\"azapi.provider.AzapiProviderConfig\"}}]")]
public class AzapiProvider : TerraformProvider
{
    /// <summary>Create a new {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs azapi} Resource.</summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="id">The scoped construct ID.</param>
    public AzapiProvider(Construct scope, string id, IAzapiProviderConfig? config = null) : base(_MakeDeputyProps(scope, id, config))
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from a Javascript-owned object reference</summary>
    /// <param name="reference">The Javascript-owned object reference</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected AzapiProvider(ByRefValue reference) : base(reference)
    {
    }

    /// <summary>Used by jsii to construct an instance of this class from DeputyProps</summary>
    /// <param name="props">The deputy props</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected AzapiProvider(DeputyProps props) : base(props)
    {
    }

    [JsiiProperty("tfResourceType", "{\"primitive\":\"string\"}")]
    public static string TfResourceType { get; }
        = GetStaticProperty<string>(typeof(AzapiProvider))!;

    [JsiiOptional]
    [JsiiProperty("aliasInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? AliasInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("auxiliaryTenantIdsInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? AuxiliaryTenantIdsInput => GetInstanceProperty<string[]?>();

    [JsiiOptional]
    [JsiiProperty("clientCertificateInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificateInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientCertificatePasswordInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificatePasswordInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientCertificatePathInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificatePathInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientIdFilePathInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientIdFilePathInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientSecretFilePathInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientSecretFilePathInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("clientSecretInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientSecretInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("customCorrelationRequestIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? CustomCorrelationRequestIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("defaultLocationInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? DefaultLocationInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("defaultNameInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? DefaultNameInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("defaultTagsInput", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? DefaultTagsInput => GetInstanceProperty<IDictionary<string, string>?>();

    [JsiiOptional]
    [JsiiProperty("disableCorrelationRequestIdInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableCorrelationRequestIdInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("disableDefaultOutputInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableDefaultOutputInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("disableTerraformPartnerIdInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableTerraformPartnerIdInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("enablePreflightInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? EnablePreflightInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("endpointInput",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}", true)]
    public virtual object? EndpointInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("environmentInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? EnvironmentInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("maximumBusyRetryAttemptsInput", "{\"primitive\":\"number\"}", true)]
    public virtual double? MaximumBusyRetryAttemptsInput => GetInstanceProperty<double?>();

    [JsiiOptional]
    [JsiiProperty("oidcAzureServiceConnectionIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcAzureServiceConnectionIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("oidcRequestTokenInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcRequestTokenInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("oidcRequestUrlInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcRequestUrlInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("oidcTokenFilePathInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcTokenFilePathInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("oidcTokenInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcTokenInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("partnerIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? PartnerIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("skipProviderRegistrationInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? SkipProviderRegistrationInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("subscriptionIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? SubscriptionIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("tenantIdInput", "{\"primitive\":\"string\"}", true)]
    public virtual string? TenantIdInput => GetInstanceProperty<string?>();

    [JsiiOptional]
    [JsiiProperty("useAksWorkloadIdentityInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseAksWorkloadIdentityInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("useCliInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseCliInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("useMsiInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseMsiInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("useOidcInput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseOidcInput => GetInstanceProperty<object?>();

    [JsiiOptional]
    [JsiiProperty("alias", "{\"primitive\":\"string\"}", true)]
    public override string? Alias
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("auxiliaryTenantIds", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public virtual string[]? AuxiliaryTenantIds
    {
        get => GetInstanceProperty<string[]?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientCertificate", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificate
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientCertificatePassword", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificatePassword
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientCertificatePath", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientCertificatePath
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientId", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientIdFilePath", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientIdFilePath
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientSecret", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientSecret
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("clientSecretFilePath", "{\"primitive\":\"string\"}", true)]
    public virtual string? ClientSecretFilePath
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("customCorrelationRequestId", "{\"primitive\":\"string\"}", true)]
    public virtual string? CustomCorrelationRequestId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("defaultLocation", "{\"primitive\":\"string\"}", true)]
    public virtual string? DefaultLocation
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("defaultName", "{\"primitive\":\"string\"}", true)]
    public virtual string? DefaultName
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("defaultTags", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public virtual IDictionary<string, string>? DefaultTags
    {
        get => GetInstanceProperty<IDictionary<string, string>?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("disableCorrelationRequestId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableCorrelationRequestId
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("disableDefaultOutput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableDefaultOutput
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("disableTerraformPartnerId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? DisableTerraformPartnerId
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("enablePreflight", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? EnablePreflight
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("endpoint",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}", true)]
    public virtual object? Endpoint
    {
        get => GetInstanceProperty<object?>();
        set
        {
            if (Configuration.RuntimeTypeChecking)
                switch (value)
                {
                    case IResolvable cast_cd4240:
                        break;
                    case IAzapiProviderEndpoint[] cast_cd4240:
                        break;
                    case AnonymousObject cast_cd4240:
                        // Not enough information to type-check...
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, {typeof(IAzapiProviderEndpoint).FullName}[]; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("environment", "{\"primitive\":\"string\"}", true)]
    public virtual string? Environment
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("maximumBusyRetryAttempts", "{\"primitive\":\"number\"}", true)]
    public virtual double? MaximumBusyRetryAttempts
    {
        get => GetInstanceProperty<double?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("oidcAzureServiceConnectionId", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcAzureServiceConnectionId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("oidcRequestToken", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcRequestToken
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("oidcRequestUrl", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcRequestUrl
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("oidcToken", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcToken
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("oidcTokenFilePath", "{\"primitive\":\"string\"}", true)]
    public virtual string? OidcTokenFilePath
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("partnerId", "{\"primitive\":\"string\"}", true)]
    public virtual string? PartnerId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("skipProviderRegistration", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? SkipProviderRegistration
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("subscriptionId", "{\"primitive\":\"string\"}", true)]
    public virtual string? SubscriptionId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("tenantId", "{\"primitive\":\"string\"}", true)]
    public virtual string? TenantId
    {
        get => GetInstanceProperty<string?>();
        set => SetInstanceProperty(value);
    }

    [JsiiOptional]
    [JsiiProperty("useAksWorkloadIdentity", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseAksWorkloadIdentity
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("useCli", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseCli
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("useMsi", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseMsi
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [JsiiOptional]
    [JsiiProperty("useOidc", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    public virtual object? UseOidc
    {
        get => GetInstanceProperty<object?>();
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
                        break;
                    default:
                        throw new ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(IResolvable).FullName}; received {value.GetType().FullName}",
                            nameof(value));
                }

            SetInstanceProperty(value);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DeputyProps _MakeDeputyProps(Construct scope, string id, IAzapiProviderConfig? config = null)
    {
        return new DeputyProps(new object?[] { scope, id, config });
    }

    /// <summary>Generates CDKTF code for importing a AzapiProvider resource upon running "cdktf plan &lt;stack-name&gt;".</summary>
    /// <param name="scope">The scope in which to define this construct.</param>
    /// <param name="importToId">The construct id used in the generated config for the AzapiProvider to import.</param>
    /// <param name="importFromId">The id of the existing AzapiProvider that should be imported.</param>
    /// <param name="provider">? Optional instance of the provider where the AzapiProvider to import is found.</param>
    [JsiiMethod("generateConfigForImport", "{\"type\":{\"fqn\":\"cdktf.ImportableResource\"}}",
        "[{\"docs\":{\"summary\":\"The scope in which to define this construct.\"},\"name\":\"scope\",\"type\":{\"fqn\":\"constructs.Construct\"}},{\"docs\":{\"summary\":\"The construct id used in the generated config for the AzapiProvider to import.\"},\"name\":\"importToId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"remarks\":\"Refer to the {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#import import section} in the documentation of this resource for the id to use\",\"summary\":\"The id of the existing AzapiProvider that should be imported.\"},\"name\":\"importFromId\",\"type\":{\"primitive\":\"string\"}},{\"docs\":{\"summary\":\"? Optional instance of the provider where the AzapiProvider to import is found.\"},\"name\":\"provider\",\"optional\":true,\"type\":{\"fqn\":\"cdktf.TerraformProvider\"}}]")]
    public static ImportableResource GenerateConfigForImport(Construct scope, string importToId, string importFromId, TerraformProvider? provider = null)
    {
        return InvokeStaticMethod<ImportableResource>(typeof(AzapiProvider), new[] { typeof(Construct), typeof(string), typeof(string), typeof(TerraformProvider) },
            new object?[] { scope, importToId, importFromId, provider })!;
    }

    [JsiiMethod("resetAlias")]
    public virtual void ResetAlias()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetAuxiliaryTenantIds")]
    public virtual void ResetAuxiliaryTenantIds()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientCertificate")]
    public virtual void ResetClientCertificate()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientCertificatePassword")]
    public virtual void ResetClientCertificatePassword()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientCertificatePath")]
    public virtual void ResetClientCertificatePath()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientId")]
    public virtual void ResetClientId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientIdFilePath")]
    public virtual void ResetClientIdFilePath()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientSecret")]
    public virtual void ResetClientSecret()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetClientSecretFilePath")]
    public virtual void ResetClientSecretFilePath()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetCustomCorrelationRequestId")]
    public virtual void ResetCustomCorrelationRequestId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDefaultLocation")]
    public virtual void ResetDefaultLocation()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDefaultName")]
    public virtual void ResetDefaultName()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDefaultTags")]
    public virtual void ResetDefaultTags()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDisableCorrelationRequestId")]
    public virtual void ResetDisableCorrelationRequestId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDisableDefaultOutput")]
    public virtual void ResetDisableDefaultOutput()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetDisableTerraformPartnerId")]
    public virtual void ResetDisableTerraformPartnerId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetEnablePreflight")]
    public virtual void ResetEnablePreflight()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetEndpoint")]
    public virtual void ResetEndpoint()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetEnvironment")]
    public virtual void ResetEnvironment()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetMaximumBusyRetryAttempts")]
    public virtual void ResetMaximumBusyRetryAttempts()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetOidcAzureServiceConnectionId")]
    public virtual void ResetOidcAzureServiceConnectionId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetOidcRequestToken")]
    public virtual void ResetOidcRequestToken()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetOidcRequestUrl")]
    public virtual void ResetOidcRequestUrl()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetOidcToken")]
    public virtual void ResetOidcToken()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetOidcTokenFilePath")]
    public virtual void ResetOidcTokenFilePath()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetPartnerId")]
    public virtual void ResetPartnerId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetSkipProviderRegistration")]
    public virtual void ResetSkipProviderRegistration()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetSubscriptionId")]
    public virtual void ResetSubscriptionId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetTenantId")]
    public virtual void ResetTenantId()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetUseAksWorkloadIdentity")]
    public virtual void ResetUseAksWorkloadIdentity()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetUseCli")]
    public virtual void ResetUseCli()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetUseMsi")]
    public virtual void ResetUseMsi()
    {
        InvokeInstanceVoidMethod(new Type[] { }, new object[] { });
    }

    [JsiiMethod("resetUseOidc")]
    public virtual void ResetUseOidc()
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