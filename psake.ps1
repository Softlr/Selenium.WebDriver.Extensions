Set-ExecutionPolicy RemoteSigned -Force
Import-Module .\packages\psake.4.4.1\tools\psake.psm1
Invoke-psake @args
Remove-Module psake