namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium.Firefox;

    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class FirefoxFixture : FixtureBase
    {
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public FirefoxFixture()
        {
            var options = new FirefoxOptions();
            options.AddArguments("--headless");
            Browser = new FirefoxDriver(options);
        }
    }
}