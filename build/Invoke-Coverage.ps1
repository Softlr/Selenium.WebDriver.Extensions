Function Invoke-Coverage {
    <#
    .SYNOPSIS
        Runs the code coverage calculations.

    .DESCRIPTION
        This function runs the code coverage calculations for the given assemblies.

    .PARAMETER Path
        The test assemblies that should be run.

    .PARAMETER Destination
        The path to write the test results file.
        
    .PARAMETER Filter
        The filter for including or excluding assemblies and types.

    .EXAMPLE
        Invoke-Tests -Path MyProject\bin\Release\MyProject.dll

        Runs the tests defined in MyProject.dll assembly.

    .EXAMPLE
        Invoke-Tests -Path MyProject\bin\Release\MyProject.dll -ExcludeCategories LongRunning

        Runs the tests defined in MyProject.dll assembly excluding tests from LongRunning category.
    #>
    [CmdletBinding()]
    [OutputType([void])]
    Param(
        [Parameter(Mandatory = $True, ValueFromPipeline = $True, ValueFromPipelineByPropertyName = $True)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Path,

        [string] $Destination,
        
        [string] $ReportDestination,
        
        [string] $Filter
    )

    Begin {
        $xunitRunner = Get-Location | Join-Path -ChildPath packages | Join-Path -ChildPath xunit.runner.console.* `
            | Join-Path -ChildPath tools | Join-Path -ChildPath xunit.console.exe | Resolve-Path
        If (-Not $xunitRunner) {
            Throw 'xunit runner is not installed'
        }
        $openCover = Get-Location | Join-Path -ChildPath packages | Join-Path -ChildPath OpenCover.* | `
            Join-Path -ChildPath tools | Join-Path -ChildPath OpenCover.Console.exe | Resolve-Path
        If (-Not $openCover) {
            Throw 'OpenCover is not installed'
        }
        $reportGenerator = Get-Location | Join-Path -ChildPath packages | Join-Path -ChildPath ReportGenerator.* `
            | Join-Path -ChildPath tools | Join-Path -ChildPath ReportGenerator.exe | Resolve-Path
        If (-Not $reportGenerator) {
            Throw 'Report generator is not installed'
        }
    }

    Process {
        $arguments = '-register:user', ('-target:"{0}"' -f $xunitRunner), `
            ('-targetargs:"{0} -noshadow -parallel all"' -f ($Path -Join ' '))
        If ($Destination) {
            $arguments += '-output:"{0}"' -f $Destination
        }
        If ($Filter) {
            $arguments += '-filter:"{0}"' -f $Filter
        }
        $process = Start-Process -FilePath $openCover -ArgumentList $arguments -NoNewWindow -Wait -PassThru
        If ($process.ExitCode) {
            Throw 'Code coverage calculation failed'
        }
        
        If ($Destination -And $ReportDestination) {
            $arguments = ('-reports:"{0}"' -f $Destination), ('-targetdir:"{0}"' -f $ReportDestination)
            $process = Start-Process -FilePath $reportGenerator -ArgumentList $arguments -NoNewWindow -Wait -PassThru
            If ($process.ExitCode) {
                Throw 'Report generation failed'
            }
        }
    }
}