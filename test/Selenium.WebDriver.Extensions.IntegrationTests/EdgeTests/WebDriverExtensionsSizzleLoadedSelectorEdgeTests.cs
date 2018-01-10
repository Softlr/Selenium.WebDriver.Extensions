namespace Selenium.WebDriver.Extensions.IntegrationTests.EdgeTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.EDGE)]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleLoadedSelectorEdgeTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<EdgeFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorEdgeTests(FixtureBase fixture)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{ServerUrl}/SizzleLoaded"));
        }
    }
}