namespace Selenium.WebDriver.Extensions.JQuery
{
    using System.Collections.ObjectModel;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Searches for DOM element using jQuery selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The first DOM element matching given jQuery selector</returns>
        public static WebElement FindElement(
            this WebElement webElement,
            JQuerySelector by)
        {
            return webElement.WrappedDriver.FindElement(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The DOM elements matching given jQuery selector.</returns>
        public static ReadOnlyCollection<WebElement> FindElements(
            this WebElement webElement,
            JQuerySelector by)
        {
            return webElement.WrappedDriver.FindElements(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Creates the jQuery selector limiting the scope of the search to descendants of current element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The jQuery selector limiting the scope of the search to descendants of current element.</returns>
        private static JQuerySelector CreateSelector(this WebElement webElement, JQuerySelector by)
        {
            var path = webElement.GetPath();
            var rootSelector = new JQuerySelector(path, jQueryVariable: by.JQueryVariable);
            return new JQuerySelector(by.Selector, rootSelector, by.JQueryVariable);
        }
    }
}
