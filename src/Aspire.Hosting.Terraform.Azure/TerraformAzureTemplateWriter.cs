//using Aspire.Hosting.ApplicationModel;
//using Aspire.Hosting.Azure;
//using Aspire.Hosting.Terraform.Templates;
//using Aspire.Hosting.Terraform.Templates.Models;

//namespace Aspire.Hosting.Terraform.Azure;

//public class TerraformAzureTemplateWriter(
//    TerraformTemplateProcessor processor
//) : TerraformTemplateWriter(processor)
//{
//    protected override Task PrepareResource(IResource resource)
//    {
//        if (resource is AzureBicepResource bicepResource)
//        {
//            var name = bicepResource.GetBicepIdentifier();
//            var type = NormalizeTypeName(bicepResource.GetType().Name);

//            var annotations = SetupAnnotations<AzureTemplateResource>(bicepResource, $"{type}.tmpl.tf");

//            foreach (var annotation in annotations)
//            {
//                annotation.TemplateResource = new Terraform.Templates.Models.AzureTemplateResource()
//                {
//                    Resource = resource,
//                    Name = name
//                };

//                foreach (var parameter in bicepResource.Parameters)
//                {
//                    annotation.TemplateResource.Parameters.Add(parameter.Key, parameter.Value);
//                }
                
//                if (resource is IResourceWithConnectionString resourceWithConnectionString)
//                {
//                    annotation.TemplateResource.ConnectionString = resourceWithConnectionString.ConnectionStringExpression.ValueExpression;
//                    annotation.TemplateResource.Outputs.Add("connectionString", "${local." + name + ".connectionString}");
//                }

//                if (resource is IResourceWithParent resourceWithParent && resourceWithParent.Parent != null)
//                {
//                    annotation.TemplateResource.Parent = ModelResources[resourceWithParent.Parent.Name];
//                }

//                switch (type)
//                {
//                    case "azure-sql-server":
//                        annotation.TemplateResource.Outputs.Add("sqlServerFqdn", "${local." + name + ".sqlServerFqdn}");
//                        break;
//                    case "azure-key-vault":
//                        annotation.TemplateResource.Outputs.Add("vaultUri", "${local." + name + ".vaultUri}");
//                        break;
//                    case "azure-storage":
//                        annotation.TemplateResource.Outputs.Add("vaultUri", "${local." + name + ".vaultUri}");
//                        annotation.TemplateResource.Outputs.Add("tableEndpoint", "${local." + name + ".tableEndpoint}");
//                        annotation.TemplateResource.Outputs.Add("blobEndpoint", "${local." + name + ".blobEndpoint}");
//                        annotation.TemplateResource.Outputs.Add("queueEndpoint", "${local." + name + ".queueEndpoint}");
//                        annotation.TemplateResource.Outputs.Add("fileEndpoint", "${local." + name + ".fileEndpoint}");
//                        break;
//                }

//                //todo check multiple
//                ModelResources.Add(resource.Name, annotation.TemplateResource);
//            }
//            return Task.CompletedTask;
//        }

//        return base.PrepareResource(resource); // default resources
//    }

//    protected override bool PrepareChildResource(IResourceWithParent resource, Dictionary<string, TemplateResource> modelResources)
//    {
//        var parent = modelResources[resource.Parent.Name];
//        var type = NormalizeTypeName(resource.GetType().Name);

//        if (resource.Parent is AzureBicepResource || resource.Parent is IResourceWithParent { Parent: AzureBicepResource })
//        {
//            var annotations = SetupAnnotations<ValueTemplateResource>(resource, $"{type}.tmpl.tf");

//            foreach (var annotation in annotations)
//            {
//                annotation.TemplateResource = new Terraform.Templates.Models.ValueTemplateResource()
//                {
//                    Resource = resource,
//                    Name = resource.Name,
//                    Parent = parent
//                };

//                if (resource is IResourceWithConnectionString resourceWithConnectionString)
//                {
//                    annotation.TemplateResource.ConnectionString = resourceWithConnectionString.ConnectionStringExpression.ValueExpression;
//                }

//                //todo check multiple
//                modelResources.Add(resource.Name, annotation.TemplateResource);
//            }

//            return true;
//        }
//        return false;
//    }

//}