properties {
	$solution = '..\Selenium.WebDriver.Extensions.sln'
	$version = '1.4.0'
	$jQueryUnitTests = '..\test\Selenium.WebDriver.Extensions.JQuery.Tests\bin\Release\Selenium.WebDriver.Extensions.JQuery.Tests.dll'
	$sizzleUnitTests = '..\test\Selenium.WebDriver.Extensions.Sizzle.Tests\bin\Release\Selenium.WebDriver.Extensions.Sizzle.Tests.dll'
	$coreUnitTests = '..\test\Selenium.WebDriver.Extensions.Core.Tests\bin\Release\Selenium.WebDriver.Extensions.Core.Tests.dll'
	$combinedUnitTests = '..\test\Selenium.WebDriver.Extensions.Tests\bin\Release\Selenium.WebDriver.Extensions.Tests.dll'
	$integrationTests = '..\test\Selenium.WebDriver.Extensions.IntegrationTests\bin\Release\Selenium.WebDriver.Extensions.IntegrationTests.dll'
	$coverageXml = '..\coverage.xml'
}

FormatTaskName '-------- {0} --------'

task default -depends Compile, Test, Coverage, Docs, Pack

task CleanNet45 {
	. .\msbuild.ps1
	Invoke-Build $solution -Target Clean
}

task CleanNet40 {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Release-Net40 -Target Clean
}

task CleanNet35 {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Release-Net35 -Target Clean
}

task CleanDocs {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Docs -Target Clean
}

task Clean -depends CleanNet45, CleanNet40, CleanNet35, CleanDocs

task CompileNet45 -depends CleanNet45 {
	. .\msbuild.ps1
	Invoke-Build $solution
}

task CompileNet40 -depends CleanNet40 {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Release-Net40
}

task CompileNet35 -depends CleanNet35 {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Release-Net35
}

task Compile -depends CompileNet45, CompileNet40, CompileNet35

task CompileDocs -depends CleanDocs {
	. .\msbuild.ps1
	Invoke-Build $solution -BuildConfiguration Docs
}

task Docs -depends CompileDocs

task Test -depends CompileNet45 {
	. .\test.ps1
	Invoke-Tests $jQueryUnitTests $sizzleUnitTests $coreUnitTests $combinedUnitTests
}

task IntegrationPhantomJs -depends CompileNet45 {
	. .\integration.ps1
	Invoke-IntegrationTests $integrationTests -Trait Browser=PhantomJS
}

task IntegrationChrome -depends CompileNet45 {
	. .\integration.ps1
	Invoke-IntegrationTests $integrationTests -Trait Browser=Chrome
}

task IntegrationFirefox -depends CompileNet45 {
	. .\integration.ps1
	Invoke-IntegrationTests $integrationTests -Trait Browser=Firefox
}

task IntegrationInternetExplorer -depends CompileNet45 {
	. .\integration.ps1
	Invoke-IntegrationTests $integrationTests -Trait Browser=InternetExplorer
}

task Integration -depends IntegrationPhantomJs, IntegrationChrome, IntegrationFirefox, IntegrationInternetExplorer

task AnalyzeCoverage -depends CompileNet45 {
	. .\coverage.ps1
	Invoke-AnalyzeCoverage $jQueryUnitTests $sizzleUnitTests $coreUnitTests $combinedUnitTests -Output $coverageXml
}

task Coverage -depends AnalyzeCoverage {
	. .\coverageReport.ps1
	Invoke-CoverageReportGenerator $coverageXml -Output ..\CoverageReport
}

task Coveralls -depends AnalyzeCoverage {
	. .\coveralls.ps1
	Send-Coveralls $coverageXml
}

task PackJQuery -depends Compile {
	. .\nugetPack.ps1
	Write-NugetPackage .\src\Selenium.WebDriver.Extensions.JQuery\Selenium.WebDriver.Extensions.JQuery.nuspec -Version $version
}

task PackSizzle -depends Compile {
	. .\nugetPack.ps1
	Write-NugetPackage .\src\Selenium.WebDriver.Extensions.Sizzle\Selenium.WebDriver.Extensions.Sizzle.nuspec -Version $version
}

task PackCore -depends Compile {
	. .\nugetPack.ps1
	Write-NugetPackage .\src\Selenium.WebDriver.Extensions.Core\Selenium.WebDriver.Extensions.Core.nuspec -Version $version
}

task PackCombined -depends Compile {
	. .\nugetPack.ps1
	Write-NugetPackage .\src\Selenium.WebDriver.Extensions\Selenium.WebDriver.Extensions.nuspec -Version $version
}

task Pack -depends PackJQuery, PackSizzle, PackCore, PackCombined