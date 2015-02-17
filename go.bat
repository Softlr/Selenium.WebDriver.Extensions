@.nuget\nuget restore
@xcopy /Y .nuget\NAnt.exe.config packages\NAnt.Portable.0.92\
@packages\NAnt.Portable.0.92\NAnt -buildfile:Selenium.WebDriver.Extensions.build %*