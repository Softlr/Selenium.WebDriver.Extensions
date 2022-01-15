namespace Selenium.WebDriver.Extensions.IntegrationTests.Fixtures
{
    [ExcludeFromCodeCoverage]
    public class FixtureBase : IDisposable
    {
        private readonly IWebHost _host;
        private bool _disposed;

        protected FixtureBase()
        {
            _host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            _host.Start();
            ServerUrl = new Uri(_host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.First());
        }

        ~FixtureBase() => Dispose(false);

        public IWebDriver Browser { get; protected set; }

        public Uri ServerUrl { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            Browser?.Quit();
            Browser?.Dispose();
            _host.Dispose();
            _disposed = true;
        }
    }
}
