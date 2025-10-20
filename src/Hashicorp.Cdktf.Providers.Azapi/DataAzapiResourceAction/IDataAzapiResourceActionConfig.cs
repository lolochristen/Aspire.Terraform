using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceAction;

[JsiiInterface(typeof(IDataAzapiResourceActionConfig), "azapi.dataAzapiResourceAction.DataAzapiResourceActionConfig")]
public interface IDataAzapiResourceActionConfig : ITerraformMetaArguments
{
    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#type
    ///     DataAzapiResourceAction#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>The name of the resource action.</summary>
    /// <remarks>
    ///     It's also possible to make HTTP requests towards the resource ID if leave this field empty.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#action
    ///     DataAzapiResourceAction#action}
    /// </remarks>
    [JsiiProperty("action", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Action => null;

    /// <summary>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#body
    ///     DataAzapiResourceAction#body}.
    /// </summary>
    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? Body => null;

    /// <summary>A map of headers to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#headers
    ///     DataAzapiResourceAction#headers}
    /// </remarks>
    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? Headers => null;

    /// <summary>The HTTP method to use when performing the action. Must be one of `POST`, `GET`. Defaults to `POST`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#method
    ///     DataAzapiResourceAction#method}
    /// </remarks>
    [JsiiProperty("method", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Method => null;

    /// <summary>A map of query parameters to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#query_parameters
    ///     DataAzapiResourceAction#query_parameters}
    /// </remarks>
    [JsiiProperty("queryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? QueryParameters => null;

    /// <summary>The ID of the Azure resource to perform the action on.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#resource_id
    ///     DataAzapiResourceAction#resource_id}
    /// </remarks>
    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ResourceId => null;

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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#response_export_values
    ///     DataAzapiResourceAction#response_export_values}
    /// </remarks>
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ResponseExportValues => null;

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#retry
    ///     DataAzapiResourceAction#retry}
    /// </remarks>
    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceActionRetry? Retry => null;

    /// <summary>The attribute can accept either a list or a map.</summary>
    /// <remarks>
    ///     <list type="bullet">
    ///         <description>
    ///             <strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to
    ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to
    ///             <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following
    ///             HCL object to the computed property sensitive_output.
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
    ///             computed property sensitive_output.
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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#sensitive_response_export_values
    ///     DataAzapiResourceAction#sensitive_response_export_values}
    /// </remarks>
    [JsiiProperty("sensitiveResponseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? SensitiveResponseExportValues => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#timeouts
    ///     DataAzapiResourceAction#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceActionTimeouts? Timeouts => null;

    [JsiiTypeProxy(typeof(IDataAzapiResourceActionConfig), "azapi.dataAzapiResourceAction.DataAzapiResourceActionConfig")]
    internal sealed class _Proxy : DeputyBase, IDataAzapiResourceActionConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#type
        ///     DataAzapiResourceAction#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>The name of the resource action.</summary>
        /// <remarks>
        ///     It's also possible to make HTTP requests towards the resource ID if leave this field empty.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#action
        ///     DataAzapiResourceAction#action}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("action", "{\"primitive\":\"string\"}", true)]
        public string? Action => GetInstanceProperty<string?>();

        /// <summary>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#body
        ///     DataAzapiResourceAction#body}.
        /// </summary>
        [JsiiOptional]
        [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? Body => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>A map of headers to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#headers
        ///     DataAzapiResourceAction#headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? Headers => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>The HTTP method to use when performing the action. Must be one of `POST`, `GET`. Defaults to `POST`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#method
        ///     DataAzapiResourceAction#method}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("method", "{\"primitive\":\"string\"}", true)]
        public string? Method => GetInstanceProperty<string?>();

        /// <summary>A map of query parameters to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#query_parameters
        ///     DataAzapiResourceAction#query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("queryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? QueryParameters => GetInstanceProperty<object?>();

        /// <summary>The ID of the Azure resource to perform the action on.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#resource_id
        ///     DataAzapiResourceAction#resource_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("resourceId", "{\"primitive\":\"string\"}", true)]
        public string? ResourceId => GetInstanceProperty<string?>();

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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#response_export_values
        ///     DataAzapiResourceAction#response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? ResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#retry
        ///     DataAzapiResourceAction#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}", true)]
        public IDataAzapiResourceActionRetry? Retry => GetInstanceProperty<IDataAzapiResourceActionRetry?>();

        /// <summary>The attribute can accept either a list or a map.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <description>
        ///             <strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to
        ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to
        ///             <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following
        ///             HCL object to the computed property sensitive_output.
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
        ///             computed property sensitive_output.
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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#sensitive_response_export_values
        ///     DataAzapiResourceAction#sensitive_response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("sensitiveResponseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? SensitiveResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#timeouts
        ///     DataAzapiResourceAction#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}", true)]
        public IDataAzapiResourceActionTimeouts? Timeouts => GetInstanceProperty<IDataAzapiResourceActionTimeouts?>();

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