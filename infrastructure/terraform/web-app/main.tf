resource "azurerm_app_service_plan" "fmm-app-service-plan" {
  name                = "fmm-appserviceplan"
  location            = "westeurope"
  resource_group_name = var.rg_name

  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_app_service" "fmm-app-service" {
  name                = "fmm-app-service"
  location            = "westeurope"
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.fmm-web-app.id

  site_config {
    linux_fx_version = "DOCKER|fmmContainerRegistry.azurecr.io/fmmapi:${var.containerTag}"
    DOCKER_REGISTRY_SERVER_USERNAME = var.cr_user
    DOCKER_REGISTRY_SERVER_PASSWORD = var.cr_pass
  }

  connection_string {
    name  = "DbConnection"
    type  = "PostgreSQL"
    value = "Server=fmm-postgresql-server-1.postgres.database.azure.com;Database=fmm-dreams;Port=5432;User Id=turelit@fmm-postgresql-server-1;Password=${var.db_pass};Ssl Mode=Require;"
  }
}