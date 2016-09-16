Function Invoke-Build {
	<#
	.SYNOPSIS
		Invokes a solution build.

	.DESCRIPTION
		This function invokes MSBuild process that builds the given solution.

	.PARAMETER Path
		The path for the solution file.

	.PARAMETER BuildConfiguration
		The build configuration name to use.

	.PARAMETER ToolsVersion
		The tools version.

	.PARAMETER Verbosity
		The verbosity level.

	.PARAMETER Target
		The target for the MS build.
	
	.PARAMETER TargetFramework
		The target framework for the MS build.
	
	.PARAMETER MSBuildToolsVersion
		The tools version for the MS build.

	.EXAMPLE
		New-Build -Path .\Foo.sln

		This example shows how to build the given solution.

	.EXAMPLE
		New-Build -Path .\Foo.sln -BuildConfiguration Debug -Verbosity normal -Target Clean -TargetFramework v4.5

		This example shows how to build the given solution in the given build configuration with specified verbosity level, target
		and target framework.

		Build configuration can be any of the build configuration configured in the solution.

		The allowed values for the Verbosity parameter are q[uiet], m[inimal], n[ormal], d[etailed] and diag[nostic].
	#>
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $True, ValueFromPipeline = $True, ValueFromPipelineByPropertyName = $True)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Path,

        [string] $BuildConfiguration = 'Release',

        [ValidateSet('q', 'quiet', 'm', 'minimal', 'n', 'normal', 'd', 'detailed', 'diag', 'diagnostic')]
        [string] $Verbosity = 'minimal',

        [string] $Target = 'Rebuild',
		
		[string] $TargetFramework = 'v4.6.2',
        
        [string] $MSBuildToolsVersion = '14.0'
    )
	
	Begin {
        $msBuildPaths = ,($Env:ProgramFiles | Join-Path -ChildPath MSBuild | Join-Path -ChildPath $MSBuildToolsVersion `
            | Join-Path -ChildPath Bin | Join-Path -ChildPath amd64 | Join-Path -ChildPath MSBuild.exe)
        If ($Env:ProgramFiles -ne ${Env:ProgramFiles(x86)}) {
            $msBuildPaths += ${Env:ProgramFiles(x86)} | Join-Path -ChildPath MSBuild | Join-Path -ChildPath $MSBuildToolsVersion `
                | Join-Path -ChildPath Bin | Join-Path -ChildPath amd64 | Join-Path -ChildPath MSBuild.exe
        }
		$msBuild = $msBuildPaths | Where-Object -FilterScript { $_ | Test-Path } | Resolve-Path | Sort-Object -Descending `
            | Select-Object -First 1
        If (-Not $msBuild) {
            Throw 'MSBuild is not installed'
        }
    }
	
	Process {
        $Path | ForEach-Object -Process {
            $arguments = $_, ('/p:Configuration={0}' -f $BuildConfiguration), ('/v:{0}' -f $Verbosity), ('/t:{0}' -f $Target), `
                ('/p:TargetFrameworkVersion={0}' -f $TargetFramework)
            $process = Start-Process -FilePath $msBuild -ArgumentList $arguments -NoNewWindow -Wait -PassThru
            If ($process.ExitCode) {
                Throw 'Build failed'
            }
        }
    }
}