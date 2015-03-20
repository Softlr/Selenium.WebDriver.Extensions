<#
.SYNOPSIS

Invoke the code coverage report generation.

.DESCRIPTION

This function invokes the code coverage report generation that generate a HTML coverage report.

.PARAMETER CoverageXmlPath

The code coverage XML file path.

.PARAMETER ReportGeneratorPath

The report generator path.

.PARAMETER Output

The output path for the coverage report.

.EXAMPLE

Invoke-CoverageReportGenerator ..\coverage.xml
#>
function Invoke-CoverageReportGenerator {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $CoverageXmlPath,
		[string] $ReportGeneratorPath = "..\packages\ReportGenerator.2.1.3.0\ReportGenerator.exe",
		[string] $Output = ".\CoverageReport"
	)

	Exec {
		  & $ReportGeneratorPath -reports:$CoverageXmlPath -targetdir:$Output -reporttypes:Html
	}
}
