using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Resource;

[JsiiInterface(typeof(IResourceConfig), "azapi.resource.ResourceConfig")]
public interface IResourceConfig : ITerraformMetaArguments
{
    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#type Resource#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>A dynamic attribute that contains the request body.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#body Resource#body}
    /// </remarks>
    [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? Body => null;

    /// <summary>A mapping of headers to be sent with the create request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#create_headers
    ///     Resource#create_headers}
    /// </remarks>
    [JsiiProperty("createHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? CreateHeaders => null;

    /// <summary>A mapping of query parameters to be sent with the create request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#create_query_parameters
    ///     Resource#create_query_parameters}
    /// </remarks>
    [JsiiProperty("createQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? CreateQueryParameters => null;

    /// <summary>A mapping of headers to be sent with the delete request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#delete_headers
    ///     Resource#delete_headers}
    /// </remarks>
    [JsiiProperty("deleteHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? DeleteHeaders => null;

    /// <summary>A mapping of query parameters to be sent with the delete request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#delete_query_parameters
    ///     Resource#delete_query_parameters}
    /// </remarks>
    [JsiiProperty("deleteQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? DeleteQueryParameters => null;

    /// <summary>identity block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#identity Resource#identity}
    /// </remarks>
    [JsiiProperty("identity",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.resource.ResourceIdentity\"},\"kind\":\"array\"}}]}}", true)]
    [JsiiOptional]
    object? Identity => null;

    /// <summary>Whether ignore the casing of the property names in the response body. Defaults to `false`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#ignore_casing
    ///     Resource#ignore_casing}
    /// </remarks>
    [JsiiProperty("ignoreCasing", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? IgnoreCasing => null;

    /// <summary>Whether ignore not returned properties like credentials in `body` to suppress plan-diff.</summary>
    /// <remarks>
    ///     Defaults to <c>true</c>. It's recommend to enable this option when some sensitive properties are not returned in
    ///     response body, instead of setting them in <c>lifecycle.ignore_changes</c> because it will make the sensitive fields
    ///     unable to update.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#ignore_missing_property
    ///     Resource#ignore_missing_property}
    /// </remarks>
    [JsiiProperty("ignoreMissingProperty", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? IgnoreMissingProperty => null;

    /// <summary>The location of the Azure resource.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#location Resource#location}
    /// </remarks>
    [JsiiProperty("location", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Location => null;

    /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#locks Resource#locks}
    /// </remarks>
    [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    [JsiiOptional]
    string[]? Locks => null;

    /// <summary>Specifies the name of the azure resource. Changing this forces a new resource to be created.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#name Resource#name}
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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#parent_id Resource#parent_id}
    /// </remarks>
    [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ParentId => null;

    /// <summary>A mapping of headers to be sent with the read request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#read_headers
    ///     Resource#read_headers}
    /// </remarks>
    [JsiiProperty("readHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? ReadHeaders => null;

    /// <summary>A mapping of query parameters to be sent with the read request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#read_query_parameters
    ///     Resource#read_query_parameters}
    /// </remarks>
    [JsiiProperty("readQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? ReadQueryParameters => null;

    /// <summary>Will trigger a replace of the resource when the value changes and is not `null`.</summary>
    /// <remarks>
    ///     This can be used by practitioners to force a replace of the resource when certain values change, e.g. changing the
    ///     SKU of a virtual machine based on the value of variables or locals. The value is a <c>dynamic</c>, so practitioners
    ///     can compose the input however they wish. For a "break glass" set the value to <c>null</c> to prevent the plan
    ///     modifier taking effect.
    ///     If you have <c>null</c> values that you do want to be tracked as affecting the resource replacement, include these
    ///     inside an object.
    ///     Advanced use cases are possible and resource replacement can be triggered by values external to the resource, for
    ///     example when a dependent resource changes.
    ///     e.g. to replace a resource when either the SKU or os_type attributes change:
    ///     <code><![CDATA[
    /// resource "azapi_resource" "example" {
    ///   name      = var.name
    ///   type      = "Microsoft.Network/publicIPAddresses@2023-11-01"
    ///   parent_id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example"
    ///   body = {
    ///     properties = {
    ///       sku   = var.sku
    ///       zones = var.zones
    ///     }
    ///   }
    /// 
    ///   replace_triggers_external_values = [
    ///     var.sku,
    ///     var.zones,
    ///   ]
    /// }
    /// ]]></code>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#replace_triggers_external_values
    ///     Resource#replace_triggers_external_values}
    /// </remarks>
    [JsiiProperty("replaceTriggersExternalValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ReplaceTriggersExternalValues => null;

    /// <summary>A list of paths in the current Terraform configuration.</summary>
    /// <remarks>
    ///     When the values at these paths change, the resource will be replaced.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#replace_triggers_refs
    ///     Resource#replace_triggers_refs}
    /// </remarks>
    [JsiiProperty("replaceTriggersRefs", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    [JsiiOptional]
    string[]? ReplaceTriggersRefs => null;

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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#response_export_values
    ///     Resource#response_export_values}
    /// </remarks>
    [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? ResponseExportValues => null;

    /// <summary>The retry object supports the following attributes:.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#retry Resource#retry}
    /// </remarks>
    [JsiiProperty("retry", "{\"fqn\":\"azapi.resource.ResourceRetry\"}", true)]
    [JsiiOptional]
    IResourceRetry? Retry => null;

    /// <summary>Whether enabled the validation on `type` and `body` with embedded schema. Defaults to `true`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#schema_validation_enabled
    ///     Resource#schema_validation_enabled}
    /// </remarks>
    [JsiiProperty("schemaValidationEnabled", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? SchemaValidationEnabled => null;

    /// <summary>A dynamic attribute that contains the write-only properties of the request body.</summary>
    /// <remarks>
    ///     This will be merge-patched to the body to construct the actual request body.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#sensitive_body
    ///     Resource#sensitive_body}
    /// </remarks>
    [JsiiProperty("sensitiveBody", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, object>? SensitiveBody => null;

    /// <summary>A mapping of tags which should be assigned to the Azure resource.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#tags Resource#tags}
    /// </remarks>
    [JsiiProperty("tags", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? Tags => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#timeouts Resource#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resource.ResourceTimeouts\"}", true)]
    [JsiiOptional]
    IResourceTimeouts? Timeouts => null;

    /// <summary>A mapping of headers to be sent with the update request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#update_headers
    ///     Resource#update_headers}
    /// </remarks>
    [JsiiProperty("updateHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? UpdateHeaders => null;

    /// <summary>A mapping of query parameters to be sent with the update request.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#update_query_parameters
    ///     Resource#update_query_parameters}
    /// </remarks>
    [JsiiProperty("updateQueryParameters",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
        true)]
    [JsiiOptional]
    object? UpdateQueryParameters => null;

    [JsiiTypeProxy(typeof(IResourceConfig), "azapi.resource.ResourceConfig")]
    internal sealed class _Proxy : DeputyBase, IResourceConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#type Resource#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>A dynamic attribute that contains the request body.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#body Resource#body}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("body", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? Body => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>A mapping of headers to be sent with the create request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#create_headers
        ///     Resource#create_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("createHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? CreateHeaders => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A mapping of query parameters to be sent with the create request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#create_query_parameters
        ///     Resource#create_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("createQueryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? CreateQueryParameters => GetInstanceProperty<object?>();

        /// <summary>A mapping of headers to be sent with the delete request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#delete_headers
        ///     Resource#delete_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("deleteHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? DeleteHeaders => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A mapping of query parameters to be sent with the delete request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#delete_query_parameters
        ///     Resource#delete_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("deleteQueryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? DeleteQueryParameters => GetInstanceProperty<object?>();

        /// <summary>identity block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#identity Resource#identity}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("identity",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.resource.ResourceIdentity\"},\"kind\":\"array\"}}]}}", true)]
        public object? Identity => GetInstanceProperty<object?>();

        /// <summary>Whether ignore the casing of the property names in the response body. Defaults to `false`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#ignore_casing
        ///     Resource#ignore_casing}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("ignoreCasing", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? IgnoreCasing => GetInstanceProperty<object?>();

        /// <summary>Whether ignore not returned properties like credentials in `body` to suppress plan-diff.</summary>
        /// <remarks>
        ///     Defaults to <c>true</c>. It's recommend to enable this option when some sensitive properties are not returned in
        ///     response body, instead of setting them in <c>lifecycle.ignore_changes</c> because it will make the sensitive fields
        ///     unable to update.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#ignore_missing_property
        ///     Resource#ignore_missing_property}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("ignoreMissingProperty", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? IgnoreMissingProperty => GetInstanceProperty<object?>();

        /// <summary>The location of the Azure resource.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#location Resource#location}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("location", "{\"primitive\":\"string\"}", true)]
        public string? Location => GetInstanceProperty<string?>();

        /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#locks Resource#locks}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("locks", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
        public string[]? Locks => GetInstanceProperty<string[]?>();

        /// <summary>Specifies the name of the azure resource. Changing this forces a new resource to be created.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#name Resource#name}
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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#parent_id Resource#parent_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
        public string? ParentId => GetInstanceProperty<string?>();

        /// <summary>A mapping of headers to be sent with the read request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#read_headers
        ///     Resource#read_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("readHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? ReadHeaders => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A mapping of query parameters to be sent with the read request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#read_query_parameters
        ///     Resource#read_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("readQueryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? ReadQueryParameters => GetInstanceProperty<object?>();

        /// <summary>Will trigger a replace of the resource when the value changes and is not `null`.</summary>
        /// <remarks>
        ///     This can be used by practitioners to force a replace of the resource when certain values change, e.g. changing the
        ///     SKU of a virtual machine based on the value of variables or locals. The value is a <c>dynamic</c>, so practitioners
        ///     can compose the input however they wish. For a "break glass" set the value to <c>null</c> to prevent the plan
        ///     modifier taking effect.
        ///     If you have <c>null</c> values that you do want to be tracked as affecting the resource replacement, include these
        ///     inside an object.
        ///     Advanced use cases are possible and resource replacement can be triggered by values external to the resource, for
        ///     example when a dependent resource changes.
        ///     e.g. to replace a resource when either the SKU or os_type attributes change:
        ///     <code><![CDATA[
        /// resource "azapi_resource" "example" {
        ///   name      = var.name
        ///   type      = "Microsoft.Network/publicIPAddresses@2023-11-01"
        ///   parent_id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/example"
        ///   body = {
        ///     properties = {
        ///       sku   = var.sku
        ///       zones = var.zones
        ///     }
        ///   }
        /// 
        ///   replace_triggers_external_values = [
        ///     var.sku,
        ///     var.zones,
        ///   ]
        /// }
        /// ]]></code>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#replace_triggers_external_values
        ///     Resource#replace_triggers_external_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("replaceTriggersExternalValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? ReplaceTriggersExternalValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>A list of paths in the current Terraform configuration.</summary>
        /// <remarks>
        ///     When the values at these paths change, the resource will be replaced.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#replace_triggers_refs
        ///     Resource#replace_triggers_refs}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("replaceTriggersRefs", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
        public string[]? ReplaceTriggersRefs => GetInstanceProperty<string[]?>();

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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#response_export_values
        ///     Resource#response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("responseExportValues", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? ResponseExportValues => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#retry Resource#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("retry", "{\"fqn\":\"azapi.resource.ResourceRetry\"}", true)]
        public IResourceRetry? Retry => GetInstanceProperty<IResourceRetry?>();

        /// <summary>Whether enabled the validation on `type` and `body` with embedded schema. Defaults to `true`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#schema_validation_enabled
        ///     Resource#schema_validation_enabled}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("schemaValidationEnabled", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? SchemaValidationEnabled => GetInstanceProperty<object?>();

        /// <summary>A dynamic attribute that contains the write-only properties of the request body.</summary>
        /// <remarks>
        ///     This will be merge-patched to the body to construct the actual request body.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#sensitive_body
        ///     Resource#sensitive_body}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("sensitiveBody", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, object>? SensitiveBody => GetInstanceProperty<IDictionary<string, object>?>();

        /// <summary>A mapping of tags which should be assigned to the Azure resource.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#tags Resource#tags}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("tags", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? Tags => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#timeouts Resource#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.resource.ResourceTimeouts\"}", true)]
        public IResourceTimeouts? Timeouts => GetInstanceProperty<IResourceTimeouts?>();

        /// <summary>A mapping of headers to be sent with the update request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#update_headers
        ///     Resource#update_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("updateHeaders", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? UpdateHeaders => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>A mapping of query parameters to be sent with the update request.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#update_query_parameters
        ///     Resource#update_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("updateQueryParameters",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}",
            true)]
        public object? UpdateQueryParameters => GetInstanceProperty<object?>();

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