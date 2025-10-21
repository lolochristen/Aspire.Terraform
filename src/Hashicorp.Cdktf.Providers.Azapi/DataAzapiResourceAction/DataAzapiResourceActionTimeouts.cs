using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataAzapiResourceAction;

[JsiiByValue("azapi.dataAzapiResourceAction.DataAzapiResourceActionTimeouts")]
public class DataAzapiResourceActionTimeouts : IDataAzapiResourceActionTimeouts
{
    /// <summary>
    ///     A string that can be [parsed as a duration](https://pkg.go.dev/time#ParseDuration) consisting of numbers and
    ///     unit suffixes, such as "30s" or "2h45m". Valid time units are "s" (seconds), "m" (minutes), "h" (hours). Read
    ///     operations occur during any refresh or planning operation when refresh is enabled.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/data-sources/resource_action#read
    ///     DataAzapiResourceAction#read}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("read", "{\"primitive\":\"string\"}", true)]
    public string? Read { get; set; }
}