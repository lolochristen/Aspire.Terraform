using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Cdk;

public class TerraformCdkPublisher(
    ILogger<TerraformCdkPublisher> logger,
    IPublishingActivityReporter progressReporter,
    DistributedApplicationExecutionContext executionContext,
    IOptions<PublishingOptions> publishingOptions,
    IOptions<TerraformCdkPublishingOptions> terraformPublishingOptions,
    IServiceProvider services) : IDistributedApplicationPublisher
{
    public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
    {
        var multipleEnvironments = model.Resources.OfType<TerraformCdkEnvironmentResource>().Count() > 1;

        foreach (var terraformCdkResource in model.Resources.OfType<TerraformCdkEnvironmentResource>())
        {
            var outputPath = publishingOptions.Value.OutputPath;

            if (multipleEnvironments) outputPath += "/" + terraformCdkResource.Name;

            var terraformPublishingContext = new TerraformCdkPublishingContext(executionContext, terraformPublishingOptions.Value, outputPath, terraformCdkResource.Name, services);

            await terraformPublishingContext.Synth(model, terraformCdkResource.Stacks, cancellationToken);
        }
    }
}