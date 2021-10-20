namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Opera;

    [ExcludeFromCodeCoverage]
    public class OperaFixture : FixtureBase
    {
        public OperaFixture()
        {
            var options = new OperaOptions();
            Browser = new OperaDriver(options);
        }
    }
}
