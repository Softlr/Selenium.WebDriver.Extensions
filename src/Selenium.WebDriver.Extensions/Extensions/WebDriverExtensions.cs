namespace OpenQA.Selenium.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Loaders;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
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
        /// <exception cref="ArgumentNullException">Version is null.</exception>
        /// <exception cref="ArgumentException">Version is empty.</exception>
        [SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads")]
        public static void LoadJQuery(this IWebDriver driver, string version = "latest", TimeSpan? timeout = null)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            if (version.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Version cannot be empty", "version");
            }

            driver.LoadExternalLibrary(
                new JQueryLoader(),
                new Uri("https://code.jquery.com/jquery-" + version + ".min.js"),
                timeout);
        }

        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="uri">The URI of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadJQuery(this IWebDriver driver, Uri uri, TimeSpan? timeout = null)
        {
            driver.LoadExternalLibrary(new JQueryLoader(), uri, timeout);
        }

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
        /// <exception cref="ArgumentNullException">Version is null.</exception>
        /// <exception cref="ArgumentException">Version is empty.</exception>
        [SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads")]
        public static void LoadSizzle(this IWebDriver driver, string version = "2.0.0", TimeSpan? timeout = null)
        {
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }

            if (version.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Version cannot be empty", "version");
            }

            driver.LoadExternalLibrary(
                new SizzleLoader(),
                new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/" + version + "/sizzle.min.js"),
                timeout);
        }

        /// <summary>
        /// Checks if Sizzle is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="uri">The URI of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadSizzle(this IWebDriver driver, Uri uri, TimeSpan? timeout = null)
        {
            driver.LoadExternalLibrary(new SizzleLoader(), uri, timeout);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static void ExecuteScript(this IWebDriver driver, string script, params object[] args)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            driver.ExecuteScript<object>(script, args);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        /// <remarks>
        /// For an HTML element, this method returns a <see cref="IWebElement"/>.
        /// For a number, a <see cref="long"/> is returned.
        /// For a boolean, a <see cref="bool"/> is returned.
        /// For all other cases a <see cref="string"/> is returned.
        /// For an array,we check the first element, and attempt to return a <see cref="List{T}"/> of that type,
        /// following the rules above. Nested lists are not supported.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Script is null.
        /// </exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public static T ExecuteScript<T>(this IWebDriver driver, string script, params object[] args)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (script == null)
            {
                throw new ArgumentNullException("script");
            }

            if (script.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Script cannot be empty", "script");
            }

            var result = ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
            return (T)result;
        }

        /// <summary>
        /// Checks if prerequisites for the selector has been met.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <returns><c>true</c> if prerequisites are met; otherwise, <c>false</c></returns>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.
        /// </exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public static bool CheckSelectorPrerequisites(this IWebDriver driver, ILoader loader)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (loader == null)
            {
                throw new ArgumentNullException("loader");
            }

            var result = driver.ExecuteScript<bool?>("return " + loader.CheckScript + ";");
            return result.HasValue && result.Value;
        }

        /// <summary>
        /// Checks if external library is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <param name="libraryUri">
        /// The URI of external library to load if it's not already loaded on the tested page.
        /// </param>
        /// <param name="timeout">The timeout value for the load.</param>
        /// <remarks>
        /// If external library is already loaded on a page this method will do nothing, even if the loaded version
        /// and version requested by invoking this method have different versions.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.
        /// </exception>
        public static void LoadExternalLibrary(
            this IWebDriver driver,
            ILoader loader,
            Uri libraryUri,
            TimeSpan? timeout = null)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (loader == null)
            {
                throw new ArgumentNullException("loader");
            }

            driver.LoadPrerequisites(
                loader,
                timeout ?? TimeSpan.FromSeconds(3),
                libraryUri == null ? loader.LibraryUri.OriginalString : libraryUri.OriginalString);
        }

        /// <summary>
        /// Loads the prerequisites for the selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="loader">The loader.</param>
        /// <param name="timeout">The timeout value for the prerequisites load.</param>
        /// <param name="loadParams">The additional parameters for load script.</param>
        private static void LoadPrerequisites(
            this IWebDriver driver,
            ILoader loader,
            TimeSpan timeout,
            params string[] loadParams)
        {
            if (driver.CheckSelectorPrerequisites(loader))
            {
                return;
            }

            driver.ExecuteScript(loader.LoadScript(loadParams));
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => driver.CheckSelectorPrerequisites(loader));
        }
    }
}
