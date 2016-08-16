namespace OpenQA.Selenium.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Support.UI;
    using PostSharp.Patterns.Contracts;
    using static OpenQA.Selenium.JavaScriptSnippets;

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
        public static void LoadJQuery(
            [Required] this IWebDriver driver, [Required] string version = "latest", TimeSpan? timeout = null)
        {
            driver.LoadExternalLibrary(
                JQuerySelector.Empty,
                new Uri($"https://code.jquery.com/jquery-{version}.min.js"),
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
        public static void LoadJQuery(
            [Required] this IWebDriver driver, [Required] Uri uri, TimeSpan? timeout = null) =>
            driver.LoadExternalLibrary(JQuerySelector.Empty, uri, timeout);

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
        public static void LoadSizzle(
            [Required] this IWebDriver driver, [Required] string version = "2.0.0", TimeSpan? timeout = null)
        {
            driver.LoadExternalLibrary(
                SizzleSelector.Empty,
                new Uri($"https://cdnjs.cloudflare.com/ajax/libs/sizzle/{version}/sizzle.min.js"),
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
        public static void LoadSizzle(
            [Required] this IWebDriver driver, [Required] Uri uri, TimeSpan? timeout = null) =>
            driver.LoadExternalLibrary(SizzleSelector.Empty, uri, timeout);

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public static void ExecuteScript([Required] this IWebDriver driver, string script, params object[] args) =>
            driver.ExecuteScript<object>(script, args);

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
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
        public static TResult ExecuteScript<TResult>(
            [Required] this IWebDriver driver, [Required] string script, params object[] args) =>
            (TResult)((IJavaScriptExecutor)driver).ExecuteScript(script, args);

        /// <summary>
        /// Checks if prerequisites for the selector has been met.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <returns><see langword="true"/> if prerequisites are met; otherwise, <see langword="false"/></returns>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.
        /// </exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public static bool CheckSelectorPrerequisites(
            [Required] this IWebDriver driver, [Required] ISelector selector) =>
            driver.ExecuteScript<bool?>($"return {selector.CheckScript};").Value;

        /// <summary>
        /// Checks if external library is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
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
            [Required] this IWebDriver driver,
            [Required] ISelector selector,
            Uri libraryUri,
            TimeSpan? timeout = null) =>
            driver.LoadPrerequisites(
                selector, timeout ?? TimeSpan.FromSeconds(3), libraryUri ?? selector.LibraryUri);

        /// <summary>
        /// Loads the prerequisites for the selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="timeout">The timeout value for the prerequisites load.</param>
        /// <param name="url">The URL for the script.</param>
        private static void LoadPrerequisites(
            this IWebDriver driver, ISelector selector, TimeSpan timeout, Uri url)
        {
            if (driver.CheckSelectorPrerequisites(selector))
            {
                return;
            }

            driver.ExecuteScript(LoadScriptCode(url));
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => driver.CheckSelectorPrerequisites(selector));
        }
    }
}
