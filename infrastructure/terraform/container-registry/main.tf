resource "azurerm_container_registry" "fmm-container-registry" {
  name                     = "fmmContainerRegistry"
  resource_group_name      = var.rg_name
  location                 = "westeurope"
  sku                      = "Basic"
  admin_enabled            = true
}
resource "azurerm_key_vault_secret" "cr-user" {
  name         = "cr-user"
  value        = azurerm_container_registry.fmm-container-registry.admin_username
  key_vault_id = "/subscriptions/ff581936-424c-495e-a9ed-0c247bdd4d78/resourceGroups/DefaultResourceGroup-WEU/providers/Microsoft.KeyVault/vaults/fmm-dev"

  tags = {
    environment = "dev"
  }
}
resource "azurerm_key_vault_secret" "cr-pass" {
  name         = "cr-pass"
  value        = azurerm_container_registry.fmm-container-registry.admin_password
  key_vault_id = "/subscriptions/ff581936-424c-495e-a9ed-0c247bdd4d78/resourceGroups/DefaultResourceGroup-WEU/providers/Microsoft.KeyVault/vaults/fmm-dev"

  tags = {
    environment = "dev"
  }
}