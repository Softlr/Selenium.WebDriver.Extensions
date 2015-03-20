<#
.SYNOPSIS
Invoke the code coverage analysis.

.DESCRIPTION
This function invokes the code coverage analysis tool for the given test assemblies.

.PARAMETER Tests
The test assemblies.

.PARAMETER Output
The output path for the coverage file.

.PARAMETER Filter
The filter for the test assemblies.

.EXAMPLE
Invoke-AnalyzeCoverage @(.\Foo.Tests\bin\Release\Foo.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml -Filter "+[*]*"
#>
function Invoke-AnalyzeCoverage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,
		
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $Output,

		[string] $Filter = "+[*]* -[*]*Exception* -[*.Tests]* -[*.IntegrationTests]*"
	)

	$testAssembies = $Tests -join " "
	Exec {
		  .\packages\OpenCover.4.5.3723\OpenCover.Console.exe -register:user -target:.\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe "-targetargs:$testAssembies -noshadow -parallel all" "-filter:$Filter" -output:$Output
	}
}

<#
.SYNOPSIS
Invoke the code coverage report generation.

.DESCRIPTION
This function invokes the code coverage report generation that generate a HTML coverage report.

.PARAMETER CoverageXmlPath
The code coverage XML file path.

.PARAMETER Output
The output path for the coverage report.

.PARAMETER Verbosity
The verebosity level.

.EXAMPLE
Invoke-CoverageReportGenerator .\coverage.xml .\CoverageReport

.EXAMPLE
Invoke-CoverageReportGenerator .\coverage.xml .\CoverageReport -Verbosity Verbose
#>
function Invoke-CoverageReportGenerator {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $CoverageXmlPath,
		
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $Output,

		[string] $Verbosity = "Error"
	)

	Exec {
		  .\packages\ReportGenerator.2.1.3.0\ReportGenerator.exe -reports:$CoverageXmlPath -targetdir:$Output -verbosity:$Verbosity
	}
}


<#
.SYNOPSIS
Sends the coverage data to coveralls.

.DESCRIPTION
This function sends the coverage data to coveralls.io.

.PARAMETER CoverageXmlPath
The code coverage XML file path.

.EXAMPLE
Send-Coveralls .\coverage.xml
#>
function Send-Coveralls {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $CoverageXmlPath
	)

	Exec {
		  .\packages\coveralls.io.1.2.2\tools\coveralls.net.exe --opencover $CoverageXmlPath
	}
}

<#
.SYNOPSIS
Invoke the MS build process.

.DESCRIPTION
This function invokes the MS build process that builds given solution.

.PARAMETER SolutionPath
The path for the Visual Studio solution file.

.PARAMETER BuildConfiguration
The build configuration name to use.

.PARAMETER VisualStudioVersion
The visual studio version to use.

.PARAMETER Verbosity
The verebosity level.

.PARAMETER Target
The target for the MS build.

.EXAMPLE
Invoke-Build .\Foo.sln

.EXAMPLE
Invoke-Build .\Foo.sln "Debug"

.EXAMPLE
Invoke-Build .\Foo.sln -Verbosity normal

.EXAMPLE
Invoke-Build .\Foo.sln -Target Clean
#>
function Invoke-Build {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $SolutionPath,

		[string] $BuildConfiguration = "Release",

		[string] $VisualStudioVersion = "12.0",

		[string] $Verbosity = "minimal",

		[string] $Target = "Rebuild"
	)

	Exec {
		msbuild $SolutionPath /property:Configuration=$BuildConfiguration /property:VisualStudioVersion=$VisualStudioVersion /verbosity:$Verbosity /t:$Target
	}
}

<#
.SYNOPSIS
Create the NuGet package based on the given specification.

.DESCRIPTION
This function creates the NuGet package based on the given NuGet specification files.

.PARAMETER SpecificationPaths
The paths for the NuGet specification files.

.PARAMETER Output
The output directory for NuGet package.

.PARAMETER Version
The version of the package.

.EXAMPLE
Write-NugetPackage .\Foo\Foo.nuspec

.EXAMPLE
Write-NugetPackage .\Foo\Foo.nuspec -Output .\packages

.EXAMPLE
Write-NugetPackage .\Foo\Foo.nuspec . -Version 2.0
#>
function Write-NugetPackage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $SpecificationPaths,

		[string] $Output = ".",

		[string] $Version = "1.0"
	)

	Foreach ($spec in $SpecificationPaths) {
		Exec {
			./.nuget/NuGet.exe pack $spec -Version $Version -OutputDirectory $Output
		}
	}
}

<#
.SYNOPSIS
Invoke the tests.

.DESCRIPTION
This function invokes the tests for the given test assemblies.

.PARAMETER Tests
The test assemblies.

.PARAMETER Trait
The trait to filter the tests.

.EXAMPLE
Invoke-Tests .\Foo.Tests\bin\Release\Foo.Tests.dll

.EXAMPLE
Invoke-Tests .\Foo.Tests\bin\Release\Foo.Tests.dll -Trait Category=UnitTests
#>
function Invoke-Tests {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,

		[string] $Trait
	)

	$testFiles = @()
	Foreach ($test in $Tests) {
		$testFiles += $test
	}

	If ($Trait -ne $null -and $Trait -ne "") {
		$testFiles += "-trait"
		$testFiles += $Trait
	}

	Exec {
		.\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe $testFiles -noshadow -parallel all
	}
}
