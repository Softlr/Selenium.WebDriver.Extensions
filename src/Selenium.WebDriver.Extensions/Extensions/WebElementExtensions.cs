namespace Selenium.WebDriver.Extensions
{
    using System;
    using Selenium.WebDriver.Extensions.Core;
    using Selenium.WebDriver.Extensions.JQuery;

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
        /// <exception cref="ArgumentNullException">
        /// Web element is null.
        /// -or- Selector is null.</exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- jQuery variable name is empty.
        /// </exception>
        public static ChainJQueryHelper JQuery(this WebElement webElement, string selector)
        {
            return Extensions.JQuery.WebElementExtensions.JQuery(webElement, selector);
        }

        /// <summary>
        /// Returns the jQuery helper, that can be used to access jQuery-specific functionalities.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>The jQuery helper.</returns>
        /// <exception cref="ArgumentNullException">
        /// Web element is null.
        /// -or- Selector is null.
        /// </exception>
        public static ChainJQueryHelper JQuery(this WebElement webElement, JQuerySelector selector)
        {
            return Extensions.JQuery.WebElementExtensions.JQuery(webElement, selector);
        }
    }
}
