namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Shared;
    using Selenium.WebDriver.Extensions.Shared.Utils;
    using Selenium.WebDriver.Extensions.Sizzle.ExternalLibraryLoaders;
    using Selenium.WebDriver.Extensions.Sizzle.Selectors;
    
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

        /// <summary>
        /// Searches for DOM elements using Sizzle selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The DOM elements matching given Sizzle selector.</returns>
        public static IWebElement FindElement(this IWebDriver driver, SizzleSelector by)
        {
            var results = driver.Find<IEnumerable<IWebElement>>(by);
            if (results == null)
            {
                throw new NoSuchElementException("No element found with Sizzle command: " + by.Selector);
            }

            var list = results.ToList();
            if (list.Count > 0)
            {
                return list.First();
            }

            throw new NoSuchElementException("No element found with Sizzle command: " + by.Selector);
        }

        /// <summary>
        /// Searches for DOM element using Sizzle selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>The first DOM element matching given Sizzle selector</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, SizzleSelector by)
        {
            return new ReadOnlyCollection<IWebElement>(driver.Find<IEnumerable<IWebElement>>(by).ToList());
        }

        /// <summary>
        /// Performs a Sizzle search on the <see cref="IWebDriver"/> using given <see cref="SizzleSelector"/> selector 
        /// and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium Sizzle selector.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable{Boolean}"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable{IWebElement}"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{Object}"/>.
        /// </remarks>
        private static T Find<T>(this IWebDriver driver, SizzleSelector by)
        {
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            driver.LoadSizzle();
            return ParseUtil.ParseResult<T>(driver.ExecuteScript(by));
        }

        /// <summary>
        /// Executes Sizzle script.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>Result of invoking the script.</returns>
        private static object ExecuteScript(
            this IWebDriver driver,
            SizzleSelector by)
        {
            return driver.ExecuteScript<object>("return " + by.Selector + ";");
        }
    }
}
