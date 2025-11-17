using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Terraform.Aspire.Hosting.Azure.Templates;
using Terraform.Aspire.Hosting.Templates;

#pragma warning disable ASPIREPIPELINES001
#pragma warning disable IDE0130

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for configuring Azure-specific Terraform template publishing.
/// </summary>
public static class DistributedApplicationBuilderExtensions
{
    /// <summary>
    /// Adds Azure-specific Terraform template publishing capabilities with enhanced Azure resource support.
    /// </summary>
    /// <param name="builder">The distributed application builder instance.</param>
    /// <param name="configureOptions">Optional action to configure publishing options.</param>
    /// <returns>The distributed application builder for method chaining.</returns>
    /// <remarks>
    /// This method extends the base Terraform template functionality with Azure-specific features
    /// and optionally disables the built-in Bicep provisioner to avoid conflicts.
    /// </remarks>
    public static IDistributedApplicationBuilder AddTerraformAzureTemplatePublishing(this IDistributedApplicationBuilder builder, Action<TerraformTemplatePublishingOptions>? configureOptions = null)
    {
        var configuration = builder.Configuration.GetSection("Terraform:Templates");

        var optionsBuilder = builder.Services.AddOptions<TerraformTemplatePublishingOptions>()
            .Bind(configuration);

        if (configureOptions != null)
            optionsBuilder.Configure(configureOptions);

        builder.Services.AddSingleton<ITerraformTemplatePublisher, TerraformAzureTemplatePublisher>();
        builder.Services.AddTransient<TerraformTemplateProcessor>();
        builder.Pipeline.AddTerraformTemplatePublishing();

        return builder;
    }

    /// <summary>
    /// Defines a role assignment for the given resource.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="name"></param>
    /// <param name="scopeResource"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static IResourceBuilder<ProjectResource> WithTerraformRoleAssignment(this IResourceBuilder<ProjectResource> builder, string name, IResourceBuilder<IResourceWithConnectionString> scopeResource, string role)
    {
        builder.ApplicationBuilder.AddTerraformTemplate(name,
                $"azure-role-assignment{TerraformTemplateProcessor.TF_TEMPLATE_EXTENSION}",
                "{{FilePrefix}}"+builder.Resource.Name+"-roles" + TerraformTemplateProcessor.TF_EXTENSION,
                true)
            .WithParameter("ParentName", builder.Resource.Name)
            .WithParameter("RoleName", role)
            .WithParameter("ScopeResourceName", scopeResource.Resource.Name)
            .WithParameter("ScopeResource", "local." + scopeResource.Resource.Name + ".id")
            .ExcludeFromManifest();

        return builder;
    }
}
