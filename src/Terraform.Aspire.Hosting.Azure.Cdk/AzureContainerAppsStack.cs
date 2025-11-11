using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Constructs;
using Hashicorp.Cdktf.Providers.Azapi.Provider;
using Hashicorp.Cdktf.Providers.Azapi.Resource;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerApp;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerAppEnvironment;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerRegistry;
using HashiCorp.Cdktf.Providers.Azurerm.DataAzurermClientConfig;
using HashiCorp.Cdktf.Providers.Azurerm.KeyVault;
using HashiCorp.Cdktf.Providers.Azurerm.KeyVaultSecret;
using HashiCorp.Cdktf.Providers.Azurerm.LogAnalyticsWorkspace;
using HashiCorp.Cdktf.Providers.Azurerm.MssqlDatabase;
using HashiCorp.Cdktf.Providers.Azurerm.MssqlServer;
using HashiCorp.Cdktf.Providers.Azurerm.Provider;
using HashiCorp.Cdktf.Providers.Azurerm.RedisCache;
using HashiCorp.Cdktf.Providers.Azurerm.ResourceGroup;
using HashiCorp.Cdktf.Providers.Azurerm.RoleAssignment;
using HashiCorp.Cdktf.Providers.Azurerm.StorageAccount;
using HashiCorp.Cdktf.Providers.Azurerm.StorageContainer;
using HashiCorp.Cdktf.Providers.Azurerm.StorageQueue;
using HashiCorp.Cdktf.Providers.Azurerm.UserAssignedIdentity;
using Humanizer.Localisation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IResource = Aspire.Hosting.ApplicationModel.IResource;
using Resource = Hashicorp.Cdktf.Providers.Azapi.Resource.Resource;
using ResourceGroup = HashiCorp.Cdktf.Providers.Azurerm.ResourceGroup.ResourceGroup;

namespace Aspire.Hosting;

/// <summary>
/// Terraform CDK stack deploying Aspire resources to Azure Container Apps.
/// </summary>
public class AzureContainerAppsTerraformStack(Construct scope, string id) : TerraformAspireStack(scope, id)
{
    protected TerraformCdkAzurePublishingOptions? AzureOptions { get; set; }

    /// <summary>
    /// Gets the created Azure resource group.
    /// </summary>
    public ResourceGroup? ResourceGroup { get; private set; }

    /// <summary>
    /// Gets the Azurerm provider instance.
    /// </summary>
    public AzurermProvider? AzurermProvider { get; private set; }

    /// <summary>
    /// Gets the user-assigned managed identity.
    /// </summary>
    public UserAssignedIdentity? UserAssignedIdentity { get; private set; }

    public DataAzurermClientConfig CurrentAzurermClient { get; set; }

    protected override void Finialize()
    {
    }

    protected override void BuildResources()
    {
        foreach (var resource in Context.Model.Resources)
            if (resource is not TerraformProvisioningResource)
            {
                Context.Logger.LogInformation("Create {ResourceName} {Type}", resource.Name, resource.GetType());
                var resourceType = resource.GetType().Name;

                switch (resource)
                {
                    case ProjectResource projectResource:
                    case ContainerResource containerResource:
                        BuildContainerApp(resource);
                        break;
                    case ParameterResource parameterResource:
                        BuildParameterResource(parameterResource);
                        break;
                    case AzureBicepResource azureBicepResource:
                        switch (resourceType)
                        {
                            case "AzureRedisCacheResource":
                                BuildAzureRedis((IResourceWithConnectionString) azureBicepResource);
                                break;
                            case "AzureSqlServerResource":
                                BuildAzureSqlServer((IResourceWithConnectionString)azureBicepResource);
                                break;
                            case "AzureKeyVaultResource":
                                BuildAzureKeyVault((IResourceWithConnectionString)azureBicepResource);
                                break;
                            case "AzureStorageResource":
                                BuildAzureStorage(azureBicepResource);
                                break;
                        }
                        break;
                    case IResourceWithParent resourceWithParent:
                        switch (resourceType)
                        {
                            case "AzureSqlDatabaseResource":
                                BuildAzureSqlDatabase(resourceWithParent);
                                break;
                            case "AzureKeyVaultSecretResource":
                                BuildAzureKeyVaultSecret(resourceWithParent);
                                break;
                            case "AzureBlobStorageResource":
                                break;
                            case "AzureBlobStorageContainerResource":
                                BuildAzureBlobStorageContainer(resourceWithParent);
                                break;
                            case "AzureQueueStorageResource":
                                break;
                            case "AzureQueueStorageQueueResource":
                                BuildAzureQueueStorageQueue(resourceWithParent);
                                break;
                        }
                        break;

                    //case AzureProvisioningResource azureProvisioningResource:
                    //    break;
                }
            }
    }

