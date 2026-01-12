using Aspire.Hosting.Pipelines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading;

#pragma warning disable ASPIREPIPELINES002
#pragma warning disable ASPIREPIPELINES001
#pragma warning disable IDE0130

namespace Terraform.Aspire.Hosting.Templates;

/// <summary>
/// Executes Terraform commands for initialization, planning, and applying infrastructure changes,
/// using deployment state and configuration to populate environment variables.
/// </summary>
public class TerraformExecutor(ILogger<TerraformExecutor> logger,
    IOptions<PipelineOptions> publishingOptions,
    IDeploymentStateManager deploymentStateManager,
    IConfiguration configuration)
{
    /// <summary>
    /// Initializes Terraform and applies the current plan without prompting for input.
    /// Populates Terraform environment variables from deployment state and configuration.
    /// </summary>
    /// <param name="cancellationToken">Token to observe while waiting for the operation to complete.</param>
    /// <returns>A task that represents the asynchronous apply operation.</returns>
    /// <remarks>Logs output and errors; throws if the Terraform command exits with a non-zero code.</remarks>
    public async Task Apply(CancellationToken cancellationToken)
    {
        var tfEnv = await BuildTerraformEnvironmentVariables(cancellationToken);

        try
        {
            await TerraformCommand("init -reconfigure", cancellationToken);
            await TerraformCommand("apply -input=false -auto-approve", cancellationToken, tfEnv);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error Apply");
        }
    }

    /// <summary>
    /// Initializes Terraform and generates a plan without prompting for input.
    /// Populates Terraform environment variables from deployment state and configuration.
    /// </summary>
    /// <param name="cancellationToken">Token to observe while waiting for the operation to complete.</param>
    /// <returns>A task that represents the asynchronous plan operation.</returns>
    /// <remarks>Logs output and errors; throws if the Terraform command exits with a non-zero code.</remarks>
    public async Task Plan(CancellationToken cancellationToken)
    {
        var tfEnv = await BuildTerraformEnvironmentVariables(cancellationToken);

        try
        {
            await TerraformCommand("init -reconfigure", cancellationToken);
            await TerraformCommand("plan -input=false", cancellationToken, tfEnv);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error Plan");
        }
    }

    private async Task TerraformCommand(string arguments, CancellationToken cancellationToken = default, Dictionary<string, string?>? environmentVariables = null)
    {
        logger.LogInformation("Call " + arguments);

        var process = new Process();
        process.StartInfo = new ProcessStartInfo()
        {
            FileName = "terraform",
            WorkingDirectory = publishingOptions.Value.OutputPath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            UseShellExecute = false,
        };
        if (environmentVariables != null)
        {
            foreach (var environmentVariable in environmentVariables)
            {
                process.StartInfo.Environment.Add(environmentVariable);
            }
        }

        process.OutputDataReceived += (sender, args) =>
        {
            if (args.Data != null) logger.LogInformation(args.Data);
        };
        process.ErrorDataReceived += (sender, args) =>
        {
            if (args.Data != null) logger.LogError(args.Data);
        };
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        await process.WaitForExitAsync(cancellationToken);
        logger.LogInformation("Exited {ExitCode}", process.ExitCode);

        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"Terraform command failed: {process.ExitCode}");
        }
    }

    private async Task<Dictionary<string, string?>> BuildTerraformEnvironmentVariables(CancellationToken cancellationToken = default)
    {
        var tfEnv = new Dictionary<string, string?>();

        var parametersSection = await deploymentStateManager.AcquireSectionAsync("Parameters", cancellationToken);
        foreach (var paramKeyValue in parametersSection.Data)
        {
            tfEnv.Add("TF_VAR_" + paramKeyValue.Key, paramKeyValue.Value.ToString());
        }

        var terraformSection = await deploymentStateManager.AcquireSectionAsync("Terraform", cancellationToken);
        var configVariables = configuration.GetSection("Terraform").GetSection("Variables");
        foreach (var configVariable in configVariables.GetChildren())
        {
            if (!terraformSection.Data.ContainsKey(configVariable.Key))
            {
                terraformSection.Data.Add(configVariable.Key, configVariable.Value);
            }
        }

        await deploymentStateManager.SaveSectionAsync(terraformSection, cancellationToken);

        foreach (var paramKeyValue in terraformSection.Data)
        {
            tfEnv.Add("TF_VAR_" + paramKeyValue.Key, paramKeyValue.Value.ToString());
        }

        return tfEnv;
    }
}