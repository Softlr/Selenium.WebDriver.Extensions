namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.PhantomJS;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
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