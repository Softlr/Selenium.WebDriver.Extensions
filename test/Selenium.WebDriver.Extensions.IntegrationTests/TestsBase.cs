namespace Selenium.WebDriver.Extensions.IntegrationTests
{
    [SuppressMessage(SONARQUBE, S2339)]
    [ExcludeFromCodeCoverage]
    public class TestsBase
    {
        public const string JQueryTestPath = "/jQueryLoaded";
        public const string SizzleTestPath = "/SizzleLoaded";
        public const string UnloadedPath = "/Unloaded";

        [SuppressMessage(SONARQUBE, S3900)]
        protected TestsBase(FixtureBase fixture, string path)
        {
            Browser = fixture.Browser;
            Browser.Navigate().GoToUrl(new Uri(fixture.ServerUrl, path));
        }

        protected IWebDriver Browser { get; }
    }
}
