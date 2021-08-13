param(
  [String]$repository_name,
  [String]$github_token,
  [String]$exclude
)

if ($repository_name -eq $null -or $repository_name -eq "") {
  Write-Output "Please specify the repository name."
  exit(1)
}

if ($github_token -eq $null -or $github_token -eq "") {
    Write-Output "Please specify the github token."
    exit(1)
}

$GIT_USER_EMAIL = "action@github.com"
$GIT_USER_NAME = "Github Update NuGets Action"

$targetBranch = "dev"
$onVersionChange = "minor" # major, minor, patch ...

$repositoryUrl = "https://github.com/$repository_name"

Write-Output "Running NuKeeper"
Write-Output "Project url: '$repositoryUrl'"

# Information about NuKeeper: https://github.com/NuKeeperDotNet/NuKeeper/wiki/Getting-Started
# Restore the NuKeeper tool
dotnet tool restore

git config --global user.email $GIT_USER_EMAIL
git config --global user.name $GIT_USER_NAME

nukeeper repo $repositoryUrl "$github_token" --targetBranch "$targetBranch" --change $onVersionChange --consolidate --verbosity detailed --exclude $excludes
