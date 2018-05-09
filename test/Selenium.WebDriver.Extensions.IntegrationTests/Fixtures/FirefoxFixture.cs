namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Firefox;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase<FirefoxDriverService>
    {
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public FirefoxFixture()
        {
            Service = FirefoxDriverService.CreateDefaultService();
            Service.FirefoxBinaryPath = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles"), "Mozilla Firefox", "firefox.exe");
            Browser = new FirefoxDriver(Service);
        }
    }
}