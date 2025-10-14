using System.Diagnostics.CodeAnalysis;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

public sealed class TerraformTemplateEnvironmentResource : Resource
{
    public TerraformTemplateEnvironmentResource(string name) : base(name)
    {
        //Annotations.Add(new PublishingCallbackAnnotation(PublishAsync));
        //Annotations.Add(new DeployingCallbackAnnotation(DeployAsync));
        //Annotations.Add(ManifestPublishingCallbackAnnotation.Ignore);
    }

    //[Experimental("ASPIREPUBLISHERS001")]
    //private async Task PublishAsync(PublishingContext context)
    //{
    //    var outputPath = GetEnvironmentOutputPath(context, this);

    //    var loggerService = context.Services.GetRequiredService<ResourceLoggerService>();
    //    var logger = loggerService.GetLogger(this);

    //    var publisher = context.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>(Name);
    //    await publisher.PublishAsync(context.Model, context.CancellationToken);

    //    // TODO call terraform plan/apply
    //}

    //[Experimental("ASPIREPUBLISHERS001")]
    //internal static string GetEnvironmentOutputPath(PublishingContext context, IComputeEnvironmentResource environment)
    //{
    //    if (context.Model.Resources.OfType<IComputeEnvironmentResource>().Count() > 1)
    //        // If there are multiple compute environments, append the environment name to the output path
    //        return Path.Combine(context.OutputPath, environment.Name);

    //    // If there is only one compute environment, use the root output path
    //    return context.OutputPath;
    //}
}