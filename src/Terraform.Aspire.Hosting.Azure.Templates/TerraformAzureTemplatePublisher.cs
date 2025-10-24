using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Terraform.Aspire.Hosting.Templates;
using Terraform.Aspire.Hosting.Templates.Models;
using AzureBicepResource = Aspire.Hosting.Azure.AzureBicepResource;

#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Azure.Templates;

/// <summary>
/// Azure-specific Terraform template publisher that extends the base publisher with Azure Bicep resource support.
/// Processes Azure resources and generates corresponding Terraform configurations with Azure-specific outputs and parameters.
/// </summary>
/// <param name="logger">Logger for tracking publisher operations.</param>
/// <param name="progressReporter">Reporter for tracking publishing progress.</param>
/// <param name="executionContext">Context information about the current execution environment.</param>
/// <param name="publishingOptions">General publishing configuration options.</param>
/// <param name="terraformPublishingOptions">Terraform-specific publishing configuration options.</param>
/// <param name="processor">Template processor for handling Handlebars templates.</param>
public class TerraformAzureTemplatePublisher(
    ILogger<TerraformTemplatePublisher> logger,
    IPublishingActivityReporter progressReporter,
    DistributedApplicationExecutionContext executionContext,
    IOptions<PublishingOptions> publishingOptions,
    IOptions<TerraformTemplatePublishingOptions> terraformPublishingOptions,
    TerraformTemplateProcessor processor) : TerraformTemplatePublisher(logger, progressReporter, executionContext, publishingOptions, terraformPublishingOptions, processor)
{
    /// <summary>
    /// Prepares Azure Bicep resources for Terraform template processing with Azure-specific outputs and parameters.
    /// </summary>
    /// <param name="resource">The resource to prepare.</param>
    /// <param name="modelResources">Dictionary of existing model resources.</param>
    /// <returns>A task representing the asynchronous preparation operation.</returns>
    protected override Task PrepareResource(IResource resource, Dictionary<string, TemplateResource> modelResources)
    {
        if (resource is AzureBicepResource bicepResource)
        {
            var name = bicepResource.GetBicepIdentifier();
            var type = NormalizeTypeName(bicepResource.GetType().Name);

            var annotations = SetupAnnotations<AzureTemplateResource>(bicepResource, type + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

            foreach (var annotation in annotations)
            {
                annotation.TemplateResource = new AzureTemplateResource
                {
                    Resource = resource,
                    Name = name
                };

                foreach (var parameter in bicepResource.Parameters) annotation.TemplateResource.Parameters.Add(parameter.Key, parameter.Value);

                if (resource is IResourceWithConnectionString resourceWithConnectionString)
                {
                    annotation.TemplateResource.ConnectionString = resourceWithConnectionString.ConnectionStringExpression.ValueExpression;
                    annotation.TemplateResource.Outputs.Add("connectionString", "${local." + name + ".connectionString}");
                }

                if (resource is IResourceWithParent resourceWithParent && resourceWithParent.Parent != null)
                    annotation.TemplateResource.Parent = modelResources[resourceWithParent.Parent.Name];

                switch (type)
                {
                    case "azure-sql-server":
                        annotation.TemplateResource.Outputs.Add("sqlServerFqdn", "${local." + name + ".sqlServerFqdn}");
                        break;
                    case "azure-key-vault":
                        annotation.TemplateResource.Outputs.Add("vaultUri", "${local." + name + ".vaultUri}");
                        break;
                    case "azure-storage":
                        annotation.TemplateResource.Outputs.Add("vaultUri", "${local." + name + ".vaultUri}");
                        annotation.TemplateResource.Outputs.Add("tableEndpoint", "${local." + name + ".tableEndpoint}");
                        annotation.TemplateResource.Outputs.Add("blobEndpoint", "${local." + name + ".blobEndpoint}");
                        annotation.TemplateResource.Outputs.Add("queueEndpoint", "${local." + name + ".queueEndpoint}");
                        annotation.TemplateResource.Outputs.Add("fileEndpoint", "${local." + name + ".fileEndpoint}");
                        break;
                    case "azure-service-bus":
                        annotation.TemplateResource.Outputs.Add("serviceBusEndpoint", "${local." + name + ".serviceBusEndpoint}");
                        break;
                }

                AppendModelResource(modelResources, annotation.TemplateResource);
            }

            return Task.CompletedTask;
        }

        return base.PrepareResource(resource, modelResources); // default resources
    }

    /// <summary>
    /// Prepares child resources of Azure Bicep resources for Terraform template processing.
    /// </summary>
    /// <param name="resource">The child resource to prepare.</param>
    /// <param name="modelResources">Dictionary of existing model resources.</param>
    /// <returns>True if the child resource was successfully prepared; otherwise, false.</returns>
    protected override bool PrepareChildResource(IResourceWithParent resource, Dictionary<string, TemplateResource> modelResources)
    {
        var parent = modelResources[resource.Parent.Name];
        var type = NormalizeTypeName(resource.GetType().Name);

        if (resource.Parent is AzureBicepResource || resource.Parent is IResourceWithParent { Parent: AzureBicepResource })
        {
            var annotations = SetupAnnotations<ValueTemplateResource>(resource, type + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

            foreach (var annotation in annotations)
            {
                annotation.TemplateResource = new ValueTemplateResource
                {
                    Resource = resource,
                    Name = resource.Name,
                    Parent = parent
                };

                if (resource is IResourceWithConnectionString resourceWithConnectionString)
                    annotation.TemplateResource.ConnectionString = resourceWithConnectionString.ConnectionStringExpression.ValueExpression;

                AppendModelResource(modelResources, annotation.TemplateResource);
            }

            return true;
        }

        return false;
    }
}