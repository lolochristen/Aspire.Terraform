using PowerArgs;

namespace Aspire.Terraform;

public class GenerationArgs
{
    [ArgDescription("The location for the generated files")]
    [ArgDefaultValue(".\\infra")]
    [ArgPosition(1)]
    public string Location { get; set; }

    [ArgDescription("The path to the manifest file")]
    [ArgPosition(2)]
    public string? Manifest { get; set; }

    [ArgDescription("The directory containing templates")]
    public string? Template { get; set; }
}