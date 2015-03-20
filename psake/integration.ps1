<#
.SYNOPSIS

Invoke the integration tests.

.DESCRIPTION

This function invokes integration tests for the given test assembly.

.PARAMETER Tests

The path for the tests assembly.

.PARAMETER Trait

The traits to be used.

.PARAMETER XUnitPath

The xunit console runner path.

.EXAMPLE

Invoke-IntegrationTests ..\Foo.Tests\bin\Release\Foo.Tests.dll
#>
function Invoke-IntegrationTests {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $Tests,
		[string] $Trait,
		[string] $XUnitPath = "..\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe"
	)

	Exec {
		& $XUnitPath $Tests -noshadow -trait $Trait
	}
}
