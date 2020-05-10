Function EnsureSuccess([string]$stepName) {
    if ($?) {
        return 0
    }

    Write-Output "Step '$stepName' failed with exit code '$LASTEXITCODE'."
    return $LASTEXITCODE
}

Function CompressDirectory([String]$sourceDirectory, [String]$targetFile) {
    if (-not (Test-Path $sourceDirectory)) {
        Write-Output "Cannot find source directory."
        exit(1)
    }

    if (Test-Path $targetFile) {
        Remove-Item $targetFile
    }
    
    Add-Type -AssemblyName "System.IO.Compression.FileSystem"
    [System.IO.Compression.ZipFile]::CreateFromDirectory($sourceDirectory, $targetFile)
}
