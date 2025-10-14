using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataPlaneResource
{
    #pragma warning disable CS8618

    [JsiiByValue(fqn: "azapi.dataPlaneResource.DataPlaneResourceConfig")]
    public class DataPlaneResourceConfig : IDataPlaneResourceConfig
    {
        /// <summary>Specifies the name of the Azure resource. Changing this forces a new resource to be created.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#name DataPlaneResource#name}
        /// </remarks>
        [JsiiProperty(name: "name", typeJson: "{\"primitive\":\"string\"}")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>The ID of the azure resource in which this resource is created.</summary>
        /// <remarks>
        /// Changing this forces a new resource to be created.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#parent_id DataPlaneResource#parent_id}
        /// </remarks>
        [JsiiProperty(name: "parentId", typeJson: "{\"primitive\":\"string\"}")]
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>In a format like `&lt;resource-type&gt;@&lt;api-version&gt;`.</summary>
        /// <remarks>
        /// <c>&lt;resource-type&gt;</c> is the Azure resource type, for example, <c>Microsoft.Storage/storageAccounts</c>. <c>&lt;api-version&gt;</c> is version of the API used to manage this azure resource.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#type DataPlaneResource#type}
        /// </remarks>
        [JsiiProperty(name: "type", typeJson: "{\"primitive\":\"string\"}")]
        public string Type
        {
            get;
            set;
        }

        /// <summary>A dynamic attribute that contains the request body.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#body DataPlaneResource#body}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "body", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, object>? Body
        {
            get;
            set;
        }

        /// <summary>A mapping of headers to be sent with the create request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#create_headers DataPlaneResource#create_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "createHeaders", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, string>? CreateHeaders
        {
            get;
            set;
        }

        private object? _createQueryParameters;

        /// <summary>A mapping of query parameters to be sent with the create request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#create_query_parameters DataPlaneResource#create_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "createQueryParameters", typeJson: "{\"union\":{\"types\":[{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        public object? CreateQueryParameters
        {
            get => _createQueryParameters;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case System.Collections.Generic.IDictionary<string, string[]> cast_cd4240:
                            break;
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: System.Collections.Generic.IDictionary<string, string[]>, {typeof(HashiCorp.Cdktf.IResolvable).FullName}; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _createQueryParameters = value;
            }
        }

        /// <summary>A mapping of headers to be sent with the delete request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#delete_headers DataPlaneResource#delete_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "deleteHeaders", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, string>? DeleteHeaders
        {
            get;
            set;
        }

        private object? _deleteQueryParameters;

        /// <summary>A mapping of query parameters to be sent with the delete request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#delete_query_parameters DataPlaneResource#delete_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "deleteQueryParameters", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}", isOptional: true)]
        public object? DeleteQueryParameters
        {
            get => _deleteQueryParameters;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case System.Collections.Generic.IDictionary<string, string[]> cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: {typeof(HashiCorp.Cdktf.IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _deleteQueryParameters = value;
            }
        }

        private object? _ignoreCasing;

        /// <summary>A dynamic attribute that contains the request body.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#ignore_casing DataPlaneResource#ignore_casing}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "ignoreCasing", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        public object? IgnoreCasing
        {
            get => _ignoreCasing;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case bool cast_cd4240:
                            break;
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(HashiCorp.Cdktf.IResolvable).FullName}; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _ignoreCasing = value;
            }
        }

        private object? _ignoreMissingProperty;

        /// <summary>Whether ignore not returned properties like credentials in `body` to suppress plan-diff.</summary>
        /// <remarks>
        /// Defaults to <c>true</c>. It's recommend to enable this option when some sensitive properties are not returned in response body, instead of setting them in <c>lifecycle.ignore_changes</c> because it will make the sensitive fields unable to update.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#ignore_missing_property DataPlaneResource#ignore_missing_property}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "ignoreMissingProperty", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"boolean\"},{\"fqn\":\"cdktf.IResolvable\"}]}}", isOptional: true)]
        public object? IgnoreMissingProperty
        {
            get => _ignoreMissingProperty;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case bool cast_cd4240:
                            break;
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: bool, {typeof(HashiCorp.Cdktf.IResolvable).FullName}; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _ignoreMissingProperty = value;
            }
        }

        /// <summary>A list of ARM resource IDs which are used to avoid create/modify/delete azapi resources at the same time.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#locks DataPlaneResource#locks}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "locks", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
        public string[]? Locks
        {
            get;
            set;
        }

        /// <summary>A mapping of headers to be sent with the read request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#read_headers DataPlaneResource#read_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "readHeaders", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, string>? ReadHeaders
        {
            get;
            set;
        }

        private object? _readQueryParameters;

        /// <summary>A mapping of query parameters to be sent with the read request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#read_query_parameters DataPlaneResource#read_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "readQueryParameters", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}", isOptional: true)]
        public object? ReadQueryParameters
        {
            get => _readQueryParameters;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case System.Collections.Generic.IDictionary<string, string[]> cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: {typeof(HashiCorp.Cdktf.IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _readQueryParameters = value;
            }
        }

        /// <summary>Will trigger a replace of the resource when the value changes and is not `null`.</summary>
        /// <remarks>
        /// This can be used by practitioners to force a replace of the resource when certain values change, e.g. changing the SKU of a virtual machine based on the value of variables or locals. The value is a <c>dynamic</c>, so practitioners can compose the input however they wish. For a "break glass" set the value to <c>null</c> to prevent the plan modifier taking effect.
        /// If you have <c>null</c> values that you do want to be tracked as affecting the resource replacement, include these inside an object.
        /// Advanced use cases are possible and resource replacement can be triggered by values external to the resource, for example when a dependent resource changes.
        ///
        /// e.g. to replace a resource when either the SKU or os_type attributes change:
        ///
        /// <code><![CDATA[
        /// resource "azapi_data_plane_resource" "example" {
        ///   name = var.name
        ///   type = "Microsoft.AppConfiguration/configurationStores/keyValues@1.0"
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
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#replace_triggers_external_values DataPlaneResource#replace_triggers_external_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "replaceTriggersExternalValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, object>? ReplaceTriggersExternalValues
        {
            get;
            set;
        }

        /// <summary>A list of paths in the current Terraform configuration.</summary>
        /// <remarks>
        /// When the values at these paths change, the resource will be replaced.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#replace_triggers_refs DataPlaneResource#replace_triggers_refs}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "replaceTriggersRefs", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}", isOptional: true)]
        public string[]? ReplaceTriggersRefs
        {
            get;
            set;
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
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#response_export_values DataPlaneResource#response_export_values}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "responseExportValues", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, object>? ResponseExportValues
        {
            get;
            set;
        }

        /// <summary>The retry object supports the following attributes:.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#retry DataPlaneResource#retry}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "retry", typeJson: "{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceRetry\"}", isOptional: true)]
        public IDataPlaneResourceRetry? Retry
        {
            get;
            set;
        }

        /// <summary>timeouts block.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#timeouts DataPlaneResource#timeouts}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "timeouts", typeJson: "{\"fqn\":\"azapi.dataPlaneResource.DataPlaneResourceTimeouts\"}", isOptional: true)]
        public IDataPlaneResourceTimeouts? Timeouts
        {
            get;
            set;
        }

        /// <summary>A mapping of headers to be sent with the update request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#update_headers DataPlaneResource#update_headers}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "updateHeaders", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"map\"}}", isOptional: true)]
        public System.Collections.Generic.IDictionary<string, string>? UpdateHeaders
        {
            get;
            set;
        }

        private object? _updateQueryParameters;

        /// <summary>A mapping of query parameters to be sent with the update request.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#update_query_parameters DataPlaneResource#update_query_parameters}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "updateQueryParameters", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.IResolvable\"},{\"collection\":{\"elementtype\":{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}},\"kind\":\"map\"}}]}}", isOptional: true)]
        public object? UpdateQueryParameters
        {
            get => _updateQueryParameters;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case HashiCorp.Cdktf.IResolvable cast_cd4240:
                            break;
                        case System.Collections.Generic.IDictionary<string, string[]> cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: {typeof(HashiCorp.Cdktf.IResolvable).FullName}, System.Collections.Generic.IDictionary<string, string[]>; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _updateQueryParameters = value;
            }
        }

        private object? _connection;

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "connection", typeJson: "{\"union\":{\"types\":[{\"fqn\":\"cdktf.SSHProvisionerConnection\"},{\"fqn\":\"cdktf.WinrmProvisionerConnection\"}]}}", isOptional: true)]
        public object? Connection
        {
            get => _connection;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case HashiCorp.Cdktf.ISSHProvisionerConnection cast_cd4240:
                            break;
                        case HashiCorp.Cdktf.IWinrmProvisionerConnection cast_cd4240:
                            break;
                        case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_cd4240:
                            // Not enough information to type-check...
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: {typeof(HashiCorp.Cdktf.ISSHProvisionerConnection).FullName}, {typeof(HashiCorp.Cdktf.IWinrmProvisionerConnection).FullName}; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _connection = value;
            }
        }

        private object? _count;

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "count", typeJson: "{\"union\":{\"types\":[{\"primitive\":\"number\"},{\"fqn\":\"cdktf.TerraformCount\"}]}}", isOptional: true)]
        public object? Count
        {
            get => _count;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    switch (value)
                    {
                        case double cast_cd4240:
                            break;
                        case byte cast_cd4240:
                            break;
                        case decimal cast_cd4240:
                            break;
                        case float cast_cd4240:
                            break;
                        case int cast_cd4240:
                            break;
                        case long cast_cd4240:
                            break;
                        case sbyte cast_cd4240:
                            break;
                        case short cast_cd4240:
                            break;
                        case uint cast_cd4240:
                            break;
                        case ulong cast_cd4240:
                            break;
                        case ushort cast_cd4240:
                            break;
                        case HashiCorp.Cdktf.TerraformCount cast_cd4240:
                            break;
                        case null:
                            break;
                        default:
                            throw new System.ArgumentException($"Expected {nameof(value)} to be one of: double, {typeof(HashiCorp.Cdktf.TerraformCount).FullName}; received {value.GetType().FullName}", nameof(value));
                    }
                }
                _count = value;
            }
        }

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "dependsOn", typeJson: "{\"collection\":{\"elementtype\":{\"fqn\":\"cdktf.ITerraformDependable\"},\"kind\":\"array\"}}", isOptional: true)]
        public HashiCorp.Cdktf.ITerraformDependable[]? DependsOn
        {
            get;
            set;
        }

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "forEach", typeJson: "{\"fqn\":\"cdktf.ITerraformIterator\"}", isOptional: true)]
        public HashiCorp.Cdktf.ITerraformIterator? ForEach
        {
            get;
            set;
        }

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "lifecycle", typeJson: "{\"fqn\":\"cdktf.TerraformResourceLifecycle\"}", isOptional: true)]
        public HashiCorp.Cdktf.ITerraformResourceLifecycle? Lifecycle
        {
            get;
            set;
        }

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "provider", typeJson: "{\"fqn\":\"cdktf.TerraformProvider\"}", isOptional: true)]
        public HashiCorp.Cdktf.TerraformProvider? Provider
        {
            get;
            set;
        }

        private object[]? _provisioners;

        /// <remarks>
        /// <strong>Stability</strong>: Experimental
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "provisioners", typeJson: "{\"collection\":{\"elementtype\":{\"union\":{\"types\":[{\"fqn\":\"cdktf.FileProvisioner\"},{\"fqn\":\"cdktf.LocalExecProvisioner\"},{\"fqn\":\"cdktf.RemoteExecProvisioner\"}]}},\"kind\":\"array\"}}", isOptional: true)]
        public object[]? Provisioners
        {
            get => _provisioners;
            set
            {
                if (Amazon.JSII.Runtime.Configuration.RuntimeTypeChecking)
                {
                    for (var __idx_cd4240 = 0 ; __idx_cd4240 < value.Length ; __idx_cd4240++)
                    {
                        switch (value[__idx_cd4240])
                        {
                            case HashiCorp.Cdktf.IFileProvisioner cast_e9c63e:
                                break;
                            case HashiCorp.Cdktf.ILocalExecProvisioner cast_e9c63e:
                                break;
                            case HashiCorp.Cdktf.IRemoteExecProvisioner cast_e9c63e:
                                break;
                            case Amazon.JSII.Runtime.Deputy.AnonymousObject cast_e9c63e:
                                // Not enough information to type-check...
                                break;
                            case null:
                                throw new System.ArgumentException($"Expected {nameof(value)}[{__idx_cd4240}] to be one of: {typeof(HashiCorp.Cdktf.IFileProvisioner).FullName}, {typeof(HashiCorp.Cdktf.ILocalExecProvisioner).FullName}, {typeof(HashiCorp.Cdktf.IRemoteExecProvisioner).FullName}; received null", nameof(value));
                            default:
                                throw new System.ArgumentException($"Expected {nameof(value)}[{__idx_cd4240}] to be one of: {typeof(HashiCorp.Cdktf.IFileProvisioner).FullName}, {typeof(HashiCorp.Cdktf.ILocalExecProvisioner).FullName}, {typeof(HashiCorp.Cdktf.IRemoteExecProvisioner).FullName}; received {value[__idx_cd4240].GetType().FullName}", nameof(value));
                        }
                    }
                }
                _provisioners = value;
            }
        }
    }
}
