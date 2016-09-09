<#
.SYNOPSIS
Creates the code coverage report.

.DESCRIPTION
This function creates the code coverage report.

.PARAMETER CoverageXml
The code coverage XML file path.

.PARAMETER Output
The output path for the coverage report.

.PARAMETER Verbosity
The verbosity level.

.EXAMPLE
New-CoverageReport -CoverageXml .\coverage.xml -Output .\CoverageReport

This example shows how to create new test coverage HTML report for the given test coverage XML file. 

The CoverageXml parameter name (-CoverageXml) and the Output parameter name (-Output) are optional and can be omitted.

.EXAMPLE
New-CoverageReport -CoverageXml .\coverage.xml -Output .\CoverageReport -Verbosity Verbose

This example shows how to create new test coverage HTML report for the given test coverage XML file and with the given
verbosity level.

The allowed values for the Verbosity parameter are Verbose, Info and Error.

The CoverageXml parameter name (-CoverageXml) and the Output parameter name (-Output) are optional and can be omitted.
#>
function New-CoverageReport {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $CoverageXml,
        
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $Output,

        [ValidateSet('Verbose', 'Info', 'Error')]
        [string] $Verbosity = 'Error'
    )

    $reportGeneratorPath = Resolve-Path .\packages\ReportGenerator.*\tools\ReportGenerator.exe
    Exec {
          & $reportGeneratorPath -reports:$CoverageXml -targetdir:$Output `
          -verbosity:$Verbosity
    }
}