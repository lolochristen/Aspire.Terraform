using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerArgs;

namespace Aspire.Terraform;

[ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
public class AspireTerraformCli
{
    private readonly IHost _host;

    public AspireTerraformCli()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureLogging(logging => { logging.AddSimpleConsole(options => options.SingleLine = true); })
            .ConfigureServices(services => { services.AddTransient<TerraformTemplateProcessor>(); })
            .Build();
    }

    [ArgActionMethod]
    [ArgDescription("Generates terraform files from an Aspire manifest file.\nTo create an manifest file, execute dotnet run --project Aspire.AppHost.csproj --publisher manifest --output-path .\\apphost-manifest.json")]
    public async Task Generate(GenerationArgs args)
    {
        try
        {
            var processor = _host.Services.GetRequiredService<TerraformTemplateProcessor>();
            processor.ManifestPath = args.Manifest;
            processor.TargetDirectory = args.Location;
            processor.TemplateDirectory = args.Template;

            await processor.Generate();
        }
        catch(Exception e)
        {
            Console.Error.WriteLine("Error in execution");
            Environment.Exit(1);
        }
    }

    [ArgActionMethod]
    [ArgDescription("Initializes a new terraform project from a template")]
    public async Task Init(InitArgs args)
    {
        var source = new DirectoryInfo(Path.Combine(System.AppContext.BaseDirectory, args.Template));
        var target = new DirectoryInfo(args.Location);
        CopyAll(source, target);
    }

    private void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        try
        {
            if (Directory.Exists(target.FullName) == false) Directory.CreateDirectory(target.FullName);

            foreach (var fi in source.GetFiles()) fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);

            foreach (var diSourceDir in source.GetDirectories())
            {
                var nextTargetDir = target.CreateSubdirectory(diSourceDir.Name);
                CopyAll(diSourceDir, nextTargetDir);
            }
        }
        catch (IOException ie)
        {
            Console.Error.WriteLine(ie.Message);
        }
    }
}