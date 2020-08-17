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
