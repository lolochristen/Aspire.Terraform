using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Constructs;
using HashiCorp.Cdktf;
using Hashicorp.Cdktf.Providers.Azapi.Provider;
using Hashicorp.Cdktf.Providers.Azapi.Resource;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerApp;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerAppEnvironment;
using HashiCorp.Cdktf.Providers.Azurerm.ContainerRegistry;
using HashiCorp.Cdktf.Providers.Azurerm.LogAnalyticsWorkspace;
using HashiCorp.Cdktf.Providers.Azurerm.MssqlDatabase;
using HashiCorp.Cdktf.Providers.Azurerm.MssqlServer;
using HashiCorp.Cdktf.Providers.Azurerm.Provider;
using HashiCorp.Cdktf.Providers.Azurerm.ResourceGroup;
using HashiCorp.Cdktf.Providers.Azurerm.RoleAssignment;
using HashiCorp.Cdktf.Providers.Azurerm.UserAssignedIdentity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using IResource = Aspire.Hosting.ApplicationModel.IResource;
using Resource = Hashicorp.Cdktf.Providers.Azapi.Resource.Resource;
using ResourceGroup = HashiCorp.Cdktf.Providers.Azurerm.ResourceGroup.ResourceGroup;

namespace Aspire.Hosting;

public class AzureContainerAppsTerraformStack(Construct scope, string id) : TerraformAspireStack(scope, id)
{
    protected TerraformCdkAzurePublishingOptions? AzureOptions { get; set; }

    public ResourceGroup? ResourceGroup { get; private set; }

    public AzurermProvider? AzurermProvider { get; private set; }
    public UserAssignedIdentity? UserAssignedIdentity { get; private set; }

    protected override void Finialize()
    {
    }

    protected override void BuildResources()
    {
        //foreach (var modelResource in Context.Model.Resources)
        //{
        //    if (modelResource.TryGetAnnotationsOfType(out IEnumerable<TerraformBuilderAnnotation> tfBuilderAnnotations))
        //    {
        //        foreach (var terraformBuilderAnnotation in tfBuilderAnnotations)
        //        {
        //            terraformBuilderAnnotation.BuildResource(modelResource, Context);
        //        }
        //    }
        //}

        foreach (var resource in Context.Model.Resources)
            if (resource is not TerraformProvisioningResource)
            {
                Console.WriteLine($"{resource.Name} {resource.GetType()}");
                switch (resource)
                {
                    case ProjectResource projectResource:
                    case ContainerResource containerResource:
                        BuildContainerApp(resource);
                        break;
                    case AzureSqlServerResource azureSqlResource:
                        BuildAzureSqlServer(azureSqlResource);
                        break;
                    //case AzureProvisioningResource azureProvisioningResource:
                    //    break;
                }
            }
    }

