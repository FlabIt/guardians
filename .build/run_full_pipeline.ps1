param(
  [String]$configuration = "Release",
  [String]$testResultsDirectory = "./test-results/",
  [String]$compress = "false"
)

if ($configuration -eq $null -or $configuration -eq "") {
  Write-Output "Please specify the configuration."
  exit(1)
}

if ($testResultsDirectory -eq $null -or $testResultsDirectory -eq "") {
  Write-Output "Please specify the test results directory."
  exit(1)
}

$useCompression = $null
if (-not [bool]::TryParse($compress, [ref]$useCompression)) {
  Write-Output "Please specify whether to compress artifacts (true/false)."
  exit(1)
}

$solutionFilePath = "./FlabIt.Guardians.sln"
$testProjectsDirectory = "./tests"

. "./.build/functions.ps1"

Write-Output "Running pipeline for: Configuration='$configuration' Test-Results-Directory='$testResultsDirectory' ..."

& "./.build/build_configuration.ps1" -configuration $configuration -target "$solutionFilePath"

if ((ensureSuccess -stepName "Build Configuration") -ne 0) {
  exit
}

& "./.build/run_all_tests.ps1" -configuration $configuration -target "$testProjectsDirectory" -testResultsFolder "$testResultsDirectory"

if ((ensureSuccess -stepName "Run Tests") -ne 0) {
  exit
}

& "./.build/run_code_coverage.ps1" -testResultsFolder "$testResultsDirectory" -compress $compress

if ((ensureSuccess -stepName "Run Code Coverage") -ne 0) {
  exit
}

& "./.build/publish_app.ps1" -configuration $configuration -target "$solutionFilePath"

if ((ensureSuccess -stepName "Publish App") -ne 0) {
  exit
}

& "./.build/build_nuget_packages.ps1" -configuration $configuration -target "$solutionFilePath"

if ((ensureSuccess -stepName "Build NuGet Packages") -ne 0) {
  exit
}

if ($useCompression) {
  Write-Output "Compressing build artifacts ..."
  
  $zipFileName = "artifacts.zip"
  $source = [System.IO.Path]::Combine($PWD, "src/FlabIt.Guardians/bin/$configuration")
  $destination = [System.IO.Path]::Combine($PWD, $zipFileName)
  
  CompressDirectory -sourceDirectory $source -targetFile $destination
  
  if ((ensureSuccess -stepName "Compress Build Artifacts") -ne 0) {
    exit
  }
  
  Write-Output "Compressed build artifacts to '$destination'."
}
