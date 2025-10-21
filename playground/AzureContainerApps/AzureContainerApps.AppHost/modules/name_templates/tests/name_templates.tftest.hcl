run "setup_tests" {
  module {
    source = "./tests/setup"
  }
}

run "test_templates" {
  command = apply

  variables {
    organization        = "org"
    workloadEnvironment = "env"
    workloadName        = "test"
  }

  assert {
    condition     = output.default == "org-env-<service>-test"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.short == "orgenv<service>test"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.default-random == "org-env-<service>-test-${output.random-string}"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.short-random == "orgenv<service>test${output.random-string}"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role == "ra-org-env-test-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission == "pm-org-env-test-<permission>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role-global == "ra-org-env-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission-global == "pm-org-env-<permission>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role-no-environment == "ra-org-test-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission-no-environment == "pm-org-test-<permission>"
    error_message = "name is not expected value"
  }
}

run "test_templates_random" {
  command = apply

  variables {
    organization        = "org"
    workloadEnvironment = "env"
    workloadName        = "test"
    random_string       = run.setup_tests.random_string
  }

  assert {
    condition     = output.default-random == "org-env-<service>-test-${run.setup_tests.random_string}"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.short-random == "orgenv<service>test${run.setup_tests.random_string}"
    error_message = "name is not expected value"
  }
}

run "test_templates_subcomp" {
  command = apply

  variables {
    organization        = "org"
    workloadEnvironment = "env"
    workloadName        = "test"
    subComponent        = "sub"
    random_string       = run.setup_tests.random_string
  }

  assert {
    condition     = output.default == "org-env-<service>-test-sub"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.short == "orgenv<service>testsub"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.default-random == "org-env-<service>-test-sub-${output.random-string}"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.short-random == "orgenv<service>testsub${output.random-string}"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role == "ra-org-env-test-sub-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission == "pm-org-env-test-sub-<permission>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role-global == "ra-org-env-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission-global == "pm-org-env-<permission>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.role-no-environment == "ra-org-test-<role>"
    error_message = "name is not expected value"
  }

  assert {
    condition     = output.permission-no-environment == "pm-org-test-<permission>"
    error_message = "name is not expected value"
  }
}
