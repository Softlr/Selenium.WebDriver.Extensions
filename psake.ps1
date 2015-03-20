Set-ExecutionPolicy RemoteSigned -Force
Import-Module .\packages\psake.4.4.1\tools\psake.psm1
Invoke-psake .\psake\default.ps1 @args
Remove-Module psake