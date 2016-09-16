Function Invoke-Test {
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
		Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll

		This example shows how to run unit tests for the given test assembly.

	.EXAMPLE
		Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll , .\Bar.Tests\bin\Release\Bar.Tests.dll

		This example shows how to run unit tests for multiple test assemblies. The test assemblies are passed as a string array
		and are separated by comma (,).
	.EXAMPLE
		Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll -Trait Category=UnitTests

		This example shows how to run unit tests filtered by the given trait value. The trait is a key and value pair separated 
		by equality sign (=).
	#>
    [CmdletBinding()]
    [OutputType([void])]
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Path,

        [string] $Trait
    )
	
	Begin {
        $xunitRunner = Get-Location | Join-Path -ChildPath packages | Join-Path -ChildPath xunit.runner.console.* `
            | Join-Path -ChildPath tools | Join-Path -ChildPath xunit.console.exe | Resolve-Path
        If (-Not $xunitRunner) {
            Throw 'xunit runner is not installed'
        }
    }

	Process {
		$arguments = $Path
		$arguments += '-noshadow', '-parallel', 'all'
		If ($Trait) {
			$arguments += '-trait', $Trait
		}
		
		$process = Start-Process -FilePath $xunitRunner -ArgumentList $arguments -NoNewWindow -Wait -PassThru
        If ($process.ExitCode) {
            Throw 'Running tests failed'
        }
	}
}
