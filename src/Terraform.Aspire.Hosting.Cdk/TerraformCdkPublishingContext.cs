using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using HashiCorp.Cdktf;
using Microsoft.Extensions.Logging;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Cdk;

/// <summary>
/// Context for Terraform CDK publishing operations, managing the synthesis of CDK stacks into Terraform configuration.
/// </summary>
/// <param name="executionContext">The execution context for the current operation.</param>
/// <param name="options">CDK publishing configuration options.</param>
/// <param name="outputPath">Directory path where Terraform files will be generated.</param>
/// <param name="resourceName">Name of the resource being processed.</param>
/// <param name="services">Service provider for dependency injection.</param>
public class TerraformCdkPublishingContext(
    DistributedApplicationExecutionContext executionContext,
    TerraformCdkPublishingOptions options,
    string outputPath,
    string resourceName,
    IServiceProvider services,
    ILogger logger)
{
    /// <summary>
    /// Gets or sets the distributed application model being processed.
    /// </summary>
    public DistributedApplicationModel? Model { get; protected set; }
    
    /// <summary>
    /// Gets the CDK publishing configuration options.
    /// </summary>
    public TerraformCdkPublishingOptions Options => options;
    
    /// <summary>
    /// Gets the execution context for the current operation.
    /// </summary>
    public DistributedApplicationExecutionContext ExecutionContext => executionContext;

    /// <summary>
    /// Gets the logger
    /// </summary>
    public ILogger Logger => logger;
    
    /// <summary>
    /// Gets the current publishing context instance for static access during stack construction.
    /// </summary>
    public static TerraformCdkPublishingContext? Current { get; protected set; }

    /// <summary>
    /// Gets the service provider for dependency injection.
    /// </summary>
    public IServiceProvider Services => services;

    /// <summary>
    /// Synthesizes the CDK application and stacks into Terraform configuration files.
    /// </summary>
    /// <param name="model">The distributed application model.</param>
    /// <param name="stacks">Collection of Terraform stacks to synthesize.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous synthesis operation.</returns>
    public async Task Synth(DistributedApplicationModel model, IReadOnlyList<TerraformStackResource> stacks, CancellationToken cancellationToken = default)
    {
        Model = model;
        Current = this;

        var app = new App(new AppConfig
        {
            Outdir = outputPath
        });

        foreach (var stackResource in stacks)
        {
            if (stackResource.CreateInstance(app) is TerraformAspireStack stackInstance)
            {
                foreach (var resourceAnnotation in stackResource.Annotations.OfType<TerraformCdkResourceAnnotation>())
                    resourceAnnotation.BuildAction(stackInstance);
            }
        }

        app.Synth();
    }
}