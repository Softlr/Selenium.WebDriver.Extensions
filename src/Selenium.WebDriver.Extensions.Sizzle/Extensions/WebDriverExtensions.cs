namespace Selenium.WebDriver.Extensions.Sizzle
{
    using OpenQA.Selenium;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Returns the Sizzle helper, that can be used to access Sizzle-specific functionalities.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <returns>The Sizzle helper.</returns>
        public static SizzleHelper Sizzle(this IWebDriver driver)
        {
            return new SizzleHelper(driver);
        }
    }
}
