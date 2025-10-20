using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Provider;

[JsiiByValue("azapi.provider.AzapiProviderEndpoint")]
public class AzapiProviderEndpoint : IAzapiProviderEndpoint
{
    /// <summary>The Azure Active Directory login endpoint to use.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_ACTIVE_DIRECTORY_AUTHORITY_HOST</c> Environment Variable. Defaults to
    ///     <c>https://login.microsoftonline.com/</c> for public cloud.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#active_directory_authority_host
    ///     AzapiProvider#active_directory_authority_host}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("activeDirectoryAuthorityHost", "{\"primitive\":\"string\"}", true)]
    public string? ActiveDirectoryAuthorityHost { get; set; }

    /// <summary>The resource ID to obtain AD tokens for.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_RESOURCE_MANAGER_AUDIENCE</c> Environment Variable. Defaults to
    ///     <c>https://management.core.windows.net/</c> for public cloud.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_audience
    ///     AzapiProvider#resource_manager_audience}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("resourceManagerAudience", "{\"primitive\":\"string\"}", true)]
    public string? ResourceManagerAudience { get; set; }

    /// <summary>The Azure Resource Manager endpoint to use.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_RESOURCE_MANAGER_ENDPOINT</c> Environment Variable. Defaults to
    ///     <c>https://management.azure.com/</c> for public cloud.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#resource_manager_endpoint
    ///     AzapiProvider#resource_manager_endpoint}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("resourceManagerEndpoint", "{\"primitive\":\"string\"}", true)]
    public string? ResourceManagerEndpoint { get; set; }
}