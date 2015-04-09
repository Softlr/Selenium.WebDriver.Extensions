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

        [string] $Filter = '+[Selenium.WebDriver.Extensions*]* -[*]*Exception* -[*Tests]* -[xunit*]*'
    )

    $testAssemblies = $Tests -Join ' '
    Exec {
          .\packages\OpenCover.4.5.3723\OpenCover.Console.exe -register:user `
          -target:.\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe `
          "-targetargs:$testAssemblies -noshadow -parallel all" '-filter:$Filter' -output:$Output
    }
}

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

    Exec {
          .\packages\ReportGenerator.2.1.4.0\ReportGenerator.exe -reports:$CoverageXml -targetdir:$Output `
          -verbosity:$Verbosity
    }
}


<#
.SYNOPSIS
Publishes the coverage data to coveralls.io.

.DESCRIPTION
This function publishes the coverage data to coveralls.io.

.PARAMETER CoverageXml
The code coverage XML file path.

.EXAMPLE
Publish-Coveralls -CoverageXml .\coverage.xml

This example shows how to publish test coverage XML file to coveralls.io. 

For the upload to be successful the $env:COVERALLS_REPO_TOKEN has to be defined with the proper token found on the
coveralls.io service.

The CoverageXml parameter name (-CoverageXml) is optional and can be omitted.
#>
function Publish-Coveralls {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $CoverageXml
    )

    Exec {
          .\packages\coveralls.io.1.3.4\tools\coveralls.net.exe --opencover $CoverageXml -f
    }
}

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
New-Build -Solution .\Foo.sln -ToolsVersion 12.0

This example shows how to build the given solution using the given tools version.

The Solution parameter name (-Solution) is optional and can be omitted.
#>
function New-Build {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string] $Solution,

        [string] $BuildConfiguration = 'Release',
        
        [string] $ToolsVersion = '4.0',

        [ValidateSet('q', 'quiet', 'm', 'minimal', 'n', 'normal', 'd', 'detailed', 'diag', 'diagnostic')]
        [string] $Verbosity = 'minimal',

        [string] $Target = 'Rebuild'
    )

    Exec {
        msbuild $Solution /property:Configuration=$BuildConfiguration /verbosity:$Verbosity /t:$Target /tv:$ToolsVersion
    }
}

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

<#
.SYNOPSIS
Invoke the tests.

.DESCRIPTION
This function invokes the tests for the given test assemblies.

.PARAMETER Tests
The test assemblies.

.PARAMETER Trait
The trait to filter the tests.

.EXAMPLE
Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll

This example shows how to run unit tests for the given test assembly.

The Tests parameter name (-Tests) is optional and can be omitted.

.EXAMPLE
Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll , .\Bar.Tests\bin\Release\Bar.Tests.dll

This example shows how to run unit tests for multiple test assemblies. The test assemblies are passed as a string 
array and are separated by comma (,).

The Tests parameter name (-Tests) is optional and can be omitted.

.EXAMPLE
Test-Assembly -Tests .\Foo.Tests\bin\Release\Foo.Tests.dll -Trait Category=UnitTests

This example shows how to run unit tests filtered by the given trait value. The trait is a key and value pair separated 
by equality sign (=).

The Tests parameter name (-Tests) is optional and can be omitted.
#>
function Test-Assembly {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidateNotNullOrEmpty()]
        [string[]] $Tests,

        [string] $Trait
    )

    $testAssemblies = @()
    $Tests | ForEach-Object -Process { $testAssemblies += $_ }

    If ($Trait -ne $null -and $Trait -ne '') {
        $testAssemblies += '-trait'
        $testAssemblies += $Trait
    }

    Exec {
        .\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe $testAssemblies -noshadow -parallel all
    }
}
