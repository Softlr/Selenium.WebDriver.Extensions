namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Xunit;

    [Trait("Category", "Integration")]
    [Trait("Browser", "PhantomJs")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
    [Collection("Integration")]
    public class WebDriverExtensionsSizzleUnloadedSelectorPhantomJsTests :
        WebDriverExtensionsSizzleSelectorTests, IClassFixture<PhantomJsFixture>
    {
        public WebDriverExtensionsSizzleUnloadedSelectorPhantomJsTests(PhantomJsFixture fixture)
        {
            this.Browser = fixture.Browser;
            this.Browser.Navigate().GoToUrl(new Uri(this.ServerUrl + "/SizzleLoaded"));
        }
    }
}
