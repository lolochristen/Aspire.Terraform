# Aspire.Terraform

Libraries for .NET Aspire to create terraform code based on templates or CDK for terraform. It supports template based generation as well as CDK for Terraform (CDKTF).

**Alpha Version** Still in development, APIs may change.

## Template based

Aspire.Terraform provides a set of templates that can be used to generate Terraform code for various resource types. These templates are stored in the .\templates folder and use Handlebars syntax for dynamic content generation.

```console
dotnet add package Terraform.Aspire.Hosting
// or
dotnet add package Terraform.Aspire.Hosting.Azure
```

Add .Azure package for support of Azure resources.

Add the following lines to you Aspire Host:

```csharp
builder.AddTerraformTemplatePublishing()
// or
builder.AddTerraformAzureTemplatePublishing()
```

Define the location template files either by defining it in the appsettings.json or in code:

```json
  "Terraform": {
    "Templates": {
      "TemplatesPath": "https://raw.githubusercontent.com/lolochristen/Aspire.Terraform/refs/heads/main/templates/container-apps/"
    } 
  } 
```

```csharp
builder.AddTerraformAzureTemplatePublishing(configureOptions: options =>
{
    options.TemplatesPath = "../my-templates";
});
```

The ./templates/container-apps in this repository contains a base template to deploy to Azure Container Apps. Other templates or targets will eventually be added.

### Publish

To execute the publisher for terraform use the following command line from your Aspire Host project folder:

```console
dotnet run --publisher terraform --output-path terraform
```

An integration into terragrunt is also possible by using run_cmd, see ./playground/AzureContainerApps/terragrunt for an example. 


## Use of CDK for Terraform

In addition to template-based generation, Aspire.Terraform also supports the use of CDK for Terraform (CDKTF). This allows developers to define their infrastructure using familiar programming languages and leverage the power of the CDK ecosystem.

### Install / Setup

1. Install CDK TF from https://developer.hashicorp.com/terraform/cdktf

```console
dotnet add package Terraform.Aspire.Hosting.Cdk
```

2. Create a cdktf.json file in your Aspire Host project folder with the following content:

```json
{
  "language": "csharp",
  "app": "dotnet run -project [Project].csproj --publisher terraform --output-path infra",
  "projectId": "d8c23291-21cf-4f76-b40d-90cc2e384901",
  "output": "infra", 
  "terraformProviders": [
    "azure/azapi@~> 2.4"
  ],
  "context": {}
}
```

3. Add the CDK publisher to your Aspire Host:

```csharp
builder.AddTerraformCdkPublishing();
```

4. Define your environment and stacks

```csharp
var terraform = builder.AddTerraformCdkEnvironment("terraform");
var mystack = terraform.AddStack<MyStack>("mystack");

public class MyStack : TerraformStack
{
   public MyStack(Construct scope, string id) : base(scope, id)
   {
       new TerraformOutput(this, "output1", new TerraformOutputConfig()
       {
           Value = "Hello from MyStack"
       });
   }
}

```

5. Use cdktf CLI or just generate stack with '''dotnet run --publisher terraform --output-path infra''' command
