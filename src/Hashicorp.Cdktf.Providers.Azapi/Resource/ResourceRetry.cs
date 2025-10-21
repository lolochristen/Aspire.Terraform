using Amazon.JSII.Runtime.Deputy;

#pragma warning disable CS0672,CS0809,CS1591

namespace Hashicorp.Cdktf.Providers.Azapi.Resource
{
    #pragma warning disable CS8618

    [JsiiByValue(fqn: "azapi.resource.ResourceRetry")]
    public class ResourceRetry : IResourceRetry
    {
        /// <summary>A list of regular expressions to match against error messages.</summary>
        /// <remarks>
        /// If any of the regular expressions match, the request will be retried.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#error_message_regex Resource#error_message_regex}
        /// </remarks>
        [JsiiProperty(name: "errorMessageRegex", typeJson: "{\"collection\":{\"elementtype\":{\"primitive\":\"string\"},\"kind\":\"array\"}}")]
        public string[] ErrorMessageRegex
        {
            get;
            set;
        }

        /// <summary>The base number of seconds to wait between retries. Default is `10`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#interval_seconds Resource#interval_seconds}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "intervalSeconds", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
        public double? IntervalSeconds
        {
            get;
            set;
        }

        /// <summary>The maximum number of seconds to wait between retries. Default is `180`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#max_interval_seconds Resource#max_interval_seconds}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "maxIntervalSeconds", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
        public double? MaxIntervalSeconds
        {
            get;
            set;
        }

        /// <summary>The multiplier to apply to the interval between retries. Default is `1.5`.</summary>
        /// <remarks>
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#multiplier Resource#multiplier}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "multiplier", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
        public double? Multiplier
        {
            get;
            set;
        }

        /// <summary>The randomization factor to apply to the interval between retries.</summary>
        /// <remarks>
        /// The formula for the randomized interval is: <c>RetryInterval * (random value in range [1 - RandomizationFactor, 1 + RandomizationFactor])</c>. Therefore set to zero <c>0.0</c> for no randomization. Default is <c>0.5</c>.
        ///
        /// Docs at Terraform Registry: {@link https://registry.terraform.io/providers/azure/azapi/2.4.0/docs/resources/resource#randomization_factor Resource#randomization_factor}
        /// </remarks>
        [JsiiOptional]
        [JsiiProperty(name: "randomizationFactor", typeJson: "{\"primitive\":\"number\"}", isOptional: true)]
        public double? RandomizationFactor
        {
            get;
            set;
        }
    }
}
