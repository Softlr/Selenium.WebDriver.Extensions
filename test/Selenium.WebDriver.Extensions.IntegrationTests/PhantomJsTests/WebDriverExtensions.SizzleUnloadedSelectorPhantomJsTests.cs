namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using Xunit;

    [Trait("Category", "Integration Tests")]
    [Trait("Browser", "PhantomJs")]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class WebDriverExtensionsSizzleUnloadedSelectorPhantomJsTests : WebDriverExtensionsSizzleSelectorTests,
        IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(Properties.Resources.SizzleUnloadedTestsUrl);
        }
    }
}
