using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Publishing;
using Aspire.Hosting.Testing;
using Aspire.Hosting.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace Terraform.Aspire.Hosting.Templates.Tests;

public class TerraformTemplatePublisherTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public async Task TerraformTemplatePublisher_PublishContainer_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformTemplatePublishing(options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        builder.AddContainer("container", "image");

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "container.tf")));
    }

    [Fact]
    public async Task TerraformTemplatePublisher_PublishParameter_Success()
    {
        await using var builder = TestDistributedApplicationBuilder.CreateWithOutput(DistributedApplicationOperation.Publish, "terraform", testOutputHelper: outputHelper);
        builder.AddTerraformTemplatePublishing(options =>
        {
            options.TemplatesPath = "../../../../../templates/container-apps";
            options.FilePrefix = null;
        });

        builder.AddParameter("parameter", "1");

        await using var app = await builder.BuildAsync();
        var model = app.Services.GetRequiredService<DistributedApplicationModel>();
        var publisher = app.Services.GetRequiredKeyedService<IDistributedApplicationPublisher>("terraform");

        await publisher.PublishAsync(model, CancellationToken.None);

        var outputPath = app.Services.GetRequiredService<IOptions<PublishingOptions>>().Value.OutputPath;
        Assert.True(File.Exists(Path.Combine(outputPath, "variables.tf")));

        var content = await File.ReadAllTextAsync(Path.Combine(outputPath, "variables.tf"));
        Assert.Contains("variable \"parameter\"", content);

    }

}

