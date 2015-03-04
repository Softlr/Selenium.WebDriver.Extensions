namespace Selenium.WebDriver.Extensions.Core
{
    using OpenQA.Selenium;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Returns the query selector helper, that can be used to access query selector specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The Sizzle helper.</returns>
        public static QuerySelectorHelper QuerySelector(this IWebDriver driver)
        {
            return new QuerySelectorHelper(driver);
        }
    }
}
