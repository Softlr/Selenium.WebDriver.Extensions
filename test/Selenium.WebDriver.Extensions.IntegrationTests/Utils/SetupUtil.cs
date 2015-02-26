namespace Selenium.WebDriver.Extensions.IntegrationTests.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.PhantomJS;

    /// <summary>
    /// The setup utilities.
    /// </summary>
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    internal static class SetupUtil
    {
        /// <summary>
        /// Configures the driver that is going to run the tests.
        /// </summary>
        /// <param name="browser">The web browser.</param>
        /// <param name="testCaseUrl">The URL of the test case.</param>
        /// <returns>The configured web driver.</returns>
        public static IWebDriver ConfigureDriver(WebBrowser browser, string testCaseUrl)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case WebBrowser.PhantomJs:
                    var phantomJsService = PhantomJSDriverService.CreateDefaultService();
                    phantomJsService.SslProtocol = "any";
                    driver = new PhantomJSDriver(phantomJsService);
                    break;
                case WebBrowser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case WebBrowser.InternetExplorer:
                    driver = new InternetExplorerDriver();
                    break;
                case WebBrowser.Firefox:
                    driver = new FirefoxDriver();
                    break;
            }

            if (driver == null)
            {
                return null;
            }

            driver.Navigate().GoToUrl(testCaseUrl);
            return driver;
        }
    }
}
