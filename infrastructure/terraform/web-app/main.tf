provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}

module "web-app-container" {
  source  = "./terraform-azurerm-web-app-container"
  resource_group_name = "DefaultResourceGroup-WEU"
  name  = "fmm"
  container_type = "docker"
  container_image = "fmmapi"
  plan = {
    sku_size  = "B1"
  }
  docker_registry_url = "http://fmmbase.azurecr.io"
  docker_registry_username = var.cr_user
  docker_registry_password = var.cr_pass

  app_settings = {
    DbConnection = "Server=fmm-postgresql-server-1.postgres.database.azure.com;Database=fmm-dreams;Port=5432;User Id=turelit@fmm-postgresql-server-1;Password=${var.db_pass};Ssl Mode=Require;"
  }
}