variable "organization" {
  type        = string
  description = "Organization code e.g. cslb"
}
variable "workloadEnvironment" {
  type        = string
  description = "workloadEnvironment"
  default     = "<env>"
}
variable "workloadName" {
  type        = string
  description = "workloadName"
}
variable "random_string" {
  type        = string
  default     = ""
  description = "A random string. If empty, a string will be created."
}
variable "subComponent" {
  type        = string
  default     = ""
  description = "sub component name as postfix"
}