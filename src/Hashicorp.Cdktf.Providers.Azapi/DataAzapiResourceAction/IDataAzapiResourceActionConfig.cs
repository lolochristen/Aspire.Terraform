using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceAction
{
    [JsiiInterface(nativeType: typeof(IDataAzapiResourceActionConfig), fullyQualifiedName: "azapi.dataAzapiResourceAction.DataAzapiResourceActionConfig")]
    public interface IDataAzapiResourceActionConfig : HashiCorp.Cdktf.ITerraformMetaArguments
    {
        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        /// <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>. <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#type DataAzapiResourceAction#type}
        /// </remarks>
        [JsiiProperty(name: "type", typeJson: "{\"primitive\":\"string\"}")]
        string Type
        {
            get;
        }

        /// <summary>The name of the resource action.</summary>
        /// <remarks>
        /// It's also possible to make HTTP requests towards the resource ID if leave this field empty.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#action DataAzapiResourceAction#action}
        /// </remarks>
        [JsiiProperty(name: "action", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? Action
        {
            get
            {
                return null;
            }
        }

        /// <summary>Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#body DataAzapiResourceAction#body}.</summary>
        [JsiiProperty(name: "body", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        System.Collections.Generic.IDictionary<string, object>? Body
        {
            get
            {
                return null;
            }
        }

        /// <summary>A map of headers to include in the request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#headers DataAzapiResourceAction#headers}
        /// </remarks>
        [JsiiProperty(name: "headers", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        System.Collections.Generic.IDictionary<string, string>? Headers
        {
            get
            {
                return null;
            }
        }

        /// <summary>The HTTP method to use when performing the action. Must be one of `POST`, `GET`. Defaults to `POST`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#method DataAzapiResourceAction#method}
        /// </remarks>
        [JsiiProperty(name: "method", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? Method
        {
            get
            {
                return null;
            }
        }

        /// <summary>A map of query parameters to include in the request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#query_parameters DataAzapiResourceAction#query_parameters}
        /// </remarks>
        [JsiiProperty(name: "queryParameters", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        object? QueryParameters
        {
            get
            {
                return null;
            }
        }

        /// <summary>The ID of the Azure resource to perform the action on.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#resource_id DataAzapiResourceAction#resource_id}
        /// </remarks>
        [JsiiProperty(name: "resourceId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        string? ResourceId
        {
            get
            {
                return null;
            }
        }

        /// <summary>The attribute can accept either a list or a map.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <description><strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following HCL object to the computed property output.
        ///
        /// <code><![CDATA[
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
        /// ]]></code></description>
        /// <description><strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query string to filter the response. Here's an example. If it sets to <c>{"login_server": "properties.loginServer", "quarantine_status": "properties.policies.quarantinePolicy.status"}</c>, it will set the following HCL object to the computed property output.
        ///
        /// <code><![CDATA[
        /// {
        /// 	"login_server" = "registry1.azurecr.io"
        /// 	"quarantine_status" = "disabled"
        /// }
        /// ]]></code></description>
        /// </list>
        ///
        /// To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#response_export_values DataAzapiResourceAction#response_export_values}
        /// </remarks>
        [JsiiProperty(name: "responseExportValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        System.Collections.Generic.IDictionary<string, object>? ResponseExportValues
        {
            get
            {
                return null;
            }
        }

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#retry DataAzapiResourceAction#retry}
        /// </remarks>
        [JsiiProperty(name: "retry", typeJson: "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        IDataAzapiResourceActionRetry? Retry
        {
            get
            {
                return null;
            }
        }

        /// <summary>The attribute can accept either a list or a map.</summary>
        /// <remarks>
        /// <list type="bullet">
        /// <description><strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following HCL object to the computed property sensitive_output.
        ///
        /// <code><![CDATA[
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
        /// ]]></code></description>
        /// <description><strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query string to filter the response. Here's an example. If it sets to <c>{"login_server": "properties.loginServer", "quarantine_status": "properties.policies.quarantinePolicy.status"}</c>, it will set the following HCL object to the computed property sensitive_output.
        ///
        /// <code><![CDATA[
        /// {
        /// 	"login_server" = "registry1.azurecr.io"
        /// 	"quarantine_status" = "disabled"
        /// }
        /// ]]></code></description>
        /// </list>
        ///
        /// To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#sensitive_response_export_values DataAzapiResourceAction#sensitive_response_export_values}
        /// </remarks>
        [JsiiProperty(name: "sensitiveResponseExportValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        System.Collections.Generic.IDictionary<string, object>? SensitiveResponseExportValues
        {
            get
            {
                return null;
            }
        }

        /// <summary>timeouts block.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#timeouts DataAzapiResourceAction#timeouts}
        /// </remarks>
        [JsiiProperty(name: "timeouts", typeJson: "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}", isOptional: true)]
        [Amazon.JSII.Runtime.Deputy.JsiiOptional]
        IDataAzapiResourceActionTimeouts? Timeouts
        {
            get
            {
                return null;
            }
        }

        [JsiiTypeProxy(nativeType: typeof(IDataAzapiResourceActionConfig), fullyQualifiedName: "azapi.dataAzapiResourceAction.DataAzapiResourceActionConfig")]
        internal sealed class _Proxy : DeputyBase, IDataAzapiResourceActionConfig
        {
            private _Proxy(ByRefValue reference): base(reference)
            {
            }

            /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
            /// <remarks>
            /// <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>. <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#type DataAzapiResourceAction#type}
            /// </remarks>
            [JsiiProperty(name: "type", typeJson: "{\"primitive\":\"string\"}")]
            public string Type
            {
                get => GetInstanceProperty<string>()!;
            }

            /// <summary>The name of the resource action.</summary>
            /// <remarks>
            /// It's also possible to make HTTP requests towards the resource ID if leave this field empty.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#action DataAzapiResourceAction#action}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "action", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? Action
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#body DataAzapiResourceAction#body}.</summary>
            [JsiiOptional]
            [JsiiProperty(name: "body", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
            public System.Collections.Generic.IDictionary<string, object>? Body
            {
                get => GetInstanceProperty<System.Collections.Generic.IDictionary<string, object>?>();
            }

            /// <summary>A map of headers to include in the request.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#headers DataAzapiResourceAction#headers}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "headers", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
            public System.Collections.Generic.IDictionary<string, string>? Headers
            {
                get => GetInstanceProperty<System.Collections.Generic.IDictionary<string, string>?>();
            }

            /// <summary>The HTTP method to use when performing the action. Must be one of `POST`, `GET`. Defaults to `POST`.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#method DataAzapiResourceAction#method}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "method", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? Method
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>A map of query parameters to include in the request.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#query_parameters DataAzapiResourceAction#query_parameters}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "queryParameters", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}", isOptional: true)]
            public object? QueryParameters
            {
                get => GetInstanceProperty<object?>();
            }

            /// <summary>The ID of the Azure resource to perform the action on.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#resource_id DataAzapiResourceAction#resource_id}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "resourceId", typeJson: "{\"primitive\":\"string\"}", isOptional: true)]
            public string? ResourceId
            {
                get => GetInstanceProperty<string?>();
            }

            /// <summary>The attribute can accept either a list or a map.</summary>
            /// <remarks>
            /// <list type="bullet">
            /// <description><strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following HCL object to the computed property output.
            ///
            /// <code><![CDATA[
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
            /// ]]></code></description>
            /// <description><strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query string to filter the response. Here's an example. If it sets to <c>{"login_server": "properties.loginServer", "quarantine_status": "properties.policies.quarantinePolicy.status"}</c>, it will set the following HCL object to the computed property output.
            ///
            /// <code><![CDATA[
            /// {
            /// 	"login_server" = "registry1.azurecr.io"
            /// 	"quarantine_status" = "disabled"
            /// }
            /// ]]></code></description>
            /// </list>
            ///
            /// To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#response_export_values DataAzapiResourceAction#response_export_values}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "responseExportValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
            public System.Collections.Generic.IDictionary<string, object>? ResponseExportValues
            {
                get => GetInstanceProperty<System.Collections.Generic.IDictionary<string, object>?>();
            }

            /// <summary>The retry object supports the following attributes:.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#retry DataAzapiResourceAction#retry}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "retry", typeJson: "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionRetry\"}", isOptional: true)]
            public IDataAzapiResourceActionRetry? Retry
            {
                get => GetInstanceProperty<IDataAzapiResourceActionRetry?>();
            }

            /// <summary>The attribute can accept either a list or a map.</summary>
            /// <remarks>
            /// <list type="bullet">
            /// <description><strong>List</strong>: A list of paths that need to be exported from the response body. Setting it to <c>["*"]</c> will export the full response body. Here's an example. If it sets to <c>["properties.loginServer", "properties.policies.quarantinePolicy.status"]</c>, it will set the following HCL object to the computed property sensitive_output.
            ///
            /// <code><![CDATA[
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
            /// ]]></code></description>
            /// <description><strong>Map</strong>: A map where the key is the name for the result and the value is a JMESPath query string to filter the response. Here's an example. If it sets to <c>{"login_server": "properties.loginServer", "quarantine_status": "properties.policies.quarantinePolicy.status"}</c>, it will set the following HCL object to the computed property sensitive_output.
            ///
            /// <code><![CDATA[
            /// {
            /// 	"login_server" = "registry1.azurecr.io"
            /// 	"quarantine_status" = "disabled"
            /// }
            /// ]]></code></description>
            /// </list>
            ///
            /// To learn more about JMESPath, visit <a href="https://jmespath.org/">JMESPath</a>.
            ///
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#sensitive_response_export_values DataAzapiResourceAction#sensitive_response_export_values}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "sensitiveResponseExportValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
            public System.Collections.Generic.IDictionary<string, object>? SensitiveResponseExportValues
            {
                get => GetInstanceProperty<System.Collections.Generic.IDictionary<string, object>?>();
            }

            /// <summary>timeouts block.</summary>
            /// <remarks>
            /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#timeouts DataAzapiResourceAction#timeouts}
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "timeouts", typeJson: "{\"fqn\":\"azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts\"}", isOptional: true)]
            public IDataAzapiResourceActionTimeouts? Timeouts
            {
                get => GetInstanceProperty<IDataAzapiResourceActionTimeouts?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "connection", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.SSHProvisionerConnection\"},{\"fqn\":\"cdktf.WinrmProvisionerConnection\"}]}}", isOptional: true)]
            public object? Connection
            {
                get => GetInstanceProperty<object?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "count", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"number\"},{\"fqn\":\"cdktf.TerraformCount\"}]}}", isOptional: true)]
            public object? Count
            {
                get => GetInstanceProperty<object?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "dependsOn", typeJson: "{\"collection\":{\"elementtype\":{\"fqn\":\"cdktf.ITerraformDependable\"},\"kind\":\"array\"}}", isOptional: true)]
            public HashiCorp.Cdktf.ITerraformDependable[]? DependsOn
            {
                get => GetInstanceProperty<HashiCorp.Cdktf.ITerraformDependable[]?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "forEach", typeJson: "{\"fqn\":\"cdktf.ITerraformIterator\"}", isOptional: true)]
            public HashiCorp.Cdktf.ITerraformIterator? ForEach
            {
                get => GetInstanceProperty<HashiCorp.Cdktf.ITerraformIterator?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "lifecycle", typeJson: "{\"fqn\":\"cdktf.TerraformResourceLifecycle\"}", isOptional: true)]
            public HashiCorp.Cdktf.ITerraformResourceLifecycle? Lifecycle
            {
                get => GetInstanceProperty<HashiCorp.Cdktf.ITerraformResourceLifecycle?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "provider", typeJson: "{\"fqn\":\"cdktf.TerraformProvider\"}", isOptional: true)]
            public HashiCorp.Cdktf.TerraformProvider? Provider
            {
                get => GetInstanceProperty<HashiCorp.Cdktf.TerraformProvider?>();
            }

            /// <remarks>
            /// <strong>Stability</strong>: Experimental
            /// </remarks>
            [JsiiOptional]
            [JsiiProperty(name: "provisioners", typeJson: "{\"collection\":{\"elementtype\":{\"union\":{\"types\":[{\"fqn\":\"cdktf.FileProvisioner\"},{\"fqn\":\"cdktf.LocalExecProvisioner\"},{\"fqn\":\"cdktf.RemoteExecProvisioner\"}]}},\"kind\":\"array\"}}", isOptional: true)]
            public object[]? Provisioners
            {
                get => GetInstanceProperty<object[]?>();
            }
        }
    }
}
