param(
  [String]$source,
  [String]$token
)

if ($source -eq $null -or $source -eq "") {
  Write-Output "No source specified, using default."

  $source = "nuget.org"
}

if ($token -eq $null -or $token -eq "") {
  Write-Output "No token specified."
  
  exit(1)
}

Write-Output "Publishing nuget packages to source '$source' ..."

Get-ChildItem -File -Filter *.nupkg -Path $pwd -Name -Recurse | Select-Object | ForEach-Object {
  Write-Output "Publishing .nupkg-file '$_' ..."  
  
  dotnet nuget push $_ --source "$source" --api-key "$token" --skip-duplicate
}
