resource "azurerm_storage_queue" "{{key}}" {
    name                 = "{{key}}"
    storage_account_name = azurerm_storage_account.{{parent.key}}.name
}

