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

Invoke-CoverageReportGenerator ..\coverage.xml
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
		  ..\packages\ReportGenerator.2.1.3.0\ReportGenerator.exe -reports:$CoverageXmlPath -targetdir:$Output -verbosity:$Verbosity
	}
}
