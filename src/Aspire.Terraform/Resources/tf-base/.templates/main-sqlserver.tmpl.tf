resource "azurerm_mssql_server" "{{key}}" {
  name                = "${replace(local.name_template, "<service>", "mssql")}-{{key}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  version             = "12.0"
  minimum_tls_version = "1.2"
  tags                = merge (local.tags, {
    aspire-resource-name = "{{key}}"
  })

  public_network_access_enabled = true
  azuread_administrator {
    azuread_authentication_only = true
    login_username              = azurerm_user_assigned_identity.app.name
    object_id                   = azurerm_user_assigned_identity.app.principal_id
    tenant_id                   = data.azurerm_client_config.current.tenant_id
  }
}

resource "azurerm_mssql_firewall_rule" "{{key}}-allowallazure" {
  name             = "AllowAllAzureIps"
  server_id        = azurerm_mssql_server.{{key}}.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

locals {
  {{key}} = {
    id = azurerm_mssql_server.{{key}}.id
    name = azurerm_mssql_server.{{key}}.name
    sqlServerFqdn = azurerm_mssql_server.{{key}}.fully_qualified_domain_name
  }
}

output "{{key}}" {
  value = local.{{key}}
}

