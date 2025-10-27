using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Aspire.Hosting.Testing;
using Aspire.Hosting.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace Terraform.Aspire.Hosting.Templates.Azure.Tests;

public class TerraformTemplatePublisherTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureSql_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        builder.AddAzureSqlServer("sqlserver")
            .AddDatabase("db");

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "sqlserver.tf")));
        Assert.True(File.Exists(Path.Combine(outputPath, "db.tf")));
    }

    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureServiceBus_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        var bus = builder.AddAzureServiceBus("servicebus");
        var queue = bus.AddServiceBusQueue("queue");
        var topic = bus.AddServiceBusTopic("topic");
        topic.AddServiceBusSubscription("topic-sub1", "sub1");

        builder.AddContainer("container", "container")
            .WithReference(bus)
            .WithReference(queue)
            .WithReference(topic);

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "servicebus.tf")));
    }

    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureCosmos_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        var cosmos = builder.AddAzureCosmosDB("cosmos");
        var db = cosmos.AddCosmosDatabase("db", "dbname");

        builder.AddContainer("container", "container")
            .WithReference(db);

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "cosmos.tf")));
    }

    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureSignalr_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        var signalr = builder.AddAzureSignalR("signalr");

        builder.AddContainer("container", "container")
            .WithReference(signalr);

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "signalr.tf")));
    }

    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureSearch_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        var search = builder.AddAzureSearch("search");

        builder.AddContainer("container", "container")
            .WithReference(search);

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "search.tf")));
    }

    [Fact]
    public async Task TerraformAzureTemplatePublisher_PublishAzureEventHub_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformAzureTemplatePublishing("terraform", options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        var hubs = builder.AddAzureEventHubs("hubs");
        var hub = hubs.AddHub("hub", "hubname");
        var consumer = hub.AddConsumerGroup("consumer", "consumerGroupName");

        builder.AddContainer("container", "container")
            .WithReference(hubs)
            .WithReference(hub)
            .WithReference(consumer);

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "hubs.tf")));
    }
}

