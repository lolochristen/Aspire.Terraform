resource "azurerm_log_analytics_workspace" "{{key}}" {
  name                = "${replace(local.name_template, "<service>", "law")}-{{key}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_application_insights" "{{key}}" {
  name                = "${replace(local.name_template, "<service>", "appi")}-{{key}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  workspace_id        = azurerm_log_analytics_workspace.{{key}}.id
  application_type    = "web"
}

locals {
  {{key}} = {
    id = azurerm_application_insights.{{key}}.id
    name = azurerm_application_insights.{{key}}.name
    law_id = azurerm_log_analytics_workspace.{{key}}.id
    connectionString = azurerm_application_insights.{{key}}.connection_string
}

output "{{key}}" {
  value = local.{{key}}
}