param(
    [String]$configuration,
    [String]$targetPath,
    [string]$testResultsFolder
)

if ($configuration -eq $null -or $configuration -eq "") {
    Write-Output "Please specify the configuration."
    exit(1)
}

if ($targetPath -eq $null -or $targetPath -eq "") {
    Write-Output "Please specify the targetPath to be build."
    exit(1)
}

if (-not(Test-Path $targetPath)) {
    Write-Output "Cannot find the targetPath: '$targetPath'."
    exit(1)
}

if ($testResultsFolder -eq $null -or $testResultsFolder -eq "") {
    Write-Output "Please specify the testResultsFolder."
    exit(1)
}

Write-Output "Running all tests ..."

Get-ChildItem -File -Include "*.Tests.*.csproj", "*.Tests.csproj" -Path "$targetPath" -Name -Recurse | ForEach-Object {
    $testProjectFileName = $_

    & "./.build/run_tests.ps1" -configuration $configuration -target "$targetPath\$testProjectFileName" -testResultsFolder "$testResultsFolder"
}
