namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsJQueryUnloadedSetterChromeTests :
        WebDriverExtensionsJQuerySetterTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSetterChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.JQueryUnloadedTestsUrl));
        }
    }
}
