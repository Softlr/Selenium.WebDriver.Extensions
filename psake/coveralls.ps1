<#
.SYNOPSIS

Sends the coverage data to coveralls.

.DESCRIPTION

This function sends the coverage data to coveralls.io.

.PARAMETER CoverageXmlPath

The code coverage XML file path.

.EXAMPLE

Send-Coveralls ..\coverage.xml
#>
function Send-Coveralls {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $CoverageXmlPath
	)

	Exec {
		  ..\packages\coveralls.io.1.2.2\tools\coveralls.net.exe --opencover $CoverageXmlPath
	}
}
