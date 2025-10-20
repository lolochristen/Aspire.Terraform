using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Terraform.Aspire.Hosting.Azure.Templates;
using Terraform.Aspire.Hosting.Templates;

namespace Aspire.Hosting;

public static class DistributedApplicationBuilderExtensions
{
    public static IDistributedApplicationBuilder AddTerraformAzureTemplatePublishing(this IDistributedApplicationBuilder builder, string name = "terraform",
        Action<TerraformTemplatePublishingOptions>? configureOptions = null, bool disableBicepAzureProvisioner = true)
    {
        if (disableBicepAzureProvisioner)
        {
            // disable azure provisioner
            var service = builder.Services.FirstOrDefault(p => p.ImplementationType != null && p.ImplementationType.Name.Contains("AzureProvisioner"));
            if (service != null)
                builder.Services.Remove(service);
            service = builder.Services.FirstOrDefault(p => p.ImplementationType != null && p.ImplementationType.Name.Contains("AzureResourcePreparer"));
            if (service != null)
                builder.Services.Remove(service);
        }

        var configuration = builder.Configuration.GetSection("Terraform:Templates");

        var optionsBuilder = builder.Services.AddOptions<TerraformTemplatePublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddKeyedSingleton<IDistributedApplicationPublisher, TerraformAzureTemplatePublisher>(name);
        builder.Services.AddTransient<TerraformTemplateProcessor>();
        return builder;
    }
}