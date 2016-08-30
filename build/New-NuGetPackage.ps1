<#
.SYNOPSIS
Create the NuGet package based on the given specification.

.DESCRIPTION
This function creates the NuGet package based on the given NuGet specification files.

.PARAMETER Specification
The paths for the NuGet specification files.

.PARAMETER Output
The output directory for NuGet package.

.PARAMETER Version
The version of the package.

.EXAMPLE
New-NugetPackage -Specification .\Foo.nuspec

This example shows how to create the new NuGet package for the given NuGet specification.

The Specification parameter name (-Specification) is optional and can be omitted.

.EXAMPLE
New-NugetPackage -Specification .\Foo.nuspec , .\Bar.nuspec

This example shows how to create the new NuGet packages for the multiple NuGet specifications. The specifications are 
passed as a string array and are separated by comma (,).

The Specification parameter name (-Specification) is optional and can be omitted.

.EXAMPLE
New-NugetPackage -Specification .\Foo.nuspec -Output .\packages

This example shows how to create the new NuGet package for the given NuGet specification and saving them in the given 
location.

The Specification parameter name (-Specification) is optional and can be omitted.

.EXAMPLE
New-NugetPackage -Specification .\Foo.nuspec -Version 2.0

This example shows how to create the new NuGet package for the given NuGet specification and replacing the version 
token in the specifications prior to the package creation.

The Specification parameter name (-Specification) is optional and can be omitted.
#>
function New-NugetPackage {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Specification,

        [string] $Output = '.',

        [string] $Version = '1.0'
    )

    Exec {
        $Specification `
        | ForEach-Object -Process { ./.nuget/NuGet.exe pack $_ -Version $Version -OutputDirectory $Output }
    }
}