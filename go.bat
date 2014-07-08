@.nuget\nuget install .nuget/packages.config -o packages
@.nuget\nuget restore Selenium.WebDriver.Extensions.sln
@xcopy /Y .nuget\NAnt.exe.config packages\NAnt.Portable.0.92\
@packages\NAnt.Portable.0.92\NAnt -buildfile:Selenium.WebDriver.Extensions.build %*