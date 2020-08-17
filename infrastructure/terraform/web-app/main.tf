provider "azurerm"{
    version = "2.19.0"
    subscription_id = "ff581936-424c-495e-a9ed-0c247bdd4d78"
    features {}
}
module "container-registry"{
  source = "./container-registry"
}

module "web-app-container" {
  source  = "./terraform-azurerm-web-app-container"
  resource_group_name = "fmmResourceGroup"
  name  = "fmm"
  container_type = "docker"
  container_image = "fmmContainerRegistry/fmmapi"
  plan = {
    sku_size  = "B1"
  }
  docker_registry_url = "fmmcontainerregistry.azurecr.io"
  docker_registry_username = "${data.azurerm_container_registry.fmm-container-registry.admin_username}"
  docker_registry_password = "${data.azurerm_container_registry.fmm-container-registry.admin_password}"
}