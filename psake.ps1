$root = Split-Path $script:MyInvocation.MyCommand.Path -Parent
& $root\.nuget\NuGet.exe restore $root/Selenium.WebDriver.Extensions.sln
Import-Module $root\packages\psake.4.4.1\tools\psake.psm1
Import-Module $root\packages\psake.net.build.module.1.0.6\tools\build.psm1
Invoke-psake $root\default.ps1 @args
Remove-Module build
Remove-Module psake