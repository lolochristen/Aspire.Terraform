using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using HashiCorp.Cdktf;

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
    IServiceProvider services)
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
            //Context = new Dictionary<string, object>()
            //{
            //    { "SubscriptionId", options.SubscriptionId }
            //},
            Outdir = outputPath
        });

        foreach (var stackResource in stacks)
        {
            var stackInstance = stackResource.CreateInstance(app) as TerraformAspireStack;

            if (stackInstance != null)
                foreach (var resourceAnnotation in stackResource.Annotations.OfType<TerraformCdkResourceAnnotation>())
                    resourceAnnotation.BuildAction(stackInstance);
        }

        app.Synth();
    }

    //public async Task WriteModel(DistributedApplicationModel model, CancellationToken cancellationToken = default)
    //{
    //    await using var file = File.OpenWrite("aspire.tf");
    //    await using TextWriter writer = new StreamWriter(file, Encoding.Default);

    //    foreach (var modelResource in model.Resources)
    //    {
    //        Console.WriteLine(modelResource.Name);
    //        var sb = new StringBuilder();

    //        if (modelResource is ProjectTemplateResource projectResource)
    //        {
    //            foreach (var annotation in modelResource.Annotations)
    //            {
    //                Console.WriteLine(annotation.GetType().FullName);
    //            }

    //            sb.AppendLine($"module \"{projectResource.Name}\"");
    //            sb.AppendLine($"  source = \"..\"");
    //            sb.AppendLine("  template  = {");
    //            sb.AppendLine("        env = [");

    //            var env = new Dictionary<string, (object, string)>();

    //            await projectResource.ProcessEnvironmentVariableValuesAsync(Context, (key, unprocessed, processed, ex) =>
    //            {
    //                if (ex is not null)
    //                {
    //                    ExceptionDispatchInfo.Throw(ex);
    //                }

    //                if (unprocessed is not null && processed is not null)
    //                {
    //                    env[key] = (unprocessed, processed);
    //                }
    //            }, NullLogger.Instance, cancellationToken: cancellationToken);

    //            foreach (var (key, envValue) in env)
    //            {
    //                sb.AppendLine($"    \"{key}\" = {BuildTerraformValue(envValue.Item2)}");
    //                Console.WriteLine($"      {envValue.Item1}");
    //            }

    //            //foreach (var environmentAnnotation in projectResource.Annotations.OfType<EnvironmentCallbackAnnotation>())
    //            //{
    //            //    var env = environmentAnnotation.Callback.Invoke(new EnvironmentCallbackContext(executionContext));

    //            //    //var r = env.WaitAsync(cancellationToken);
    //            //}
    //            sb.AppendLine("        ]");

    //            await writer.WriteAsync(sb, cancellationToken);
    //            Console.WriteLine(sb);

    //        }
    //    }
    //}

    //private string BuildTerraformValue(string value)
    //{
    //    if (value.StartsWith("{"))
    //    {
    //        return value.Replace("{", "module.").Replace("}", "");
    //    }

    //    return "\"" + value + "\"";
    //}
}