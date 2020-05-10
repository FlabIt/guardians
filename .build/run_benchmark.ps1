param(
    [String]$compress
)

$useCompression = $null
if (-not [bool]::TryParse($compress, [ref]$useCompression)) {
    Write-Output "Please specify whether to compress artifacts (true/false)."
    exit(1)
}

$benchmarkDirectory = [System.IO.Path]::Combine($PWD, "benchmarks\FlabIt.Guardians.Benchmarks\bin\Release\netcoreapp3.1\publish")
$benchmarkRunner = [System.IO.Path]::Combine($benchmarkDirectory, "FlabIt.Guardians.Benchmarks.dll")

Write-Output "Running benchmark ..."

dotnet $benchmarkRunner

if ((ensureSuccess -stepName "Run Benchmark") -ne 0) {
    exit(1)
}

if ($useCompression) {
    Write-Output "Compressing benchmark artifacts ..."

    $benchmarkZipFileName = "benchmark-reports.zip"
    $benchmarkSource = [System.IO.Path]::Combine($PWD, "BenchmarkDotNet.Artifacts")
    $benchmarkDestination = [System.IO.Path]::Combine($PWD, $benchmarkZipFileName)

    CompressDirectory -sourceDirectory $benchmarkSource -targetFile $benchmarkDestination

    if ((ensureSuccess -stepName "Compress Benchmark Reports") -ne 0) {
        exit(1)
    }

    Write-Output "Compressed benchmark artifacts to '$benchmarkDestination'."
}
