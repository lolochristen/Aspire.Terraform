using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Aspire.Hosting.Pipelines;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Terraform.Aspire.Hosting.Templates;
using Terraform.Aspire.Hosting.Templates.Models;
using static Google.Protobuf.Reflection.GeneratedCodeInfo.Types;
using AzureBicepResource = Aspire.Hosting.Azure.AzureBicepResource;

#pragma warning disable ASPIREPIPELINES001
#pragma warning disable ASPIREPUBLISHERS001

namespace Terraform.Aspire.Hosting.Azure.Templates;

/// <summary>
/// Azure-specific Terraform template publisher that extends the base publisher with Azure Bicep resource support.
/// Processes Azure resources and generates corresponding Terraform configurations with Azure-specific outputs and parameters.
/// </summary>
/// <param name="logger">Logger for tracking publisher operations.</param>
/// <param name="publishingOptions">General publishing configuration options.</param>
/// <param name="terraformPublishingOptions">Terraform-specific publishing configuration options.</param>
/// <param name="processor">Template processor for handling Handlebars templates.</param>
public class TerraformAzureTemplatePublisher(
    ILogger<TerraformTemplatePublisher> logger,
    IOptions<PipelineOptions> publishingOptions,
    IOptions<TerraformTemplatePublishingOptions> terraformPublishingOptions,
    TerraformTemplateProcessor processor) : TerraformTemplatePublisher(logger, publishingOptions, terraformPublishingOptions, processor)
{
    /// <summary>
    /// Prepares Azure Bicep resources for Terraform template processing with Azure-specific outputs and parameters.
    /// </summary>
    /// <param name="resource">The resource to prepare.</param>
    /// <param name="modelResources">Dictionary of existing model resources.</param>
    /// <returns>A task representing the asynchronous preparation operation.</returns>
    protected override async Task PrepareResource(IResource resource, Dictionary<string, TemplateResource> modelResources)
    {
        if (resource is AzureBicepResource bicepResource)
        {
            if (resource.GetType() == typeof(AzureProvisioningResource))
            {
                // ignore direct AzureProvisioningResource (e.g. roles via biceps)
                return;
            }

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
                    case "azure-application-insights":
                        annotation.TemplateResource.Outputs.Add("appInsightsConnectionString", "${local." + name + ".connectionString}");
                        break;
                    case "azure-signal-r":
                        annotation.TemplateResource.Outputs.Add("hostName", "${local." + name + ".hostName}");
                        break;
                    case "azure-event-hubs":
                        annotation.TemplateResource.Outputs.Add("eventHubsEndpoint", "${local." + name + ".eventHubsEndpoint}");
                        break;
                    case "azure-user-assigned-identity":
                        annotation.Parameters ??= new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
                        var systemIdentityResource = modelResources.Values.FirstOrDefault(p => p.Name + "_identity" == name); // assumption its uai of compute 
                        annotation.Parameters.Add("IdentityType", systemIdentityResource != null ? "SystemAssigned" : "UserAssigned");

                        if (systemIdentityResource != null)
                            annotation.Parameters.Add("IdentityResourceName", systemIdentityResource.Name);

                        annotation.TemplateResource.Outputs.Add("principalId", "${local." + name + ".principalId}");

                        if (systemIdentityResource == null)
                        {
                            annotation.TemplateResource.Outputs.Add("id", "${local." + name + ".id}");
                            annotation.TemplateResource.Outputs.Add("clientId", "${local." + name + ".clientId}");
                            annotation.TemplateResource.Outputs.Add("principalName", "${local." + name + ".principalName}");
                            annotation.TemplateResource.Outputs.Add("name", "${local." + name + ".name}");
                        }
                        break;
                }

                AppendModelResource(modelResources, annotation.TemplateResource);
            }

            ApplyAppIdentityAnnotation(resource);
            ApplyRoleAssignmentAnnotation(resource);
            return;
        }

        await base.PrepareResource(resource, modelResources); // default resources
        ApplyAppIdentityAnnotation(resource);
        ApplyRoleAssignmentAnnotation(resource);
    }

    private void ApplyAppIdentityAnnotation(IResource resource)
    {
        var appIdentityAnnotation = resource.Annotations.OfType<AppIdentityAnnotation>().FirstOrDefault();
        if (appIdentityAnnotation != null)
        {
            foreach (var annotation in resource.Annotations.OfType<ITerraformTemplateAnnotation>())
            {
                annotation.Parameters ??= new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

                // if the app identity is named name-identity, it represents itself, use system assigned
                var isSystemAssigned = appIdentityAnnotation.IdentityResource.Id.Resource.Name == resource.Name + "-identity";
                annotation.Parameters.Add("IdentityType", isSystemAssigned ? "SystemAssigned" : "UserAssigned");
                annotation.Parameters.Add("IdentityPrincipalId", appIdentityAnnotation.IdentityResource.PrincipalId);

                if (!isSystemAssigned)
                {
                    annotation.Parameters.Add("IdentityClientId", appIdentityAnnotation.IdentityResource.ClientId);
                    annotation.Parameters.Add("IdentityId", appIdentityAnnotation.IdentityResource.Id);
                    annotation.Parameters.Add("IdentityPrincipalName", appIdentityAnnotation.IdentityResource.PrincipalName);
                }
            }
        }
    }

    private void ApplyRoleAssignmentAnnotation(IResource resource)
    {
        var roleAssignments = resource.Annotations.OfType<RoleAssignmentAnnotation>().ToList();
       
        foreach (var annotation in resource.Annotations.OfType<ITerraformTemplateAnnotation>())
        {
            annotation.Parameters ??= new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            annotation.Parameters.Add("RoleAssignments", roleAssignments);
        }
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
        var parentTemplateAnnotation = resource.Parent.Annotations.OfType<ITerraformTemplateAnnotation>().FirstOrDefault();

        switch (type)
        {
            case "azure-key-vault-secret":
                parent.Secrets.Add(resource.Name, "${local." + resource.Name + ".key_vault_secret_id}");
                break;
        }

        if (resource.Parent is AzureBicepResource || resource.Parent is IResourceWithParent { Parent: AzureBicepResource })
        {
            var annotations = SetupAnnotations<ValueTemplateResource>(resource, type + TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION);

            foreach (var annotation in annotations)
            {
                if (parentTemplateAnnotation != null)
                {
                    annotation.OutputFileName = parentTemplateAnnotation.OutputFileName;
                    annotation.AppendFile = true;
                }

                annotation.TemplateResource = new ValueTemplateResource
                {
                    Resource = resource,
                    Name = resource.Name,
                    Parent = parent,
                };

                if (resource is IResourceWithConnectionString resourceWithConnectionString)
                    annotation.TemplateResource.ConnectionString = resourceWithConnectionString.ConnectionStringExpression.ValueExpression;

                if (resource is AzureKeyVaultSecretResource keyVaultSecretResource)
                {
                    if (keyVaultSecretResource.Value is IManifestExpressionProvider expressionProvider)
                    {
                        annotation.TemplateResource.Value = expressionProvider.ValueExpression;
                    }
                    else
                    {
                        annotation.TemplateResource.Value = keyVaultSecretResource.Value.ToString() ?? "";
                    }
                }
                else if (resource is IManifestExpressionProvider valueProvider)
                {
                    annotation.TemplateResource.Value = valueProvider.ValueExpression;
                }
                
                AppendModelResource(modelResources, annotation.TemplateResource);
            }

            return true;
        }

        return false;
    }
}
