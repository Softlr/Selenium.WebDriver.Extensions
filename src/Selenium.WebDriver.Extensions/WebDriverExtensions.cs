namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static partial class WebDriverExtensions
    {
        /// <summary>
        /// Checks if prerequisites for the selector has been met.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector that is to be executed.</param>
        /// <returns><c>true</c> if prerequisites are met; otherwise, <c>false</c></returns>
        private static bool CheckSelectorPrerequisites(this IWebDriver driver, ISelector selector)
        {
            var result = (bool?)((IJavaScriptExecutor)driver).ExecuteScript(selector.CheckScript);
            return result.HasValue && result.Value;
        }

        /// <summary>
        /// Loads the prerequisites for the selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The selector that is to be executed.</param>
        /// <param name="timeout">The timeout value for the prerequisites load.</param>
        /// <param name="loadParams">The additional parameters for load script.</param>
        private static void LoadPrerequisites(
            this IWebDriver driver,
            ISelector selector, 
            TimeSpan timeout, 
            params string[] loadParams)
        {
            if (driver.CheckSelectorPrerequisites(selector))
            {
                return;
            }

            var loadScript = selector.LoadScript(loadParams);

            Debug.Assert(loadScript != null, "Load script not resolved");
            
            ((IJavaScriptExecutor)driver).ExecuteScript(loadScript);
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => driver.CheckSelectorPrerequisites(selector));
        }

        /// <summary>
        /// Parses the result of executed jQuery script.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="result">The result of jQuery script.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// IE is returning numbers as doubles, while other browsers return them as long. This method casts IE-doubles
        /// to long integer type.
        /// </remarks>
        private static T ParseResult<T>(object result)
        {
            if (result == null)
            {
                return default(T);
            }

            if (typeof(T) == typeof(IEnumerable<IWebElement>)
                && result.GetType() == typeof(ReadOnlyCollection<object>))
            {
                result = ((ReadOnlyCollection<object>)result).Cast<IWebElement>();
            }

            if (result is double)
            {
                result = (long?)(double)result;
            }

            return (T)result;
        }
    }
}
