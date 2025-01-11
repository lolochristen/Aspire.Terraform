resource "azurerm_application_insights" "{{key}}" {
  name                = "${replace(local.name_template, "<service>", "appi")}-{{key}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  workspace_id        = azurerm_log_analytics_workspace.app.id
  application_type    = "web"
}

locals {
  {{key}} = {
    id               = azurerm_application_insights.{{key}}.id
    name             = azurerm_application_insights.{{key}}.name
    connectionString = azurerm_application_insights.{{key}}.connection_string
    }
}

output "{{key}}" {
  value = local.{{key}}
  sensitive = true
}