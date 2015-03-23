namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;

    /// <summary>
    /// The JavaScript runner.
    /// </summary>
    public class JavaScriptRunner : IRunner
    {
        /// <summary>
        /// Performs a JavaScript search on the <see cref="IWebDriver"/> using given <see cref="ISelector"/> selector 
        /// and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium JavaScript query selector selector.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{T}"/>.
        /// </remarks>
        public virtual T Find<T>(IWebDriver driver, ISelector by)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            return Find<T>(driver, "return " + by.Selector + ";");
        }

        /// <summary>
        /// Performs a JavaScript search on the <see cref="IWebDriver"/> using given script.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="script">The JavaScript to be executed.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{T}"/>.
        /// </remarks>
        protected static T Find<T>(IWebDriver driver, string script)
        {
            return ParseUtil.ParseResult<T>(driver.ExecuteScript<object>(script));
        }
    }
}
