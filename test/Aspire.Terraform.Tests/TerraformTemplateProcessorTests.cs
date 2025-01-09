using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Aspire.Terraform.Tests;

public class TerraformTemplateProcessorTests
{

    private readonly ITestOutputHelper _testOutputHelper;

    public TerraformTemplateProcessorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(".\\testdata\\apphost-manifest-1.json")]
    [InlineData(".\\testdata\\apphost-manifest-2.json")]
    [InlineData(".\\testdata\\apphost-manifest-3.json")]
    [InlineData(".\\testdata\\aspire-args.json")]
    [InlineData(".\\testdata\\aspire-bicep.json")]
    [InlineData(".\\testdata\\aspire-container.json")]
    [InlineData(".\\testdata\\aspire-container-args.json")]
    [InlineData(".\\testdata\\aspire-docker.json")]
    [InlineData(".\\testdata\\aspire-escaping.json")]
    public async Task TerraformTemplateProcessor_Generate_TestManifests(string manifest)
    {
        // setup
        var location = ".\\" + Path.GetFileNameWithoutExtension(manifest);
        if (Directory.Exists(location))
            Directory.Delete(location, true);
        var cli = new AspireTerraformCli();
        await cli.Init(new InitArgs() { Location = location, Template = ".\\Resources\\tf-base\\"});

        // action
        var processor = new TerraformTemplateProcessor(new Logger<TerraformTemplateProcessor>(new XunitLoggerFactory(_testOutputHelper)));
        processor.ManifestPath = manifest;
        processor.TargetDirectory = location;
        processor.TemplateDirectory = Path.Combine(location, ".templates");
        await processor.Generate();

        // todo assert
    }
}
