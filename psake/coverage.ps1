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
Invoke-AnalyzeCoverage @(..\Foo.Tests\bin\Release\Foo.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(..\Foo.Tests\bin\Release\Foo.Tests.dll, ..\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(..\Foo.Tests\bin\Release\Foo.Tests.dll, ..\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml

.EXAMPLE
Invoke-AnalyzeCoverage @(..\Foo.Tests\bin\Release\Foo.Tests.dll, ..\Bar.Tests\bin\Release\Bar.Tests.dll) ./coverage.xml -Filter "+[*]*"
#>
function Invoke-AnalyzeCoverage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,
		
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $Output,

		[string] $Filter = "+[*]* -[*]*Exception* -[*.Tests]* -[*.IntegrationTests]*"
	)

	$testAssembies = $Tests -join " "
	Exec {
		  ..\packages\OpenCover.4.5.3723\OpenCover.Console.exe -register:user -target:..\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe "-targetargs:$testAssembies -noshadow -parallel all" "-filter:$Filter" -output:$Output
	}
}
