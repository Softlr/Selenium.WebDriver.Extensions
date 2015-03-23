namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// Additional methods for <see cref="SizzleSelector"/>.
    /// </summary>
    public class SizzleHelper : HelperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleHelper"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="webElement">The web element.</param>
        public SizzleHelper(IWebDriver driver, WebElement webElement = null)
            : base(driver, webElement)
        {
        }

        /// <summary>
        /// Checks if Sizzle is loaded and loads it if needed.
        /// </summary>
        /// <param name="version">
        /// The version of Sizzle to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://github.com/jquery/sizzle"/>.
        /// </param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(string version = "2.0.0", TimeSpan? timeout = null)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            if (version.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Version cannot be empty", "version");
            }

            this.Driver.LoadExternalLibrary(
                new SizzleLoader(),
                new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/" + version + "/sizzle.min.js"),
                timeout);
        }

        /// <summary>
        /// Checks if Sizzle is loaded and loads it if needed.
        /// </summary>
        /// <param name="sizzleUri">The URI of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(Uri sizzleUri, TimeSpan? timeout = null)
        {
            this.Driver.LoadExternalLibrary(new SizzleLoader(), sizzleUri, timeout);
        }
    }
}
