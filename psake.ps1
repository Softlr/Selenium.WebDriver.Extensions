Import-Module .\packages\psake.4.4.1\tools\psake.psm1
Import-Module .\build.psm1
Invoke-psake .\default.ps1 @args
Remove-Module build
Remove-Module psake