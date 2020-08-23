provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

resource "azurerm_container_registry" "fmm-container-registry" {
  name                     = "fmmContainerRegistry"
  resource_group_name      = "fmmResourceGroup"
  location                 = "westeurope"
  sku                      = "Basic"
  admin_enabled            = true
}
resource "azurerm_key_vault_secret" "cr-user" {
  name         = "cr-user"
  value        = azurerm_container_registry.fmm-container-registry.admin_username
  key_vault_id = "21f9aca0-dde5-4dd5-a267-50fd39dda9b1"

  tags = {
    environment = "dev"
  }
}
resource "azurerm_key_vault_secret" "cr-pass" {
  name         = "cr-pass"
  value        = azurerm_container_registry.fmm-container-registry.admin_password
  key_vault_id = "21f9aca0-dde5-4dd5-a267-50fd39dda9b1"

  tags = {
    environment = "dev"
  }
}