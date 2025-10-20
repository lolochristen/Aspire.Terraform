using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataPlaneResource;

[JsiiByValue("azapi.dataPlaneResource.DataPlaneResourceTimeouts")]
public class DataPlaneResourceTimeouts : IDataPlaneResourceTimeouts
{
    /// <summary>
    ///     A string that can be [parsed as a duration](https://pkg.go.dev/time#ParseDuration) consisting of numbers and
    ///     unit suffixes, such as "30s" or "2h45m". Valid time units are "s" (seconds), "m" (minutes), "h" (hours).
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#create
    ///     DataPlaneResource#create}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("create", "{\"primitive\":\"string\"}", true)]
    public string? Create { get; set; }

    /// <summary>
    ///     A string that can be [parsed as a duration](https://pkg.go.dev/time#ParseDuration) consisting of numbers and
    ///     unit suffixes, such as "30s" or "2h45m". Valid time units are "s" (seconds), "m" (minutes), "h" (hours). Setting a
    ///     timeout for a Delete operation is only applicable if changes are saved into state before the destroy operation
    ///     occurs.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#delete
    ///     DataPlaneResource#delete}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("delete", "{\"primitive\":\"string\"}", true)]
    public string? Delete { get; set; }

    /// <summary>
    ///     A string that can be [parsed as a duration](https://pkg.go.dev/time#ParseDuration) consisting of numbers and
    ///     unit suffixes, such as "30s" or "2h45m". Valid time units are "s" (seconds), "m" (minutes), "h" (hours). Read
    ///     operations occur during any refresh or planning operation when refresh is enabled.
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#read
    ///     DataPlaneResource#read}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("read", "{\"primitive\":\"string\"}", true)]
    public string? Read { get; set; }

    /// <summary>
    ///     A string that can be [parsed as a duration](https://pkg.go.dev/time#ParseDuration) consisting of numbers and
    ///     unit suffixes, such as "30s" or "2h45m". Valid time units are "s" (seconds), "m" (minutes), "h" (hours).
    /// </summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#update
    ///     DataPlaneResource#update}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("update", "{\"primitive\":\"string\"}", true)]
    public string? Update { get; set; }
}