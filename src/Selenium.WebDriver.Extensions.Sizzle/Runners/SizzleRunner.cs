namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// The Sizzle runner.
    /// </summary>
    public class SizzleRunner : JavaScriptRunner
    {
        /// <summary>
        /// Performs a JavaScript query selector search on the <see cref="IWebDriver"/> using given 
        /// <see cref="ISelector"/> selector and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The Selenium JavaScript query selector.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{T}"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Selector is null.</exception>
        /// <exception cref="ArgumentException">Version is empty.</exception>
        /// <exception cref="InvalidCastException">
        /// An element in the sequence cannot be cast to type <typeparamref name="T" />.
        /// </exception>
        /// <exception cref="OverflowException">
        /// Value is less than <see cref="TimeSpan.MinValue" /> or greater than <see cref="TimeSpan.MaxValue" />.
        /// -or- Value is <see cref="double.PositiveInfinity" />.
        /// -or- Value is <see cref="double.NegativeInfinity" />.
        /// </exception>
        /// <exception cref="UriFormatException">
        /// URI string is empty.
        /// -or- The scheme specified in URI string is not correctly formed. See 
        /// <see cref="M:System.Uri.CheckSchemeName(System.String)" />.
        /// -or- URI string contains too many slashes.
        /// -or- The password specified in URI string is not valid.
        /// -or- The host name specified in URI string is not valid.
        /// -or- The file name specified in URI string is not valid. 
        /// -or- The user name specified in URI string is not valid.
        /// -or- The host or authority name specified in URI string cannot be terminated by backslashes.
        /// -or- The port number specified in URI string is not valid or cannot be parsed.
        /// -or- The length of URI string exceeds 65519 characters.
        /// -or- The length of the scheme specified in URI string exceeds 1023 characters.
        /// -or- There is an invalid character sequence in URI string.
        /// -or- The MS-DOS path specified in URI string must start with c:\\.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// This instance represents a relative URI, and this property is valid only for absolute URIs.
        /// </exception>
        public override T Find<T>(IWebDriver driver, ISelector selector)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            driver.Sizzle().Load();
            return JavaScriptRunner.Find<T>(driver, "return " + selector.Selector + ";");
        }
    }
}
