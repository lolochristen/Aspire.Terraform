using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Provider
{
    [JsiiInterface(nativeType: typeof(IAzapiProviderConfig), fullyQualifiedName: "azapi.provider.AzapiProviderConfig")]
    public interface IAzapiProviderConfig
    {
        /// <summary>Alias name.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#alias AzapiProvider#alias}
        /// </remarks>
        [JsiiProperty(name: "alias", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? Alias
        {
            get
            {
                return null;
            }
        }

        /// <summary>List of auxiliary Tenant IDs required for multi-tenancy and cross-tenant scenarios.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_AUXILIARY_TENANT_IDS</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#auxiliary_tenant_ids AzapiProvider#auxiliary_tenant_ids}
        /// </remarks>
        [JsiiProperty(name: "auxiliaryTenantIds", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string[]? AuxiliaryTenantIds
        {
            get
            {
                return null;
            }
        }

        /// <summary>A base64-encoded PKCS#12 bundle to be used as the client certificate for authentication.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE</c> environment variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate AzapiProvider#client_certificate}
        /// </remarks>
        [JsiiProperty(name: "clientCertificate", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientCertificate
        {
            get
            {
                return null;
            }
        }

        /// <summary>The password associated with the Client Certificate. This can also be sourced from the `ARM_CLIENT_CERTIFICATE_PASSWORD` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_password AzapiProvider#client_certificate_password}
        /// </remarks>
        [JsiiProperty(name: "clientCertificatePassword", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientCertificatePassword
        {
            get
            {
                return null;
            }
        }

        /// <summary>The path to the Client Certificate associated with the Service Principal which should be used.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE_PATH</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_path AzapiProvider#client_certificate_path}
        /// </remarks>
        [JsiiProperty(name: "clientCertificatePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientCertificatePath
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Client ID which should be used. This can also be sourced from the `ARM_CLIENT_ID` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id AzapiProvider#client_id}
        /// </remarks>
        [JsiiProperty(name: "clientId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientId
        {
            get
            {
                return null;
            }
        }

        /// <summary>The path to a file containing the Client ID which should be used.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_CLIENT_ID_FILE_PATH</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id_file_path AzapiProvider#client_id_file_path}
        /// </remarks>
        [JsiiProperty(name: "clientIdFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientIdFilePath
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Client Secret which should be used. This can also be sourced from the `ARM_CLIENT_SECRET` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret AzapiProvider#client_secret}
        /// </remarks>
        [JsiiProperty(name: "clientSecret", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientSecret
        {
            get
            {
                return null;
            }
        }

        /// <summary>The path to a file containing the Client Secret which should be used.</summary>
        /// <remarks>
        /// For use When authenticating as a Service Principal using a Client Secret. This can also be sourced from the <c>ARM_CLIENT_SECRET_FILE_PATH</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret_file_path AzapiProvider#client_secret_file_path}
        /// </remarks>
        [JsiiProperty(name: "clientSecretFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ClientSecretFilePath
        {
            get
            {
                return null;
            }
        }

        /// <summary>The value of the `x-ms-correlation-request-id` header, otherwise an auto-generated UUID will be used.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_CORRELATION_REQUEST_ID</c> environment variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#custom_correlation_request_id AzapiProvider#custom_correlation_request_id}
        /// </remarks>
        [JsiiProperty(name: "customCorrelationRequestId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? CustomCorrelationRequestId
        {
            get
            {
                return null;
            }
        }

        /// <summary>The default Azure Region where the azure resource should exist.</summary>
        /// <remarks>
        /// The <c>location</c> in each resource block can override the <c>default_location</c>. Changing this forces new resources to be created.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_location AzapiProvider#default_location}
        /// </remarks>
        [JsiiProperty(name: "defaultLocation", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? DefaultLocation
        {
            get
            {
                return null;
            }
        }

        /// <summary>The default name to create the azure resource.</summary>
        /// <remarks>
        /// The <c>name</c> in each resource block can override the <c>default_name</c>. Changing this forces new resources to be created.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_name AzapiProvider#default_name}
        /// </remarks>
        [JsiiProperty(name: "defaultName", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? DefaultName
        {
            get
            {
                return null;
            }
        }

        /// <summary>A mapping of tags which should be assigned to the azure resource as default tags.</summary>
        /// <remarks>
        /// The<c>tags</c> in each resource block can override the <c>default_tags</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_tags AzapiProvider#default_tags}
        /// </remarks>
        [JsiiProperty(name: "defaultTags", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        System.Collections.Generic.IDictionary<string, string>? DefaultTags
        {
            get
            {
                return null;
            }
        }

        /// <summary>This will disable the x-ms-correlation-request-id header.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_correlation_request_id AzapiProvider#disable_correlation_request_id}
        /// </remarks>
        [JsiiProperty(name: "disableCorrelationRequestId", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? DisableCorrelationRequestId
        {
            get
            {
                return null;
            }
        }

        /// <summary>Disable default output.</summary>
        /// <remarks>
        /// The default is false. When set to false, the provider will output the read-only properties if <c>response_export_values</c> is not specified in the resource block. When set to true, the provider will disable this output. This can also be sourced from the <c>ARM_DISABLE_DEFAULT_OUTPUT</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_default_output AzapiProvider#disable_default_output}
        /// </remarks>
        [JsiiProperty(name: "disableDefaultOutput", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? DisableDefaultOutput
        {
            get
            {
                return null;
            }
        }

        /// <summary>Disable sending the Terraform Partner ID if a custom `partner_id` isn't specified, which allows Microsoft to better understand the usage of Terraform.</summary>
        /// <remarks>
        /// The Partner ID does not give HashiCorp any direct access to usage information. This can also be sourced from the <c>ARM_DISABLE_TERRAFORM_PARTNER_ID</c> environment variable. Defaults to <c>false</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_terraform_partner_id AzapiProvider#disable_terraform_partner_id}
        /// </remarks>
        [JsiiProperty(name: "disableTerraformPartnerId", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? DisableTerraformPartnerId
        {
            get
            {
                return null;
            }
        }

        /// <summary>Enable Preflight Validation.</summary>
        /// <remarks>
        /// The default is false. When set to true, the provider will use Preflight to do static validation before really deploying a new resource. When set to false, the provider will disable this validation. This can also be sourced from the <c>ARM_ENABLE_PREFLIGHT</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#enable_preflight AzapiProvider#enable_preflight}
        /// </remarks>
        [JsiiProperty(name: "enablePreflight", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? EnablePreflight
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Azure API Endpoint Configuration.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#endpoint AzapiProvider#endpoint}
        /// </remarks>
        [JsiiProperty(name: "endpoint", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? Endpoint
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Cloud Environment which should be used.</summary>
        /// <remarks>
        /// Possible values are <c>public</c>, <c>usgovernment</c> and <c>china</c>. Defaults to <c>public</c>. This can also be sourced from the <c>ARM_ENVIRONMENT</c> Environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#environment AzapiProvider#environment}
        /// </remarks>
        [JsiiProperty(name: "environment", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? Environment
        {
            get
            {
                return null;
            }
        }

        /// <summary>The maximum number of retries to attempt if the Azure API returns an HTTP 408, 429, 500, 502, 503, or 504 response.</summary>
        /// <remarks>
        /// The default is <c>3</c>. The resource-specific retry configuration may additionally be used to retry on other errors and conditions.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#maximum_busy_retry_attempts AzapiProvider#maximum_busy_retry_attempts}
        /// </remarks>
        [JsiiProperty(name: "maximumBusyRetryAttempts", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        double? MaximumBusyRetryAttempts
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Azure Pipelines Service Connection ID to use for authentication.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_ADO_PIPELINE_SERVICE_CONNECTION_ID</c>, <c>ARM_OIDC_AZURE_SERVICE_CONNECTION_ID</c>, or <c>AZURESUBSCRIPTION_SERVICE_CONNECTION_ID</c> Environment Variables.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_azure_service_connection_id AzapiProvider#oidc_azure_service_connection_id}
        /// </remarks>
        [JsiiProperty(name: "oidcAzureServiceConnectionId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? OidcAzureServiceConnectionId
        {
            get
            {
                return null;
            }
        }

        /// <summary>The bearer token for the request to the OIDC provider.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_OIDC_REQUEST_TOKEN</c>, <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>, or <c>SYSTEM_ACCESSTOKEN</c> Environment Variables.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_token AzapiProvider#oidc_request_token}
        /// </remarks>
        [JsiiProperty(name: "oidcRequestToken", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? OidcRequestToken
        {
            get
            {
                return null;
            }
        }

        /// <summary>The URL for the OIDC provider from which to request an ID token.</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_OIDC_REQUEST_URL</c>, <c>ACTIONS_ID_TOKEN_REQUEST_URL</c>, or <c>SYSTEM_OIDCREQUESTURI</c> Environment Variables.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_url AzapiProvider#oidc_request_url}
        /// </remarks>
        [JsiiProperty(name: "oidcRequestUrl", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? OidcRequestUrl
        {
            get
            {
                return null;
            }
        }

        /// <summary>The ID token when authenticating using OpenID Connect (OIDC). This can also be sourced from the `ARM_OIDC_TOKEN` environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token AzapiProvider#oidc_token}
        /// </remarks>
        [JsiiProperty(name: "oidcToken", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? OidcToken
        {
            get
            {
                return null;
            }
        }

        /// <summary>The path to a file containing an ID token when authenticating using OpenID Connect (OIDC).</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_OIDC_TOKEN_FILE_PATH</c> environment Variable.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token_file_path AzapiProvider#oidc_token_file_path}
        /// </remarks>
        [JsiiProperty(name: "oidcTokenFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? OidcTokenFilePath
        {
            get
            {
                return null;
            }
        }

        /// <summary>A GUID/UUID that is [registered](https://docs.microsoft.com/azure/marketplace/azure-partner-customer-usage-attribution#register-guids-and-offers) with Microsoft to facilitate partner resource usage attribution. This can also be sourced from the `ARM_PARTNER_ID` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#partner_id AzapiProvider#partner_id}
        /// </remarks>
        [JsiiProperty(name: "partnerId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? PartnerId
        {
            get
            {
                return null;
            }
        }

        /// <summary>Should the Provider skip registering the Resource Providers it supports?</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_SKIP_PROVIDER_REGISTRATION</c> Environment Variable. Defaults to <c>false</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#skip_provider_registration AzapiProvider#skip_provider_registration}
        /// </remarks>
        [JsiiProperty(name: "skipProviderRegistration", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? SkipProviderRegistration
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Subscription ID which should be used. This can also be sourced from the `ARM_SUBSCRIPTION_ID` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#subscription_id AzapiProvider#subscription_id}
        /// </remarks>
        [JsiiProperty(name: "subscriptionId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? SubscriptionId
        {
            get
            {
                return null;
            }
        }

        /// <summary>The Tenant ID should be used. This can also be sourced from the `ARM_TENANT_ID` Environment Variable.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#tenant_id AzapiProvider#tenant_id}
        /// </remarks>
        [JsiiProperty(name: "tenantId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? TenantId
        {
            get
            {
                return null;
            }
        }

        /// <summary>Should AKS Workload Identity be used for Authentication?</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_USE_AKS_WORKLOAD_IDENTITY</c> Environment Variable. Defaults to <c>false</c>. When set, <c>client_id</c>, <c>tenant_id</c> and <c>oidc_token_file_path</c> will be detected from the environment and do not need to be specified.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_aks_workload_identity AzapiProvider#use_aks_workload_identity}
        /// </remarks>
        [JsiiProperty(name: "useAksWorkloadIdentity", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? UseAksWorkloadIdentity
        {
            get
            {
                return null;
            }
        }

        /// <summary>Should Azure CLI be used for authentication?</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_USE_CLI</c> environment variable. Defaults to <c>true</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_cli AzapiProvider#use_cli}
        /// </remarks>
        [JsiiProperty(name: "useCli", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? UseCli
        {
            get
            {
                return null;
            }
        }

        /// <summary>Should Managed Identity be used for Authentication?</summary>
        /// <remarks>
        /// This can also be sourced from the <c>ARM_USE_MSI</c> Environment Variable. Defaults to <c>false</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_msi AzapiProvider#use_msi}
        /// </remarks>
        [JsiiProperty(name: "useMsi", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? UseMsi
        {
            get
            {
                return null;
            }
        }

        /// <summary>Should OIDC be used for Authentication? This can also be sourced from the `ARM_USE_OIDC` Environment Variable. Defaults to `false`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_oidc AzapiProvider#use_oidc}
        /// </remarks>
        [JsiiProperty(name: "useOidc", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? UseOidc
        {
            get
            {
                return null;
            }
        }

        [JsiiTypeProxy(nativeType: typeof(IAzapiProviderConfig), fullyQualifiedName: "azapi.provider.AzapiProviderConfig")]
        internal sealed class _Proxy : DeputyBase, IAzapiProviderConfig
        {
            private _Proxy(ByRefValue reference): base(reference)
            {
            }

            /// <summary>Alias name.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#alias AzapiProvider#alias}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "alias", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? Alias
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>List of auxiliary Tenant IDs required for multi-tenancy and cross-tenant scenarios.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_AUXILIARY_TENANT_IDS</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#auxiliary_tenant_ids AzapiProvider#auxiliary_tenant_ids}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "auxiliaryTenantIds", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
            public string[]? AuxiliaryTenantIds
            {
                get => GetInstanceProperty<string[]?>();
            }

            /// <summary>A base64-encoded PKCS#12 bundle to be used as the client certificate for authentication.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE</c> environment variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate AzapiProvider#client_certificate}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientCertificate", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientCertificate
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The password associated with the Client Certificate. This can also be sourced from the `ARM_CLIENT_CERTIFICATE_PASSWORD` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_password AzapiProvider#client_certificate_password}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientCertificatePassword", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientCertificatePassword
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The path to the Client Certificate associated with the Service Principal which should be used.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_CLIENT_CERTIFICATE_PATH</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_certificate_path AzapiProvider#client_certificate_path}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientCertificatePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientCertificatePath
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The Client ID which should be used. This can also be sourced from the `ARM_CLIENT_ID` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id AzapiProvider#client_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The path to a file containing the Client ID which should be used.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_CLIENT_ID_FILE_PATH</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_id_file_path AzapiProvider#client_id_file_path}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientIdFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientIdFilePath
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The Client Secret which should be used. This can also be sourced from the `ARM_CLIENT_SECRET` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret AzapiProvider#client_secret}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientSecret", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientSecret
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The path to a file containing the Client Secret which should be used.</summary>
            /// <remarks>
            /// For use When authenticating as a Service Principal using a Client Secret. This can also be sourced from the <c>ARM_CLIENT_SECRET_FILE_PATH</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#client_secret_file_path AzapiProvider#client_secret_file_path}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "clientSecretFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ClientSecretFilePath
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The value of the `x-ms-correlation-request-id` header, otherwise an auto-generated UUID will be used.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_CORRELATION_REQUEST_ID</c> environment variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#custom_correlation_request_id AzapiProvider#custom_correlation_request_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "customCorrelationRequestId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? CustomCorrelationRequestId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The default Azure Region where the azure resource should exist.</summary>
            /// <remarks>
            /// The <c>location</c> in each resource block can override the <c>default_location</c>. Changing this forces new resources to be created.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_location AzapiProvider#default_location}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "defaultLocation", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? DefaultLocation
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The default name to create the azure resource.</summary>
            /// <remarks>
            /// The <c>name</c> in each resource block can override the <c>default_name</c>. Changing this forces new resources to be created.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_name AzapiProvider#default_name}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "defaultName", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? DefaultName
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>A mapping of tags which should be assigned to the azure resource as default tags.</summary>
            /// <remarks>
            /// The<c>tags</c> in each resource block can override the <c>default_tags</c>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#default_tags AzapiProvider#default_tags}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "defaultTags", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
            public System.Collections.Generic.IDictionary<string, string>? DefaultTags
            {
                get => GetInstanceProperty<System.Collections.Generic.IDictionary<string, string>?>();
            }

            /// <summary>This will disable the x-ms-correlation-request-id header.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_correlation_request_id AzapiProvider#disable_correlation_request_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "disableCorrelationRequestId", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? DisableCorrelationRequestId
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Disable default output.</summary>
            /// <remarks>
            /// The default is false. When set to false, the provider will output the read-only properties if <c>response_export_values</c> is not specified in the resource block. When set to true, the provider will disable this output. This can also be sourced from the <c>ARM_DISABLE_DEFAULT_OUTPUT</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_default_output AzapiProvider#disable_default_output}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "disableDefaultOutput", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? DisableDefaultOutput
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Disable sending the Terraform Partner ID if a custom `partner_id` isn't specified, which allows Microsoft to better understand the usage of Terraform.</summary>
            /// <remarks>
            /// The Partner ID does not give HashiCorp any direct access to usage information. This can also be sourced from the <c>ARM_DISABLE_TERRAFORM_PARTNER_ID</c> environment variable. Defaults to <c>false</c>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#disable_terraform_partner_id AzapiProvider#disable_terraform_partner_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "disableTerraformPartnerId", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? DisableTerraformPartnerId
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Enable Preflight Validation.</summary>
            /// <remarks>
            /// The default is false. When set to true, the provider will use Preflight to do static validation before really deploying a new resource. When set to false, the provider will disable this validation. This can also be sourced from the <c>ARM_ENABLE_PREFLIGHT</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#enable_preflight AzapiProvider#enable_preflight}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "enablePreflight", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? EnablePreflight
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>The Azure API Endpoint Configuration.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#endpoint AzapiProvider#endpoint}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "endpoint", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"fqn\":\"azapi.provider.AzapiProviderEndpoint\"},\"kind\":\"array\"}}]}}", isOptional: true)]
            public object? Endpoint
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>The Cloud Environment which should be used.</summary>
            /// <remarks>
            /// Possible values are <c>public</c>, <c>usgovernment</c> and <c>china</c>. Defaults to <c>public</c>. This can also be sourced from the <c>ARM_ENVIRONMENT</c> Environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#environment AzapiProvider#environment}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "environment", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? Environment
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The maximum number of retries to attempt if the Azure API returns an HTTP 408, 429, 500, 502, 503, or 504 response.</summary>
            /// <remarks>
            /// The default is <c>3</c>. The resource-specific retry configuration may additionally be used to retry on other errors and conditions.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#maximum_busy_retry_attempts AzapiProvider#maximum_busy_retry_attempts}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "maximumBusyRetryAttempts", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
            public double? MaximumBusyRetryAttempts
            {
                get => GetInstanceProperty<double?>();
            }

            /// <summary>The Azure Pipelines Service Connection ID to use for authentication.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_ADO_PIPELINE_SERVICE_CONNECTION_ID</c>, <c>ARM_OIDC_AZURE_SERVICE_CONNECTION_ID</c>, or <c>AZURESUBSCRIPTION_SERVICE_CONNECTION_ID</c> Environment Variables.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_azure_service_connection_id AzapiProvider#oidc_azure_service_connection_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "oidcAzureServiceConnectionId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? OidcAzureServiceConnectionId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The bearer token for the request to the OIDC provider.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_OIDC_REQUEST_TOKEN</c>, <c>ACTIONS_ID_TOKEN_REQUEST_TOKEN</c>, or <c>SYSTEM_ACCESSTOKEN</c> Environment Variables.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_token AzapiProvider#oidc_request_token}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "oidcRequestToken", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? OidcRequestToken
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The URL for the OIDC provider from which to request an ID token.</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_OIDC_REQUEST_URL</c>, <c>ACTIONS_ID_TOKEN_REQUEST_URL</c>, or <c>SYSTEM_OIDCREQUESTURI</c> Environment Variables.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_request_url AzapiProvider#oidc_request_url}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "oidcRequestUrl", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? OidcRequestUrl
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The ID token when authenticating using OpenID Connect (OIDC). This can also be sourced from the `ARM_OIDC_TOKEN` environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token AzapiProvider#oidc_token}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "oidcToken", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? OidcToken
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The path to a file containing an ID token when authenticating using OpenID Connect (OIDC).</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_OIDC_TOKEN_FILE_PATH</c> environment Variable.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#oidc_token_file_path AzapiProvider#oidc_token_file_path}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "oidcTokenFilePath", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? OidcTokenFilePath
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>A GUID/UUID that is [registered](https://docs.microsoft.com/azure/marketplace/azure-partner-customer-usage-attribution#register-guids-and-offers) with Microsoft to facilitate partner resource usage attribution. This can also be sourced from the `ARM_PARTNER_ID` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#partner_id AzapiProvider#partner_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "partnerId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? PartnerId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>Should the Provider skip registering the Resource Providers it supports?</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_SKIP_PROVIDER_REGISTRATION</c> Environment Variable. Defaults to <c>false</c>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#skip_provider_registration AzapiProvider#skip_provider_registration}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "skipProviderRegistration", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? SkipProviderRegistration
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>The Subscription ID which should be used. This can also be sourced from the `ARM_SUBSCRIPTION_ID` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#subscription_id AzapiProvider#subscription_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "subscriptionId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? SubscriptionId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The Tenant ID should be used. This can also be sourced from the `ARM_TENANT_ID` Environment Variable.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#tenant_id AzapiProvider#tenant_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "tenantId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? TenantId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>Should AKS Workload Identity be used for Authentication?</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_USE_AKS_WORKLOAD_IDENTITY</c> Environment Variable. Defaults to <c>false</c>. When set, <c>client_id</c>, <c>tenant_id</c> and <c>oidc_token_file_path</c> will be detected from the environment and do not need to be specified.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_aks_workload_identity AzapiProvider#use_aks_workload_identity}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "useAksWorkloadIdentity", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? UseAksWorkloadIdentity
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Should Azure CLI be used for authentication?</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_USE_CLI</c> environment variable. Defaults to <c>true</c>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_cli AzapiProvider#use_cli}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "useCli", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? UseCli
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Should Managed Identity be used for Authentication?</summary>
            /// <remarks>
            /// This can also be sourced from the <c>ARM_USE_MSI</c> Environment Variable. Defaults to <c>false</c>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_msi AzapiProvider#use_msi}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "useMsi", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? UseMsi
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>Should OIDC be used for Authentication? This can also be sourced from the `ARM_USE_OIDC` Environment Variable. Defaults to `false`.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs#use_oidc AzapiProvider#use_oidc}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "useOidc", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
            public object? UseOidc
            {
                get => GetInstanceProperty<object?>();
            }
        }
    }
}
