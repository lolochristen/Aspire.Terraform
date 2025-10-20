resource "azurerm_servicebus_namespace" "{{name}}" {
  name                = "${replace(local.name_template, "<service>", "svcbus")}-{{name}}"
  resource_group_name = azurerm_resource_group.app.name
  location            = var.location
  sku                 = "Standard"
  identity {
    type         = "UserAssigned"
    identity_ids = [azurerm_user_assigned_identity.app.id]
  }
  tags                = merge (local.tags, {
    aspire-resource-name = "{{name}}"
  })
}

resource "azurerm_role_assignment" "{{name}}_sb_data_owner" {
  scope                = azurerm_servicebus_namespace.{{name}}.id
  role_definition_name = "Azure Service Bus Data Owner"
  principal_id         = azurerm_user_assigned_identity.app.principal_id
}

{{#params}}
{{#if (Equals @key "queues") }}
// queues
{{#each this}}
resource "azurerm_servicebus_queue" "{{@root.key}}_{{this}}" {
  name         = "{{this}}"
  namespace_id = azurerm_servicebus_namespace.{{@root.key}}.id
}
{{/each}}
{{/if}}   
{{#if (Equals @key "topics") }}
// topics
{{#each this}}
resource "azurerm_servicebus_topic" "{{@root.key}}_{{name}}" {
  name         = "{{name}}"
  namespace_id = azurerm_servicebus_namespace.{{@root.key}}.id
}
{{#each subscriptions}}
resource "azurerm_servicebus_subscription" "{{@root.key}}_{{../name}}_{{this}}" {
  name     = "{{this}}"
  topic_id = azurerm_servicebus_topic.{{../name}}.id
}
{{/each}}
{{/each}}
{{/if}}   
{{/params}}

locals {
  {{name}} = {
    id = azurerm_servicebus_namespace.{{name}}.id
    name = azurerm_servicebus_namespace.{{name}}.name
    serviceBusEndpoint = azurerm_servicebus_namespace.{{name}}.endpoint
  }
}

output "{{name}}" {
  value = local.{{name}}
}

