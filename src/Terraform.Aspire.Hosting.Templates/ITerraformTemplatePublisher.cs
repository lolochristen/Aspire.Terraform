using Aspire.Hosting.ApplicationModel;

namespace Terraform.Aspire.Hosting.Templates;

public interface ITerraformTemplatePublisher
{
    /// <summary>
    /// Publishes the specified distributed application model.
    /// </summary>
    /// <param name="model">The distributed application model to publish.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task PublishAsync(DistributedApplicationModel model, CancellationToken cancellationToken);

}