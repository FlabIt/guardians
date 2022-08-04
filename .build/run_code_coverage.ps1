param(
    [string]$testResultsFolder,
    [String]$compress
)

if ($testResultsFolder -eq $null -or $testResultsFolder -eq "") {
    Write-Output "Please specify the test results folder."
    exit(1)
}

if (-not (Test-Path $testResultsFolder)) {
    Write-Output "Creating folder '$testResultsFolder' ..."
    mkdir $testResultsFolder > $null
}

$useCompression = $null
if (-not [bool]::TryParse($compress, [ref]$useCompression)) {
  Write-Output "Please specify whether to compress artifacts (true/false)."
  exit(1)
}

. "./.build/functions.ps1"

$codeCoveragePackageVersion = "17.2.0"

# Restore the Code Coverage Generator tool
dotnet tool restore

if ((ensureSuccess -stepName "Install Code Coverage Generator") -ne 0) {
    exit(1)
}

$coverageToolPath = "$ENV:UserProfile\.nuget\packages\microsoft.codecoverage\$codeCoveragePackageVersion\build\netstandard1.0\CodeCoverage\CodeCoverage.exe"

if (-not (Test-Path $coverageToolPath)) {
    Write-Output "Could not find CodeCoverage tool path for version '$codeCoveragePackageVersion'."
    exit(1)
}

$reports = ""
Get-ChildItem -File -Filter *.coverage -Path $testResultsFolder -Name -Recurse | Select-Object | ForEach-Object {
    $recentCoverageFile = $_

    Write-Output "Found coverage file: '$recentCoverageFile'"

    $recentCoverageFileName = [System.IO.Path]::GetFileNameWithoutExtension($recentCoverageFile)

    & $coverageToolPath analyze /output:"$testResultsFolder/$recentCoverageFileName.coveragexml" "$testResultsFolder/$recentCoverageFile"

    $reports = $reports + "$testResultsFolder/$recentCoverageFileName.coveragexml;"
}

# Remove the last separator char ';'
$reports = $reports.Substring(0, $reports.Length - 1)

$targetReportDirectory = [System.IO.Path]::Combine($testResultsFolder, "coveragereport")
dotnet reportgenerator "-reports:$reports" "-targetdir:$targetReportDirectory" "-reporttypes:Html"

if ((ensureSuccess -stepName "Generate HTML Coverage Reports") -ne 0) {
    exit(1)
}

if ($useCompression){
    Write-Output "Compressing coverage reports ..."
    
    $zipFileName = "coverage-reports.zip"
    $source = [System.IO.Path]::Combine($PWD, "$testResultsFolder")
    $destination = [System.IO.Path]::Combine($PWD, $zipFileName)
    
    CompressDirectory -sourceDirectory $source -targetFile $destination
    
    if ((ensureSuccess -stepName "Compress Coverage Reports") -ne 0) {
        exit(1)
    }
    
    Write-Output "Compressed coverage reports to '$destination'."
}
    