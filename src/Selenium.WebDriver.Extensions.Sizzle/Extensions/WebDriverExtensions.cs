namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Shared;
    
    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
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
            driver.LoadExternalLibrary(
                new SizzleLoader(),
                new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/" + version + "/sizzle.min.js"),
                timeout);
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
            driver.LoadExternalLibrary(new SizzleLoader(), sizzleUri, timeout);
        }
    }
}
