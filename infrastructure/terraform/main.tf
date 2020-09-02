terraform{
  backend "azurerm"{
    
  }
}

provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

resource "azurerm_resource_group" "fmm-resource-group" {
    name     = "fmmResourceGroup"
    location = "westeurope"
}

module "database" {
  source  = "./database"
  db_pass = var.db_pass
  rg_name = azurerm_resource_group.fmm-resource-group.name
}

module "web-app" {
  source = "./web-app"
  containerTag = "dev"
  db_pass = var.db_pass
  cr_user = var.cr_user
  cr_pass = var.cr_pass
  rg_name = azurerm_resource_group.fmm-resource-group.name
}

module "container-registry" {
  source = "./container-registry"
  rg_name = azurerm_resource_group.fmm-resource-group.name
}