namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsJQueryLoadedSelectorChromeTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsJQueryLoadedSelectorChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri($"{this.ServerUrl}/JQueryLoaded"));
        }
    }
}
