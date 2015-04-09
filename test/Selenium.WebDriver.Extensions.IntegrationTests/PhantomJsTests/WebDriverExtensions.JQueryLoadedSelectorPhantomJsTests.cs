namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "PhantomJs")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    public class WebDriverExtensionsJQueryLoadedSelectorPhantomJsTests : 
        WebDriverExtensionsJQuerySelectorTests, IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsJQueryLoadedSelectorPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(Properties.Resources.JQueryLoadedTestsUrl));
        }
    }
}
