$root = Split-Path $script:MyInvocation.MyCommand.Path -Parent
& $root\.nuget\NuGet.exe restore $root/Selenium.WebDriver.Extensions.sln
$psakePath = Resolve-Path $root\packages\psake.*\tools\psake.psm1
Import-Module $psakePath
$psakeBuildPath = Resolve-Path $root\packages\psake.net.build.module.*\tools\build.psm1
Import-Module $psakeBuildPath
Invoke-psake $root\default.ps1 @args
Remove-Module build
Remove-Module psake
