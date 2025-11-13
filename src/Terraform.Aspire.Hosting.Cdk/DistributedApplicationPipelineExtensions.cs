using Aspire.Hosting.Pipelines;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using Microsoft.Extensions.Options;
using Terraform.Aspire.Hosting.Cdk;

#pragma warning disable ASPIREPIPELINES001
#pragma warning disable IDE0130

namespace Aspire.Hosting;

/// <summary>
/// Extensions for IDistributedApplicationPipeline
/// </summary>
public static class DistributedApplicationPipelineExtensions
{
    /// <summary>
    /// Adds a step to the pipeline that publishes terraform.
    /// </summary>
    /// <param name="pipeline">The pipeline to add the terraform publishing step to.</param>
    /// <returns>The pipeline for chaining.</returns>
    public static IDistributedApplicationPipeline AddTerraformCdkPublishing(this IDistributedApplicationPipeline pipeline, TerraformCdkEnvironmentResource resource)
    {
        var step = new PipelineStep
        {
            Name = "publish-" + resource.Name,
            Action = async context =>
            {
                var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("Aspire.Hosting.Publishing.TerraformCdkPublisher");
                var pipelineOptions = context.Services.GetRequiredService<IOptions<PipelineOptions>>();
                var executionContext = context.Services.GetRequiredService<DistributedApplicationExecutionContext>();
                var terraformPublishingOptions = context.Services.GetRequiredService<IOptions<TerraformCdkPublishingOptions>>();
                var multipleEnvironments = context.Model.Resources.OfType<TerraformCdkEnvironmentResource>().Count() > 1;

                var outputPath = pipelineOptions.Value.OutputPath ?? "./.terraform";

                if (multipleEnvironments)
                {
                    outputPath = Path.Combine(outputPath, resource.Name);
                }

                var terraformPublishingContext = new TerraformCdkPublishingContext(executionContext,
                    terraformPublishingOptions.Value,
                    outputPath,
                    resource.Name,
                    context.Services,
                    logger);

                await terraformPublishingContext.Synth(context.Model, resource.Stacks, context.CancellationToken);
            },
            Resource = resource
        };

        pipeline.AddStep(step);
        return pipeline;
    }
}