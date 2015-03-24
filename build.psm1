<#
.SYNOPSIS
Creates the code coverage analysis.

.DESCRIPTION
This function creates the code coverage analysis tool for the given test assemblies.

.PARAMETER Tests
The test assemblies.

.PARAMETER Output
The output path for the coverage file.

.PARAMETER Filter
The filter for the test assemblies.

.EXAMPLE
New-CoverageAnalysis @(.\Foo.Tests\bin\Release\Foo.Tests.dll) ./coverage.xml

.EXAMPLE
New-CoverageAnalysis @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
New-CoverageAnalysis @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
New-CoverageAnalysis @(.\Foo.Tests\bin\Release\Foo.Tests.dll, .\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml -Filter "+[*]*"
#>
function New-CoverageAnalysis {
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

	$testAssemblies = $Tests -Join " "
	Exec {
		  .\packages\OpenCover.4.5.3723\OpenCover.Console.exe -register:user -target:.\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe "-targetargs:$testAssemblies -noshadow -parallel all" "-filter:$Filter" -output:$Output
	}
}

<#
.SYNOPSIS
Creates the code coverage report.

.DESCRIPTION
This function creates the code coverage report.

.PARAMETER CoverageXmlPath
The code coverage XML file path.

.PARAMETER Output
The output path for the coverage report.

.PARAMETER Verbosity
The verebosity level.

.EXAMPLE
New-CoverageReport .\coverage.xml .\CoverageReport

.EXAMPLE
New-CoverageReport .\coverage.xml .\CoverageReport -Verbosity Verbose
#>
function New-CoverageReport {
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
		  .\packages\ReportGenerator.2.1.4.0\ReportGenerator.exe -reports:$CoverageXmlPath -targetdir:$Output -verbosity:$Verbosity
	}
}


<#
.SYNOPSIS
Pushishes the coverage data to coveralls.io.

.DESCRIPTION
This function publishes the coverage data to coveralls.io.

.PARAMETER CoverageXmlPath
The code coverage XML file path.

.EXAMPLE
Publish-Coveralls .\coverage.xml
#>
function Publish-Coveralls {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $CoverageXmlPath
	)

	Exec {
		  .\packages\coveralls.io.1.3.2\tools\coveralls.net.exe --opencover $CoverageXmlPath
	}
}

<#
.SYNOPSIS
Creates the build.

.DESCRIPTION
This function creates the build for the given solution.

.PARAMETER SolutionPath
The path for the solution file.

.PARAMETER BuildConfiguration
The build configuration name to use.

.PARAMETER ToolsVersion
The tools version.

.PARAMETER Verbosity
The verebosity level.

.PARAMETER Target
The target for the MS build.

.EXAMPLE
New-Build .\Foo.sln

.EXAMPLE
New-Build .\Foo.sln "Debug"

.EXAMPLE
New-Build .\Foo.sln -Verbosity normal

.EXAMPLE
New-Build .\Foo.sln -Target Clean

.EXAMPLE
New-Build .\Foo.sln -ToolsVersion 12.0
#>
function New-Build {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $SolutionPath,

		[string] $BuildConfiguration = "Release",
		
		[string] $ToolsVersion = "4.0",

		[string] $Verbosity = "minimal",

		[string] $Target = "Rebuild"
	)

	Exec {
		msbuild $SolutionPath /property:Configuration=$BuildConfiguration /verbosity:$Verbosity /t:$Target /tv:$ToolsVersion
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
New-NugetPackage .\Foo\Foo.nuspec . -Version 2.0
#>
function New-NugetPackage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $SpecificationPaths,

		[string] $Output = ".",

		[string] $Version = "1.0"
	)

	Exec {
		$SpecificationPaths | ForEach-Object -Process { ./.nuget/NuGet.exe pack $_ -Version $Version -OutputDirectory $Output }
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
Test-Assembly .\Foo.Tests\bin\Release\Foo.Tests.dll

.EXAMPLE
Test-Assembly .\Foo.Tests\bin\Release\Foo.Tests.dll -Trait Category=UnitTests
#>
function Test-Assembly {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,

		[string] $Trait
	)

	$testAssemblies = @()
	$Tests | ForEach-Object -Process { $testAssemblies += $_ }

	If ($Trait -ne $null -and $Trait -ne "") {
		$testAssemblies += "-trait"
		$testAssemblies += $Trait
	}

	Exec {
		.\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe $testAssemblies -noshadow -parallel all
	}
}
