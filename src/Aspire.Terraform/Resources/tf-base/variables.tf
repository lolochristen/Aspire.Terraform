variable "subscription_id" {
  type = string
}

variable "environment_code" {
  type    = string
  default = "d1"
}

variable "location" {
  type    = string
  default = "Switzerland North"
}

variable "container_app_environment_workload_profile_type" {
  type    = string
  default = "Consumption"
}

variable "container_registry_sku" {
  type    = string
  default = "Basic"
}
