namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Returns the query selector helper, that can be used to access query selector specific functionalities.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <returns>The Sizzle helper.</returns>
        public static QuerySelectorHelper QuerySelector(this WebElement webElement)
        {
            return new QuerySelectorHelper(webElement.WrappedDriver, webElement);
        }
    }
}
