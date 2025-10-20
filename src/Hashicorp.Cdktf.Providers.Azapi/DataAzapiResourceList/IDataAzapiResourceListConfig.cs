using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceList;

[JsiiInterface(typeof(IDataAzapiResourceListConfig), "azapi.dataAzapiResourceList.DataAzapiResourceListConfig")]
public interface IDataAzapiResourceListConfig : ITerraformMetaArguments
{
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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#parent_id
    ///     DataAzapiResourceList#parent_id}
    /// </remarks>
    [JsiiProperty("parentId", "{\"primitive\":\"string\"}")]
    string ParentId { get; }

    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#type
    ///     DataAzapiResourceList#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>A map of headers to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#headers
    ///     DataAzapiResourceList#headers}
    /// </remarks>
    [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? Headers => null;

    /// <summary>A map of query parameters to include in the request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#query_parameters
    ///     DataAzapiResourceList#query_parameters}
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
    ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["value"]</c>, it will
    ///             set the following HCL object to the computed property output.
    ///             <code><![CDATA[
    /// {
    ///   "value" = [
    /// 	{
    /// 	  "id" = "/subscriptions/000000/resourceGroups/demo-rg/providers/Microsoft.Automation/automationAccounts/example"
    /// 	  "location" = "eastus2"
    /// 	  "name" = "example"
    /// 	  "properties" = {
    /// 		"creationTime" = "2024-10-11T08:18:38.737+00:00"
    /// 		"disableLocalAuth" = false
    /// 		"lastModifiedTime" = "2024-10-11T08:18:38.737+00:00"
    /// 		"publicNetworkAccess" = true
    /// 	  }
    /// 	  "tags" = {}
    /// 	  "type" = "Microsoft.Automation/AutomationAccounts"
    /// 	}
    ///   ]
    /// }
    /// ]]></code>
    ///         </description>
    ///         <description>
    ///             <strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query
    ///             string to filter the response. Here's an example. If it sets to
    ///             <c>
    ///                 {"values": "value[].{name: name, publicNetworkAccess: properties.publicNetworkAccess}", "names":
    ///                 "value[].name"}
    ///             </c>
    ///             , it will set the following HCL object to the computed property output.
    ///             <code><![CDATA[
    /// {
    /// 	"names" = [
    /// 		"example",
    /// 		"fredaccount01",
    /// 	]
    /// 	"values" = [
    /// 		{
    /// 		  "name" = "example"
    /// 		  "publicNetworkAccess" = true
    /// 		},
    /// 		{
    /// 		  "name" = "fredaccount01"
    /// 		  "publicNetworkAccess" = null
    /// 		},
    /// 	]
    /// }
    /// ]]></code>
    ///         </description>
    ///     </list>
    ///     To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#response_export_values
    ///     DataAzapiResourceList#response_export_values}
    /// </remarks>
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ResponseExportValues => null;

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#retry
    ///     DataAzapiResourceList#retry}
    /// </remarks>
    [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListRetry\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceListRetry? Retry => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#timeouts
    ///     DataAzapiResourceList#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListTimeouts\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceListTimeouts? Timeouts => null;

    [JsiiTypeProxy(typeof(IDataAzapiResourceListConfig), "azapi.dataAzapiResourceList.DataAzapiResourceListConfig")]
    internal sealed class _Proxy : DeputyBase, IDataAzapiResourceListConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#parent_id
        ///     DataAzapiResourceList#parent_id}
        /// </remarks>
        [JsiiProperty("parentId", "{\"primitive\":\"string\"}")]
        public string ParentId => GetInstanceProperty<string>()!;

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#type
        ///     DataAzapiResourceList#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>A map of headers to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#headers
        ///     DataAzapiResourceList#headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("headers", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? Headers => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A map of query parameters to include in the request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#query_parameters
        ///     DataAzapiResourceList#query_parameters}
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
        ///             <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["value"]</c>, it will
        ///             set the following HCL object to the computed property output.
        ///             <code><![CDATA[
        /// {
        ///   "value" = [
        /// 	{
        /// 	  "id" = "/subscriptions/000000/resourceGroups/demo-rg/providers/Microsoft.Automation/automationAccounts/example"
        /// 	  "location" = "eastus2"
        /// 	  "name" = "example"
        /// 	  "properties" = {
        /// 		"creationTime" = "2024-10-11T08:18:38.737+00:00"
        /// 		"disableLocalAuth" = false
        /// 		"lastModifiedTime" = "2024-10-11T08:18:38.737+00:00"
        /// 		"publicNetworkAccess" = true
        /// 	  }
        /// 	  "tags" = {}
        /// 	  "type" = "Microsoft.Automation/AutomationAccounts"
        /// 	}
        ///   ]
        /// }
        /// ]]></code>
        ///         </description>
        ///         <description>
        ///             <strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query
        ///             string to filter the response. Here's an example. If it sets to
        ///             <c>
        ///                 {"values": "value[].{name: name, publicNetworkAccess: properties.publicNetworkAccess}", "names":
        ///                 "value[].name"}
        ///             </c>
        ///             , it will set the following HCL object to the computed property output.
        ///             <code><![CDATA[
        /// {
        /// 	"names" = [
        /// 		"example",
        /// 		"fredaccount01",
        /// 	]
        /// 	"values" = [
        /// 		{
        /// 		  "name" = "example"
        /// 		  "publicNetworkAccess" = true
        /// 		},
        /// 		{
        /// 		  "name" = "fredaccount01"
        /// 		  "publicNetworkAccess" = null
        /// 		},
        /// 	]
        /// }
        /// ]]></code>
        ///         </description>
        ///     </list>
        ///     To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#response_export_values
        ///     DataAzapiResourceList#response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? ResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#retry
        ///     DataAzapiResourceList#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("retry", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListRetry\"}", true)]
        public IDataAzapiResourceListRetry? Retry => GetInstanceProperty<IDataAzapiResourceListRetry?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_list#timeouts
        ///     DataAzapiResourceList#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceList.DataAzapiResourceListTimeouts\"}", true)]
        public IDataAzapiResourceListTimeouts? Timeouts => GetInstanceProperty<IDataAzapiResourceListTimeouts?>();

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