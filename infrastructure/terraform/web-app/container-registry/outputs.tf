output "container-registry-user" {
  value = azurerm_container_registry.fmm-container-registry.admin_username
}
output "container-registry-pass" {
  value = azurerm_container_registry.fmm-container-registry.admin_password
  sensitive   = true
}