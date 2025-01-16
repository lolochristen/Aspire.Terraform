resource "azurerm_storage_account" "{{key}}" {
  name                     = "${replace(local.name_template_short, "<service>", "sa")}{{key}}"
  resource_group_name      = azurerm_resource_group.app.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  tags                     = merge (local.tags, {
    aspire-resource-name = "{{key}}"
  })
}

resource "azurerm_role_assignment" "{{key}}_blob_contributor" {
  scope                = azurerm_storage_account.{{key}}.id
  role_definition_name = "Storage Blob Data Contributor"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

locals {
  {{key}} = {
    id = azurerm_storage_account.{{key}}.id
    name = azurerm_storage_account.{{key}}.name
    tableEndpoint = azurerm_storage_account.{{key}}.primary_table_endpoint
    blobEndpoint = azurerm_storage_account.{{key}}.primary_blob_endpoint
    queueEndpoint = azurerm_storage_account.{{key}}.primary_queue_endpoint
    fileEndpoint = azurerm_storage_account.{{key}}.primary_file_endpoint
  }
}

output "{{key}}" {
  value = local.{{key}}
}

