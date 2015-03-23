namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;
    
    /// <summary>
    /// Additional methods for <see cref="JQuerySelector"/>.
    /// </summary>
    public class JQueryHelper : HelperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQueryHelper"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="webElement">The web element.</param>
        public JQueryHelper(IWebDriver driver, WebElement webElement = null)
            : base(driver, webElement)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }
        }

        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="version">
        /// The version of jQuery to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://code.jquery.com/jquery"/>. The default value will
        /// get the latest stable version.
        /// </param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(string version = "latest", TimeSpan? timeout = null)
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
                new JQueryLoader(),
                new Uri("https://code.jquery.com/jquery-" + version + ".min.js"),
                timeout);
        }

        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="jQueryUri">The URI of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(Uri jQueryUri, TimeSpan? timeout = null)
        {
            if (jQueryUri == null)
            {
                throw new ArgumentNullException("jQueryUri");
            }

            this.Driver.LoadExternalLibrary(new JQueryLoader(), jQueryUri, timeout);
        }
    }
}