    protected override void Initialize()
    {
        base.Initialize();

        var azureSettings = Context.Services.GetRequiredService<IOptions<TerraformCdkAzurePublishingOptions>>();
        AzureOptions = azureSettings.Value;

        AzurermProvider = new AzurermProvider(this, "azurerm", new AzurermProviderConfig
        {
            SubscriptionId = AzureOptions.SubscriptionId,
            TenantId = AzureOptions.TenantId,
            Features = new IAzurermProviderFeatures[] { new AzurermProviderFeatures() }
        });

        new AzapiProvider(this, "azapi", new AzapiProviderConfig
        {
            SubscriptionId = AzureOptions.SubscriptionId,
            TenantId = AzureOptions.TenantId,
            DefaultLocation = AzureOptions.Location
        });

        CurrentAzurermClient = new DataAzurermClientConfig(this, "current");
    }
    
    protected override void BuildCoreResources()
    {
        var resourceGroup = AddTerraformResource(Context.Options.BaseName, name => new ResourceGroup(this, name, new ResourceGroupConfig
        {
            Name = name,
            Location = AzureOptions.Location ?? "East US",
            Tags = Context.Options.Tags
        }));

        ResourceGroup = resourceGroup;

        var userAssignedIdentity = AddTerraformResource(Context.Options.BaseName, name => new UserAssignedIdentity(this, name, new UserAssignedIdentityConfig
        {
            Name = name,
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Tags = Context.Options.Tags
        }));

        UserAssignedIdentity = userAssignedIdentity;

        var logAnalyticsWorkspace = AddTerraformResource(Context.Options.BaseName, name => new LogAnalyticsWorkspace(this, name, new LogAnalyticsWorkspaceConfig
        {
            Name = name,
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Sku = "PerGB2018",
            Tags = Context.Options.Tags
        }));

        var containerAppEnvironment = AddTerraformResource(Context.Options.BaseName, name => new ContainerAppEnvironment(this, name, new ContainerAppEnvironmentConfig
        {
            Name = name,
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Tags = Context.Options.Tags,
            WorkloadProfile = new[]
            {
                new ContainerAppEnvironmentWorkloadProfile
                {
                    Name = "consumption",
                    WorkloadProfileType = "Consumption"
                }
            },
            LogAnalyticsWorkspaceId = logAnalyticsWorkspace.Id
        }));

        var containerRegistry = AddTerraformResource(Context.Options.BaseName, name => new ContainerRegistry(this, name, new ContainerRegistryConfig
        {
            Name = name,
            ResourceGroupName = resourceGroup.Name,
            Tags = Context.Options.Tags,
            Location = resourceGroup.Location,
            Sku = "Basic"
        }));

        AddTerraformResource("IdentityArcPull", name => new RoleAssignment(this, name, new RoleAssignmentConfig
        {
            Name = name,
            RoleDefinitionName = "AcrPull",
            Scope = containerRegistry.Id,
            PrincipalId = userAssignedIdentity.PrincipalId
        }));

        var aspireapp = AddTerraformResource("aspire-app", name => new Resource(this, name, new ResourceConfig
        {
            Type = "Microsoft.App/managedEnvironments/dotNetComponents@2023-11-02-preview",
            Name = "aspire-dashboard",
            ParentId = containerAppEnvironment.Id,
            Body = new Dictionary<string, object>
            {
                {
                    "properties", new Dictionary<string, object>
                    {
                        { "componentType", "aspire-dashboard" }
                    }
                }
            }
        }));

        new TerraformOutput(this, "containerAppEnvironmentId", new TerraformOutputConfig
        {
            Value = containerAppEnvironment.Id
        });

        new TerraformOutput(this, "containerAppEnvironment", new TerraformOutputConfig
        {
            Value = new Dictionary<string, object>
            {
                { "Id", containerAppEnvironment.Id },
                { "DefaultDomain", containerAppEnvironment.DefaultDomain }
            }
        });
    }

