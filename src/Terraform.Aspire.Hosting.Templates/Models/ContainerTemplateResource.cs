namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Template resource for container-based resources including images, bindings, and volumes.
/// </summary>
public class ContainerTemplateResource : TemplateResourceWithConnectionString
{
    /// <summary>
    /// Gets or sets the container image name.
    /// </summary>
    public string? Image { get; set; }
    
    /// <summary>
    /// Gets or sets the container entrypoint.
    /// </summary>
    public string? Entrypoint { get; set; }

    /// <summary>
    /// Gets or sets the container command arguments.
    /// </summary>
    public string[] Args { get; set; } = [];
    
    /// <summary>
    /// Gets or sets the network bindings for the container.
    /// </summary>
    public Dictionary<string, Bindings> Bindings { get; set; } = new();

    /// <summary>
    /// Gets or sets the Docker build arguments.
    /// </summary>
    public Dictionary<string, string> BuildArgs { get; set; } = new();

    /// <summary>
    /// Gets or sets the environment variables.
    /// </summary>
    public Dictionary<string, string> Env { get; set; } = new();

    /// <summary>
    /// Gets or sets the volume mounts.
    /// </summary>
    public List<Volumes> Volumes { get; set; } = new();
    
    /// <summary>
    /// Gets or sets whether this container requires building.
    /// </summary>
    public bool Build { get; set; }

    /// <summary>
    /// Gets or sets the number of replicas.
    /// </summary>
    public int Replicas { get; set; } = 1;

    /// <summary>
    /// Gets or sets the secret environment variables.
    /// </summary>
    public Dictionary<string, string> SecretEnv { get; set; } = new();

    /// <summary>
    /// Gets all environment variables.
    /// </summary>
    public Dictionary<string, string> AllEnv => Env.Union(SecretEnv).ToDictionary();
}