param(
  [String]$configuration,
  [String]$target,
  [string]$testResultsFolder
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

if ($testResultsFolder -eq $null -or $testResultsFolder -eq "") {
    Write-Output "Please specify the testResultsFolder."
    exit(1)
}

if (-not(Test-Path $testResultsFolder)) {
    Write-Output "Creating folder '$testResultsFolder' ..."
    mkdir "$testResultsFolder" > $null
}

$tempTestResultsFolder = "${testResultsFolder}temp"
if (-not(Test-Path $tempTestResultsFolder)) {
    Write-Output "Creating folder '$tempTestResultsFolder' ..."
    mkdir "$tempTestResultsFolder" > $null
}

$testProjectPath = [System.IO.Path]::GetDirectoryName($target)
$testSettingsPath = "$testProjectPath/../runsettings.xml"

if (-not(Test-Path $testSettingsPath)) {
    Write-Output "Cannot find the runsettings file: '$testSettingsPath'."
    exit(1)
}

Write-Output "Running tests for target '$target' with configuration '$configuration' ..."

dotnet test $target --configuration $configuration --no-build --results-directory:"$tempTestResultsFolder" --settings:"$testSettingsPath" --collect:"Code Coverage" --verbosity normal --nologo

$recentCoverageFileTemp = Get-ChildItem -File -Filter *.coverage -Path "$tempTestResultsFolder" -Name -Recurse | Select-Object -First 1;

# Give report a proper name
$fileName = [System.IO.Path]::GetFileNameWithoutExtension($target)
$recentCoverageFile = "$testResultsFolder/$fileName.coverage"
Copy-Item "$tempTestResultsFolder/$recentCoverageFileTemp" $recentCoverageFile

# Clear temp directory
Get-ChildItem -Path $tempTestResultsFolder -Recurse | Remove-Item -force -recurse