    private void BuildContainerApp(IResource resource)
    {
        resource.TryGetEndpoints(out var endpoints);

        var containerAppEnvironment = GetTerraformResource<ContainerAppEnvironment>(Context.Options.BaseName);

        var primaryEndpoint = endpoints?.FirstOrDefault();

        var envList = new List<ContainerAppTemplateContainerEnv>();
        var secretList = new List<ContainerAppSecret>();
        var resourceEnv = GetResourceEnvironmentValues(Context.ExecutionContext, resource);

        var targetPort = primaryEndpoint?.TargetPort ?? 8080;

        if (endpoints != null)
            foreach (var endpoint in endpoints)
            {
                Substitutions.Add($"{resource.Name}.bindings.{endpoint.Name}.host", resource.Name + ".internal." + containerAppEnvironment.DefaultDomain);
                Substitutions.Add($"{resource.Name}.bindings.{endpoint.Name}.port", (endpoint.Port ?? targetPort).ToString());
                Substitutions.Add($"{resource.Name}.bindings.{endpoint.Name}.targetPort", (endpoint.TargetPort ?? targetPort).ToString());
                Substitutions.Add($"{resource.Name}.bindings.{endpoint.Name}.url",
                    endpoint.UriScheme + "://" + resource.Name + ".internal." + containerAppEnvironment.DefaultDomain);
            }

        foreach (var envValue in resourceEnv)
        {
            var containerAppTemplateContainerEnv = new ContainerAppTemplateContainerEnv
            {
                Name = envValue.Key,
                Value = SubstituteValueExpressions(envValue.Value.Item2)
            };

            if (envValue.Value.Item1 is ReferenceExpression referenceExpression)
            {
                containerAppTemplateContainerEnv.Value = SubstituteValueExpressions(referenceExpression.ValueExpression);
            }

            if (envValue.Value.Item1 is ConnectionStringReference connectionStringReference)
            {
                secretList.Add(new ContainerAppSecret()
                {
                    Name = envValue.Key,
                    Value = SubstituteValueExpressions(connectionStringReference.Resource.ConnectionStringExpression.ValueExpression)
                });

                containerAppTemplateContainerEnv.SecretName = envValue.Key;
                containerAppTemplateContainerEnv.Value = null; 
            }

            if (envValue.Value.Item1 is IAzureKeyVaultSecretReference secretReference)
            {
                var secret = GetTerraformResource<KeyVaultSecret>(secretReference.SecretName);

                secretList.Add(new ContainerAppSecret()
                {
                    Name = envValue.Key,
                    KeyVaultSecretId = secret.VersionlessId
                });

                containerAppTemplateContainerEnv.SecretName = envValue.Key;
                containerAppTemplateContainerEnv.Value = null; 
            }

            envList.Add(containerAppTemplateContainerEnv);
        }

        ContainerAppIngress? ingress = null;
        ContainerAppRegistry? registry = null;

        if (primaryEndpoint != null)
            ingress = new ContainerAppIngress
            {
                TargetPort = (double)targetPort,
                ExternalEnabled = primaryEndpoint.IsExternal,
                Transport = "auto",
                TrafficWeight = new[] { new ContainerAppIngressTrafficWeight { Percentage = 100 } }
            };

        // identity
        var uai = GetTerraformResource<UserAssignedIdentity>(Context.Options.BaseName);

        if (!resource.TryGetContainerImageName(out var imageName))
        {
            var car = GetTerraformResource<ContainerRegistry>(Context.Options.BaseName);

            registry = new ContainerAppRegistry
            {
                Server = car.LoginServer,
                Identity = uai.Id
            };

            imageName = $"{car.LoginServer}/{resource.Name}:latest"; // TODO project image tag
        }

        var containerApp = AddTerraformResource(resource.Name, name => new ContainerApp(this, name, new ContainerAppConfig
        {
            Name = name,
            ResourceGroupName = GetTerraformResource<ResourceGroup>(Context.Options.BaseName).Name,
            ContainerAppEnvironmentId = containerAppEnvironment.Id,
            Identity = new ContainerAppIdentity
            {
                Type = "UserAssigned",
                IdentityIds = [uai.Id]
            },
            RevisionMode = "Single",
            Secret = secretList.ToArray(),
            Template = new ContainerAppTemplate
            {
                Container = new[]
                {
                    new ContainerAppTemplateContainer
                    {
                        Image = imageName,
                        Memory = "0.5Gi",
                        Cpu = 0.25,
                        Name = resource.Name,
                        Env = envList.ToArray()
                    }
                }
            },
            Ingress = ingress,
            Registry = registry != null ? new[] { registry } : null,
            Tags = new Dictionary<string, string>(Context.Options.Tags) { { "aspire-resource-name", resource.Name } }
        }));
    }


