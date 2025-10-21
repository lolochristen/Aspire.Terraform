/*
# module to simplify nameing for resources
https://wiki.vifn.app/pages/viewpage.action?pageId=86507707

example:

module "name_templates" {
  source = "../../../shared/name_templates"
  organization = var.organization
  workloadEnvironment = var.workloadEnvironment
  workloadName = var.workloadName
}

resource "azurerm_resource_group" "rg" {
  name     = "${replace(module.name_templates.default, "<service>", "rg")}"
...
*/

resource "random_string" "postfix" {
  count   = length(var.random_string) == 0 ? 1 : 0
  length  = 3
  lower   = true
  upper   = false
  special = false
  numeric = false
}

locals {
  random_string = length(var.random_string) == 0 ? random_string.postfix[0].id : var.random_string
}
