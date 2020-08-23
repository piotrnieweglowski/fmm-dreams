variable "cr_user"{
  type              = string
  description       = "Login for container registry"
}
variable "cr_pass"{
  type              = string
  description       = "Pass for container registry"
}
variable "db_pass"{
  type              = string
  description       = "Password for database instance"
}
variable "containerTag"{
  type              = string
  description       = "Tag for container"
}
variable "rg_name"{
  type              = string
  description       = "Resource Group name"
}