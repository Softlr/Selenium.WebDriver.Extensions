namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "Chrome")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsJQueryLoadedSetterChromeTests :
        WebDriverExtensionsJQuerySetterTests, IClassFixture<ChromeFixture>
    {
        public WebDriverExtensionsJQueryLoadedSetterChromeTests(ChromeFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri("http://localhost:50502/JQueryLoaded"));
        }
    }
}
