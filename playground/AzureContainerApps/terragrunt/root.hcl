locals {
  environment_vars              = read_terragrunt_config(find_in_parent_folders("environment.hcl"))
  subscription_id               = get_env("ARM_SUBSCRIPTION_ID", local.environment_vars.locals.subscription_id)
  tenant_id                     = get_env("ARM_TENANT_ID", local.environment_vars.locals.tenant_id)
  tf_basename                   = basename(path_relative_to_include())
  tf_plan_path                  = get_env("TF_PLAN_PATH", "./")
  tf_state_container            = get_env("TFSTATE_CONTAINER", "tfstate")
  tf_state_storage_account_name = get_env("TFSTATE_SA_NAME", local.environment_vars.locals.tf_state_storage_account_name)
  tf_state_resource_group_name  = get_env("TFSTATE_RG_NAME", local.environment_vars.locals.tf_state_resource_group_name)
}

# Generate an Azure provider block
generate "providers" {
  path      = "providers.tf"
  if_exists = "skip"
  contents  = <<-EOF
    provider "azurerm" {
      environment         = "public"
      subscription_id     = "${local.subscription_id}"
      tenant_id           = "${local.tenant_id}"
      storage_use_azuread = true
      features {}
    }

    provider "azuread" {
      tenant_id = "${local.tenant_id}"
    }

    provider "azapi" {
      environment         = "public"
      subscription_id     = "${local.subscription_id}"
      tenant_id           = "${local.tenant_id}"
    }
 EOF
}

generate "versions" {
  path      = "versions.tf"
  if_exists = "skip"
  contents  = <<-EOF
    terraform {
      required_providers {
        azurerm = {
          source  = "hashicorp/azurerm"
          version = "~> 4.47"
        }
        azuread = {
          source  = "hashicorp/azuread"
          version = "~> 3.6"
        }
        azapi = {
          source  = "azure/azapi"
          version = "~> 2.7"
        }
      }
    }
 EOF
}

# Configure Terragrunt to automatically store tfstate files in an Blob Storage container
# remote_state {
#   backend = "azurerm"
#   generate = {
#     path      = "backend.tf"
#     if_exists = "overwrite_terragrunt"
#   }
#   config = {
#     subscription_id      = local.subscription_id
#     resource_group_name  = local.tf_state_resource_group_name
#     storage_account_name = local.tf_state_storage_account_name
#     container_name       = local.tf_state_container
#     use_azuread_auth     = true
#     use_oidc             = true
#     key                  = "${local.tf_basename}.tfstate"
#   }
# }

terraform {
  # Force Terraform to keep trying to acquire a lock for
  # up to 20 minutes if someone else already has the lock
  extra_arguments "retry_lock" {
    commands = get_terraform_commands_that_need_locking()

    arguments = [
      "-lock-timeout=20m"
    ]
  }
  extra_arguments "plan" {
    commands = ["plan"]
    arguments = [
      "--out=${local.tf_plan_path}${local.tf_basename}.tfplan"
    ]
  }
}

inputs = merge(
  {
    subscription_id               = local.subscription_id
    tenant_id                     = local.tenant_id
    tf_state_container            = local.tf_state_container,
    tf_state_resource_group_name  = local.tf_state_resource_group_name
    tf_state_storage_account_name = local.tf_state_storage_account_name
    resource_group_tags = {
      environment  = local.environment_vars.locals.environment
      organization = local.environment_vars.locals.organization
      workload     = local.tf_basename
    },
    service_tags = {
      environment = local.environment_vars.locals.environment
      workload    = local.tf_basename
    }
  },
  local.environment_vars.locals
)

