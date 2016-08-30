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
If (-Not ((Get-PackageProvider -Name NuGet).Version -gt [System.Version]'2.8.5.201')) {
	Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
}

Set-PSRepository -Name PSGallery -InstallationPolicy Trusted

'psake', 'Pester', 'PSScriptAnalyzer' | ForEach-Object -Process {
	$installedModule = Get-InstalledModule | Where-Object -Property Name -EQ -Value $_
	$latestVersion = (Find-Module -Name $_).Version
	If (-Not $installedModule) {
		'Installing {0} {1}' -f $_, $latestVersion | Write-Output
		Find-Module -Name $_ | Install-Module
	} ElseIf ($installedModule.Version -ne $latestVersion) {
		'Updating {0} from {1} to {2}' -f $_, $installedModule.Version, $latestVersion | Write-Output
		Update-Module -Name $_
	} Else {
		'{0} in version {1} is up-to-date' -f $_, $installedModule.Version | Write-Output
	}
}

# invoke psake
Import-Module -Name psake
Import-Module -Name ($root | Join-Path -ChildPath build | Join-Path -ChildPath build.psd1)
Invoke-psake -BuildFile ($root | Join-Path -ChildPath default.ps1)

# evaluate task status
$psakeBuildStatus = If ($psake -And ($psake.build_success -eq $True)) { 0 } Else { 1 }
Exit $psakeBuildStatus