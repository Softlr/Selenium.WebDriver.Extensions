namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    public static class Fixture
    {
        [SuppressMessage(SONARQUBE, S2339)]
        public const string SERVER_URL = "http://localhost:50000";
    }
}
