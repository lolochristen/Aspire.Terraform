terraform {
  required_providers {
    random = {
      source  = "hashicorp/random"
      version = "3.5.1"
    }
  }
}

resource "random_pet" "random_string" {
  length = 4
}

output "random_string" {
  value = random_pet.random_string.id
}