namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using System;
    using OpenQA.Selenium;

    public class FixtureBase : IDisposable
    {
        protected FixtureBase()
        {
        }

        ~FixtureBase() => Dispose(false);

        public IWebDriver Browser { get; protected set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            Browser?.Quit();
            Browser?.Dispose();
        }
    }
}