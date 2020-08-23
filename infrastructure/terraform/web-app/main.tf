module "web-app-container" {
  source  = "./terraform-azurerm-web-app-container"
  resource_group_name = var.rg_name
  name  = "fmm"
  container_type = "docker"
  container_image = "fmmapi:${var.containerTag}"
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

resource "azurerm_role_assignment" "fmm-web-app" {
  scope                = data.azurerm_subscription.primary.id
  role_definition_name = "Contributor"
  principal_id         = module.web-app-container.id
}