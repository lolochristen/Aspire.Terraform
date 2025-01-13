# Aspire.Terraform

A tool to create terraform IaC based on .NET Aspire projects.

**Alpha Version**

## Install

Aspire.Terraform is (soon) available as a .NET tool. To install it, run the following command:

```dotnetcli
dotnet tool install --global Aspire.Terraform 
```

## Usage

Go to your Aspire Host project folder and run the following commands: 

To create an .\infra folder with the baseline terraform files and templates:

```console
aspire-tf init
```

To generate the terraform files based on the current Aspire project:

```console
aspire-tf generate
```

### General Usage

```console
Usage - aspire-tf <action>

Actions

  Generate [<Location>] [<Manifest>] -options - Generates terraform files from an Aspire manifest file.

    Option              Description
    Location (-L)       The location for the generated files [Default='.\infra']
    Manifest (-M)       The path to the manifest file
    Template (-T)       The directory containing templates
    SkipExisting (-s)   Skip existing files/do not overwrite files

  Init <Location> [<Template>]  - Initializes a new terraform project from a template

    Option           Description
    Location* (-L)   The location for the generated files [Default='.\infra']
    Template (-T)    The directory containing templates relative to aspire-tf location [Default='.\Resources\tf-base']

```

## Concept

The tool builds or uses a given manifest file of an Aspire project to generate terraform files using templates for various resource types. The templates are using Handlebars syntax and are stored in the .\templates folder.

## Known Limitations

- Not all resource types have a template yet.
