resource "azurerm_key_vault" "{{key}}" {
  name                      = "${replace(local.name_template_short, "<service>", "kv")}{{key}}"
  resource_group_name       = azurerm_resource_group.app.name
  location                  = var.location
  enable_rbac_authorization = true
  sku_name                  = "standard"
  tenant_id                 = data.azurerm_client_config.current.tenant_id
  tags                      = merge (local.tags, {
    aspire-resource-name = "{{key}}"
  })
}

resource "azurerm_role_assignment" "kv_admin_{{key}}" {
  scope                = azurerm_key_vault.{{key}}.id
  role_definition_name = "Key Vault Administrator"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

locals {
  {{key}} = {
    id       = azurerm_key_vault.{{key}}.id
    name     = azurerm_key_vault.{{key}}.name
    vaultUri = azurerm_key_vault.{{key}}.vault_uri
  }
}

output "{{key}}" {
  value = local.{{key}}
  sensitive = true
}

