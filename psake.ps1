#Requires -Version 5.0

# ensure admin privileges
If (-Not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(
    [Security.Principal.WindowsBuiltInRole]'Administrator')) {
    Throw 'Administrator rights are required to run this script'
}

# resolve paths
$root = Split-Path -Path $script:MyInvocation.MyCommand.Path -Parent
$nugetPath = $root | Join-Path -ChildPath .nuget | Join-Path -ChildPath NuGet.exe
$solutionPath = $root | Join-Path -ChildPath *.sln | Resolve-Path

# restore solution packages
$process = Start-Process -FilePath $nugetPath 'restore', $solutionPath -NoNewWindow -Wait -PassThru
If ($process.ExitCode) {
	Throw 'Package restore failed'
}

# install/update psake
If (-Not ((Get-PackageProvider -Name PowerShellGet).Version -gt [System.Version]'2.8.5.201')) {
	Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
}

Set-PSRepository -Name PSGallery -InstallationPolicy Trusted

$installedModule = Get-InstalledModule | Where-Object -Property Name -EQ -Value psake
$latestVersion = (Find-Module -Name psake).Version
If (-Not $installedModule) {
    'Installing psake {0}' -f $latestVersion | Write-Output
    Find-Module -Name psake | Install-Module
} ElseIf ($installedModule.Version -ne $latestVersion) {
    'Updating psake from {0} to {1}' -f $installedModule.Version, $latestVersion | Write-Output
    Find-Module -Name psake | Install-Module -Force
} Else {
    'psake in version {0} is up-to-date' -f $installedModule.Version | Write-Output
}

# invoke psake
Import-Module -Name psake
Import-Module -Name ($root | Join-Path -ChildPath build.psm1)
Invoke-psake -BuildFile ($root | Join-Path -ChildPath default.ps1)

# evaluate task status
$psakeBuildStatus = If ($psake -And ($psake.build_success -eq $True)) { 0 } Else { 1 }
Exit $psakeBuildStatus