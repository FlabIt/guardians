param(
  [String]$configuration,
  [String]$target
)

if ($configuration -eq $null -or $configuration -eq "") {
    Write-Output "Please specify the configuration."
    exit(1)
}

if ($target -eq $null -or $target -eq "") {
  Write-Output "Please specify the target to be build."
  exit(1)
}

if (-not(Test-Path $target)) {
  Write-Output "Cannot find the target: '$target'."
  exit(1)
}

Write-Output "Publishing target '$target' with configuration '$configuration' ..."

dotnet publish $target --configuration $configuration --no-build --nologo
