provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

resource "azurerm_resource_group" "fmm_resource_group" {
    name     = "fmmResourceGroup"
    location = "westeurope"
}

resource "azurerm_postgresql_server" "fmm_database_server" {
  name                = "fmm_postgresql_server_1"
  location            = "westeurope"
  resource_group_name = azurerm_resource_group.fmm_resource_group.name

  sku_name = "B_Gen5_1"

  storage_mb                   = 5120
  backup_retention_days        = 7
  geo_redundant_backup_enabled = false
  auto_grow_enabled            = false

  administrator_login          = "turelit"
  administrator_login_password = var.db_pass
  version                      = "9.5"
  ssl_enforcement_enabled      = false
}

resource "azurerm_postgresql_database" "fmm_dreams_database" {
  name                = "fmm_dreams"
  resource_group_name = azurerm_resource_group.fmm_resource_group.name
  server_name         = azurerm_postgresql_server.fmm_database_server.name
  charset             = "UTF8"
  collation           = "English_United States.1252"
    timeouts {
    create = "20m"
    delete = "1h"
  }
}