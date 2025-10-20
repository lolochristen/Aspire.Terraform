resource "azurerm_redis_cache" "{{name}}" {
  name                     = "${replace(local.name_template_short, "<service>", "redis")}{{name}}"
  resource_group_name      = azurerm_resource_group.app.name
  location                 = var.location
  capacity                 = 1
  family                   = "C"
  sku_name                 = "Basic"
  non_ssl_port_enabled     = false
  minimum_tls_version      = "1.2"
  redis_configuration      {
    active_directory_authentication_enabled = true
  }
  tags                     = merge (local.tags, {
    aspire-resource-name = "{{name}}"
  })
}

resource "azurerm_redis_cache_access_policy_assignment" "data_contributor_{{name}}" {
  name               = "${replace(local.name_template, "<service>", "cache")}-{{name}}-data-contributor"
  redis_cache_id     = azurerm_redis_cache.{{name}}.id
  access_policy_name = "Data Contributor"
  object_id          = azurerm_user_assigned_identity.app.principal_id
  object_id_alias    = azurerm_user_assigned_identity.app.name
}

locals {
  {{name}} = {
    id               = azurerm_redis_cache.{{name}}.id
    name             = azurerm_redis_cache.{{name}}.name
    hostname         = azurerm_redis_cache.{{name}}.hostname
    ssl_port         = azurerm_redis_cache.{{name}}.ssl_port
    connectionString = azurerm_redis_cache.{{name}}.primary_connection_string
  }
}

output "{{name}}" {
  value = local.{{name}}
  sensitive = true
}

