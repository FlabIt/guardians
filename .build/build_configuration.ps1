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

Write-Output "Building target '$target' with configuration '$configuration' ..."

dotnet restore $target --configfile "nuget.config"

dotnet build $target --configuration $configuration --no-restore --nologo
