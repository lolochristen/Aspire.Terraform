resource "azurerm_postgresql_flexible_server" "{{name}}" {
  name                    = "{{name}}"
  resource_group_name     = azurerm_resource_group.app.name
  location                = azurerm_resource_group.app.location
  administrator_login     = "{{params.administratorLogin}}"
  administrator_password  = "{{prams.administratorLoginPassword}}"
  sku_name				  = "Standard_B1ms"
  tier					  = "Bustable"
}

resource "azurerm_postgresql_flexible_server_firewall_rule" "{{name}}" {
  name             = "AllowAllIps"
  server_id        = azurerm_postgresql_flexible_server.{{name}}.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "255.255.255.255"
}

locals {
  {{name}} = {
    id = azurerm_postgresql_flexible_server.{{name}}.id
    name = azurerm_postgresql_flexible_server.{{name}}.name
    fqdn = azurerm_postgresql_flexible_server.{{name}}.fqdn
  }
}

output "{{name}}" {
  value = local.{{name}}
}
