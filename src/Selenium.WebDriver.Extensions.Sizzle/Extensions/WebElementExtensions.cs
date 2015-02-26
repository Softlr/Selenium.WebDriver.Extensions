namespace Selenium.WebDriver.Extensions.Sizzle
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
        /// Searches for DOM element using Sizzle selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The first DOM element matching given Sizzle selector</returns>
        public static WebElement FindElement(
            this WebElement webElement,
            SizzleSelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElement(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using Sizzle selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The DOM elements matching given Sizzle selector.</returns>
        public static ReadOnlyCollection<WebElement> FindElements(
            this WebElement webElement,
            SizzleSelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElements(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Creates the Sizzle selector limiting the scope of the search to descendants of current element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The Sizzle selector limiting the scope of the search to descendants of current element.</returns>
        private static SizzleSelector CreateSelector(this WebElement webElement, SizzleSelector by)
        {
            var path = webElement.GetPath();
            var rootSelector = new SizzleSelector(path);
            return new SizzleSelector(by.RawSelector, rootSelector);
        }
    }
}
