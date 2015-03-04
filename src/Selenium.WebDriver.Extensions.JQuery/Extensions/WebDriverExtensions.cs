namespace Selenium.WebDriver.Extensions.JQuery
{
    using OpenQA.Selenium;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The jQuery helper.</returns>
        public static JQueryHelper JQuery(this IWebDriver driver)
        {
            return new JQueryHelper(driver);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        public static ChainJQueryHelper JQuery(this IWebDriver driver, JQuerySelector selector)
        {
            return new ChainJQueryHelper(driver, selector);
        }
    }
}
