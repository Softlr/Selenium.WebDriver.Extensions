<#
.SYNOPSIS

Create the NuGet package based on the given specification.

.DESCRIPTION

This function creates the NuGet package based on the given NuGet specification file.

.PARAMETER SpecPath

The path for the NuGet specification file.

.PARAMETER Version

The version of the package.

.EXAMPLE

Write-NugetPackage ..\Foo\Foo.nuspec
#>
function Write-NugetPackage {
	[CmdletBinding()]
	param(
		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $SpecPath,
		[string] $Version = "1.0"
	)

	Exec {
		../.nuget/NuGet.exe pack $SpecPath -Version $Version
	}
}
