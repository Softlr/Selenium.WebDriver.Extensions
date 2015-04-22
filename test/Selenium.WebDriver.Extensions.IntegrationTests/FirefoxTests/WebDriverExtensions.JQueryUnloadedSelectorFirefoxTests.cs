namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Firefox")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsJQueryUnloadedSelectorFirefoxTests :
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<FirefoxFixture>
    {
        public WebDriverExtensionsJQueryUnloadedSelectorFirefoxTests(FirefoxFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Resources.HostUrl + "/JQueryUnloaded"));
        }
    }
}
