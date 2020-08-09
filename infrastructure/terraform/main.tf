provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

resource "azurerm_resource_group" "rg_fmm" {
    name     = "fmmResourceGroup"
    location = "westeurope"
}

resource "azurerm_postgresql_server" "fmm-test" {
  name                = "fmm-postgresql-server-1"
  location            = "westeurope"
  resource_group_name = "fmmResourceGroup"

  sku_name = "B_Gen5_1"

  storage_mb                   = 5120
  backup_retention_days        = 7
  geo_redundant_backup_enabled = false
  auto_grow_enabled            = false

  administrator_login          = "turelit"
  administrator_login_password = var.db_pass
  version                      = "9.5"
  ssl_enforcement_enabled      = true
}

resource "azurerm_postgresql_database" "fmm-test-turel" {
  name                = "exampledb"
  resource_group_name = "fmmResourceGroup"
  server_name         = "fmm-postgresql-server-1"
  charset             = "UTF8"
  collation           = "English_United States.1252"
    timeouts {
    create = "20m"
    delete = "1h"
  }
}