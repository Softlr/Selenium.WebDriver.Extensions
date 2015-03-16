namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsCoreChromeTests : WebDriverExtensionsCoreTests, IUseFixture<ChromeFixture>
    {
        public void SetFixture(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.CoreTestsUrl);
        }
    }
}
