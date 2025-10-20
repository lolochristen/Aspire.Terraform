using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.ResourceAction;

[JsiiInterface(typeof(IResourceActionRetry), "azapi.resourceAction.ResourceActionRetry")]
public interface IResourceActionRetry
{
    /// <summary>A list of regular expressions to match against error messages.</summary>
    /// <remarks>
    ///     If any of the regular expressions match, the request will be retried.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#error_message_regex
    ///     ResourceAction#error_message_regex}
    /// </remarks>
    [JsiiProperty("errorMessageRegex", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
    string[] ErrorMessageRegex { get; }

    /// <summary>The base number of seconds to wait between retries. Default is `10`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#interval_seconds
    ///     ResourceAction#interval_seconds}
    /// </remarks>
    [JsiiProperty("intervalSeconds", "{\"primitive\":\"number\"}", true)]
    [JsiiOptional]
    double? IntervalSeconds => null;

    /// <summary>The maximum number of seconds to wait between retries. Default is `180`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#max_interval_seconds
    ///     ResourceAction#max_interval_seconds}
    /// </remarks>
    [JsiiProperty("maxIntervalSeconds", "{\"primitive\":\"number\"}", true)]
    [JsiiOptional]
    double? MaxIntervalSeconds => null;

    /// <summary>The multiplier to apply to the interval between retries. Default is `1.5`.</summary>
    /// <remarks>
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#multiplier
    ///     ResourceAction#multiplier}
    /// </remarks>
    [JsiiProperty("multiplier", "{\"primitive\":\"number\"}", true)]
    [JsiiOptional]
    double? Multiplier => null;

    /// <summary>The randomization factor to apply to the interval between retries.</summary>
    /// <remarks>
    ///     The formula for the randomized interval is:
    ///     <c>RetryInterval * (random value in range [1 - RandomizationFactor, 1 + RandomizationFactor])</c>. Therefore set to
    ///     zero <c>0.0</c> for no randomization. Default is <c>0.5</c>.
    ///     Docs at Terraform Registry: {@link
    ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#randomization_factor
    ///     ResourceAction#randomization_factor}
    /// </remarks>
    [JsiiProperty("randomizationFactor", "{\"primitive\":\"number\"}", true)]
    [JsiiOptional]
    double? RandomizationFactor => null;

    [JsiiTypeProxy(typeof(IResourceActionRetry), "azapi.resourceAction.ResourceActionRetry")]
    internal sealed class _Proxy : DeputyBase, IResourceActionRetry
    {
        private _Proxy(ByRefValue reference) : base(reference)
        {
        }

        /// <summary>A list of regular expressions to match against error messages.</summary>
        /// <remarks>
        ///     If any of the regular expressions match, the request will be retried.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#error_message_regex
        ///     ResourceAction#error_message_regex}
        /// </remarks>
        [JsiiProperty("errorMessageRegex", "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
        public string[] ErrorMessageRegex => GetInstanceProperty<string[]>()!;

        /// <summary>The base number of seconds to wait between retries. Default is `10`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#interval_seconds
        ///     ResourceAction#interval_seconds}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("intervalSeconds", "{\"primitive\":\"number\"}", true)]
        public double? IntervalSeconds => GetInstanceProperty<double?>();

        /// <summary>The maximum number of seconds to wait between retries. Default is `180`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#max_interval_seconds
        ///     ResourceAction#max_interval_seconds}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("maxIntervalSeconds", "{\"primitive\":\"number\"}", true)]
        public double? MaxIntervalSeconds => GetInstanceProperty<double?>();

        /// <summary>The multiplier to apply to the interval between retries. Default is `1.5`.</summary>
        /// <remarks>
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#multiplier
        ///     ResourceAction#multiplier}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("multiplier", "{\"primitive\":\"number\"}", true)]
        public double? Multiplier => GetInstanceProperty<double?>();

        /// <summary>The randomization factor to apply to the interval between retries.</summary>
        /// <remarks>
        ///     The formula for the randomized interval is:
        ///     <c>RetryInterval * (random value in range [1 - RandomizationFactor, 1 + RandomizationFactor])</c>. Therefore set to
        ///     zero <c>0.0</c> for no randomization. Default is <c>0.5</c>.
        ///     Docs at Terraform Registry: {@link
        ///     https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource_action#randomization_factor
        ///     ResourceAction#randomization_factor}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty("randomizationFactor", "{\"primitive\":\"number\"}", true)]
        public double? RandomizationFactor => GetInstanceProperty<double?>();
    }
}