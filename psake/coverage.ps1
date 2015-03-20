<#
.SYNOPSIS

Invoke the code coverage analysis.

.DESCRIPTION

This function invokes the code coverage analysis tool for the given test assemblies.

.PARAMETER Tests

The test assemblies.

.PARAMETER XUnitPath

The xunit console runner path.

.PARAMETER OpenCoverPath

The Open Cover path.

.PARAMETER Output

The output path for the coverage file.

.EXAMPLE

Invoke-AnalyzeCoverage ..\Foo.Tests\bin\Release\Foo.Tests.dll
#>
function Invoke-AnalyzeCoverage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,
		[string] $XUnitPath = "..\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe",
		[string] $OpenCoverPath = "..\packages\OpenCover.4.5.3723\OpenCover.Console.exe",
		[string] $Output = ".\coverage.xml"
	)

	$testAssembies = $Tests -join " "
	Exec {
		  & $OpenCoverPath -register:user -target:$XUnitPath "-targetargs:$testAssembies -noshadow -parallel all" "-filter:+[*]* -[*]*Exception* -[*.Tests]* -[*.IntegrationTests]*" -output:$Output
	}
}
