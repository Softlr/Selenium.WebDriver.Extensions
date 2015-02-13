namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Sizzle.Selectors;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static partial class WebDriverExtensions
    {
        /// <summary>
        /// Checks if Sizzle is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="version">
        /// The version of Sizzle to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://github.com/jquery/sizzle"/>.
        /// </param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadSizzle(this IWebDriver driver, string version = "2.0.0", TimeSpan? timeout = null)
        {
            Sizzle.WebDriverExtensions.LoadSizzle(driver, version, timeout);
        }

        /// <summary>
        /// Checks if Sizzle is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="sizzleUri">The URI of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadSizzle(this IWebDriver driver, Uri sizzleUri, TimeSpan? timeout = null)
        {
            Sizzle.WebDriverExtensions.LoadSizzle(driver, sizzleUri, timeout);
        }

        /// <summary>
        /// Searches for DOM elements using Sizzle selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The DOM elements matching given Sizzle selector.</returns>
        public static IWebElement FindElement(this IWebDriver driver, SizzleSelector by)
        {
            return Sizzle.WebDriverExtensions.FindElement(driver, by);
        }

        /// <summary>
        /// Searches for DOM element using Sizzle selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The first DOM element matching given Sizzle selector</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, SizzleSelector by)
        {
            return Sizzle.WebDriverExtensions.FindElements(driver, by);
        }
    }
}
