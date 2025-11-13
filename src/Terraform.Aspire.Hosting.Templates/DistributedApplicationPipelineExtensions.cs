using Aspire.Hosting.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Terraform.Aspire.Hosting.Templates;

#pragma warning disable ASPIREPIPELINES001
#pragma warning disable IDE0130

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring distributed application pipelines with additional steps, such as
/// publishing Terraform templates.
/// </summary>
public static class DistributedApplicationPipelineExtensions
{
    /// <summary>
    /// Adds a step to the pipeline that publishes terraform.
    /// </summary>
    /// <param name="pipeline">The pipeline to add the terraform publishing step to.</param>
    /// <returns>The pipeline for chaining.</returns>
    public static IDistributedApplicationPipeline AddTerraformTemplatePublishing(this IDistributedApplicationPipeline pipeline)
    {
        var step = new PipelineStep
        {
            Name = "publish-terraform",
            Action = async context =>
            {
                var terraformTemplatePublisher = context.Services.GetRequiredService<ITerraformTemplatePublisher>();
                await terraformTemplatePublisher.PublishAsync(context.Model, context.CancellationToken);
            }
        };

        pipeline.AddStep(step);
        return pipeline;
    }
}