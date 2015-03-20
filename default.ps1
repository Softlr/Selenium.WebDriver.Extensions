properties {
	$solution = '.\Selenium.WebDriver.Extensions.sln'
	$version = '1.4.0'
	$unitTests = '.\test\Selenium.WebDriver.Extensions.JQuery.Tests\bin\Release\Selenium.WebDriver.Extensions.JQuery.Tests.dll', '.\test\Selenium.WebDriver.Extensions.Sizzle.Tests\bin\Release\Selenium.WebDriver.Extensions.Sizzle.Tests.dll', '.\test\Selenium.WebDriver.Extensions.Core.Tests\bin\Release\Selenium.WebDriver.Extensions.Core.Tests.dll', '.\test\Selenium.WebDriver.Extensions.Tests\bin\Release\Selenium.WebDriver.Extensions.Tests.dll'
	$integrationTests = '.\test\Selenium.WebDriver.Extensions.IntegrationTests\bin\Release\Selenium.WebDriver.Extensions.IntegrationTests.dll'
	$coverageXml = '.\coverage.xml'
}

FormatTaskName '-------- {0} --------'

Task default -Depends Compile, Test, Coverage, Docs, Pack

Task CleanNet45 -Description "Cleans the output directory of the default .NET 4.5 build configuration" {
	New-Build $solution -Target Clean
}

Task CleanNet40 -Description "Cleans the output directory of the .NET 4.0 build configuration" {
	New-Build $solution -BuildConfiguration Release-Net40 -Target Clean
}

Task CleanNet35 -Description "Cleans the output directory of the .NET 3.5 build configuration" {
	New-Build $solution -BuildConfiguration Release-Net35 -Target Clean
}

Task CleanDocs -Description "Cleans the output directory of the documentation build configuration" {
	New-Build $solution -BuildConfiguration Docs -Target Clean
}

Task Clean -Description "Cleans the output directory of all build configurations" -Depends CleanNet45, CleanNet40, CleanNet35, CleanDocs

Task CompileNet45 -Description "Compiles the default .NET 4.5 build configuration" -Depends CleanNet45 {
	New-Build $solution
}

Task CompileNet40 -Description "Compiles the .NET 4.0 build configuration" -Depends CleanNet40 {
	New-Build $solution -BuildConfiguration Release-Net40
}

Task CompileNet35 -Description "Compiles the .NET 3.5 build configuration" -Depends CleanNet35 {
	New-Build $solution -BuildConfiguration Release-Net35
}

Task Compile -Description "Compiles all of the build configurations" -Depends CompileNet45, CompileNet40, CompileNet35

Task Docs  -Description "Compiles the documentation build configuration" -Depends CleanDocs {
	Invoke-Build $solution -BuildConfiguration Docs
}

Task Test -Description "Runs the unit tests" -Depends CompileNet45 {
	Test-Assembly $unitTests
}

Task IntegrationPhantomJs -Description "Runs the PhantomJS integration tests" -Depends CompileNet45 {
	Test-Assembly $integrationTests -Trait Browser=PhantomJS
}

Task IntegrationChrome -Description "Runs the Chrome integration tests" -Depends CompileNet45 {
	Test-Assembly $integrationTests -Trait Browser=Chrome
}

Task IntegrationFirefox -Description "Runs the Firefox integration tests" -Depends CompileNet45 {
	Test-Assembly $integrationTests -Trait Browser=Firefox
}

Task IntegrationInternetExplorer -Description "Runs the Internet Explorer integration tests" -Depends CompileNet45 {
	Test-Assembly $integrationTests -Trait Browser=InternetExplorer
}

Task Integration  -Description "Runs all of the integration tests" -Depends IntegrationPhantomJs, IntegrationChrome, IntegrationFirefox, IntegrationInternetExplorer

Task AnalyzeCoverage -Description "Analyzes the code coverage" -Depends CompileNet45 {
	New-CoverageAnalysis $unitTests $coverageXml
}

Task Coverage -Description "Generates the code coverage HTML report" -Depends AnalyzeCoverage {
	New-CoverageReport $coverageXml .\CoverageReport
}

Task Coveralls -Description "Sends coverage data to coveralls.io" -Depends AnalyzeCoverage {
	Publish-Coveralls $coverageXml
}

Task PackJQuery -Description "Packs JQuery module NuGet package" -Depends Compile {
	New-NugetPackage .\src\Selenium.WebDriver.Extensions.JQuery\Selenium.WebDriver.Extensions.JQuery.nuspec -Version $version
}

Task PackSizzle -Description "Packs Sizzle module NuGet package" -Depends Compile {
	New-NugetPackage .\src\Selenium.WebDriver.Extensions.Sizzle\Selenium.WebDriver.Extensions.Sizzle.nuspec -Version $version
}

Task PackCore -Description "Packs core module NuGet package" -Depends Compile {
	New-NugetPackage .\src\Selenium.WebDriver.Extensions.Core\Selenium.WebDriver.Extensions.Core.nuspec -Version $version
}

Task PackCombined -Description "Packs combined module NuGet package" -Depends Compile {
	New-NugetPackage .\src\Selenium.WebDriver.Extensions\Selenium.WebDriver.Extensions.nuspec -Version $version
}

Task Pack -Description "Packs all of the module NuGet packages" -Depends PackJQuery, PackSizzle, PackCore, PackCombined