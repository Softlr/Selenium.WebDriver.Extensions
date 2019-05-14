namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using JetBrains.Annotations;
    using OpenQA.Selenium.Firefox;
    using System.Diagnostics.CodeAnalysis;

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
