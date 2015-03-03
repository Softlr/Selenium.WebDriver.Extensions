namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Shared;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Checks if query selector is supported by the browser.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        public static void CheckQuerySelectorSupport(this IWebDriver driver)
        {
            if (!driver.CheckSelectorPrerequisites(new QuerySelectorLoader()))
            {
                throw new QuerySelectorNotSupportedException();
            }
        }
    }
}
