using Aspire.Hosting;
using Aspire.Hosting.Azure;

#pragma warning disable ASPIREPUBLISHERS001
var builder = DistributedApplication.CreateBuilder(args);

//builder.AddTerraformTemplatePublishing();

builder.AddTerraformAzureTemplatePublishing(configureOptions: options =>
{
    options.BaseFiles = "main.tf;variables.tf;outputs.tf"; // for terragrunt without providers.tf;versions.tf;backend.tf
});

var tfTemplate = builder.AddTerraformTemplate("tf-template", "my-template.tf.hbs") // explicit
    .WithParameter("tfp1", "Hello");

var cache = builder.AddAzureRedis("cache");

var sql = builder.AddAzureSqlServer("sql");
var db = sql.AddDatabase("db");

var param1 = builder.AddParameter("param1");
var param2 = builder.AddParameter("param2", secret: true);
var param3 = builder.AddParameter("param3", "default value");

var storage = builder.AddAzureStorage("storage");
var blob = storage.AddBlobContainer("blob1", "myblob");
var queue = storage.AddQueue("queue1", "myqueue");

var insights = builder.ExecutionContext.IsPublishMode
    ? builder.AddAzureApplicationInsights("appinsights")
    : builder.AddConnectionString("appinsights", "APPLICATIONINSIGHTS_CONNECTION_STRING");

var signalr = builder.AddAzureSignalR("signalr");

var kv = builder.AddAzureKeyVault("kv");
kv.AddSecret("kvsecret1", "secret1", param2);
kv.AddSecret("kvsecret2", ReferenceExpression.Create($"new secret"));
kv.AddSecret("kvsecret3", ReferenceExpression.Create($"{tfTemplate.GetSecretOutput("output2")}"));

var apiService = builder.AddProject<Projects.AzureContainerApps_ApiService>("apiservice")
    .WaitFor(db)
    .WithReference(db)
    .WithEnvironment("P1", param1)
    .WithEnvironment("P2", param2)
    .WithEnvironment("OUTPUT_TF", tfTemplate.GetOutput("output1"))
    .WithEnvironment("OUTPUT_TF2", tfTemplate.GetSecretOutput("output2"))
    .WithEnvironment("KV_SECRET", kv.GetSecret("kvsecret1"))
    .WithReference(tfTemplate)
    .WithReference(queue)
    .WithReference(insights);

var web = builder.AddProject<Projects.AzureContainerApps_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WithReference(insights)
    .WithReference(signalr)
    .WithEnvironment("TEST_PORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Port))
    .WithEnvironment("TEST_HOST", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Host))
    .WithEnvironment("TEST_HOSTPORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.HostAndPort))
    .WaitFor(apiService)
    .WithTerraformTemplateParameter("CPU", "0.5");

var container = builder.AddContainer("container", "mcr.microsoft.com/dotnet/aspnet", "9.0")
    .WithHttpEndpoint(targetPort: 7080)
    .WithReference(apiService)
    .WithVolume("vol1", "/app")
    .WithBindMount("./source", "/target")
    .WithContainerFiles("/target_files", "./properties")
    .WithEnvironment("SQL", db)
    .WithReference(blob)
    .WithTerraformTemplate("container-app.tf.hbs") // default
    .WithTerraformTemplate("container-app-extra.tf.hbs", "container-app-extra.tf"); // extra

if (builder.ExecutionContext.IsRunMode)
{
    sql.RunAsContainer();
    cache.RunAsContainer();
    storage.RunAsEmulator();
}

await builder.Build().RunAsync();
