<#
.SYNOPSIS

Invoke the tests.

.DESCRIPTION

This function invokes the tests for the given test assemblies.

.PARAMETER Test1

The first test assembly.

.PARAMETER Test2

The second test assembly.

.PARAMETER Test3

The third test assembly.

.PARAMETER Test4

The fourth test assembly.

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
		[string] $Test1,
		[string] $Test2 = "",
		[string] $Test3 = "",
		[string] $Test4 = "",
		[string] $XUnitPath = "..\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe"
	)

	Exec {
		& $XUnitPath $Test1 $Test2 $Test3 $Test4 -noshadow -parallel all
	}
}
