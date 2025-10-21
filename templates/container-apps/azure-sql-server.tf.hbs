resource "azurerm_mssql_server" "{{name}}" {
  name                = "${replace(local.name_template, "<service>", "mssql")}-{{name}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  version             = "12.0"
  minimum_tls_version = "1.2"
  tags                = merge (local.tags, {
    aspire-resource-name = "{{name}}"
  })

  public_network_access_enabled = true
  azuread_administrator {
    azuread_authentication_only = true
    login_username              = azurerm_user_assigned_identity.app.name
    object_id                   = azurerm_user_assigned_identity.app.principal_id
    tenant_id                   = data.azurerm_client_config.current.tenant_id
  }
}

resource "azurerm_mssql_firewall_rule" "{{name}}-allowallazure" {
  name             = "AllowAllAzureIps"
  server_id        = azurerm_mssql_server.{{name}}.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

locals {
  {{name}} = {
    id = azurerm_mssql_server.{{name}}.id
    name = azurerm_mssql_server.{{name}}.name
    sqlServerFqdn = azurerm_mssql_server.{{name}}.fully_qualified_domain_name
  }
}

output "{{name}}" {
  value = local.{{name}}
}

