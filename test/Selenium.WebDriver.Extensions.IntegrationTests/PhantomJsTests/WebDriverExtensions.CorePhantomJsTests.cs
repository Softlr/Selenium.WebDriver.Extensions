namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "PhantomJS")]
    [ExcludeFromCodeCoverage]
    public class WebDriverExtensionsCorePhantomJsTests : WebDriverExtensionsCoreTests, 
        IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsCorePhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.CoreTestsUrl));
        }
    }
}
