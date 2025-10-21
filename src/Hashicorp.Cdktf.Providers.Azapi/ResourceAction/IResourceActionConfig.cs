using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.ResourceAction;

[JsiiInterface(typeof(IResourceActionConfig), "azapi.resourceAction.ResourceActionConfig")]
public interface IResourceActionConfig : ITerraformMetaArguments
{
    /// <summary>The ID of an existing Azure source.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#resource_id
    ///     ResourceAction#resource_id}
    /// </remarks>
    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}")]
    string ResourceId { get; }

    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#type ResourceAction#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>The name of the resource action.</summary>
    /// <remarks>
    ///     It's also possible to make HTTP requests towards the resource ID if leave this field empty.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#action
    ///     ResourceAction#action}
    /// </remarks>
    [JsiiProperty("action", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Action => null;

    /// <summary>A dynamic attribute that contains the request body.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#body ResourceAction#body}
    /// </remarks>
    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? Body => null;

    /// <summary>A map of headers to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#headers
    ///     ResourceAction#headers}
    /// </remarks>
    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? Headers => null;

    /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#locks
    ///     ResourceAction#locks}
    /// </remarks>
    [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    [JsiiOptional]
    string[]? Locks => null;

    /// <summary>Specifies the HTTP method of the azure resource action.</summary>
    /// <remarks>
    ///     Allowed values are <c>POST</c>, <c>PATCH</c>, <c>PUT</c> and <c>DELETE</c>. Defaults to <c>POST</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#method
    ///     ResourceAction#method}
    /// </remarks>
    [JsiiProperty("method", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Method => null;

    /// <summary>A map of query parameters to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#query_parameters
    ///     ResourceAction#query_parameters}
    /// </remarks>
    [JsiiProperty("queryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? QueryParameters => null;

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
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ResponseExportValues => null;

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#retry
    ///     ResourceAction#retry}
    /// </remarks>
    [JsiiProperty("retry", "{\"fqn\":\"azapi.resourceAction.ResourceActionRetry\"}", true)]
    [JsiiOptional]
    IResourceActionRetry? Retry => null;

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
    [JsiiProperty("sensitiveResponseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? SensitiveResponseExportValues => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#timeouts
    ///     ResourceAction#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resourceAction.ResourceActionTimeouts\"}", true)]
    [JsiiOptional]
    IResourceActionTimeouts? Timeouts => null;

    /// <summary>When to perform the action, value must be one of: `apply`, `destroy`. Default is `apply`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#when ResourceAction#when}
    /// </remarks>
    [JsiiProperty("when", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? When => null;

    [JsiiTypeProxy(typeof(IResourceActionConfig), "azapi.resourceAction.ResourceActionConfig")]
    internal sealed class _Proxy : DeputyBase, IResourceActionConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>The ID of an existing Azure source.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#resource_id
        ///     ResourceAction#resource_id}
        /// </remarks>
        [JsiiProperty("resourceId", "{\"primitive\":\"string\"}")]
        public string ResourceId => GetInstanceProperty<string>()!;

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#type ResourceAction#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>The name of the resource action.</summary>
        /// <remarks>
        ///     It's also possible to make HTTP requests towards the resource ID if leave this field empty.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#action
        ///     ResourceAction#action}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("action", "{\"primitive\":\"string\"}", true)]
        public string? Action => GetInstanceProperty<string?>();

        /// <summary>A dynamic attribute that contains the request body.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#body ResourceAction#body}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? Body => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>A map of headers to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#headers
        ///     ResourceAction#headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? Headers => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#locks
        ///     ResourceAction#locks}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
        public string[]? Locks => GetInstanceProperty<string[]?>();

        /// <summary>Specifies the HTTP method of the azure resource action.</summary>
        /// <remarks>
        ///     Allowed values are <c>POST</c>, <c>PATCH</c>, <c>PUT</c> and <c>DELETE</c>. Defaults to <c>POST</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#method
        ///     ResourceAction#method}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("method", "{\"primitive\":\"string\"}", true)]
        public string? Method => GetInstanceProperty<string?>();

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
        public object? QueryParameters => GetInstanceProperty<object?>();

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
        public IDictionary<string, object>? ResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#retry
        ///     ResourceAction#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("retry", "{\"fqn\":\"azapi.resourceAction.ResourceActionRetry\"}", true)]
        public IResourceActionRetry? Retry => GetInstanceProperty<IResourceActionRetry?>();

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
        public IDictionary<string, object>? SensitiveResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#timeouts
        ///     ResourceAction#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resourceAction.ResourceActionTimeouts\"}", true)]
        public IResourceActionTimeouts? Timeouts => GetInstanceProperty<IResourceActionTimeouts?>();

        /// <summary>When to perform the action, value must be one of: `apply`, `destroy`. Default is `apply`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#when ResourceAction#when}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("when", "{\"primitive\":\"string\"}", true)]
        public string? When => GetInstanceProperty<string?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("connection", "{\"union\":{\"types\":[{\"fqn\":\"cdktf.SSHProvisionerConnection\"},{\"fqn\":\"cdktf.WinrmProvisionerConnection\"}]}}", true)]
        public object? Connection => GetInstanceProperty<object?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("count", "{\"union\":{\"types\":[{\"primitive\":\"number\"},{\"fqn\":\"cdktf.TerraformCount\"}]}}", true)]
        public object? Count => GetInstanceProperty<object?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("dependsOn", "{\"collection\":{\"elementtype\":{\"fqn\":\"cdktf.ITerraformDependable\"},\"kind\":\"array\"}}", true)]
        public ITerraformDependable[]? DependsOn => GetInstanceProperty<ITerraformDependable[]?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("forEach", "{\"fqn\":\"cdktf.ITerraformIterator\"}", true)]
        public ITerraformIterator? ForEach => GetInstanceProperty<ITerraformIterator?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("lifecycle", "{\"fqn\":\"cdktf.TerraformResourceLifecycle\"}", true)]
        public ITerraformResourceLifecycle? Lifecycle => GetInstanceProperty<ITerraformResourceLifecycle?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("provider", "{\"fqn\":\"cdktf.TerraformProvider\"}", true)]
        public TerraformProvider? Provider => GetInstanceProperty<TerraformProvider?>();

        /// <remarks>
        ///     <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("provisioners",
            "{\"collection\":{\"elementtype\":{\"union\":{\"types\":[{\"fqn\":\"cdktf.FileProvisioner\"},{\"fqn\":\"cdktf.LocalExecProvisioner\"},{\"fqn\":\"cdktf.RemoteExecProvisioner\"}]}},\"kind\":\"array\"}}",
            true)]
        public object[]? Provisioners => GetInstanceProperty<object[]?>();
    }
}