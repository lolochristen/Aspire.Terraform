using System.Diagnostics.CodeAnalysis;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Terraform.Cdk;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Aspire.Hosting;

//[Experimental("ASPIREPUBLISHERS001")]
public sealed class TerraformCdkEnvironmentResource : Resource //, IComputeEnvironmentResource
{
    private readonly List<TerraformStackResource> _stacks = new();

    //[Experimental("ASPIREPUBLISHERS001")]
    public TerraformCdkEnvironmentResource(string name) : base(name)
    {
        //Annotations.Add(new PublishingCallbackAnnotation(PublishAsync));
    }

    public IReadOnlyList<TerraformStackResource> Stacks => _stacks;

    public void AddStack(TerraformStackResource stackResource)
    {
        _stacks.Add(stackResource);
    }

    //[Experimental("ASPIREPUBLISHERS001")]
    //private async Task PublishAsync(PublishingContext context)
    //{
    //    //var options = new TerraformCdkPublishingOptions();

    //    //if (Options != null)
    //    //{
    //    //    Options(options);
    //    //}

    //    var optionsMonitor = context.Services.GetRequiredService<IOptionsMonitor<TerraformCdkPublishingOptions>>();
    //    var options = optionsMonitor.Get(Name);
    //    var outputPath = GetEnvironmentOutputPath(context, this);

    //    var terraformPublishingContext = new TerraformCdkPublishingContext(context.ExecutionContext, options, outputPath, Name);

    //    await terraformPublishingContext.Synth(context.Model, _stacks, context.CancellationToken);
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