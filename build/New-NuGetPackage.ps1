Function New-NugetPackage {
	<#
	.SYNOPSIS
		Create the NuGet package based on the given specification.

	.DESCRIPTION
		This function creates the NuGet package based on the given NuGet specification files.

	.PARAMETER Path
		The paths for the NuGet specification files.

	.PARAMETER Destination
		The destination for NuGet package.

	.PARAMETER Version
		The version of the package.

	.EXAMPLE
		New-NugetPackage -Path .\Foo.nuspec

		This example shows how to create the new NuGet package for the given NuGet specification.

	.EXAMPLE
		New-NugetPackage -Path .\Foo.nuspec, .\Bar.nuspec

		This example shows how to create the new NuGet packages for the multiple NuGet specifications. The specifications are 
		passed as a string array and are separated by comma (,).

	.EXAMPLE
		New-NugetPackage -Path .\Foo.nuspec -Destination .\packages

		This example shows how to create the new NuGet package for the given NuGet specification and saving them in the given 
		location.

	.EXAMPLE
		New-NugetPackage -Path .\Foo.nuspec -Version 2.0

		This example shows how to create the new NuGet package for the given NuGet specification and replacing the version 
		token in the specifications prior to the package creation.
	#>
	[Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSUseShouldProcessForStateChangingFunctions', '')]
    [CmdletBinding()]
	[OutputType([void])]
    Param(
        [Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Path,

        [string] $Destination = '.',

        [string] $Version = '1.0'
    )
	
	Begin {
        $nugetPath = Get-Location | Join-Path -ChildPath .nuget | Join-Path -ChildPath NuGet.exe
        If ($nugetPath | Test-Path) {
            $nuget = $nugetPath | Resolve-Path
        } Else {
            Throw 'NuGet.exe not found'
        }
    }

    Process {
		$Path | ForEach-Object -Process {
			$arguments = 'pack', $_,  '-OutputDirectory', $Destination, '-Version', $Version, '-Symbols'
			$process = Start-Process -FilePath $nuget -ArgumentList $arguments -NoNewWindow -Wait -PassThru
            If ($process.ExitCode) {
                Throw 'NuGet package generation failed'
            }
        }
    }
}