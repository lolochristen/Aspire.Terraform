using System;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceId;
#pragma warning disable CS8618

[JsiiByValue("azapi.dataAzapiResourceId.DataAzapiResourceIdConfig")]
public class DataAzapiResourceIdConfig : IDataAzapiResourceIdConfig
{
    private object? _connection;

    private object? _count;

    private object[]? _provisioners;

    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#type
    ///     DataAzapiResourceId#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    public string Type { get; set; }

    /// <summary>The name of the Azure resource.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#name
    ///     DataAzapiResourceId#name}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("name", "{\"primitive\":\"string\"}", true)]
    public string? Name { get; set; }

    /// <summary>The ID of the azure resource in which this resource is created.</summary>
    /// <remarks>
    ///     It supports different kinds of deployment scope for <strong>top level</strong> resources:
    ///     <list type="bullet">
    ///         <description>
    ///             resource group scope: <c>parent_id</c> should be the ID of a resource group, it's recommended to manage a
    ///             resource group by azurerm_resource_group.
    ///             <list type="bullet">
    ///                 <description>
    ///                     management group scope: <c>parent_id</c> should be the ID of a management group, it's
    ///                     recommended to manage a management group by azurerm_management_group.
    ///                 </description>
    ///                 <description>
    ///                     extension scope: <c>parent_id</c> should be the ID of the resource you're adding the
    ///                     extension to.
    ///                 </description>
    ///                 <description>
    ///                     subscription scope: <c>parent_id</c> should be like
    ///                     \x60/subscriptions/00000000-0000-0000-0000-000000000000\x60
    ///                 </description>
    ///                 <description>tenant scope: <c>parent_id</c> should be /</description>
    ///             </list>
    ///         </description>
    ///     </list>
    ///     For child level resources, the <c>parent_id</c> should be the ID of its parent resource, for example, subnet
    ///     resource's <c>parent_id</c> is the ID of the vnet.
    ///     For type <c>Microsoft.Resources/resourceGroups</c>, the <c>parent_id</c> could be omitted, it defaults to
    ///     subscription ID specified in provider or the default subscription (You could check the default subscription by
    ///     azure cli command: <c>az account show</c>).
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#parent_id
    ///     DataAzapiResourceId#parent_id}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
    public string? ParentId { get; set; }

    /// <summary>The ID of an existing Azure source.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#resource_id
    ///     DataAzapiResourceId#resource_id}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}", true)]
    public string? ResourceId { get; set; }

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#timeouts
    ///     DataAzapiResourceId#timeouts}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeouts\"}", true)]
    public IDataAzapiResourceIdTimeouts? Timeouts { get; set; }

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