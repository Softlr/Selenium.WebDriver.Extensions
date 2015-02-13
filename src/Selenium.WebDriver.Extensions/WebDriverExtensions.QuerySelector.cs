namespace Selenium.WebDriver.Extensions
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static partial class WebDriverExtensions
    {
        /// <summary>
        /// Checks if query selector is supported by the browser.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        public static void CheckQuerySelectorSupport(this IWebDriver driver)
        {
            QuerySelector.WebDriverExtensions.CheckQuerySelectorSupport(driver);
        }

        /// <summary>
        /// Searches for DOM elements using JavaScript query selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The DOM elements matching given JavaScript query selector.</returns>
        public static IWebElement FindElement(this IWebDriver driver, QuerySelector.Selectors.QuerySelector by)
        {
            return QuerySelector.WebDriverExtensions.FindElement(driver, by);
        }

        /// <summary>
        /// Searches for DOM element using JavaScript query selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium JavaScript query selector.</param>
        /// <returns>The first DOM element matching given JavaScript query selector</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(
            this IWebDriver driver,
            QuerySelector.Selectors.QuerySelector by)
        {
            return QuerySelector.WebDriverExtensions.FindElements(driver, by);
        }
    }
}
