namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium.PhantomJS;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class PhantomJsFixture : FixtureBase<PhantomJSDriverService>
    {
        public PhantomJsFixture()
        {
            Service = PhantomJSDriverService.CreateDefaultService();
            Service.SslProtocol = "any";
            Browser = new PhantomJSDriver(Service);
        }
    }
}