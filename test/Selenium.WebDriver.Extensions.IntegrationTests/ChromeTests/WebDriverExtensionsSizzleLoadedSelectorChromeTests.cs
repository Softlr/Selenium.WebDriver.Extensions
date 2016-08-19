namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleLoadedSelectorChromeTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsSizzleLoadedSelectorChromeTests(ChromeFixture fixture)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri($"{ServerUrl}/SizzleLoaded"));
        }
    }
}