    private void BuildAzureRedis(IResourceWithConnectionString resource)
    {
        var redis = AddTerraformResource(resource.Name, name => new RedisCache(this, name, new RedisCacheConfig()
        {
            Name = name,
            ResourceGroupName = ResourceGroup.Name,
            Tags = Context.Options.Tags,
            Location = ResourceGroup.Location,
            MinimumTlsVersion = "1.2",
            Family = "C",
            SkuName = "Basic",
            Capacity = 1,
            NonSslPortEnabled = false,
            RedisConfiguration = new RedisCacheRedisConfiguration()
            {
                ActiveDirectoryAuthenticationEnabled = true
            }
        }));

        Substitutions.Add($"{resource.Name}.outputs.connectionString", redis.PrimaryConnectionString);
    }

    private void BuildAzureSqlServer(IResourceWithConnectionString resource)
    {
        if (ResourceGroup is null) throw new InvalidOperationException("ResourceGroup ist not created");

        var sqlServer = AddTerraformResource(resource.Name, name => new MssqlServer(this, name, new MssqlServerConfig
        {
            Name = name,
            ResourceGroupName = ResourceGroup.Name,
            Tags = Context.Options.Tags,
            Location = ResourceGroup.Location,
            Version = "12.0",
            MinimumTlsVersion = "1.2",
            AzureadAdministrator = new MssqlServerAzureadAdministrator
            {
                AzureadAuthenticationOnly = true,
                //TenantId = Context.Options.TenantId,
                LoginUsername = UserAssignedIdentity.Name,
                ObjectId = UserAssignedIdentity.PrincipalId
            }
        }));

        Substitutions.Add($"{resource.Name}.sqlServerFqdn", sqlServer.FullyQualifiedDomainName);
        Substitutions.Add($"{resource.Name}.sqlServerAdminName", sqlServer.AzureadAdministrator.LoginUsername);
        Substitutions.Add($"{resource.Name}.connectionString",
            resource.ConnectionStringExpression.ValueExpression.Replace("{" + resource.Name + ".outputs.sqlServerFqdn}", sqlServer.FullyQualifiedDomainName));
    }

    private void BuildAzureSqlDatabase(IResourceWithParent resource)
    {
        var dynamicResource = ToDynamic(resource);
        var parent = resource.Parent;
        var sqlServer = GetTerraformResource<MssqlServer>(parent.Name);

        var db = AddTerraformResource(resource.Name, name => new MssqlDatabase(this, name, new MssqlDatabaseConfig
        {
            Name = dynamicResource.DatabaseName,
            Tags = Context.Options.Tags,
            ServerId = sqlServer.Id,
            SkuName = "Serverless"
        }));
    }

    private void BuildAzureKeyVault(IResourceWithConnectionString resource)
    {
        if (ResourceGroup is null) throw new InvalidOperationException("ResourceGroup ist not created");

        var kv = AddTerraformResource(resource, name => new KeyVault(this, name, new KeyVaultConfig()
        {
            Name = name,
            ResourceGroupName = ResourceGroup.Name,
            TenantId = CurrentAzurermClient.TenantId,
            Tags = Context.Options.Tags,
            Location = ResourceGroup.Location,
            RbacAuthorizationEnabled = true,
            SkuName = "standard"
        }));

        Substitutions.Add($"{resource.Name}.vaultUri", kv.VaultUri);

        var role = AddTerraformResource("kv_admin_" + resource.Name, name => new RoleAssignment(this, name, new RoleAssignmentConfig()
        {
            Scope = kv.Id,
            RoleDefinitionName = "Key Vault Administrator",
            PrincipalId = UserAssignedIdentity.PrincipalId

        }));
    }

