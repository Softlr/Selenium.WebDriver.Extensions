namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using static JavaScriptSnippets;
    using static Softlr.Suppress;
    using static Validate;

    /// <summary>Web driver extensions.</summary>
    [PublicAPI]
    public static class WebDriverExtensions
    {
        private static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(10);

        /// <summary>Executes JavaScript in the context of the currently selected frame or window.</summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        public static void ExecuteScript(this IWebDriver driver, string script, params object[] args) =>
            ExecuteScript<object>(driver, script, args);

        /// <summary>Executes JavaScript in the context of the currently selected frame or window.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The script to be executed.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        /// <remarks>
        /// For an HTML element, this method returns a <see cref="IWebElement" />. For a number, a <see cref="long" />
        /// is returned. For a boolean, a <see cref="bool" /> is returned. For all other cases a <see cref="string" />
        /// is returned. For an array,we check the first element, and attempt to return a <see cref="List{T}" /> of
        /// that type, following the rules above. Nested lists are not supported.
        /// </remarks>
        [SuppressMessage(SONARQUBE, S4018)]
        public static TResult ExecuteScript<TResult>(this IWebDriver driver, string script, params object[] args) =>
            (TResult)((IJavaScriptExecutor)NotNull(() => driver)).ExecuteScript(Required(() => script), args);

        /// <summary>Checks if jQuery is loaded and loads it if needed.</summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="version">
        /// The version of jQuery to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://code.jquery.com/jquery" />.
        /// </param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadJQuery(this IWebDriver driver, string version = "3.5.1", TimeSpan? timeout = null)
        {
            var validatedVersion = VersionOrLatest(() => version);
            LoadJQuery(driver, new Uri($"https://code.jquery.com/jquery-{validatedVersion}.min.js"), timeout);
        }

        /// <summary>Checks if jQuery is loaded and loads it if needed.</summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="uri">The URI of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadJQuery(this IWebDriver driver, Uri uri, TimeSpan? timeout = null) =>
            NotNull(() => driver).LoadExternalLibrary(
                JQuerySelector.Empty, NotNull(() => uri), timeout ?? _defaultTimeout);

        /// <summary>Checks if Sizzle is loaded and loads it if needed.</summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="version">
        /// The version of Sizzle to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://github.com/jquery/sizzle" />.
        /// </param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadSizzle(this IWebDriver driver, string version = "2.0.0", TimeSpan? timeout = null)
        {
            var validatedVersion = Version(() => version);
            LoadSizzle(
                driver,
                new Uri($"https://cdnjs.cloudflare.com/ajax/libs/sizzle/{validatedVersion}/sizzle.min.js"),
                timeout);
        }

        /// <summary>Checks if Sizzle is loaded and loads it if needed.</summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="uri">The URI of Sizzle to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the Sizzle load.</param>
        /// <remarks>
        /// If Sizzle is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public static void LoadSizzle(this IWebDriver driver, Uri uri, TimeSpan? timeout = null) =>
            NotNull(() => driver).LoadExternalLibrary(
                SizzleSelector.Empty, NotNull(() => uri), timeout ?? _defaultTimeout);

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        private static bool CheckSelectorPrerequisites(
            this IWebDriver driver,
            ISelector selector) =>
            driver.ExecuteScript<bool?>($"return {selector.CheckScript};").Value;

        private static void LoadExternalLibrary(this IWebDriver driver, ISelector selector, Uri url, TimeSpan timeout)
        {
            if (driver.CheckSelectorPrerequisites(selector))
            {
                return;
            }

            driver.ExecuteScript(LoadScriptCode(url));
            new WebDriverWait(driver, timeout).Until(x => x.CheckSelectorPrerequisites(selector));
        }
    }
}
