Properties {
	$currentDir = '.' | Resolve-Path
    $solution = $currentDir | Join-Path -ChildPath Selenium.WebDriver.Extensions.sln
    $version = '3.0.0'
    $unitTests = $currentDir | Join-Path -ChildPath test | Join-Path -ChildPath Selenium.WebDriver.Extensions.Tests `
		| Join-Path -ChildPath bin | Join-Path -ChildPath Release | Join-Path -ChildPath netcoreapp2.0 `
		| Join-Path -ChildPath Selenium.WebDriver.Extensions.Tests.dll
    $integrationTests = $currentDir | Join-Path -ChildPath test `
		| Join-Path -ChildPath Selenium.WebDriver.Extensions.IntegrationTests | Join-Path -ChildPath bin `
		| Join-Path -ChildPath Release | Join-Path -ChildPath netcoreapp2.0 `
		| Join-Path -ChildPath Selenium.WebDriver.Extensions.IntegrationTests.dll
    $artifactsDir = $currentDir | Join-Path -ChildPath .artifacts
	$coverageXml = $artifactsDir | Join-Path -ChildPath coverage.xml
}

FormatTaskName '-------- {0} --------'

Task Default -Depends Clean, Build, Test, Coverage, Pack

Task CleanArtifacts -Description 'Cleans the artifacts directory' {
    If (Test-Path -Path $artifactsDir) {
        Remove-Item -Path $artifactsDir -Recurse
    }
    New-Item -ItemType directory -Path $artifactsDir | Out-Null
}

Task CleanCode -Description 'Cleans the output directory of the .NET build configuration' {
    Invoke-Build -Path $solution -Target Clean
}

Task Clean -Description 'Cleans the output directory of all build configurations' `
	-Depends CleanCode, CleanArtifacts

Task Build -Description 'Builds the default build configuration' -Depends CleanCode {
    Invoke-Build -Path $solution
}

Task Test -Description 'Runs the unit tests' -Depends Build {
    Invoke-Test -Path $unitTests
}

Task IntegrationPhantomJs -Description 'Runs the PhantomJS integration tests' -Depends Build {
    Invoke-Test -Path $integrationTests -Trait Browser=PhantomJS
}

Task IntegrationChrome -Description 'Runs the Chrome integration tests' -Depends Build {
    Invoke-Test -Path $integrationTests -Trait Browser=Chrome
}

Task IntegrationFirefox -Description 'Runs the Firefox integration tests' -Depends Build {
    Invoke-Test -Path $integrationTests -Trait Browser=Firefox
}

Task IntegrationInternetExplorer -Description 'Runs the Internet Explorer integration tests' -Depends Build {
    Invoke-Test -Path $integrationTests -Trait Browser=InternetExplorer
}

Task IntegrationEdge -Description 'Runs the Internet Explorer integration tests' -Depends Build {
    Invoke-Test -Path $integrationTests -Trait Browser=Edge
}

Task Integration -Description 'Runs all of the integration tests' `
	-Depends IntegrationPhantomJs, IntegrationChrome, IntegrationFirefox, IntegrationInternetExplorer, IntegrationEdge

Task Coverage -Description 'Generates the code coverage HTML report' -Depends Build {
	Invoke-Coverage -Path $unitTests -Destination $coverageXml `
		-Filter '+[Selenium.WebDriver.Extensions*]* -[*]*Exception* -[*Tests]* -[xunit*]*'`
		-ReportDestination ($artifactsDir | Join-Path -ChildPath CoverageReport)
}

Task Pack -Description 'Packs NuGet package' -Depends Build {
	$specPath = $currentDir | Join-Path -ChildPath src | Join-Path -ChildPath Selenium.WebDriver.Extensions `
		| Join-Path -ChildPath *.nuspec | Resolve-Path
    New-NugetPackage -Path $specPath -Version $version
    Move-Item -Path ($currentDir | Join-Path -ChildPath *.nupkg) -Destination $artifactsDir
}
