resource "azurerm_storage_account" "{{name}}" {
  name                     = "${replace(local.name_template_short_unique, "<service>", "sa")}{{name}}"
  resource_group_name      = azurerm_resource_group.app.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  tags                     = merge (local.tags, {
    aspire-resource-name = "{{name}}"
  })
}

resource "azurerm_role_assignment" "{{name}}_blob_contributor" {
  scope                = azurerm_storage_account.{{name}}.id
  role_definition_name = "Storage Blob Data Contributor"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

locals {
  {{name}} = {
    id = azurerm_storage_account.{{name}}.id
    name = azurerm_storage_account.{{name}}.name
    tableEndpoint = azurerm_storage_account.{{name}}.primary_table_endpoint
    blobEndpoint = azurerm_storage_account.{{name}}.primary_blob_endpoint
    queueEndpoint = azurerm_storage_account.{{name}}.primary_queue_endpoint
    fileEndpoint = azurerm_storage_account.{{name}}.primary_file_endpoint
  }
}

output "{{name}}" {
  value = local.{{name}}
}

