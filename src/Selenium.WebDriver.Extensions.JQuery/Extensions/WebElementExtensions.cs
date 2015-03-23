namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        public static ChainJQueryHelper JQuery(this WebElement webElement, string selector)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            return webElement.JQuery(By.JQuerySelector(selector));
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        public static ChainJQueryHelper JQuery(this WebElement webElement, JQuerySelector selector)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            return new ChainJQueryHelper(webElement.WrappedDriver, selector, webElement);
        }
    }
}
