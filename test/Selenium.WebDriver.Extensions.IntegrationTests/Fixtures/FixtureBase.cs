namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using OpenQA.Selenium;
    using PostSharp.Patterns.Model;

    [Disposable]
    public class FixtureBase
    {
        protected FixtureBase()
        {
        }

        [Child]
        public IWebDriver Browser { get; protected set; }

        protected virtual void Dispose(bool disposing)
        {
            Browser?.Close();
            Browser?.Quit();
            Browser?.Dispose();
        }
    }
}