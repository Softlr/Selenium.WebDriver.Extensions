@echo off

powershell -ExecutionPolicy RemoteSigned -command "%~dp0psake.ps1" %*
echo WILL EXIT WITH RCODE %ERRORLEVEL%
exit /b %ERRORLEVEL%