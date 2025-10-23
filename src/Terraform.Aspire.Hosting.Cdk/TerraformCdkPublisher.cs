using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Cdk;

/// <summary>
/// Publisher implementation for generating Terraform configuration using CDK for Terraform (CDKTF).
/// Processes CDK environments and stacks to generate deployable Terraform code.
/// </summary>
/// <param name="logger">Logger for tracking publisher operations.</param>
/// <param name="progressReporter">Reporter for tracking publishing progress.</param>
/// <param name="executionContext">Context information about the current execution environment.</param>
/// <param name="publishingOptions">General publishing configuration options.</param>
/// <param name="terraformPublishingOptions">CDK-specific publishing configuration options.</param>
/// <param name="services">Service provider for dependency injection.</param>
public class TerraformCdkPublisher(
    ILogger<TerraformCdkPublisher> logger,
    IPublishingActivityReporter progressReporter,
    DistributedApplicationExecutionContext executionContext,
    IOptions<PublishingOptions> publishingOptions,
    IOptions<TerraformCdkPublishingOptions> terraformPublishingOptions,
    IServiceProvider services) : IDistributedApplicationPublisher
{
    /// <summary>
    /// Publishes the distributed application model by synthesizing CDK stacks into Terraform configuration.
    /// </summary>
    /// <param name="model">The distributed application model containing CDK environments and stacks.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous publishing operation.</returns>
    public async Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken)
    {
        var multipleEnvironments = model.Resources.OfType<TerraformCdkEnvironmentResource>().Count() > 1;

        foreach (var terraformCdkResource in model.Resources.OfType<TerraformCdkEnvironmentResource>())
        {
            await progressReporter.CreateStepAsync($"Create terraform stacks {terraformCdkResource.Name}", cancellationToken);

            var outputPath = publishingOptions.Value.OutputPath ?? "./.terraform";

            if (multipleEnvironments)
            {
                outputPath = Path.Combine(outputPath, terraformCdkResource.Name);
            }

            var terraformPublishingContext = new TerraformCdkPublishingContext(executionContext, terraformPublishingOptions.Value, outputPath ?? "./infra", terraformCdkResource.Name, services, logger);

            await terraformPublishingContext.Synth(model, terraformCdkResource.Stacks, cancellationToken);
        }

        await progressReporter.CompletePublishAsync("Terraform stacks created", CompletionState.Completed, false, cancellationToken);
    }
}