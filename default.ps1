properties {
  $solution = 'Selenium.WebDriver.Extensions.sln'
  $version = '1.4.0'
  $buildConfig = 'Release'
  $visualStudioVersion = '12.0'
  $nuget = '.\.nuget\NuGet.exe'
  $xunit = '.\packages\xunit.runner.console.2.0.0-rc4-build2924\tools\xunit.console.exe'
  $opencover = '.\packages\OpenCover.4.5.3723\OpenCover.Console.exe'
  $reportGenerator = '.\packages\ReportGenerator.2.1.3.0\ReportGenerator.exe'
  $coveralls = '.\packages\coveralls.io.1.2.2\tools\coveralls.net.exe'
  $jQueryUnitTests = '.\test\Selenium.WebDriver.Extensions.JQuery.Tests\bin\Release\Selenium.WebDriver.Extensions.JQuery.Tests.dll'
  $sizzleUnitTests = '.\test\Selenium.WebDriver.Extensions.Sizzle.Tests\bin\Release\Selenium.WebDriver.Extensions.Sizzle.Tests.dll'
  $coreUnitTests = '.\test\Selenium.WebDriver.Extensions.Core.Tests\bin\Release\Selenium.WebDriver.Extensions.Core.Tests.dll'
  $combinedUnitTests = '.\test\Selenium.WebDriver.Extensions.Tests\bin\Release\Selenium.WebDriver.Extensions.Tests.dll'
  $integrationTests = '.\test\Selenium.WebDriver.Extensions.IntegrationTests\bin\$buildConfig\Selenium.WebDriver.Extensions.IntegrationTests.dll'
  $coverageXml = '.\coverage.xml'
  $coverageReportDir = '.\CoverageReport'
}

task default -depends Compile, Test, Coverage, Docs, Pack

task CleanNet45 {
  msbuild /property:Configuration=$buildConfig /property:VisualStudioVersion=$visualStudioVersion /t:Clean
}

task CleanNet40 {
  msbuild /property:Configuration=$buildConfig-Net40 /property:VisualStudioVersion=$visualStudioVersion /t:Clean
}

task CleanNet35 {
  msbuild /property:Configuration=$buildConfig-Net35 /property:VisualStudioVersion=$visualStudioVersion /t:Clean
}

task CleanDocs {
  msbuild /property:Configuration=Docs /property:VisualStudioVersion=$visualStudioVersion /t:Clean
}

task Clean -depends CleanNet45, CleanNet40, CleanNet35, CleanDocs

task CompileNet45 -depends CleanNet45 {
  msbuild $solution /property:Configuration=$buildConfig /property:VisualStudioVersion=$visualStudioVersion
}

task CompileNet40 -depends CleanNet40 {
  msbuild $solution /property:Configuration=$buildConfig-Net40 /property:VisualStudioVersion=$visualStudioVersion
}

task CompileNet35 -depends CleanNet35 {
  msbuild $solution /property:Configuration=$buildConfig-Net35 /property:VisualStudioVersion=$visualStudioVersion
}

task Compile -depends CompileNet45, CompileNet40, CompileNet35

task CompileDocs -depends CleanDocs {
  msbuild $solution /property:Configuration=Docs /property:VisualStudioVersion=$visualStudioVersion
}

task Docs -depends CompileDocs

task Test -depends CompileNet45 {
  & $xunit $jQueryUnitTests $sizzleUnitTests $coreUnitTests $combinedUnitTests -noshadow -parallel all
}

task IntegrationPhantomJs -depends CompileNet45 {
  & $xunit $integrationTests -noshadow -trait Browser=PhantomJS
}

task IntegrationChrome -depends CompileNet45 {
  & $xunit $integrationTests -noshadow -trait Browser=Chrome
}

task IntegrationFirefox -depends CompileNet45 {
  & $xunit $integrationTests -noshadow -trait Browser=Firefox
}

task IntegrationInternetExplorer -depends CompileNet45 {
  & $xunit $integrationTests -noshadow -trait Browser=InternetExplorer
}

task Integration -depends IntegrationPhantomJs, IntegrationChrome, IntegrationFirefox, IntegrationInternetExplorer

task AnalyzeCoverage -depends CompileNet45 {
  & $opencover -register:user -target:$xunit "-targetargs:$jQueryUnitTests $sizzleUnitTests $coreUnitTests $combinedUnitTests -noshadow -parallel all" "-filter:+[*]* -[*]*Exception* -[*.Tests]* -[*.IntegrationTests]*" -output:$coverageXml
}

task Coverage -depends AnalyzeCoverage {
  & $reportGenerator -reports:$coverageXml -targetdir:$coverageReportDir -reporttypes:Html
}

task Coveralls -depends AnalyzeCoverage {
  & $coveralls --opencover $coverageXml
}

task PackJQuery -depends Compile {
  & $nuget pack .\src\Selenium.WebDriver.Extensions.JQuery\Selenium.WebDriver.Extensions.JQuery.nuspec -Version $version
}

task PackSizzle -depends Compile {
  & $nuget pack .\src\Selenium.WebDriver.Extensions.Sizzle\Selenium.WebDriver.Extensions.Sizzle.nuspec -Version $version
}

task PackCore -depends Compile {
  & $nuget pack .\src\Selenium.WebDriver.Extensions.Core\Selenium.WebDriver.Extensions.Core.nuspec -Version $version
}

task PackCombined -depends Compile {
  & $nuget pack .\src\Selenium.WebDriver.Extensions\Selenium.WebDriver.Extensions.nuspec -Version $version
}

task Pack -depends PackJQuery, PackSizzle, PackCore, PackCombined