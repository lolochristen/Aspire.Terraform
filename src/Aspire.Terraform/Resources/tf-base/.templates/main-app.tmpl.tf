resource "azurerm_container_app" "{{key}}" {
  name                         = "${replace(local.name_template, "<service>", "app")}-{{key}}"
  resource_group_name          = azurerm_resource_group.app.name
  container_app_environment_id = azurerm_container_app_environment.app.id
  tags                         = merge (local.tags, {
    aspire-resource-name = "{{key}}"
  })

  revision_mode                = "Single"
  identity {
    type = "UserAssigned"
    identity_ids = [
      azurerm_user_assigned_identity.app.id
    ]
  }
{{#if bindings}}{{#FirstOrDefault bindings}}
  ingress {
    external_enabled           = {{#if value.external}}true{{else}}false{{/if}}
    target_port                = {{value.targetport}}
    transport                  = "{{value.transport}}"
    allow_insecure_connections = false
    traffic_weight {
      latest_revision = true
      percentage      = 100
    }
  }{{/FirstOrDefault}}{{/if}}
  registry {
    server   = azurerm_container_registry.app.login_server
    identity = azurerm_user_assigned_identity.app.id
  }
{{#env}}
{{#if (StartsWith @key "ConnectionStrings") }}
  secret {
    name  = "{{Replace (Lowercase @key) "_" "-"}}"
    value = "{{TfEscape @value}}"
  }
{{/if}}
{{/env}}
  template {
    container {
      name   = "{{key}}"
      image  = "{{image}}"
      cpu    = 0.25
      memory = "0.5Gi"
      args = [ {{#args}}{{#if @index}}, {{/if}}"{{TfEscape @value}}"{{/args}} ]
      env {
        name = "AZURE_CLIENT_ID"
        value = azurerm_user_assigned_identity.app.client_id
      }
{{#env}}
      env {
        name  = "{{@key}}"
{{#if (StartsWith @key "ConnectionStrings") }}
        secret_name = "{{Replace (Lowercase @key) "_" "-"}}"
{{else}}
        value = "{{TfEscape @value}}"
{{/if}}
      }
{{/env}}
    }
    max_replicas = 2
    min_replicas = 1
  }
}

locals {
  {{key}} = {
    id = azurerm_container_app.{{key}}.id
    name = azurerm_container_app.{{key}}.name
    fqdn = length(azurerm_container_app.{{key}}.ingress) > 0 ? azurerm_container_app.{{key}}.ingress[0].fqdn : null
  }
}

output "{{key}}" {
  value = local.{{key}}
}
