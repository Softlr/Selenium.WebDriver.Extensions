namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.IntegrationTests.Properties;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsCoreChromeTests : WebDriverExtensionsCoreTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsCoreChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Resources.HostUrl + "/Core"));
        }
    }
}
