using PowerArgs;

namespace Aspire.Terraform;

public class InitArgs
{
    [ArgRequired]
    [ArgDescription("The location for the generated files")]
    [ArgPosition(1)]
    [ArgDefaultValue(".\\infra")]
    public string Location { get; set; }

    [ArgDescription("The directory containing templates relative to aspire-tf location")]
    [ArgDefaultValue(".\\Resources\\tf-base")]
    [ArgPosition(2)]
    public string Template { get; set; }
}