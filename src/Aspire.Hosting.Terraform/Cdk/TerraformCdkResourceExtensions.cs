//using System.Diagnostics.CodeAnalysis;
//using Aspire.Hosting.ApplicationModel;
//using Microsoft.Extensions.DependencyInjection;

//// ReSharper disable once CheckNamespace
//namespace Aspire.Hosting;

//public static class TerraformCdkResourceExtensions
//{
//    [Experimental("ASPIREPUBLISHERS001")]
//    public static IResourceBuilder<TerraformCdkEnvironmentResource> WithOptions(this IResourceBuilder<TerraformCdkEnvironmentResource> builder, Action<TerraformCdkPublishingOptions> configureOptions)
//    {
//        builder.ApplicationBuilder.Services.AddOptions<TerraformCdkPublishingOptions>(builder.Resource.Name)
//            .BindConfiguration("Terraform")
//            .Configure(configureOptions);
//        return builder;
//    }
//}