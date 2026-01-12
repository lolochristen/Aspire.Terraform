using Aspire.Hosting.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading;
using Terraform.Aspire.Hosting.Templates;
#pragma warning disable ASPIREPIPELINES002
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
        pipeline.AddStep(new PipelineStep
        {
            Name = "publish-terraform",
            Action = async context =>
            {
                var terraformTemplatePublisher = context.Services.GetRequiredService<ITerraformTemplatePublisher>();
                await terraformTemplatePublisher.PublishAsync(context.Model, context.CancellationToken);
            },
            //RequiredBySteps = [WellKnownPipelineSteps.Publish],
            //DependsOnSteps = [WellKnownPipelineSteps.PublishPrereq]
        });

        pipeline.AddStep(new PipelineStep()
        {
            Name = "deploy-terraform",
            Action = async context =>
            {
                var terraformTemplatePublisher = context.Services.GetRequiredService<TerraformExecutor>();
                await terraformTemplatePublisher.Apply(context.CancellationToken);
            },
            RequiredBySteps = [WellKnownPipelineSteps.Deploy],
            DependsOnSteps = ["publish-terraform", WellKnownPipelineSteps.DeployPrereq]
            //DependsOnSteps = ["publish-terraform"]
        });

        return pipeline;
    }
}