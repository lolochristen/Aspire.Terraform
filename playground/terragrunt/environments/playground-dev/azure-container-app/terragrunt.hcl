include "root" {
  path   = find_in_parent_folders("root.hcl")
  expose = true
}

terraform {
  source = "${get_parent_terragrunt_dir()}/modules//azure-container-app"
}

# dependency "launchpad" {
#   config_path = "../launchpad"
# }

locals {
  publish_output = run_cmd("dotnet", "run", "--project", "${get_parent_terragrunt_dir()}/../AzureContainerApps/AzureContainerApps.AppHost/AzureContainerApps.AppHost.csproj", "--publisher", "terraform", "--output-path", "${get_parent_terragrunt_dir()}/modules/azure-container-app")
}

inputs = {
  project = "play"
  param1 = "Param1"
  param2 = "Param2"
}
