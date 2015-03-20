<#
.SYNOPSIS

Invoke the tests.

.DESCRIPTION

This function invokes the tests for the given test assemblies.

.PARAMETER Tests

The test assemblies.

.PARAMETER XUnitPath

The xunit console runner path.

.EXAMPLE

Invoke-Tests ..\Foo.Tests\bin\Release\Foo.Tests.dll
#>
function Invoke-Tests {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string[]] $Tests,
		[string] $Trait = "",
		[string] $XUnitPath = "..\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe"
	)

	$testFiles = @()
	Foreach ($test in $Tests) {
		$testFiles += $test
	}

	If ($Trait -ne "") {
		$testFiles += "-trait"
		$testFiles += $Trait
	}

	Exec {
		& $XUnitPath $testFiles -noshadow -parallel all
	}
}
