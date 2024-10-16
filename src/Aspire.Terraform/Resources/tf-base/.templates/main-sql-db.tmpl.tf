resource "azurerm_mssql_database" "{{key}}" {
  name      = "{{key}}"
  server_id = azurerm_mssql_server.{{parent.key}}.id
}


locals {
  {{key}} = {
    id = azurerm_mssql_database.{{key}}.id
  }
}

output "{{key}}" {
  value = local.{{key}}
}

