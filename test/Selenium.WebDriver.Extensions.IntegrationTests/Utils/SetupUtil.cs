namespace Selenium.WebDriver.Extensions.IntegrationTests.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
        /// <param name="driverName">The name of the driver.</param>
        /// <param name="testCaseUrl">The URL of the test case.</param>
        /// <returns>The configured web driver.</returns>
        public static IWebDriver ConfigureDriver(string driverName, string testCaseUrl)
        {
            IWebDriver driver = null;
            switch (driverName)
            {
                case "PhantomJS":
                    var phantomJsService = PhantomJSDriverService.CreateDefaultService();
                    phantomJsService.SslProtocol = "any";
                    driver = new PhantomJSDriver(phantomJsService);
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
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
