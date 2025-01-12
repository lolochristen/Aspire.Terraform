using System.Collections;
using System.Text.Json.Serialization;

namespace Aspire.Terraform.Models;

public class AppHostManifest
{
    public Dictionary<string, Resource> Resources { get; set; }
}

// "https://json.schemastore.org/aspire-8.0.json

[JsonPolymorphic(IgnoreUnrecognizedTypeDiscriminators = true, TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AzureBicepResource), "azure.bicep.v0")]
[JsonDerivedType(typeof(DockerFileResource), "dockerfile.v0")]
[JsonDerivedType(typeof(ContainerResource), "container.v0")]
[JsonDerivedType(typeof(ProjectResource), "project.v0")]
[JsonDerivedType(typeof(ExecutableResource), "executable.v0")]
[JsonDerivedType(typeof(ValueResource), "value.v0")]
[JsonDerivedType(typeof(ParameterResource), "parameter.v0")]
public class Resource
{
    [JsonIgnore] public string Key { get; set; }

    [JsonIgnore] public Dictionary<string, string> Outputs { get; set; } = new();

    [JsonIgnore] public Resource? Parent { get; set; }
}

public class ResourceWithConnectionString : Resource
{
    public string ConnectionString { get; set; }

    [JsonIgnore] public IDictionary? ConnectionStringValues { get; set; }
}

public class AzureBicepResource : ResourceWithConnectionString
{
    public string Path { get; set; }
    public Dictionary<string, object>? Params { get; set; }
}

public class DockerFileResource : ContainerResource
{
    public string Context { get; set; }
    public string Path { get; set; }
}

public class ContainerResource : ResourceWithConnectionString
{
    public string Image { get; set; }
    public string Entrypoint { get; set; }
    public List<string> Args { get; set; }
    public Dictionary<string, Bindings> Bindings { get; set; }
    public Dictionary<string, string> BuildArgs { get; set; }
    public Dictionary<string, string>? Env { get; set; }
    public BindingMounts BindingMounts { get; set; }
    public List<Volumes> Volumes { get; set; }
    public bool Build { get; set; }
}

public class ProjectResource : ContainerResource
{
    public string Path { get; set; }
}

public class Bindings
{
    public string Scheme { get; set; }
    public string Protocol { get; set; }
    public string Transport { get; set; }

    public bool External { get; set; }
    public int TargetPort { get; set; } = 8080;
    public int? Port { get; set; }

    [JsonIgnore] public string Host { get; set; } = "TODO";
    [JsonIgnore] public string Url { get; set; } = "TODO";
}

public class ExecutableResource : Resource
{
}

public class ValueResource : ResourceWithConnectionString
{
}

public class ParameterResource : ResourceWithConnectionString
{
    public string Value { get; set; }

    public Dictionary<string, Inputs> Inputs { get; set; }
}

public class Inputs
{
    public string Type { get; set; } = "string";
    public bool Secret { get; set; }
    public DefaultValue? Default { get; set; }
}

public class DefaultValue
{
    public GenerateValue Generate { get; set; }
}

public class GenerateValue
{
    public int MinLength { get; set; }
    public bool Lower { get; set; }
    public bool Upper { get; set; }
    public bool Numeric { get; set; }
    public bool Special { get; set; }
    public int MinLower { get; set; }
    public int MinUpper { get; set; }
    public int MinNumeric { get; set; }
    public int MinSpecial { get; set; }
}

public class BindingMounts
{
}

public class Volumes
{
}

//public enum Scheme
//{
//    http, https, tcp, udp
//}

//public enum Protocol
//{
//    tcp, udp
//}