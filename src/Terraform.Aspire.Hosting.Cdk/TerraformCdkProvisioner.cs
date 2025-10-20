using System.Diagnostics.CodeAnalysis;
using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Lifecycle;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Terraform.Aspire.Hosting.Cdk;

[Experimental("ASPIREPUBLISHERS001")]
internal class TerraformCdkProvisioner(
    ResourceLoggerService loggerService,
    ResourceNotificationService notificationService,
    IOptionsMonitor<TerraformCdkPublishingOptions> optionsMonitor,
    DistributedApplicationExecutionContext executionContext,
    IServiceProvider services) : IDistributedApplicationLifecycleHook
{
    public async Task BeforeStartAsync(DistributedApplicationModel appModel, CancellationToken cancellationToken = new())
    {
        // AzureProvisioner only applies to RunMode
        if (executionContext.IsPublishMode) return;

        var tfResources = appModel.Resources.OfType<TerraformCdkEnvironmentResource>();

        _ = Task.Run(async () =>
        {
            foreach (var terraformResource in tfResources)
            {
                await notificationService.PublishUpdateAsync(terraformResource, s => s with
                {
                    State = new ResourceStateSnapshot("Starting", KnownResourceStateStyles.Info)
                });

                var logger = loggerService.GetLogger(terraformResource.Name);

                //var optionsMonitor = context.Services.GetRequiredService<IOptionsMonitor<TerraformCdkPublishingOptions>>();
                var options = optionsMonitor.Get(terraformResource.Name);
                var outputPath = "./.terraform"; //GetEnvironmentOutputPath(context, this);

                logger.LogInformation("Synthesize...");

                var terraformPublishingContext = new TerraformCdkPublishingContext(executionContext, options, outputPath, terraformResource.Name, services);

                await terraformPublishingContext.Synth(appModel, terraformResource.Stacks, cancellationToken);

                logger.LogInformation("Done...");

                await notificationService.PublishUpdateAsync(terraformResource, s => s with
                {
                    State = new ResourceStateSnapshot("Running", KnownResourceStateStyles.Success)
                });
            }
        });
    }
}