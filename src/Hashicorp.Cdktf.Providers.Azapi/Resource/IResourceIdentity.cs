using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Resource
{
    [JsiiInterface(nativeType: typeof(IResourceIdentity), fullyQualifiedName: "azapi.resource.ResourceIdentity")]
    public interface IResourceIdentity
    {
        /// <summary>The Type of Identity which should be used for this azure resource. Possible values are `SystemAssigned`, `UserAssigned` and `SystemAssigned,UserAssigned`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#type Resource#type}
        /// </remarks>
        [JsiiProperty(name: "type", typeJson: "{\"primitive\":\"string\"}")]
        string Type
        {
            get;
        }

        /// <summary>A list of User Managed Identity ID's which should be assigned to the azure resource.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#identity_ids Resource#identity_ids}
        /// </remarks>
        [JsiiProperty(name: "identityIds", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string[]? IdentityIds
        {
            get
            {
                return null;
            }
        }

        [JsiiTypeProxy(nativeType: typeof(IResourceIdentity), fullyQualifiedName: "azapi.resource.ResourceIdentity")]
        internal sealed class _Proxy : DeputyBase, IResourceIdentity
        {
            private _Proxy(ByRefValue reference): base(reference)
            {
            }

            /// <summary>The Type of Identity which should be used for this azure resource. Possible values are `SystemAssigned`, `UserAssigned` and `SystemAssigned,UserAssigned`.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#type Resource#type}
            /// </remarks>
            [JsiiProperty(name: "type", typeJson: "{\"primitive\":\"string\"}")]
            public string Type
            {
                get => GetInstanceProperty<string>()!;
            }

            /// <summary>A list of User Managed Identity ID's which should be assigned to the azure resource.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#identity_ids Resource#identity_ids}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "identityIds", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
            public string[]? IdentityIds
            {
                get => GetInstanceProperty<string[]?>();
            }
        }
    }
}
