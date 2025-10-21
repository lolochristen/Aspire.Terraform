using Aspire.Hosting.ApplicationModel;

namespace Terraform.Aspire.Hosting.Templates.Models;

/// <summary>
/// Base class for template resource models used in Terraform generation.
/// </summary>
public class TemplateResource
{
    /// <summary>
    /// Gets or sets the original Aspire resource.
    /// </summary>
    public IResource Resource { get; set; }
    
    /// <summary>
    /// Gets or sets the resource name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the Terraform outputs for this resource.
    /// </summary>
    public Dictionary<string, string> Outputs { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the parent resource if this is a child resource.
    /// </summary>
    public TemplateResource? Parent { get; set; }
    
    /// <summary>
    /// Gets or sets custom parameters for template processing.
    /// </summary>
    public Dictionary<string, object?> Parameters { get; set; } = new();
}

/// <summary>
/// Template resource that includes connection string information.
/// </summary>
public class TemplateResourceWithConnectionString : TemplateResource
{
    /// <summary>
    /// Gets or sets the connection string for the resource.
    /// </summary>
    public string ConnectionString { get; set; }

    //public IDictionary? ConnectionStringValues { get; set; }
}

/// <summary>
/// Azure-specific template resource with Azure resource properties.
/// </summary>
public class AzureTemplateResource : TemplateResourceWithConnectionString
{
}

/// <summary>
/// Template resource for Docker containers built from Dockerfile.
/// </summary>
public class DockerFileTemplateResource : ContainerTemplateResource
{
    /// <summary>
    /// Gets or sets the build context path.
    /// </summary>
    public string Context { get; set; }
    
    /// <summary>
    /// Gets or sets the Dockerfile path.
    /// </summary>
    public string Path { get; set; }
}

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
    public string[] Args { get; set; }
    
    /// <summary>
    /// Gets or sets the network bindings for the container.
    /// </summary>
    public Dictionary<string, Bindings> Bindings { get; set; }
    
    /// <summary>
    /// Gets or sets the Docker build arguments.
    /// </summary>
    public Dictionary<string, string> BuildArgs { get; set; }
    
    /// <summary>
    /// Gets or sets the environment variables.
    /// </summary>
    public Dictionary<string, string>? Env { get; set; }
    
    /// <summary>
    /// Gets or sets the volume mounts.
    /// </summary>
    public List<Volumes> Volumes { get; set; }
    
    /// <summary>
    /// Gets or sets whether this container requires building.
    /// </summary>
    public bool Build { get; set; }
    
    /// <summary>
    /// Gets or sets the number of replicas.
    /// </summary>
    public int Replicas { get; set; }
}

/// <summary>
/// Template resource for .NET project resources.
/// </summary>
public class ProjectTemplateResource : ContainerTemplateResource
{
    /// <summary>
    /// Gets or sets the project file path.
    /// </summary>
    public string Path { get; set; }
}

/// <summary>
/// Represents network binding configuration for containers.
/// </summary>
public class Bindings
{
    /// <summary>
    /// Gets or sets the URI scheme (http, https).
    /// </summary>
    public string Scheme { get; set; }
    
    /// <summary>
    /// Gets or sets the network protocol.
    /// </summary>
    public string Protocol { get; set; }
    
    /// <summary>
    /// Gets or sets the transport protocol.
    /// </summary>
    public string Transport { get; set; }

    /// <summary>
    /// Gets or sets whether the binding is externally accessible.
    /// </summary>
    public bool External { get; set; }
    
    /// <summary>
    /// Gets or sets the target port inside the container.
    /// </summary>
    public int? TargetPort { get; set; } = 8080;
    
    /// <summary>
    /// Gets or sets the external port.
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    /// Gets or sets the hostname for the binding.
    /// </summary>
    public string Host { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the full URL for the binding.
    /// </summary>
    public string Url { get; set; } = string.Empty;
}

/// <summary>
/// Template resource for executable resources.
/// </summary>
public class ExecutableTemplateResource : TemplateResource
{
}

/// <summary>
/// Template resource for value-based resources.
/// </summary>
public class ValueTemplateResource : TemplateResourceWithConnectionString
{
}

/// <summary>
/// Template resource for parameter resources.
/// </summary>
public class ParameterTemplateResource : TemplateResourceWithConnectionString
{
    /// <summary>
    /// Gets or sets the parameter value.
    /// </summary>
    public string Value { get; set; }

    //public Dictionary<string, Inputs> Inputs { get; set; }
}

/// <summary>
/// Represents volume mount configuration for containers.
/// </summary>
public class Volumes
{
    /// <summary>
    /// Gets or sets the volume name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the volume source path.
    /// </summary>
    public string? Source { get; set; }
    
    /// <summary>
    /// Gets or sets the target mount path in the container.
    /// </summary>
    public string Target { get; set; }
    
    /// <summary>
    /// Gets or sets whether the volume is read-only.
    /// </summary>
    public bool IsReadOnly { get; set; }
}