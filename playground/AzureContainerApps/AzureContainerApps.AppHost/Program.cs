using Aspire.Hosting.Azure;
using Aspire.Hosting.Lifecycle;
using Terraform.Aspire.Hosting;
using Terraform.Aspire.Hosting.Templates;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Azurerm.Provider;
using k8s.KubeConfigModels;

#pragma warning disable ASPIREPUBLISHERS001
var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddAzureRedis("cache");

var sql = builder.AddAzureSqlServer("sql");
var db = sql.AddDatabase("db");

var param1 = builder.AddParameter("param1");
var param2 = builder.AddParameter("param2");

var storage = builder.AddAzureStorage("storage");
var blob = storage.AddBlobs("blob1");
var queue = storage.AddQueue("queue1");

var apiService = builder.AddProject<Projects.AzureContainerApps_ApiService>("apiservice")
    .WaitFor(db)
    .WithReference(db)
    .WithEnvironment("P1", param1)
    .WithReference(queue);

var web = builder.AddProject<Projects.AzureContainerApps_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    //.WithReference(cache)
    //.WaitFor(cache)
    .WithReference(apiService)
    .WithEnvironment("TEST_PORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Port))
    .WithEnvironment("TEST_HOST", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.Host))
    .WithEnvironment("TEST_HOSTPORT", apiService.Resource.GetEndpoint("http").Property(EndpointProperty.HostAndPort))
    .WaitFor(apiService)
    .WithTerraformTemplateParameter("CPU", "0.5");

var container = builder.AddContainer("container", "mcr.microsoft.com/dotnet/aspnet", "9.0")
    .WithHttpEndpoint(targetPort: 7080)
    //.WithEntrypoint("KickIt")
    .WithReference(apiService)
    .WithVolume("vol1", "/app")
    .WithBindMount("./source", "/target")
    .WithContainerFiles("/target_files", "./properties")
    .WithEnvironment("SQL", db)
    .WithReference(blob);


if (builder.ExecutionContext.IsRunMode)
{
    sql.RunAsContainer();
    //cache.RunAsContainer();
    storage.RunAsEmulator();
}

//builder.AddAzureProvisioning();
//#pragma warning disable ASPIREAZURE001
//builder.AddAzureEnvironment();
//#pragma warning restore ASPIREAZURE001
//builder.AddAzureContainerAppEnvironment("aca-env");


//builder.AddTerraformTemplatePublishing();
builder.AddTerraformAzureTemplatePublishing(configureOptions: options =>
{
    options.BaseFiles = "main.tf;variables.tf;outputs.tf"; // for terragrunt without providers.tf;versions.tf;backend.tf
});

//builder.AddTerraformTemplateProvisioning();

//builder.AddTerraformTemplateEnvironment("terraform-template");
//    .WithReferenceRelationship(cache);


//builder.AddTerraformCdkPublishing(configureOptions: options =>
//{
//    options.NamePrefix = "isol-p1";
//    options.Tags = new Dictionary<string, string>() { { "customer", "isol" }, { "environment", "p1" } };
//});

//var terraform = builder.AddTerraformCdkEnvironment("terraform");

//terraform.AddAzureContainerAppStack("azure-tf", options =>
//{
//    options.SubscriptionId = "de17f00b-e44f-4012-931a-2cec4b870839";
//});

//var mystack = terraform.AddStack<MyStack>("mystack");

//var mystack2 = terraform.AddStack<MyStack2>("mystack2")
//    .WithTerraformResource(stack =>
//    {
//        new TerraformVariable(stack, "var1", new TerraformVariableConfig() { Type = "string" });
//        new TerraformLocal(stack, "local1", new Dictionary<string, string> {
//            { "Service", "service_name" },
//            { "Owner", "owner" },
//        });
//    });

//var otherstack = terraform.AddStack("customstack")
//    .WithTerraformResource((stack) =>
//    {
//        new TerraformVariable(stack, "var1", new TerraformVariableConfig() { Type = "string" });

//        new TerraformLocal(stack, "local1", new Dictionary<string, string> {
//            { "Service", "service_name" },
//            { "Owner", "owner" },
//        });
//    })
//    .WithModule("a_module", "./modules/a_module");

await builder.Build().RunAsync();


//public class AzureContainerAppsContainerAppsTerraform : AzureContainerAppsTerraformStack
//{
//    public AzureContainerAppsContainerAppsTerraform(Construct scope, string id) : base(scope, id)
//    {
//        TerraformResourceCreated += (sender, args) =>
//        {
//            Console.WriteLine(args.Resource.FriendlyUniqueId);
//        };
//    }
//}

//public class MyStack : TerraformStack
//{
//    public MyStack(Construct scope, string id) : base(scope, id)
//    {
//        new TerraformOutput(this, "output1", new TerraformOutputConfig()
//        {
//            Value = "Hello from MyStack"
//        });
//    }
//}

//public class MyStack2 : TerraformAspireStack
//{
//    public MyStack2(Construct scope, string id) : base(scope, id)
//    {
//        new TerraformOutput(this, "output1", new TerraformOutputConfig()
//        {
//            Value = "Hello from MyStack"
//        });
//    }
//}