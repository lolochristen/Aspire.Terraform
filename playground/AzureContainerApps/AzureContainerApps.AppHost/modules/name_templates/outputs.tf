
output "default" {
  description = "Default naming template. e.g. cslb-c1-<service>-sap1"
  value       = "${var.organization}-${var.workloadEnvironment}-<service>-${var.workloadName}${length(var.subComponent) > 0 ? "-${var.subComponent}" : ""}"
}

output "default-random" {
  description = "Default naming including a random string part"
  value       = "${var.organization}-${var.workloadEnvironment}-<service>-${var.workloadName}${length(var.subComponent) > 0 ? "-${var.subComponent}" : ""}-${local.random_string}"
}

output "short" {
  value = "${var.organization}${var.workloadEnvironment}<service>${var.workloadName}${var.subComponent}"
}

output "short-random" {
  value = "${var.organization}${var.workloadEnvironment}<service>${var.workloadName}${var.subComponent}${local.random_string}"
}

output "role" {
  value = "ra-${var.organization}-${var.workloadEnvironment}-${var.workloadName}${length(var.subComponent) > 0 ? "-${var.subComponent}" : ""}-<role>"
}

output "permission" {
  value = "pm-${var.organization}-${var.workloadEnvironment}-${var.workloadName}${length(var.subComponent) > 0 ? "-${var.subComponent}" : ""}-<permission>"
}

output "role-global" {
  value = "ra-${var.organization}-${var.workloadEnvironment}-<role>"
}

output "permission-global" {
  value = "pm-${var.organization}-${var.workloadEnvironment}-<permission>"
}

output "role-no-environment" {
  value = "ra-${var.organization}-${var.workloadName}-<role>"
}

output "permission-no-environment" {
  value = "pm-${var.organization}-${var.workloadName}-<permission>"
}

output "random-string" {
  value = local.random_string
}
