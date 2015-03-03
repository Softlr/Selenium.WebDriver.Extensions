namespace Selenium.WebDriver.Extensions.Sizzle
{
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Returns the Sizzle helper, that can be used to access Sizzle-specific functionalities.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <returns>The Sizzle helper.</returns>
        public static SizzleHelper JQuery(this WebElement webElement)
        {
            return new SizzleHelper(webElement.WrappedDriver, webElement);
        }
    }
}
