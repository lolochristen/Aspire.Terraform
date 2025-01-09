resource "azurerm_redis_cache" "{{key}}" {
  name                     = "${replace(local.name_template_short, "<service>", "redis")}{{key}}"
  resource_group_name      = azurerm_resource_group.app.name
  location                 = var.location
  capacity                 = 1
  family                   = "C"
  sku_name                 = "Basic"
  non_ssl_port_enabled     = false
  minimum_tls_version      = "1.2"
  redis_configuration      = {
    active_directory_authentication_enabled = true
  }
  tags                     = merge (local.tags, {
    aspire-resource-name = "{{key}}"
  })
}

locals {
  {{key}} = {
    id = azurerm_redis_cache.{{key}}.id
    name = azurerm_redis_cache.{{key}}.name
    hostname = azurerm_redis_cache.{{key}}.hostname
    ssl_port = azurerm_redis_cache.{{key}}.ssl_port
    connectionString = azurerm_redis_cache.{{key}}.primary_connection_string
  }
}

output "{{key}}" {
  value = local.{{key}}
}

