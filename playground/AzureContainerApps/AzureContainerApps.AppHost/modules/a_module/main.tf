
resource "random_string" "postfix" {
  length  = 3
  lower   = true
  upper   = false
  special = false
  numeric = false
}

locals {
  random_string = random_string.postfix.id
}
