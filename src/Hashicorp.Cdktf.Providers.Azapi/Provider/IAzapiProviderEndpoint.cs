using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Provider
{
    [JsiiInterface(nativeType: typeof(IAzapiProviderEndpoint), fullyQualifiedName: "azapi.provider.AzapiProviderEndpoint")]
    public interface IAzapiProviderEndpoint
    {
        /// <summary>The Azure Active Directory login endpoint to use.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_ACTIVE_DIRECTORY_AUTHORITY_HOST</c> Environment Variable. Defaults to <c>https://login.microsoftonline.com/</c> for public cloud.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#active_directory_authority_host AzapiProvider#active_directory_authority_host}
        /// </remarks>
        [JsiiProperty(name: "activeDirectoryAuthorityHost", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ActiveDirectoryAuthorityHost
        {
            get
            {
                return null;
            }
        }

        /// <summary>The resource ID to obtain AD tokens for.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_RESOURCE_MANAGER_AUDIENCE</c> Environment Variable. Defaults to <c>https://management.core.windows.net/</c> for public cloud.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_audience AzapiProvider#resource_manager_audience}
        /// </remarks>
        [JsiiProperty(name: "resourceManagerAudience", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ResourceManagerAudience
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Azure Resource Manager endpoint to use.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_RESOURCE_MANAGER_ENDPOINT</c> Environment Variable. Defaults to <c>https://management.azure.com/</c> for public cloud.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_endpoint AzapiProvider#resource_manager_endpoint}
        /// </remarks>
        [JsiiProperty(name: "resourceManagerEndpoint", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ResourceManagerEndpoint
        {
            get
            {
                return null;
            }
        }

        [JsiiTypeProxy(nativeType: typeof(IAzapiProviderEndpoint), fullyQualifiedName: "azapi.provider.AzapiProviderEndpoint")]
        internal sealed class _Proxy : DeputyBase, IAzapiProviderEndpoint
        {
            private _Proxy(ByRefValue reference): base(reference)
            {
            }

            /// <summary>The Azure Active Directory login endpoint to use.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_ACTIVE_DIRECTORY_AUTHORITY_HOST</c> Environment Variable. Defaults to <c>https://login.microsoftonline.com/</c> for public cloud.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#active_directory_authority_host AzapiProvider#active_directory_authority_host}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "activeDirectoryAuthorityHost", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ActiveDirectoryAuthorityHost
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The resource ID to obtain AD tokens for.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_RESOURCE_MANAGER_AUDIENCE</c> Environment Variable. Defaults to <c>https://management.core.windows.net/</c> for public cloud.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_audience AzapiProvider#resource_manager_audience}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "resourceManagerAudience", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ResourceManagerAudience
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The Azure Resource Manager endpoint to use.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_RESOURCE_MANAGER_ENDPOINT</c> Environment Variable. Defaults to <c>https://management.azure.com/</c> for public cloud.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_endpoint AzapiProvider#resource_manager_endpoint}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "resourceManagerEndpoint", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ResourceManagerEndpoint
            {
                get => GetInstanceProperty<string?>();
            }
        }
    }
}
