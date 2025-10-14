resource "azurerm_application_insights" "{{name}}" {
  name                = "${replace(local.name_template, "<service>", "appi")}-{{name}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  workspace_id        = azurerm_log_analytics_workspace.app.id
  application_type    = "web"
}

locals {
  {{name}} = {
    id               = azurerm_application_insights.{{name}}.id
    name             = azurerm_application_insights.{{name}}.name
    connectionString = azurerm_application_insights.{{name}}.connection_string
    }
}

output "{{name}}" {
  value = local.{{name}}
  sensitive = true
}