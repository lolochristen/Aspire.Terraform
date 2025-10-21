using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.DataPlaneResource;
#pragma warning disable CS8618

[JsiiByValue("azapi.dataPlaneResource.DataPlaneResourceRetry")]
public class DataPlaneResourceRetry : IDataPlaneResourceRetry
{
    /// <summary>A list of regular expressions to match against error messages.</summary>
    /// <remarks>
    ///     If any of the regular expressions match, the request will be retried.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#error_message_regex
    ///     DataPlaneResource#error_message_regex}
    /// </remarks>
    [JsiiProperty("errorMessageRegex", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    public string[] ErrorMessageRegex { get; set; }

    /// <summary>The base number of seconds to wait between retries. Default is `10`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#interval_seconds
    ///     DataPlaneResource#interval_seconds}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("intervalSeconds", "{\"primitive\":\"number\"}", true)]
    public double? IntervalSeconds { get; set; }

    /// <summary>The maximum number of seconds to wait between retries. Default is `180`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#max_interval_seconds
    ///     DataPlaneResource#max_interval_seconds}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("maxIntervalSeconds", "{\"primitive\":\"number\"}", true)]
    public double? MaxIntervalSeconds { get; set; }

    /// <summary>The multiplier to apply to the interval between retries. Default is `1.5`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#multiplier
    ///     DataPlaneResource#multiplier}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("multiplier", "{\"primitive\":\"number\"}", true)]
    public double? Multiplier { get; set; }

    /// <summary>The randomization factor to apply to the interval between retries.</summary>
    /// <remarks>
    ///     The formula for the randomized interval is:
    ///     <c>RetryInterval * (random value in range [1 - RandomizationFactor, 1 + RandomizationFactor])</c>. Therefore set to
    ///     zero <c>0.0</c> for no randomization. Default is <c>0.5</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/data_plane_resource#randomization_factor
    ///     DataPlaneResource#randomization_factor}
    /// </remarks>
    [JsiiOptional]
    [JsiiProperty("randomizationFactor", "{\"primitive\":\"number\"}", true)]
    public double? RandomizationFactor { get; set; }
}