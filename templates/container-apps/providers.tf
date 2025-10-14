provider "azurerm" {
  subscription_id = var.subscription_id
  features {}
}

provider "azuread" {
}

provider "azapi" {
}