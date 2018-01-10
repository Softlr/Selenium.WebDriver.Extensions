namespace Selenium.WebDriver.Extensions.IntegrationTests.InternetExplorerTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Fixtures;
    using Selenium.WebDriver.Extensions.IntegrationTests.Tests;
    using Selenium.WebDriver.Extensions.Tests;
    using Xunit;

    [Trait(Trait.Name.CATEGORY, Trait.Category.INTEGRATION)]
    [Trait(Trait.Name.BROWSER, Trait.Browser.INTERNET_EXPLORER)]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<InternetExplorerFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorInternetExplorerTests(FixtureBase fixture)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{ServerUrl}/JQueryUnloaded"));
        }
    }
}