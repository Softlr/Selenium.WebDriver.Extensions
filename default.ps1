Properties {
	$currentDir = '.' | Resolve-Path
    $solution = $currentDir | Join-Path -ChildPath *.sln | Resolve-Path
    $version = '3.0.0'
    $unitTests = $currentDir | Join-Path -ChildPath test | Join-Path -ChildPath Selenium.WebDriver.Extensions.Tests `
		| Join-Path -ChildPath bin | Join-Path -ChildPath Release | Join-Path -ChildPath Selenium.WebDriver.Extensions.Tests.dll
    $integrationTests = $currentDir | Join-Path -ChildPath test `
		| Join-Path -ChildPath Selenium.WebDriver.Extensions.IntegrationTests | Join-Path -ChildPath bin `
		| Join-Path -ChildPath Release | Join-Path -ChildPath Selenium.WebDriver.Extensions.IntegrationTests.dll
    $artifactsDir = $currentDir | Join-Path -ChildPath .artifacts
	$coverageXml = $artifactsDir | Join-Path -ChildPath coverage.xml
}

FormatTaskName '-------- {0} --------'

Task default -Depends Clean, Compile, Test, Coverage, Docs, Pack

Task CleanArtifacts -Description 'Cleans the artifacts directory' {
    If (Test-Path -Path $artifactsDir) {
        Remove-Item -Path $artifactsDir -Recurse
    }
    New-Item -ItemType directory -Path $artifactsDir | Out-Null
}

Task CleanNet46 -Description 'Cleans the output directory of the default .NET 4.6 build configuration' {
    New-Build -Solution $solution -Target Clean
}

Task CleanNet45 -Description 'Cleans the output directory of the default .NET 4.5 build configuration' {
    New-Build -Solution $solution -BuildConfiguration Release-Net45 -Target Clean
}

Task CleanNet40 -Description 'Cleans the output directory of the .NET 4.0 build configuration' {
    New-Build -Solution $solution -BuildConfiguration Release-Net40 -Target Clean
}

Task CleanDocs -Description 'Cleans the output directory of the documentation build configuration' {
    $envVarNotDefined = $env:SHFBROOT -eq $null
    If ($envVarNotDefined) {
        $env:SHFBROOT = $PWD.Path + '\packages\EWSoftware.SHFB.2015.10.10.0\tools'
    }
    Try {
        New-Build -Solution $solution -BuildConfiguration Docs -Target Clean
    } Finally {
        If ($envVarNotDefined) {
            $env:SHFBROOT = $null
        }
    }
}

Task Clean -Description 'Cleans the output directory of all build configurations' `
	-Depends CleanNet46, CleanNet45, CleanNet40, CleanDocs, CleanArtifacts

Task CompileNet46 -Description 'Compiles the default .NET 4.6 build configuration' -Depends CleanNet46 {
    New-Build -Solution $solution
}

Task CompileNet45 -Description 'Compiles the default .NET 4.5 build configuration' -Depends CleanNet45 {
    New-Build -Solution $solution -BuildConfiguration Release-Net45
}

Task CompileNet40 -Description 'Compiles the .NET 4.0 build configuration' -Depends CleanNet40 {
    New-Build -Solution $solution -BuildConfiguration Release-Net40
}

Task Compile -Description 'Compiles all of the build configurations' -Depends CompileNet46, CompileNet45, CompileNet40

Task Docs -Description 'Compiles the documentation build configuration' -Depends CleanDocs, CleanArtifacts, CompileNet46 {
    New-Build -Solution $solution -BuildConfiguration Docs
    
	$docsDir = $currentDir | Join-Path -ChildPath Docs | Join-Path -ChildPath bin | Join-Path -ChildPath Docs
    Move-Item -Path $docsDir -Destination $artifactsDir
}

Task Test -Description 'Runs the unit tests' -Depends CompileNet46 {
    Test-Assembly -Tests $unitTests
}

Task IntegrationPhantomJs -Description 'Runs the PhantomJS integration tests' -Depends CompileNet46 {
    Test-Assembly -Tests $integrationTests -Trait Browser=PhantomJS
}

Task IntegrationChrome -Description 'Runs the Chrome integration tests' -Depends CompileNet46 {
    Test-Assembly -Tests $integrationTests -Trait Browser=Chrome
}

Task IntegrationFirefox -Description 'Runs the Firefox integration tests' -Depends CompileNet46 {
    Test-Assembly -Tests $integrationTests -Trait Browser=Firefox
}

Task IntegrationInternetExplorer -Description 'Runs the Internet Explorer integration tests' -Depends CompileNet46 {
    Test-Assembly -Tests $integrationTests -Trait Browser=InternetExplorer
}

Task IntegrationEdge -Description 'Runs the Internet Explorer integration tests' -Depends CompileNet46 {
    Test-Assembly -Tests $integrationTests -Trait Browser=Edge
}

Task Integration -Description 'Runs all of the integration tests' `
	-Depends IntegrationPhantomJs, IntegrationChrome, IntegrationFirefox, IntegrationInternetExplorer, IntegrationEdge

Task AnalyzeCoverage -Description 'Analyzes the code coverage' -Depends CompileNet46 {
    New-CoverageAnalysis -Tests $unitTests -Output $coverageXml `
		-Filter '+[Selenium.WebDriver.Extensions*]* -[*]*Exception* -[*Tests]* -[xunit*]*'
}

Task Coverage -Description 'Generates the code coverage HTML report' -Depends AnalyzeCoverage {
    New-CoverageReport -CoverageXml $coverageXml -Output ($artifactsDir | Join-Path -ChildPath CoverageReport)
}

Task Pack -Description 'Packs NuGet package' -Depends Compile {
	$specPath = $currentDir | Join-Path -ChildPath src | Join-Path -ChildPath Selenium.WebDriver.Extensions `
		| Join-Path -ChildPath *.nuspec | Resolve-Path
    New-NugetPackage -Specification $specPath -Version $version
    Move-Item -Path ($currentDir | Join-Path -ChildPath *.nupkg) -Destination $artifactsDir
}
