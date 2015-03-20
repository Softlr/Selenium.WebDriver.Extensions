<#
.SYNOPSIS
Invoke the MS build process.

.DESCRIPTION
This function invokes the MS build process that builds given solution.

.PARAMETER SolutionPath
The path for the Visual Studio solution file.

.PARAMETER BuildConfiguration
The build configuration name to use.

.PARAMETER VisualStudioVersion
The visual studio version to use.

.PARAMETER Verbosity
The verebosity level.

.PARAMETER Target
The target for the MS build..

.EXAMPLE
Invoke-Build ..\Foo.sln

.EXAMPLE
Invoke-Build ..\Foo.sln "Debug"

.EXAMPLE
Invoke-Build ..\Foo.sln -Verbosity normal

.EXAMPLE
Invoke-Build ..\Foo.sln -Target Clean
#>
function Invoke-Build {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $SolutionPath,

		[string] $BuildConfiguration = "Release",

		[string] $VisualStudioVersion = "12.0",

		[string] $Verbosity = "minimal",

		[string] $Target = "Rebuild"
	)

	Exec {
		msbuild $SolutionPath /property:Configuration=$BuildConfiguration /property:VisualStudioVersion=$VisualStudioVersion /verbosity:$Verbosity /t:$Target
	}
}
