namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    using OpenQA.Selenium;

    public class FixtureBase<TDriverService> : FixtureBase
        where TDriverService : DriverService
    {
        protected FixtureBase()
        {
        }

        protected TDriverService Service { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            Service?.Dispose();
            base.Dispose(true);
        }
    }
}