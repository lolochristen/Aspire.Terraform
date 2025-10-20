using System;
using System.Collections.Generic;
using Amazon.JSII.Runtime;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.ResourceAction;
#pragma warning disable CS8618

[JsiiByValue("azapi.resourceAction.ResourceActionConfig")]
public class ResourceActionConfig : IResourceActionConfig
{
    private object? _connection;

    private object? _count;

    private object[]? _provisioners;

    private object? _queryParameters;

    /// <summary>The ID of an existing Azure source.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#resource_id
    ///     ResourceAction#resource_id}
    /// </remarks>
    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}")]
    public string ResourceId { get; set; }

    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#type ResourceAction#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    public string Type { get; set; }

    /// <summary>The name of the resource action.</summary>
    /// <remarks>
    ///     It's also possible to make HTTP requests towards the resource ID if leave this field empty.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#action
    ///     ResourceAction#action}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("action", "{\"primitive\":\"string\"}", true)]
    public string? Action { get; set; }

    /// <summary>A dynamic attribute that contains the request body.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#body ResourceAction#body}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public IDictionary<string, object>? Body { get; set; }

    /// <summary>A map of headers to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#headers
    ///     ResourceAction#headers}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    public IDictionary<string, string>? Headers { get; set; }

    /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#locks
    ///     ResourceAction#locks}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    public string[]? Locks { get; set; }

    /// <summary>Specifies the HTTP method of the azure resource action.</summary>
    /// <remarks>
    ///     Allowed values are <c>POST</c>, <c>PATCH</c>, <c>PUT</c> and <c>DELETE</c>. Defaults to <c>POST</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#method
    ///     ResourceAction#method}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("method", "{\"primitive\":\"string\"}", true)]
    public string? Method { get; set; }

    /// <summary>A map of query parameters to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#query_parameters
    ///     ResourceAction#query_parameters}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("queryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    public object? QueryParameters
    {
        get => _queryParameters;
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
                        break;
                    default:
                        throw new ArgumentException(
                            $"Expected {nameof(value)} to be one of: {typeof(IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received {value.GetType().FullName}",
                            nameof(value));
                }

            _queryParameters = value;
        }
    }

    /// <summary>The attribute can accept either a list or a map.</summary>
    /// <remarks>
    ///     <list type="bullet">
    ///         <description>
    ///             <strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to
    ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to
    ///             <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following
    ///             HCL object to the computed property output.
    ///             <code><![CDATA[
    /// {
    /// 	properties = {
    /// 		loginServer = "registry1.azurecr.io"
    /// 		policies = {
    /// 			quarantinePolicy = {
    /// 				status = "disabled"
    /// 			}
    /// 		}
    /// 	}
    /// }
    /// ]]></code>
    ///         </description>
    ///         <description>
    ///             <strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query
    ///             string to filter the response. Here's an example. If it sets to
    ///             <c>
    ///                 {"login_server": "properties.loginServer", "quarantine_status":
    ///                 "properties.policies.quarantinePolicy.status"}
    ///             </c>
    ///             , it will set the following HCL object to the
    ///             computed property output.
    ///             <code><![CDATA[
    /// {
    /// 	"login_server" = "registry1.azurecr.io"
    /// 	"quarantine_status" = "disabled"
    /// }
    /// ]]></code>
    ///         </description>
    ///     </list>
    ///     To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#response_export_values
    ///     ResourceAction#response_export_values}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public IDictionary<string, object>? ResponseExportValues { get; set; }

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#retry
    ///     ResourceAction#retry}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("retry", "{\"fqn\":\"azapi.resourceAction.ResourceActionRetry\"}", true)]
    public IResourceActionRetry? Retry { get; set; }

    /// <summary>The attribute can accept either a list or a map.</summary>
    /// <remarks>
    ///     <list type="bullet">
    ///         <description>
    ///             <strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to
    ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to
    ///             <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following
    ///             HCL object to the computed property output.
    ///             <code><![CDATA[
    /// {
    /// 	properties = {
    /// 		loginServer = "registry1.azurecr.io"
    /// 		policies = {
    /// 			quarantinePolicy = {
    /// 				status = "disabled"
    /// 			}
    /// 		}
    /// 	}
    /// }
    /// ]]></code>
    ///         </description>
    ///         <description>
    ///             <strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query
    ///             string to filter the response. Here's an example. If it sets to
    ///             <c>
    ///                 {"login_server": "properties.loginServer", "quarantine_status":
    ///                 "properties.policies.quarantinePolicy.status"}
    ///             </c>
    ///             , it will set the following HCL object to the
    ///             computed property output.
    ///             <code><![CDATA[
    /// {
    /// 	"login_server" = "registry1.azurecr.io"
    /// 	"quarantine_status" = "disabled"
    /// }
    /// ]]></code>
    ///         </description>
    ///     </list>
    ///     To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#sensitive_response_export_values
    ///     ResourceAction#sensitive_response_export_values}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("sensitiveResponseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    public IDictionary<string, object>? SensitiveResponseExportValues { get; set; }

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#timeouts
    ///     ResourceAction#timeouts}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resourceAction.ResourceActionTimeouts\"}", true)]
    public IResourceActionTimeouts? Timeouts { get; set; }

    /// <summary>When to perform the action, value must be one of: `apply`, `destroy`. Default is `apply`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#when ResourceAction#when}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("when", "{\"primitive\":\"string\"}", true)]
    public string? When { get; set; }

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