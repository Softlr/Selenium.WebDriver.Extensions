namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using System;
    using System.Collections.ObjectModel;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Searches for DOM element using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium query selector.</param>
        /// <returns>The first DOM element matching given query selector</returns>
        public static WebElement FindElement(
            this WebElement webElement,
            QuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElement(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium query selector.</param>
        /// <returns>The DOM elements matching given query selector.</returns>
        public static ReadOnlyCollection<WebElement> FindElements(
            this WebElement webElement,
            QuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElements(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Creates the query selector limiting the scope of the search to descendants of current element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium query selector.</param>
        /// <returns>The query selector limiting the scope of the search to descendants of current element.</returns>
        private static QuerySelector CreateSelector(this WebElement webElement, QuerySelector by)
        {
            var path = webElement.GetPath();
            var rootSelector = new QuerySelector(path, by.BaseElement);
            return new QuerySelector(by.RawSelector, rootSelector);
        }
    }
}