    private void BuildAzureSqlServer(AzureSqlServerResource azureSqlResource)
    {
        if (ResourceGroup is null) throw new InvalidOperationException("ResourceGroup ist not created");

        var sqlServer = AddTerraformResource(azureSqlResource.Name, name => new MssqlServer(this, name, new MssqlServerConfig
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

        Substitutions.Add($"{azureSqlResource.Name}.sqlServerFqdn", sqlServer.FullyQualifiedDomainName);
        Substitutions.Add($"{azureSqlResource.Name}.sqlServerAdminName", sqlServer.AzureadAdministrator.LoginUsername);
        Substitutions.Add($"{azureSqlResource.Name}.connectionString",
            $"Server=tcp:{sqlServer.FullyQualifiedDomainName},1433;Encrypt=True;Authentication=\"Active Directory Default\"");

        foreach (var azureSqlDatabaseResource in azureSqlResource.AzureSqlDatabases)
        {
            var db = AddTerraformResource(azureSqlDatabaseResource.Key, name => new MssqlDatabase(this, name, new MssqlDatabaseConfig
            {
                Name = azureSqlDatabaseResource.Value.DatabaseName,
                Tags = Context.Options.Tags,
                ServerId = sqlServer.Id,
                SkuName = "Serverless"
            }));
        }
    }

    protected override void Initialize()
    {
        base.Initialize();

        var azureSettings = Context.Services.GetRequiredService<IOptions<TerraformCdkAzurePublishingOptions>>();
        AzureOptions = azureSettings.Value;

        //foreach (var resource in Context.Model.Resources)
        //{
        //    if (resource is not TerraformProvisioningResource || !resource.Annotations.OfType<TerraformBuilderAnnotation>().Any())
        //    {
        //        if (resource is ProjectTemplateResource projectResource)
        //        {
        //            resource.Annotations.Add(new TerraformBuilderAnnotation()
        //            {
        //                BuildResource = BuildContainerApp
        //            });
        //        }
        //    }
        //}

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

        // explicit uai
        //foreach (var uaiResource in Context.Model.Resources.OfType<AzureUserAssignedIdentityResource>())
        //{
        //    var uai = AddTerraformResource(uaiResource.Name, (name) => new UserAssignedIdentity(this, name, new UserAssignedIdentityConfig
        //    {
        //        Name = uaiResource.Name,
        //        ResourceGroupName = resourceGroup.Name,
        //        Location = resourceGroup.Location,
        //        Tags = Context.Options.Tags
        //    }));
        //}
    }

    private void BuildContainerApp(IResource resource)
    {
        resource.TryGetEndpoints(out var endpoints);

        var containerAppEnvironment = GetTerraformResource<ContainerAppEnvironment>(Context.Options.BaseName);

        var primaryEndpoint = endpoints?.FirstOrDefault();

        var envList = new List<ContainerAppTemplateContainerEnv>();
        var resourceEnv = GetResourceEnvironmentValues(Context.ExecutionContext, resource);

        //var httpPorts = resourceEnv.ContainsKey("HTTP_PORTS") ? resourceEnv["HTTP_PORTS"].Item2 : null; // envList.FirstOrDefault(p => p.Value == "HTTP_PORTS")?.Value;
        var targetPort = primaryEndpoint?.TargetPort;
        //if (targetPort is null && httpPorts != null)
        //{
        //    targetPort = int.Parse(httpPorts, CultureInfo.InvariantCulture);
        //}
        targetPort ??= 8080;

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

            if (envValue.Value.Item1 is EndpointReference endpointReference)
            {
                // if external url shall be used:
                //var referencedApp = GetTerraformResource<ContainerApp>(endpointReference.TemplateResource.Name);
                //containerAppTemplateContainerEnv.Value = endpointReference.Scheme + "://" + referencedApp.Ingress.Fqdn;
            }

            if (envValue.Value.Item1 is ReferenceExpression referenceExpression)
            {
                Console.WriteLine(referenceExpression.ValueExpression);
                containerAppTemplateContainerEnv.Value = SubstituteValueExpressions(referenceExpression.ValueExpression);
            }

            if (envValue.Value.Item1 is ConnectionStringReference connectionStringReference)
            {
                Console.WriteLine(connectionStringReference.Resource.ConnectionStringExpression.ValueExpression);
                containerAppTemplateContainerEnv.Value = SubstituteValueExpressions(connectionStringReference.Resource.ConnectionStringExpression.ValueExpression);
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

        // custom uai. 
        //if (resource.TryGetAnnotationsOfType<AppIdentityAnnotation>(out var appIdentityAnnotations))
        //{
        //    if (appIdentityAnnotations.First().IdentityResource is IResource azuai)
        //    {
        //        uai = GetTerraformResource<UserAssignedIdentity>(azuai.Name);
        //    }
        //}

        if (!resource.TryGetContainerImageName(out var imageName))
        {
            var car = GetTerraformResource<ContainerRegistry>(Context.Options.BaseName);

            registry = new ContainerAppRegistry
            {
                Server = car.LoginServer,
                Identity = uai.Id
            };

            imageName = $"{car.LoginServer}/{resource.Name}:latest";
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
}