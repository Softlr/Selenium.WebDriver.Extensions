namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "Chrome")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsJQueryUnloadedSetterChromeTests : WebDriverExtensionsJQuerySetterTests, 
        IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSetterChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryUnloadedTestsUrl);
        }
    }
}
