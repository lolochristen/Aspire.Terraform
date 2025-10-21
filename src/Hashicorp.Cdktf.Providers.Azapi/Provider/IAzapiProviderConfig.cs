using System.Collections.Generic;
using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Provider;

[JsiiInterface(typeof(IAzapiProviderConfig), "azapi.provider.AzapiProviderConfig")]
public interface IAzapiProviderConfig
{
    /// <summary>Alias name.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#alias
    ///     AzapiProvider#alias}
    /// </remarks>
    [JsiiProperty("alias", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Alias => null;

    /// <summary>List of auxiliary Tenant IDs required for multi-tenancy and cross-tenant scenarios.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_AUXILIARY_TENANT_IDS</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#auxiliary_tenant_ids
    ///     AzapiProvider#auxiliary_tenant_ids}
    /// </remarks>
    [JsiiProperty("auxiliaryTenantIds", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
    [JsiiOptional]
    string[]? AuxiliaryTenantIds => null;

    /// <summary>A base64-encoded PKCS#12 bundle to be used as the client certificate for authentication.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE</c> environment variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate AzapiProvider#client_certificate}
    /// </remarks>
    [JsiiProperty("clientCertificate", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientCertificate => null;

    /// <summary>
    ///     The password associated with the Client Certificate. This can also be sourced from the
    ///     `ARM_CLIENT_CERTIFICATE_PASSWORD` Environment Variable.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_password
    ///     AzapiProvider#client_certificate_password}
    /// </remarks>
    [JsiiProperty("clientCertificatePassword", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientCertificatePassword => null;

    /// <summary>The path to the Client Certificate associated with the Service Principal which should be used.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE_PATH</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_path
    ///     AzapiProvider#client_certificate_path}
    /// </remarks>
    [JsiiProperty("clientCertificatePath", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientCertificatePath => null;

    /// <summary>The Client ID which should be used. This can also be sourced from the `ARM_CLIENT_ID` Environment Variable.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id
    ///     AzapiProvider#client_id}
    /// </remarks>
    [JsiiProperty("clientId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientId => null;

    /// <summary>The path to a file containing the Client ID which should be used.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_CLIENT_ID_FILE_PATH</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id_file_path
    ///     AzapiProvider#client_id_file_path}
    /// </remarks>
    [JsiiProperty("clientIdFilePath", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientIdFilePath => null;

    /// <summary>
    ///     The Client Secret which should be used. This can also be sourced from the `ARM_CLIENT_SECRET` Environment
    ///     Variable.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret
    ///     AzapiProvider#client_secret}
    /// </remarks>
    [JsiiProperty("clientSecret", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientSecret => null;

    /// <summary>The path to a file containing the Client Secret which should be used.</summary>
    /// <remarks>
    ///     For use When authenticating as a Service Principal using a Client Secret. This can also be sourced from the
    ///     <c>ARM_CLIENT_SECRET_FILE_PATH</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret_file_path
    ///     AzapiProvider#client_secret_file_path}
    /// </remarks>
    [JsiiProperty("clientSecretFilePath", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? ClientSecretFilePath => null;

    /// <summary>The value of the `x-ms-correlation-request-id` header, otherwise an auto-generated UUID will be used.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_CORRELATION_REQUEST_ID</c> environment variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#custom_correlation_request_id
    ///     AzapiProvider#custom_correlation_request_id}
    /// </remarks>
    [JsiiProperty("customCorrelationRequestId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? CustomCorrelationRequestId => null;

    /// <summary>The default Azure Region where the azure resource should exist.</summary>
    /// <remarks>
    ///     The <c>location</c> in each resource block can override the <c>default_location</c>. Changing this forces new
    ///     resources to be created.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_location
    ///     AzapiProvider#default_location}
    /// </remarks>
    [JsiiProperty("defaultLocation", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? DefaultLocation => null;

    /// <summary>The default name to create the azure resource.</summary>
    /// <remarks>
    ///     The <c>name</c> in each resource block can override the <c>default_name</c>. Changing this forces new resources to
    ///     be created.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_name
    ///     AzapiProvider#default_name}
    /// </remarks>
    [JsiiProperty("defaultName", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? DefaultName => null;

    /// <summary>A mapping of tags which should be assigned to the azure resource as default tags.</summary>
    /// <remarks>
    ///     The<c>tags</c> in each resource block can override the <c>default_tags</c>.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_tags
    ///     AzapiProvider#default_tags}
    /// </remarks>
    [JsiiProperty("defaultTags", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
    [JsiiOptional]
    IDictionary<string, string>? DefaultTags => null;

    /// <summary>This will disable the x-ms-correlation-request-id header.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_correlation_request_id
    ///     AzapiProvider#disable_correlation_request_id}
    /// </remarks>
    [JsiiProperty("disableCorrelationRequestId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? DisableCorrelationRequestId => null;

    /// <summary>Disable default output.</summary>
    /// <remarks>
    ///     The default is false. When set to false, the provider will output the read-only properties if
    ///     <c>response_export_values</c> is not specified in the resource block. When set to true, the provider will disable
    ///     this output. This can also be sourced from the <c>ARM_DISABLE_DEFAULT_OUTPUT</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_default_output
    ///     AzapiProvider#disable_default_output}
    /// </remarks>
    [JsiiProperty("disableDefaultOutput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? DisableDefaultOutput => null;

    /// <summary>
    ///     Disable sending the Terraform Partner ID if a custom `partner_id` isn't specified, which allows Microsoft to
    ///     better understand the usage of Terraform.
    /// </summary>
    /// <remarks>
    ///     The Partner ID does not give HashiCorp any direct access to usage information. This can also be sourced from the
    ///     <c>ARM_DISABLE_TERRAFORM_PARTNER_ID</c> environment variable. Defaults to <c>false</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_terraform_partner_id
    ///     AzapiProvider#disable_terraform_partner_id}
    /// </remarks>
    [JsiiProperty("disableTerraformPartnerId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? DisableTerraformPartnerId => null;

    /// <summary>Enable Preflight Validation.</summary>
    /// <remarks>
    ///     The default is false. When set to true, the provider will use Preflight to do static validation before really
    ///     deploying a new resource. When set to false, the provider will disable this validation. This can also be sourced
    ///     from the <c>ARM_ENABLE_PREFLIGHT</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#enable_preflight
    ///     AzapiProvider#enable_preflight}
    /// </remarks>
    [JsiiProperty("enablePreflight", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? EnablePreflight => null;

    /// <summary>The Azure API Endpoint Configuration.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#endpoint
    ///     AzapiProvider#endpoint}
    /// </remarks>
    [JsiiProperty("endpoint",
        "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}", true)]
    [JsiiOptional]
    object? Endpoint => null;

    /// <summary>The Cloud Environment which should be used.</summary>
    /// <remarks>
    ///     Possible values are <c>public</c>, <c>usgovernment</c> and <c>china</c>. Defaults to <c>public</c>. This can also
    ///     be sourced from the <c>ARM_ENVIRONMENT</c> Environment Variable.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#environment
    ///     AzapiProvider#environment}
    /// </remarks>
    [JsiiProperty("environment", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? Environment => null;

    /// <summary>
    ///     The maximum number of retries to attempt if the Azure API returns an HTTP 408, 429, 500, 502, 503, or 504
    ///     response.
    /// </summary>
    /// <remarks>
    ///     The default is <c>3</c>. The resource-specific retry configuration may additionally be used to retry on other
    ///     errors and conditions.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#maximum_busy_retry_attempts
    ///     AzapiProvider#maximum_busy_retry_attempts}
    /// </remarks>
    [JsiiProperty("maximumBusyRetryAttempts", "{\"primitive\":\"number\"}", true)]
    [JsiiOptional]
    double? MaximumBusyRetryAttempts => null;

    /// <summary>The Azure Pipelines Service Connection ID to use for authentication.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_ADO_PIPELINE_SERVICE_CONNECTION_ID</c>,
    ///     <c>ARM_OIDC_AZURE_SERVICE_CONNECTION_ID</c>, or <c>AZURESUBSCRIPTION_SERVICE_CONNECTION_ID</c> Environment
    ///     Variables.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_azure_service_connection_id
    ///     AzapiProvider#oidc_azure_service_connection_id}
    /// </remarks>
    [JsiiProperty("oidcAzureServiceConnectionId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? OidcAzureServiceConnectionId => null;

    /// <summary>The bearer token for the request to the OIDC provider.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_OIDC_REQUEST_TOKEN</c>, <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>, or
    ///     <c>SYSTEM_ACCESSTOKEN</c> Environment Variables.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_token AzapiProvider#oidc_request_token}
    /// </remarks>
    [JsiiProperty("oidcRequestToken", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? OidcRequestToken => null;

    /// <summary>The URL for the OIDC provider from which to request an ID token.</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_OIDC_REQUEST_URL</c>, <c>ACTIONS_ID_TOKEN_REQUEST_URL</c>, or
    ///     <c>SYSTEM_OIDCREQUESTURI</c> Environment Variables.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_url
    ///     AzapiProvider#oidc_request_url}
    /// </remarks>
    [JsiiProperty("oidcRequestUrl", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? OidcRequestUrl => null;

    /// <summary>
    ///     The ID token when authenticating using OpenID Connect (OIDC). This can also be sourced from the
    ///     `ARM_OIDC_TOKEN` environment Variable.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token
    ///     AzapiProvider#oidc_token}
    /// </remarks>
    [JsiiProperty("oidcToken", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? OidcToken => null;

    /// <summary>The path to a file containing an ID token when authenticating using OpenID Connect (OIDC).</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_OIDC_TOKEN_FILE_PATH</c> environment Variable.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token_file_path
    ///     AzapiProvider#oidc_token_file_path}
    /// </remarks>
    [JsiiProperty("oidcTokenFilePath", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? OidcTokenFilePath => null;

    /// <summary>
    ///     A GUID/UUID that is
    ///     [registered](https://docs.microsoft.com/azure/marketplace/azure-partner-customer-usage-attribution#register-guids-and-offers)
    ///     with Microsoft to facilitate partner resource usage attribution. This can also be sourced from the `ARM_PARTNER_ID`
    ///     Environment Variable.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#partner_id
    ///     AzapiProvider#partner_id}
    /// </remarks>
    [JsiiProperty("partnerId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? PartnerId => null;

    /// <summary>Should the Provider skip registering the Resource Providers it supports?</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_SKIP_PROVIDER_REGISTRATION</c> Environment Variable. Defaults to
    ///     <c>false</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#skip_provider_registration
    ///     AzapiProvider#skip_provider_registration}
    /// </remarks>
    [JsiiProperty("skipProviderRegistration", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? SkipProviderRegistration => null;

    /// <summary>
    ///     The Subscription ID which should be used. This can also be sourced from the `ARM_SUBSCRIPTION_ID` Environment
    ///     Variable.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#subscription_id
    ///     AzapiProvider#subscription_id}
    /// </remarks>
    [JsiiProperty("subscriptionId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? SubscriptionId => null;

    /// <summary>The Tenant ID should be used. This can also be sourced from the `ARM_TENANT_ID` Environment Variable.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#tenant_id
    ///     AzapiProvider#tenant_id}
    /// </remarks>
    [JsiiProperty("tenantId", "{\"primitive\":\"string\"}", true)]
    [JsiiOptional]
    string? TenantId => null;

    /// <summary>Should AKS Workload Identity be used for Authentication?</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_USE_AKS_WORKLOAD_IDENTITY</c> Environment Variable. Defaults to
    ///     <c>false</c>. When set, <c>client_id</c>, <c>tenant_id</c> and <c>oidc_token_file_path</c> will be detected from
    ///     the environment and do not need to be specified.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_aks_workload_identity
    ///     AzapiProvider#use_aks_workload_identity}
    /// </remarks>
    [JsiiProperty("useAksWorkloadIdentity", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? UseAksWorkloadIdentity => null;

    /// <summary>Should Azure CLI be used for authentication?</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_USE_CLI</c> environment variable. Defaults to <c>true</c>.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_cli
    ///     AzapiProvider#use_cli}
    /// </remarks>
    [JsiiProperty("useCli", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? UseCli => null;

    /// <summary>Should Managed Identity be used for Authentication?</summary>
    /// <remarks>
    ///     This can also be sourced from the <c>ARM_USE_MSI</c> Environment Variable. Defaults to <c>false</c>.
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_msi
    ///     AzapiProvider#use_msi}
    /// </remarks>
    [JsiiProperty("useMsi", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? UseMsi => null;

    /// <summary>
    ///     Should OIDC be used for Authentication? This can also be sourced from the `ARM_USE_OIDC` Environment Variable.
    ///     Defaults to `false`.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_oidc
    ///     AzapiProvider#use_oidc}
    /// </remarks>
    [JsiiProperty("useOidc", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
    [JsiiOptional]
    object? UseOidc => null;

    [JsiiTypeProxy(typeof(IAzapiProviderConfig), "azapi.provider.AzapiProviderConfig")]
    internal sealed class _Proxy : DeputyBase, IAzapiProviderConfig
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>Alias name.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#alias
        ///     AzapiProvider#alias}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("alias", "{\"primitive\":\"string\"}", true)]
        public string? Alias => GetInstanceProperty<string?>();

        /// <summary>List of auxiliary Tenant IDs required for multi-tenancy and cross-tenant scenarios.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_AUXILIARY_TENANT_IDS</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#auxiliary_tenant_ids
        ///     AzapiProvider#auxiliary_tenant_ids}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("auxiliaryTenantIds", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", true)]
        public string[]? AuxiliaryTenantIds => GetInstanceProperty<string[]?>();

        /// <summary>A base64-encoded PKCS#12 bundle to be used as the client certificate for authentication.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE</c> environment variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate AzapiProvider#client_certificate}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientCertificate", "{\"primitive\":\"string\"}", true)]
        public string? ClientCertificate => GetInstanceProperty<string?>();

        /// <summary>
        ///     The password associated with the Client Certificate. This can also be sourced from the
        ///     `ARM_CLIENT_CERTIFICATE_PASSWORD` Environment Variable.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_password
        ///     AzapiProvider#client_certificate_password}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientCertificatePassword", "{\"primitive\":\"string\"}", true)]
        public string? ClientCertificatePassword => GetInstanceProperty<string?>();

        /// <summary>The path to the Client Certificate associated with the Service Principal which should be used.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE_PATH</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_path
        ///     AzapiProvider#client_certificate_path}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientCertificatePath", "{\"primitive\":\"string\"}", true)]
        public string? ClientCertificatePath => GetInstanceProperty<string?>();

        /// <summary>The Client ID which should be used. This can also be sourced from the `ARM_CLIENT_ID` Environment Variable.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id
        ///     AzapiProvider#client_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientId", "{\"primitive\":\"string\"}", true)]
        public string? ClientId => GetInstanceProperty<string?>();

        /// <summary>The path to a file containing the Client ID which should be used.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_CLIENT_ID_FILE_PATH</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id_file_path
        ///     AzapiProvider#client_id_file_path}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientIdFilePath", "{\"primitive\":\"string\"}", true)]
        public string? ClientIdFilePath => GetInstanceProperty<string?>();

        /// <summary>
        ///     The Client Secret which should be used. This can also be sourced from the `ARM_CLIENT_SECRET` Environment
        ///     Variable.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret
        ///     AzapiProvider#client_secret}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientSecret", "{\"primitive\":\"string\"}", true)]
        public string? ClientSecret => GetInstanceProperty<string?>();

        /// <summary>The path to a file containing the Client Secret which should be used.</summary>
        /// <remarks>
        ///     For use When authenticating as a Service Principal using a Client Secret. This can also be sourced from the
        ///     <c>ARM_CLIENT_SECRET_FILE_PATH</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret_file_path
        ///     AzapiProvider#client_secret_file_path}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("clientSecretFilePath", "{\"primitive\":\"string\"}", true)]
        public string? ClientSecretFilePath => GetInstanceProperty<string?>();

        /// <summary>The value of the `x-ms-correlation-request-id` header, otherwise an auto-generated UUID will be used.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_CORRELATION_REQUEST_ID</c> environment variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#custom_correlation_request_id
        ///     AzapiProvider#custom_correlation_request_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("customCorrelationRequestId", "{\"primitive\":\"string\"}", true)]
        public string? CustomCorrelationRequestId => GetInstanceProperty<string?>();

        /// <summary>The default Azure Region where the azure resource should exist.</summary>
        /// <remarks>
        ///     The <c>location</c> in each resource block can override the <c>default_location</c>. Changing this forces new
        ///     resources to be created.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_location
        ///     AzapiProvider#default_location}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("defaultLocation", "{\"primitive\":\"string\"}", true)]
        public string? DefaultLocation => GetInstanceProperty<string?>();

        /// <summary>The default name to create the azure resource.</summary>
        /// <remarks>
        ///     The <c>name</c> in each resource block can override the <c>default_name</c>. Changing this forces new resources to
        ///     be created.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_name
        ///     AzapiProvider#default_name}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("defaultName", "{\"primitive\":\"string\"}", true)]
        public string? DefaultName => GetInstanceProperty<string?>();

        /// <summary>A mapping of tags which should be assigned to the azure resource as default tags.</summary>
        /// <remarks>
        ///     The<c>tags</c> in each resource block can override the <c>default_tags</c>.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_tags
        ///     AzapiProvider#default_tags}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("defaultTags", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", true)]
        public IDictionary<string, string>? DefaultTags => GetInstanceProperty<IDictionary<string, string>?>();

        /// <summary>This will disable the x-ms-correlation-request-id header.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_correlation_request_id
        ///     AzapiProvider#disable_correlation_request_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("disableCorrelationRequestId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? DisableCorrelationRequestId => GetInstanceProperty<object?>();

        /// <summary>Disable default output.</summary>
        /// <remarks>
        ///     The default is false. When set to false, the provider will output the read-only properties if
        ///     <c>response_export_values</c> is not specified in the resource block. When set to true, the provider will disable
        ///     this output. This can also be sourced from the <c>ARM_DISABLE_DEFAULT_OUTPUT</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_default_output
        ///     AzapiProvider#disable_default_output}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("disableDefaultOutput", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? DisableDefaultOutput => GetInstanceProperty<object?>();

        /// <summary>
        ///     Disable sending the Terraform Partner ID if a custom `partner_id` isn't specified, which allows Microsoft to
        ///     better understand the usage of Terraform.
        /// </summary>
        /// <remarks>
        ///     The Partner ID does not give HashiCorp any direct access to usage information. This can also be sourced from the
        ///     <c>ARM_DISABLE_TERRAFORM_PARTNER_ID</c> environment variable. Defaults to <c>false</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_terraform_partner_id
        ///     AzapiProvider#disable_terraform_partner_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("disableTerraformPartnerId", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? DisableTerraformPartnerId => GetInstanceProperty<object?>();

        /// <summary>Enable Preflight Validation.</summary>
        /// <remarks>
        ///     The default is false. When set to true, the provider will use Preflight to do static validation before really
        ///     deploying a new resource. When set to false, the provider will disable this validation. This can also be sourced
        ///     from the <c>ARM_ENABLE_PREFLIGHT</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#enable_preflight
        ///     AzapiProvider#enable_preflight}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("enablePreflight", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? EnablePreflight => GetInstanceProperty<object?>();

        /// <summary>The Azure API Endpoint Configuration.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#endpoint
        ///     AzapiProvider#endpoint}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("endpoint",
            "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}",
            true)]
        public object? Endpoint => GetInstanceProperty<object?>();

        /// <summary>The Cloud Environment which should be used.</summary>
        /// <remarks>
        ///     Possible values are <c>public</c>, <c>usgovernment</c> and <c>china</c>. Defaults to <c>public</c>. This can also
        ///     be sourced from the <c>ARM_ENVIRONMENT</c> Environment Variable.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#environment
        ///     AzapiProvider#environment}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("environment", "{\"primitive\":\"string\"}", true)]
        public string? Environment => GetInstanceProperty<string?>();

        /// <summary>
        ///     The maximum number of retries to attempt if the Azure API returns an HTTP 408, 429, 500, 502, 503, or 504
        ///     response.
        /// </summary>
        /// <remarks>
        ///     The default is <c>3</c>. The resource-specific retry configuration may additionally be used to retry on other
        ///     errors and conditions.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#maximum_busy_retry_attempts
        ///     AzapiProvider#maximum_busy_retry_attempts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("maximumBusyRetryAttempts", "{\"primitive\":\"number\"}", true)]
        public double? MaximumBusyRetryAttempts => GetInstanceProperty<double?>();

        /// <summary>The Azure Pipelines Service Connection ID to use for authentication.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_ADO_PIPELINE_SERVICE_CONNECTION_ID</c>,
        ///     <c>ARM_OIDC_AZURE_SERVICE_CONNECTION_ID</c>, or <c>AZURESUBSCRIPTION_SERVICE_CONNECTION_ID</c> Environment
        ///     Variables.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_azure_service_connection_id
        ///     AzapiProvider#oidc_azure_service_connection_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("oidcAzureServiceConnectionId", "{\"primitive\":\"string\"}", true)]
        public string? OidcAzureServiceConnectionId => GetInstanceProperty<string?>();

        /// <summary>The bearer token for the request to the OIDC provider.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_OIDC_REQUEST_TOKEN</c>, <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>, or
        ///     <c>SYSTEM_ACCESSTOKEN</c> Environment Variables.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_token AzapiProvider#oidc_request_token}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("oidcRequestToken", "{\"primitive\":\"string\"}", true)]
        public string? OidcRequestToken => GetInstanceProperty<string?>();

        /// <summary>The URL for the OIDC provider from which to request an ID token.</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_OIDC_REQUEST_URL</c>, <c>ACTIONS_ID_TOKEN_REQUEST_URL</c>, or
        ///     <c>SYSTEM_OIDCREQUESTURI</c> Environment Variables.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_url
        ///     AzapiProvider#oidc_request_url}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("oidcRequestUrl", "{\"primitive\":\"string\"}", true)]
        public string? OidcRequestUrl => GetInstanceProperty<string?>();

        /// <summary>
        ///     The ID token when authenticating using OpenID Connect (OIDC). This can also be sourced from the
        ///     `ARM_OIDC_TOKEN` environment Variable.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token
        ///     AzapiProvider#oidc_token}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("oidcToken", "{\"primitive\":\"string\"}", true)]
        public string? OidcToken => GetInstanceProperty<string?>();

        /// <summary>The path to a file containing an ID token when authenticating using OpenID Connect (OIDC).</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_OIDC_TOKEN_FILE_PATH</c> environment Variable.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token_file_path
        ///     AzapiProvider#oidc_token_file_path}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("oidcTokenFilePath", "{\"primitive\":\"string\"}", true)]
        public string? OidcTokenFilePath => GetInstanceProperty<string?>();

        /// <summary>
        ///     A GUID/UUID that is
        ///     [registered](https://docs.microsoft.com/azure/marketplace/azure-partner-customer-usage-attribution#register-guids-and-offers)
        ///     with Microsoft to facilitate partner resource usage attribution. This can also be sourced from the `ARM_PARTNER_ID`
        ///     Environment Variable.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#partner_id
        ///     AzapiProvider#partner_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("partnerId", "{\"primitive\":\"string\"}", true)]
        public string? PartnerId => GetInstanceProperty<string?>();

        /// <summary>Should the Provider skip registering the Resource Providers it supports?</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_SKIP_PROVIDER_REGISTRATION</c> Environment Variable. Defaults to
        ///     <c>false</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#skip_provider_registration
        ///     AzapiProvider#skip_provider_registration}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("skipProviderRegistration", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? SkipProviderRegistration => GetInstanceProperty<object?>();

        /// <summary>
        ///     The Subscription ID which should be used. This can also be sourced from the `ARM_SUBSCRIPTION_ID` Environment
        ///     Variable.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#subscription_id
        ///     AzapiProvider#subscription_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("subscriptionId", "{\"primitive\":\"string\"}", true)]
        public string? SubscriptionId => GetInstanceProperty<string?>();

        /// <summary>The Tenant ID should be used. This can also be sourced from the `ARM_TENANT_ID` Environment Variable.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#tenant_id
        ///     AzapiProvider#tenant_id}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("tenantId", "{\"primitive\":\"string\"}", true)]
        public string? TenantId => GetInstanceProperty<string?>();

        /// <summary>Should AKS Workload Identity be used for Authentication?</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_USE_AKS_WORKLOAD_IDENTITY</c> Environment Variable. Defaults to
        ///     <c>false</c>. When set, <c>client_id</c>, <c>tenant_id</c> and <c>oidc_token_file_path</c> will be detected from
        ///     the environment and do not need to be specified.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_aks_workload_identity
        ///     AzapiProvider#use_aks_workload_identity}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("useAksWorkloadIdentity", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? UseAksWorkloadIdentity => GetInstanceProperty<object?>();

        /// <summary>Should Azure CLI be used for authentication?</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_USE_CLI</c> environment variable. Defaults to <c>true</c>.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_cli
        ///     AzapiProvider#use_cli}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("useCli", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? UseCli => GetInstanceProperty<object?>();

        /// <summary>Should Managed Identity be used for Authentication?</summary>
        /// <remarks>
        ///     This can also be sourced from the <c>ARM_USE_MSI</c> Environment Variable. Defaults to <c>false</c>.
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_msi
        ///     AzapiProvider#use_msi}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("useMsi", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? UseMsi => GetInstanceProperty<object?>();

        /// <summary>
        ///     Should OIDC be used for Authentication? This can also be sourced from the `ARM_USE_OIDC` Environment Variable.
        ///     Defaults to `false`.
        /// </summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_oidc
        ///     AzapiProvider#use_oidc}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("useOidc", "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", true)]
        public object? UseOidc => GetInstanceProperty<object?>();
    }
}