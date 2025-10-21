using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResource;

[JsiiInterface(typeof(IDataAzapiResourceConfig), "azapi.dataAzapiResource.DataAzapiResourceConfig")]
public interface IDataAzapiResourceConfig : ITerraformMetaArguments
{
    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#type DataAzapiResource#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>A map of headers to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#headers
    ///     DataAzapiResource#headers}
    /// </remarks>
    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? Headers => null;

    /// <summary>Specifies the name of the Azure resource.</summary>
    /// <remarks>
    ///     Exactly one of the arguments <c>name</c> or <c>resource_id</c> must be set. It could be omitted if the <c>type</c>
    ///     is <c>Microsoft.Resources/subscriptions</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#name DataAzapiResource#name}
    /// </remarks>
    [JsiiProperty("name", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Name => null;

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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#parent_id
    ///     DataAzapiResource#parent_id}
    /// </remarks>
    [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ParentId => null;

    /// <summary>A map of query parameters to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#query_parameters
    ///     DataAzapiResource#query_parameters}
    /// </remarks>
    [JsiiProperty("queryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? QueryParameters => null;

    /// <summary>The ID of the Azure resource to retrieve.</summary>
    /// <remarks>
    ///     Exactly one of the arguments <c>name</c> or <c>resource_id</c> must be set. It could be omitted if the <c>type</c>
    ///     is <c>Microsoft.Resources/subscriptions</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#resource_id
    ///     DataAzapiResource#resource_id}
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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#response_export_values
    ///     DataAzapiResource#response_export_values}
    /// </remarks>
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ResponseExportValues => null;

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#retry DataAzapiResource#retry}
    /// </remarks>
    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceRetry\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceRetry? Retry => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#timeouts
    ///     DataAzapiResource#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceTimeouts\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceTimeouts? Timeouts => null;

    [JsiiTypeProxy(typeof(IDataAzapiResourceConfig), "azapi.dataAzapiResource.DataAzapiResourceConfig")]
    internal sealed class _Proxy : DeputyBase, IDataAzapiResourceConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#type DataAzapiResource#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>A map of headers to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#headers
        ///     DataAzapiResource#headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? Headers => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>Specifies the name of the Azure resource.</summary>
        /// <remarks>
        ///     Exactly one of the arguments <c>name</c> or <c>resource_id</c> must be set. It could be omitted if the <c>type</c>
        ///     is <c>Microsoft.Resources/subscriptions</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#name DataAzapiResource#name}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("name", "{\"primitive\":\"string\"}", true)]
        public string? Name => GetInstanceProperty<string?>();

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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#parent_id
        ///     DataAzapiResource#parent_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
        public string? ParentId => GetInstanceProperty<string?>();

        /// <summary>A map of query parameters to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#query_parameters
        ///     DataAzapiResource#query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("queryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? QueryParameters => GetInstanceProperty<object?>();

        /// <summary>The ID of the Azure resource to retrieve.</summary>
        /// <remarks>
        ///     Exactly one of the arguments <c>name</c> or <c>resource_id</c> must be set. It could be omitted if the <c>type</c>
        ///     is <c>Microsoft.Resources/subscriptions</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#resource_id
        ///     DataAzapiResource#resource_id}
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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#response_export_values
        ///     DataAzapiResource#response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? ResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#retry DataAzapiResource#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceRetry\"}", true)]
        public IDataAzapiResourceRetry? Retry => GetInstanceProperty<IDataAzapiResourceRetry?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource#timeouts
        ///     DataAzapiResource#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResource.DataAzapiResourceTimeouts\"}", true)]
        public IDataAzapiResourceTimeouts? Timeouts => GetInstanceProperty<IDataAzapiResourceTimeouts?>();

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