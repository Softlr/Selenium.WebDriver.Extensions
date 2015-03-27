namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsQuerySelectorFirefoxTests : 
        WebDriverExtensionsQuerySelectorTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsQuerySelectorFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.QuerySelectorTestsUrl));
        }
    }
}
