using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.Terraform.Templates.Models;

public class TemplateResource
{
    public IResource Resource { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Outputs { get; set; } = new();
    public TemplateResource? Parent { get; set; }
    public Dictionary<string, object?> Parameters { get; set; } = new();
}

public class TemplateResourceWithConnectionString : TemplateResource
{
    public string ConnectionString { get; set; }

    //public IDictionary? ConnectionStringValues { get; set; }
}

public class AzureTemplateResource : TemplateResourceWithConnectionString
{
}

public class DockerFileTemplateResource : ContainerTemplateResource
{
    public string Context { get; set; }
    public string Path { get; set; }
}

public class ContainerTemplateResource : TemplateResourceWithConnectionString
{
    public string? Image { get; set; }
    public string? Entrypoint { get; set; }
    public string[] Args { get; set; }
    public Dictionary<string, Bindings> Bindings { get; set; }
    public Dictionary<string, string> BuildArgs { get; set; }
    public Dictionary<string, string>? Env { get; set; }
    public List<Volumes> Volumes { get; set; }
    public bool Build { get; set; }
    public int Replicas { get; set; }
}

public class ProjectTemplateResource : ContainerTemplateResource
{
    public string Path { get; set; }
}

public class Bindings
{
    public string Scheme { get; set; }
    public string Protocol { get; set; }
    public string Transport { get; set; }

    public bool External { get; set; }
    public int? TargetPort { get; set; } = 8080;
    public int? Port { get; set; }

    public string Host { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class ExecutableTemplateResource : TemplateResource
{
}

public class ValueTemplateResource : TemplateResourceWithConnectionString
{
}

public class ParameterTemplateResource : TemplateResourceWithConnectionString
{
    public string Value { get; set; }

    //public Dictionary<string, Inputs> Inputs { get; set; }
}

public class Volumes
{
    public string Name { get; set; }
    public string? Source { get; set; }
    public string Target { get; set; }
    public bool IsReadOnly { get; set; }
}
