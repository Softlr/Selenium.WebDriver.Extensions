namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Firefox;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class FirefoxFixture : FixtureBase<FirefoxDriverService>
    {
        public FirefoxFixture()
        {
            Service = FirefoxDriverService.CreateDefaultService();
            Service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            Browser = new FirefoxDriver(Service);
        }
    }
}