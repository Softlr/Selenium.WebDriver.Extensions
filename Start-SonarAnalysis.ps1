Param(
    [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [string] $SonarProjectName,

    [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [string] $SonarProjectKey,

    [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [string] $Version,

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $SolutionPath = "",

    [Parameter(ValueFromPipelineByPropertyName)]
    [switch] $DisableTests,

    [Parameter(ValueFromPipelineByPropertyName)]
    [switch] $GenerateHtmlReport,

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $DotNetPath = "C:\Program Files\dotnet\dotnet.exe",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $MSBuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $OpenCoverPath = "C:\Program Files (x86)\OpenCover\OpenCover.Console.exe",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $ReportGeneratorPath = "C:\Program Files (x86)\ReportGenerator\ReportGenerator.exe",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $SonarScannerPath = "D:\sonar-scanner-msbuild-2.3.1.554\SonarQube.Scanner.MSBuild.exe",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $CoverageFilePath = ".coverage.*.xml",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $CoverageReportPath = ".coverage",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $SonarUrl = "http://localhost:9999",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $AuthToken = "129f1453b5b8cdc41d16b81398fcc2a5e202ca23",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $Platform = "Any CPU",

    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $Configuration = "Debug",
    
    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $Framework = "net46",
    
    [Parameter(ValueFromPipelineByPropertyName)]
    [string] $Exclusions = "**\lib\**\*.*"
)

& $DotNetPath restore
If (-Not $DisableTests) {
    ls test\**\*.Tests.csproj | % {
        $name = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
        $path = $_.FullName
        $folder = $_.FullName | Split-Path -Parent
        $binPath = "$folder\bin\$Configuration\$Framework\$name.dll" | Resolve-Path -ErrorAction SilentlyContinue | Split-Path -Parent
        $targetArgs = "test -c $Configuration $path"
        $filter = "+[*]* -[*Test*]*"
        & $OpenCoverPath -register:user -target:$DotNetPath -output:".coverage.$name.xml" -targetargs:$targetArgs -filter:$filter -searchdirs:$binPath -excludebyattribute:*.ExcludeFromCoverageAttribute -hideskipped:Attribute
    }

    If ($GenerateHtmlReport) {
        & $ReportGeneratorPath -targetdir:$CoverageReportPath -reporttypes:"Html;Badges" -reports:$CoverageFilePath -verbosity:Error
    }

    & $SonarScannerPath begin /k:$SonarProjectKey /n:$SonarProjectName /v:$Version /d:sonar.cs.opencover.reportsPaths=$CoverageFilePath /d:sonar.host.url=$SonarUrl /d:sonar.login=$AuthToken /d:sonar.exclusions=$Exclusions
} Else {
    & $SonarScannerPath begin /k:$SonarProjectKey /n:$SonarProjectName /v:$Version /d:sonar.host.url=$SonarUrl /d:sonar.login=$AuthToken /d:sonar.exclusions=$Exclusions
}

& $MSBuildPath $SolutionPath /t:Rebuild /p:Configuration=$Configuration /p:Platform=$Platform
& $SonarScannerPath end /d:sonar.login=$AuthToken