namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
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
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            return new JQueryHelper(driver);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        public static ChainJQueryHelper JQuery(this IWebDriver driver, string selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            return driver.JQuery(By.JQuerySelector(selector));
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        public static ChainJQueryHelper JQuery(this IWebDriver driver, JQuerySelector selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            return new ChainJQueryHelper(driver, selector);
        }
    }
}
