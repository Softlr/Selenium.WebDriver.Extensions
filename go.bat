@src\.nuget\nuget install src/.nuget/packages.config -o src/packages
@src\.nuget\nuget restore src/Selenium.WebDriver.Extensions.sln
@xcopy /Y src\.nuget\NAnt.exe.config src\packages\NAnt.Portable.0.92\
@src\packages\NAnt.Portable.0.92\NAnt -buildfile:Selenium.WebDriver.Extensions.build %*