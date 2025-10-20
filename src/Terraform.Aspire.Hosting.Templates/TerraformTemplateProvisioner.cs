//using Aspire.Hosting.ApplicationModel;
//using Aspire.Hosting.Eventing;
//using Aspire.Hosting.Lifecycle;
//using Aspire.Hosting.Publishing;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace Terraform.Aspire.Hosting.Templates;

//public class TerraformTemplateProvisioner(
//    DistributedApplicationExecutionContext executionContext,
//    IConfiguration configuration,
//    IServiceProvider serviceProvider,
//    ResourceNotificationService notificationService,
//    ResourceLoggerService loggerService,
//    IDistributedApplicationEventing eventing
//) : IDistributedApplicationLifecycleHook
//{
//    public async Task BeforeStartAsync(DistributedApplicationModel appModel, CancellationToken cancellationToken = new CancellationToken())
//    {
//        // AzureProvisioner only applies to RunMode
//        if (executionContext.IsPublishMode)
//        {
//            return;
//        }


//        var environments = appModel.Resources.OfType<TerraformTemplateEnvironmentResource>().ToList();

//        foreach (var environment in environments)
//        {
//            var publisher =  serviceProvider.GetRequiredKeyedService<IDistributedApplicationPublisher>(environment.Name);

//            var logger = loggerService.GetLogger(environment.Name);

//            // publish tf files
//            await publisher.PublishAsync(appModel, cancellationToken);

//            loggerService.Complete(environment.Name);

//        }

//        // export files

//        // run terraform init/apply

//    }
//}

