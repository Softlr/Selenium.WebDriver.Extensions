@echo off
cls
powershell -ExecutionPolicy RemoteSigned -Command "%~dp0psake.ps1" %*
echo WILL EXIT WITH RCODE %ERRORLEVEL%
exit /b %ERRORLEVEL%