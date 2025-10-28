resource "random_string" "unique" {
  length  = 3
  lower   = true
  upper   = false
  special = false
  numeric = false
}

locals {
  name_template              = "${var.organization}-${var.environment_code}-<service>-${var.project}"
  name_template_unique       = "${var.organization}-${var.environment_code}-<service>-${var.project}-${random_string.unique.result}"
  name_template_short        = "${var.organization}${var.environment_code}<service>${substr(var.project, 0, 3)}"
  name_template_short_unique = "${var.organization}${var.environment_code}<service>${substr(var.project, 0, 3)}${random_string.unique.result}"
  tags = {
    project     = var.project
    environment = var.environment_code
  }
}

data "azurerm_client_config" "current" {}

resource "azurerm_resource_group" "app" {
  name     = replace(local.name_template, "<service>", "rg")
  location = var.location
  tags     = local.tags
}

resource "azurerm_user_assigned_identity" "app" {
  name                = replace(local.name_template, "<service>", "uai")
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
}

resource "azurerm_container_registry" "app" {
  name                = replace(local.name_template_short, "<service>", "cr")
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  sku                 = var.container_registry_sku
  tags                = local.tags
}

resource "azurerm_role_assignment" "uai-acrpull" {
  scope                = azurerm_container_registry.app.id
  role_definition_name = "AcrPull"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

resource "azurerm_log_analytics_workspace" "app" {
  name                = replace(local.name_template, "<service>", "law")
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_container_app_environment" "app" {
  name                = replace(local.name_template, "<service>", "cae")
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  tags                = local.tags
  workload_profile {
    name                  = var.container_app_environment_workload_profile_type
    workload_profile_type = var.container_app_environment_workload_profile_type
  }
  log_analytics_workspace_id = azurerm_log_analytics_workspace.app.id
}

resource "azurerm_role_assignment" "uai-cae-contributor" {
  scope                = azurerm_container_app_environment.app.id
  role_definition_name = "Contributor"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

resource "azurerm_key_vault" "app" {
  name                = replace(local.name_template, "<service>", "kv")
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  sku_name            = "standard"
  tenant_id           = data.azurerm_client_config.current.tenant_id
}

resource "azurerm_role_assignment" "uai-secret-user" {
  scope                = azurerm_key_vault.app.id
  role_definition_name = "Key Vault Secrets User"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

resource "azapi_resource" "aspire_dashboard" {
  type      = "Microsoft.App/managedEnvironments/dotNetComponents@2023-11-02-preview"
  name      = "aspire-dashboard"
  parent_id = azurerm_container_app_environment.app.id
  body = {
    properties = {
      componentType = "AspireDashboard"
    }
  }
}

resource "azurerm_storage_account" "app" {
  name                     = replace(local.name_template_short_unique, "<service>", "sa")
  resource_group_name      = azurerm_resource_group.app.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  tags                     = local.tags
}

resource "azurerm_role_assignment" "app_file_share_contributor" {
  scope                = azurerm_storage_account.app.id
  role_definition_name = "Storage File Data SMB Share Contributor"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}
