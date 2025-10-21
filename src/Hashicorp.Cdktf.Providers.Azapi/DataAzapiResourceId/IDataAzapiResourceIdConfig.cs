using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceId;

[JsiiInterface(typeof(IDataAzapiResourceIdConfig), "azapi.dataAzapiResourceId.DataAzapiResourceIdConfig")]
public interface IDataAzapiResourceIdConfig : ITerraformMetaArguments
{
    /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
    /// <remarks>
    ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
    ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#type
    ///     DataAzapiResourceId#type}
    /// </remarks>
    [JsiiProperty("type", "{\"primitive\":\"string\"}")]
    string Type { get; }

    /// <summary>The name of the Azure resource.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#name
    ///     DataAzapiResourceId#name}
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
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#parent_id
    ///     DataAzapiResourceId#parent_id}
    /// </remarks>
    [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ParentId => null;

    /// <summary>The ID of an existing Azure source.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#resource_id
    ///     DataAzapiResourceId#resource_id}
    /// </remarks>
    [JsiiProperty("resourceId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ResourceId => null;

    /// <summary>timeouts block.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#timeouts
    ///     DataAzapiResourceId#timeouts}
    /// </remarks>
    [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeouts\"}", true)]
    [JsiiOptional]
    IDataAzapiResourceIdTimeouts? Timeouts => null;

    [JsiiTypeProxy(typeof(IDataAzapiResourceIdConfig), "azapi.dataAzapiResourceId.DataAzapiResourceIdConfig")]
    internal sealed class _Proxy : DeputyBase, IDataAzapiResourceIdConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        ///     <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>.
        ///     <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#type
        ///     DataAzapiResourceId#type}
        /// </remarks>
        [JsiiProperty("type", "{\"primitive\":\"string\"}")]
        public string Type => GetInstanceProperty<string>()!;

        /// <summary>The name of the Azure resource.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#name
        ///     DataAzapiResourceId#name}
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
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#parent_id
        ///     DataAzapiResourceId#parent_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("parentId", "{\"primitive\":\"string\"}", true)]
        public string? ParentId => GetInstanceProperty<string?>();

        /// <summary>The ID of an existing Azure source.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#resource_id
        ///     DataAzapiResourceId#resource_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("resourceId", "{\"primitive\":\"string\"}", true)]
        public string? ResourceId => GetInstanceProperty<string?>();

        /// <summary>timeouts block.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_id#timeouts
        ///     DataAzapiResourceId#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("timeouts", "{\"fqn\":\"azapi.dataAzapiResourceId.DataAzapiResourceIdTimeouts\"}", true)]
        public IDataAzapiResourceIdTimeouts? Timeouts => GetInstanceProperty<IDataAzapiResourceIdTimeouts?>();

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