resource "azurerm_app_service_plan" "fmm-app-service-plan" {
  name                = "fmm-appserviceplan"
  location            = "westeurope"
  resource_group_name = var.rg_name
  reserved            = true
  kind                = "Linux"

  sku {
    tier = "Basic"
    size = "B1"
  }
}

resource "azurerm_app_service" "fmm-app-service" {
  name                = "fmm"
  location            = "westeurope"
  resource_group_name = var.rg_name
  app_service_plan_id = azurerm_app_service_plan.fmm-app-service-plan.id

  site_config {
    default_documents = ["Default.htm",
                    "Default.html",
                    "Default.asp",
                    "index.htm",
                    "index.html",
                    "iisstart.htm",
                    "default.aspx",
                    "index.php",
                    "hostingstart.html"]
    use_32_bit_worker_process = true                    
    linux_fx_version = "DOCKER|fmmContainerRegistry.azurecr.io/fmmapi:${var.containerTag}"
  }

  app_settings = {
    DOCKER_REGISTRY_SERVER_URL = "fmmContainerRegistry.azurecr.io"
    DOCKER_REGISTRY_SERVER_USERNAME = var.cr_user
    DOCKER_REGISTRY_SERVER_PASSWORD = var.cr_pass
  }
     
  connection_string {
    name  = "DbConnection"
    type  = "MySQL"
    value = "Server=fmm-postgresql-server-1.postgres.database.azure.com;Database=fmm-dreams;Port=5432;User Id=turelit@fmm-postgresql-server-1;Password=${var.db_pass};Ssl Mode=Require;"
  }
}