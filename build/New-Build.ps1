<#
.SYNOPSIS
Creates the build.

.DESCRIPTION
This function creates the build for the given solution.

.PARAMETER Solution
The path for the solution file.

.PARAMETER BuildConfiguration
The build configuration name to use.

.PARAMETER ToolsVersion
The tools version.

.PARAMETER Verbosity
The verbosity level.

.PARAMETER Target
The target for the MS build.

.EXAMPLE
New-Build -Solution .\Foo.sln

This example shows how to build the given solution. 

The Solution parameter name (-Solution) is optional and can be omitted.

.EXAMPLE
New-Build -Solution .\Foo.sln -BuildConfiguration Debug

This example shows how to build the given solution in the given build configuration.

Build configuration can be any of the build configuration configured in the solution.

The Solution parameter name (-Solution) is optional and can be omitted.

.EXAMPLE
New-Build -Solution .\Foo.sln -Verbosity normal

This example shows how to build the given solution with the given verbosity level.

The allowed values for the Verbosity parameter are q[uiet], m[inimal], n[ormal], d[etailed] and diag[nostic].

The Solution parameter name (-Solution) is optional and can be omitted.

.EXAMPLE
New-Build -Solution .\Foo.sln -Target Clean

This example shows how to build the given targets in the given solution.

The Solution parameter name (-Solution) is optional and can be omitted.

.EXAMPLE
New-Build -Solution .\Foo.sln -TargetFramework v4.6

This example shows how to build the given solution using the given target framework.

The Solution parameter name (-Solution) is optional and can be omitted.
#>
function New-Build {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $Solution,

        [string] $BuildConfiguration = 'Release',

        [ValidateSet('q', 'quiet', 'm', 'minimal', 'n', 'normal', 'd', 'detailed', 'diag', 'diagnostic')]
        [string] $Verbosity = 'minimal',

        [string] $Target = 'Rebuild',
		
		[string] $TargetFramework = 'v4.6'
    )

    Exec {
        & ${Env:ProgramFiles(x86)}\MSBuild\14.0\Bin\amd64\MSBuild.exe $Solution /p:Configuration=$BuildConfiguration /v:$Verbosity /t:$Target /p:TargetFrameworkVersion=$TargetFramework
    }
}