namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsJQueryLoadedSetterFirefoxTests :
        WebDriverExtensionsJQuerySetterTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsJQueryLoadedSetterFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.JQueryLoadedTestsUrl);
        }
    }
}
