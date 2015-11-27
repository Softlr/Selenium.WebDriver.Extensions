namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    [Collection("Integration")]
    public class WebDriverExtensionsJQueryLoadedSelectorFirefoxTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsJQueryLoadedSelectorFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(this.ServerUrl + "/JQueryLoaded"));
        }
    }
}
