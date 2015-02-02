namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
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
            if (!driver.CheckSelectorPrerequisites(QuerySelector.Empty))
            {
                throw new QuerySelectorNotSupportedException();
            }
        }

        /// <summary>
        /// Searches for DOM elements using JavaScript query selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The DOM elements matching given JavaScript query selector.</returns>
        public static IWebElement FindElement(this IWebDriver driver, QuerySelector by)
        {
            var results = driver.Find<IEnumerable<IWebElement>>(by);
            if (results == null)
            {
                throw new NoSuchElementException("No element found with JavaScript query selector: " + by.Selector);
            }

            var list = results.ToList();
            if (list.Count > 0)
            {
                return list.First();
            }

            throw new NoSuchElementException("No element found with Sizzle command: " + by.Selector);
        }

        /// <summary>
        /// Searches for DOM element using JavaScript query selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium JavaScript query selector.</param>
        /// <returns>The first DOM element matching given JavaScript query selector</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, QuerySelector by)
        {
            return new ReadOnlyCollection<IWebElement>(driver.Find<IEnumerable<IWebElement>>(by).ToList());
        }

        /// <summary>
        /// Performs a JavaScript query selector search on the <see cref="IWebDriver"/> using given 
        /// <see cref="QuerySelector"/> selector and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium JavaScript query selector selector.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable{Boolean}"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable{IWebElement}"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{Object}"/>.
        /// </remarks>
        private static T Find<T>(this IWebDriver driver, QuerySelector by)
        {
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            driver.CheckQuerySelectorSupport();
            return ParseResult<T>(driver.ExecuteScript(by));
        }

        /// <summary>
        /// Executes JavaScript query selector script.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium JavaScript query selector.</param>
        /// <returns>Result of invoking the script.</returns>
        private static object ExecuteScript(this IWebDriver driver, QuerySelector by)
        {
            return driver.ExecuteScript<object>("return " + by.Selector + ";");
        }
    }
}
