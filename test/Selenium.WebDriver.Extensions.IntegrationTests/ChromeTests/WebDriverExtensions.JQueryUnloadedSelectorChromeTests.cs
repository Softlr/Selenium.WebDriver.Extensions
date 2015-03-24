namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsJQueryUnloadedSelectorChromeTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryUnloadedTestsUrl);
        }
    }
}
