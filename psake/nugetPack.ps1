<#
.SYNOPSIS

Create the NuGet package based on the given specification.

.DESCRIPTION

This function creates the NuGet package based on the given NuGet specification file.

.PARAMETER SpecPath

The path for the NuGet specification file.

.PARAMETER SpecificationPath

The path for the NuGet specification file.

.PARAMETER Output

The output directory for NuGet package.

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
		[string] $SpecificationPath,

		[Parameter(Mandatory = $true)]
		[ValidateNotNullOrEmpty()]
		[string] $Output,

		[string] $Version = "1.0"
	)

	Exec {
		../.nuget/NuGet.exe pack $SpecificationPath -Version $Version -OutputDirectory $Output
	}
}
