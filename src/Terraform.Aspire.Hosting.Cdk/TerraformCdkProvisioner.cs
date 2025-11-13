//using System.Diagnostics.CodeAnalysis;
//using Aspire.Hosting;
//using Aspire.Hosting.ApplicationModel;
//using Aspire.Hosting.Lifecycle;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;

//namespace Terraform.Aspire.Hosting.Cdk;

///// <summary>
///// Lifecycle hook that automatically provisions Terraform CDK infrastructure during application startup.
///// This experimental feature synthesizes CDK stacks during the BeforeStart phase.
///// </summary>
///// <param name="loggerService">Service for creating resource-specific loggers.</param>
///// <param name="notificationService">Service for publishing resource state updates.</param>
///// <param name="optionsMonitor">Monitor for CDK publishing configuration options.</param>
///// <param name="executionContext">Context information about the current execution environment.</param>
///// <param name="services">Service provider for dependency injection.</param>
//[Experimental("ASPIREPUBLISHERS001")]
//internal class TerraformCdkProvisioner(
//    ResourceLoggerService loggerService,
//    ResourceNotificationService notificationService,
//    IOptionsMonitor<TerraformCdkPublishingOptions> optionsMonitor,
//    DistributedApplicationExecutionContext executionContext,
//    IServiceProvider services) : IDistributedApplicationLifecycleHook
//{
//    /// <summary>
//    /// Synthesizes Terraform CDK environments before application start in run mode.
//    /// This method is skipped in publish mode to avoid conflicts with the publisher.
//    /// </summary>
//    /// <param name="appModel">The distributed application model.</param>
//    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
//    /// <returns>A task representing the asynchronous provisioning operation.</returns>
//    public async Task BeforeStartAsync(DistributedApplicationModel appModel, CancellationToken cancellationToken = new())
//    {
//        // AzureProvisioner only applies to RunMode
//        if (executionContext.IsPublishMode) return;

//        var tfResources = appModel.Resources.OfType<TerraformCdkEnvironmentResource>();

//        _ = Task.Run(async () =>
//        {
//            foreach (var terraformResource in tfResources)
//            {
//                await notificationService.PublishUpdateAsync(terraformResource, s => s with
//                {
//                    State = new ResourceStateSnapshot("Starting", KnownResourceStateStyles.Info)
//                });

//                var logger = loggerService.GetLogger(terraformResource.Name);

//                //var optionsMonitor = context.Services.GetRequiredService<IOptionsMonitor<TerraformCdkPublishingOptions>>();
//                var options = optionsMonitor.Get(terraformResource.Name);
//                var outputPath = "./.terraform"; //GetEnvironmentOutputPath(context, this);

//                logger.LogInformation("Synthesize...");

//                var terraformPublishingContext = new TerraformCdkPublishingContext(executionContext, options, outputPath, terraformResource.Name, services, logger);

//                await terraformPublishingContext.Synth(appModel, terraformResource.Stacks, cancellationToken);

//                logger.LogInformation("Done...");

//                await notificationService.PublishUpdateAsync(terraformResource, s => s with
//                {
//                    State = new ResourceStateSnapshot("Running", KnownResourceStateStyles.Success)
//                });
//            }
//        });
//    }
//}