    private void BuildAzureStorage(AzureBicepResource resource)
    {
        if (ResourceGroup is null) throw new InvalidOperationException("ResourceGroup ist not created");

        var sa = AddTerraformResource(resource, name => new StorageAccount(this, name, new StorageAccountConfig()
        {
            Name = name,
            ResourceGroupName = ResourceGroup.Name,
            Tags = Context.Options.Tags,
            Location = ResourceGroup.Location,
            AccountTier = "Standard",
            AccountReplicationType = "LRS"
        }));

        Substitutions.Add($"{resource.Name}.outputs.tableEndpoint", sa.PrimaryTableEndpoint);
        Substitutions.Add($"{resource.Name}.outputs.blobEndpoint", sa.PrimaryBlobEndpoint);
        Substitutions.Add($"{resource.Name}.outputs.queueEndpoint", sa.PrimaryQueueEndpoint);
        Substitutions.Add($"{resource.Name}.outputs.fileEndpoint", sa.PrimaryFileEndpoint);

        var role = AddTerraformResource("sa_blob_contrib_" + resource.Name, name => new RoleAssignment(this, name, new RoleAssignmentConfig()
        {
            Scope = sa.Id,
            RoleDefinitionName = "Storage Blob Data Contributor",
            PrincipalId = UserAssignedIdentity.PrincipalId
        }));
    }

    private void BuildAzureQueueStorageQueue(IResourceWithParent resource)
    {
        var dynamicResource = ToDynamic(resource);
        var parent = resource.Parent;
        if (parent is IResourceWithParent parent2)
            parent = parent2.Parent;
        var sa = GetTerraformResource<StorageAccount>(parent.Name);

        var queue = AddTerraformResource(resource, name => new StorageQueue(this, name, new StorageQueueConfig()
        {
            Name = dynamicResource.QueueName,
            //StorageAccountId = sa.Id, // not yet in provider
            StorageAccountName = sa.Name
        }));
    }

    //private void BuildAzureTableStorage(IResourceWithParent resource)
    //{
    //    var dynamicResource = ToDynamic(resource);
    //    var parent = resource.Parent;
    //    if (parent is IResourceWithParent parent2)
    //        parent = parent2;
    //    var sa = GetTerraformResource<StorageAccount>(parent.Name);

    //    var queue = AddTerraformResource(resource, name => new StorageTable(this, name, new StorageTableConfig()
    //    {
    //        Name = dynamicResource.TableName,
    //        //StorageAccountId = sa.Id, // not yet in provider
    //        StorageAccountName = sa.Name
    //    }));
    //}

    private void BuildAzureBlobStorageContainer(IResourceWithParent resource)
    {
        var dynamicResource = ToDynamic(resource);
        var parent = resource.Parent;
        if (parent is IResourceWithParent parent2)
            parent = parent2.Parent;
        var sa = GetTerraformResource<StorageAccount>(parent.Name);

        var blob = AddTerraformResource(resource, name => new StorageContainer(this, name, new StorageContainerConfig()
        {
            Name = dynamicResource.BlobContainerName,
            StorageAccountId = sa.Id
        }));
    }

    private void BuildAzureKeyVaultSecret(IResourceWithParent resource)
    {
        var dynamicResource = ToDynamic(resource);
        var parent = resource.Parent;
        var kv = GetTerraformResource<KeyVault>(parent.Name);

        string value = "";
        if (dynamicResource.Value is ParameterResource parameterResource)
        {
            value = TerraformVariables[parameterResource.Name].StringValue;
        }
        else if (dynamicResource.Value is string)
        {
            value = dynamicResource.Value;
        }

        var secret = AddTerraformResource(resource, name => new KeyVaultSecret(this, name, new KeyVaultSecretConfig()
        {
            Name = dynamicResource.SecretName,
            KeyVaultId = kv.Id,
            Tags = Context.Options.Tags,
            Value = value,
        }));

        Substitutions.Add(parent.Name + ".secrets." + resource.Name, secret.Value);
    }
}
