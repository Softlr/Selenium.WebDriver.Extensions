<#
.SYNOPSIS
Creates the code coverage analysis.

.DESCRIPTION
This function creates the code coverage analysis tool for the given test assemblies.

.PARAMETER Tests
The test assemblies.

.PARAMETER Output
The output path for the coverage file.

.PARAMETER Filter
The filter for the test assemblies.

.EXAMPLE
New-CoverageAnalysis -Tests Foo.Tests.dll -Output ./coverage.xml

This example shows how to create new test coverage XML report for the given test assembly. 

The Tests parameter name (-Tests) and the Output parameter name (-Output) are optional and can be omitted.

.EXAMPLE
New-CoverageAnalysis -Tests ./Foo.Tests.dll , ./Bar.Tests.dll -Output ./coverage.xml

This example shows how to create new test coverage XML report for the multiple test assemblies. The test assemblies are 
passed as a string array and are separated by comma (,).

The Tests parameter name (-Tests) and the Output parameter name (-Output) are optional and can be omitted.

.EXAMPLE
New-CoverageAnalysis -Tests ./Foo.Tests.dll -Output ./coverage.xml -Filter '+[*]*'

This example shows how to create new test coverage XML report with the filtering applied on the test assemblies and 
members.

Filters can be inclusive and exclusive represented by + and – prefix respectively, where exclusive (-) filters take 
precedence over inclusive (+) filters.

The next part of a filter is the module-filter and usually this happens to be the same name as the assembly but without 
the extension and this rule will normally apply 99.999% of the time. If this filter isn’t working look in the coverage 
XML and compare the found <ModuleName/> entries against the filter. The final part of the filter is the class-filter 
and this also includes the namespace part of the class as well.

Filter Examples:

+[Open*]* -[Open.Test]*
Include all classes in modules starting with Open.* but exclude all those in modules Open.Test.

+[Open]* -[Open]Data.*
Include all classes in module Open but exclude all classes in the Data namespace.

+[Open]* -[Open]*Attribute
Include all classes in module Open but exclude all classes ending with Attribute.

The Tests parameter name (-Tests) and the Output parameter name (-Output) are optional and can be omitted.
#>
function New-CoverageAnalysis {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Tests,
        
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $Output,

        [string] $Filter = '+[*]*'
    )

    $testAssemblies = $Tests -Join ' '
    $openCoverPath = Resolve-Path .\packages\OpenCover.*\tools\OpenCover.Console.exe
    $xunitPath = Resolve-Path .\packages\xunit.runner.console.*\tools\xunit.console.exe
    Exec {
          & $openCoverPath -register:user -target:$xunitPath `
          "-targetargs:$testAssemblies -noshadow -parallel all" "-filter:$Filter" -output:$Output
    }
}