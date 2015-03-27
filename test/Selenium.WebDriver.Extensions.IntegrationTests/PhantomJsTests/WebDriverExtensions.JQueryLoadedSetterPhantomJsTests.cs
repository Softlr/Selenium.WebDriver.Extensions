namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "PhantomJs")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsJQueryLoadedSetterPhantomJsTests :
        WebDriverExtensionsJQuerySetterTests, IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsJQueryLoadedSetterPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.JQueryLoadedTestsUrl));
        }
    }
}
