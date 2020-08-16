provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

resource "azurerm_resource_group" "fmm-resource-group" {
    name     = "fmmResourceGroup"
    location = "westeurope"
}

resource "azurerm_postgresql_server" "fmm-database-server" {
  name                = "fmm-postgresql-server-1"
  location            = "westeurope"
  resource_group_name = azurerm_resource_group.fmm-resource-group.name

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

resource "azurerm_postgresql_database" "fmm-dreams-database" {
  name                = "fmm-dreams"
  resource_group_name = azurerm_resource_group.fmm-resource-group.name
  server_name         = azurerm_postgresql_server.fmm-database-server.name
  charset             = "UTF8"
  collation           = "English_United States.1252"
    timeouts {
    create = "20m"
    delete = "1h"
  }
}
resource "azurerm_container_registry" "fmm-container-registry" {
  name                     = "fmmContainerRegistry"
  resource_group_name      = azurerm_resource_group.fmm-resource-group.name
  location                 = "westeurope"
  sku                      = "Basic"
  admin_enabled            = true
}
resource "azurerm_postgresql_firewall_rule" "turelit" {
  name                = "turelit-hq"
  resource_group_name = azurerm_resource_group.fmm-resource-group.name
  server_name         = azurerm_postgresql_server.fmm-database-server.name
  start_ip_address    = "185.93.94.115"
  end_ip_address      = "185.93.94.115"
}
resource "azurerm_postgresql_firewall_rule" "azure-app-service" {
  name                = "azure-app-service"
  resource_group_name = azurerm_resource_group.fmm-resource-group.name
  server_name         = azurerm_postgresql_server.fmm-database-server.name
  start_ip_address    = "13.94.139.19"
  end_ip_address      = "13.94.139.19"
}
resource "azurerm_app_service_plan" "fmm-api-app-service" {
  name                = "fmm"
  location            = "westeurope"
  resource_group_name = azurerm_resource_group.fmm-resource-group.name

  sku {
    tier = "Free"
    size = "F1"
  }
}