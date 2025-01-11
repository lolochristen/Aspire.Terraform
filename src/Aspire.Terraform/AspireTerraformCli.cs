using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using HandlebarsDotNet.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerArgs;

namespace Aspire.Terraform;

[ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
public class AspireTerraformCli
{
    private readonly IHost _host;
    private readonly ILogger<AspireTerraformCli> _logger;

    public AspireTerraformCli()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureLogging(logging => { logging.AddSimpleConsole(options => options.SingleLine = true); })
            .ConfigureServices(services => { services.AddTransient<TerraformTemplateProcessor>(); })
            .Build();

        _logger = _host.Services.GetRequiredService<ILogger<AspireTerraformCli>>();
    }

    [ArgActionMethod]
    [ArgDescription("Generates terraform files from an Aspire manifest file.\nTo create an manifest file, execute dotnet run --project Aspire.AppHost.csproj --publisher manifest --output-path .\\apphost-manifest.json")]
    public async Task Generate(GenerationArgs args)
    {
        try
        {
            var processor = _host.Services.GetRequiredService<TerraformTemplateProcessor>();

            processor.ManifestPath = args.Manifest ?? BuildManifest(args.Manifest);
            
            Directory.CreateDirectory(args.Location);
            if (Directory.GetFiles(args.Location).Length == 0)
            {
                await Init(new InitArgs() { Location = args.Location, Template = ".\\Resources\\tf-base"});
            }

            processor.TargetDirectory = args.Location;

            processor.TemplateDirectory = args.Template;

            await processor.Generate();

            _logger.LogInformation("Done");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error while generating");
            Environment.Exit(1);
        }
    }

    [ArgActionMethod]
    [ArgDescription("Initializes a new terraform project from a template")]
    public async Task Init(InitArgs args)
    {
        var source = new DirectoryInfo(Path.Combine(System.AppContext.BaseDirectory, args.Template));
        var target = new DirectoryInfo(args.Location);
        _logger.LogInformation("Initializing aspire terraform folder {source} to {target}", target, source);
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
        catch (IOException ex)
        {
            _logger.LogError(ex, "copy failed");
        }
    }

    private string BuildManifest(string? csProjectPath = null)
    {
        if (csProjectPath == null)
        {
            var files = Directory.GetFiles(".", "*.csproj");
            if (files.Length != 1)
            {
                throw new ApplicationException("No project found or too many.");
            }
            csProjectPath = files.First();
        }

        string manifestPath = Path.GetTempFileName();

        Console.WriteLine($"Build {csProjectPath}");
        var process = Process.Start(new ProcessStartInfo("dotnet", new []{"run", 
            "--project", csProjectPath, "--publisher", "manifest", "--output-path", manifestPath}));

        if (process == null)
        {
            _logger.LogError("Failed to start manifest creation process.");
            throw new ApplicationException("Failed to start manifest creation process.");
        }

        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            _logger.LogError("Failed to create manifest");
            throw new ApplicationException("Failed to create manifest");
        }

        return manifestPath;
    }
}