using Aspire.Hosting;
using Constructs;
using HashiCorp.Cdktf;

#pragma warning disable ASPIREPUBLISHERS001
var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddAzureRedis("cache");

var sql = builder.AddAzureSqlServer("sql");
var db = sql.AddDatabase("db");

var param1 = builder.AddParameter("param1");
var param2 = builder.AddParameter("param2", true);

var storage = builder.AddAzureStorage("storage");
var blob = storage.AddBlobContainer("blob1", "myblob");
var queue = storage.AddQueue("queue1", "myqueue");

var kv = builder.AddAzureKeyVault("kv");
kv.AddSecret("kvsecret1", "secret1", param2);
kv.AddSecret("kvsecret2", ReferenceExpression.Create($"new secret"));

kv.AddSecret("kvsecret3", db.Resource.ConnectionStringExpression);

var apiService = builder.AddProject<Projects.AzureContainerApps_ApiService>("apiservice")
    .WaitFor(db)
    .WithReference(db)
    .WithEnvironment("P1", param1)
    .WithEnvironment("KV_SECRET", kv.GetSecret("kvsecret1"))
    .WithReference(queue);

var web = builder.AddProject<Projects.AzureContainerApps_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WithEnvironment("TEST_PORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Port))
    .WithEnvironment("TEST_HOST", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Host))
    .WithEnvironment("TEST_HOSTPORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.HostAndPort))
    .WithEnvironment("KV_SECRET_3", kv.GetSecret("kvsecret3"))
    .WaitFor(apiService);

var container = builder.AddContainer("container", "mcr.microsoft.com/dotnet/aspnet", "9.0")
    .WithHttpEndpoint(targetPort: 7080)
    .WithReference(apiService)
    .WithVolume("vol1", "/app")
    .WithBindMount("./source", "/target")
    .WithContainerFiles("/target_files", "./properties")
    .WithEnvironment("SQL", db)
    .WithReference(blob);




if (builder.ExecutionContext.IsRunMode)
{
    sql.RunAsContainer();
    cache.RunAsContainer();
    storage.RunAsEmulator();
}

builder.AddTerraformCdkPublishing(configureOptions: options =>
{
    options.NamePrefix = "aspire-p1";
    options.Tags = new Dictionary<string, string>() { { "customer", "aspire" }, { "environment", "p1" } };
});

var terraform = builder.AddTerraformCdkEnvironment("terraform");

var appStack = terraform.AddAzureContainerAppStack("azure-tf", options => { options.SubscriptionId = "de17f00b-e44f-4012-931a-2cec4b870839"; })
    .WithBackend((scope) => new AzurermBackend(scope, new AzurermBackendConfig()
        {
            TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
            StorageAccountName = "sa1",
            ContainerName = "container1",
            UseAzureadAuth = true,
            SubscriptionId = "de17f00b-e44f-4012-931a-2cec4b870839",
            Key = "azurerm"
        }
    ));

var mystack = terraform.AddStack<MyStack>("mystack");

var otherstack = terraform.AddStack("customstack")
    .WithTerraformResource((stack) =>
    {
        new TerraformVariable(stack, "var1", new TerraformVariableConfig() { Type = "string" });

        new TerraformLocal(stack, "local1", new Dictionary<string, string> {
            { "Service", "service_name" },
            { "Owner", "owner" },
        });
    })
    .WithModule("a_module", "./modules/a_module");

await builder.Build().RunAsync();

public class MyStack : TerraformStack
{
    public MyStack(Construct scope, string id) : base(scope, id)
    {
        new TerraformOutput(this, "output1", new TerraformOutputConfig()
        {
            Value = "Hello from MyStack"
        });
    }
}
