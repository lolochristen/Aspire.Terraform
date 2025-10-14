using Aspire.Hosting.ApplicationModel;
using HashiCorp.Cdktf;

#pragma warning disable ASPIREPUBLISHERS001

namespace Aspire.Hosting.Terraform.Cdk;

public class TerraformCdkPublishingContext(DistributedApplicationExecutionContext executionContext, TerraformCdkPublishingOptions options, string outputPath, string resourceName, IServiceProvider services)
{
    public DistributedApplicationModel? Model { get; protected set; }
    public TerraformCdkPublishingOptions Options => options;
    public DistributedApplicationExecutionContext ExecutionContext => executionContext;
    public static TerraformCdkPublishingContext? Current { get; protected set; }

    public IServiceProvider Services => services;

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