output "resource_group_name" {
  value = azurerm_resource_group.app.name
}

output "container_registry_name" {
  value = azurerm_container_registry.app.name
}

output "container_registry_server" {
  value = azurerm_container_registry.app.login_server
}

output "app_storage_account_name" {
  value = azurerm_storage_account.app.name
}
