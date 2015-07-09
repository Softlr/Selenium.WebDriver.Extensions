namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;

    /// <summary>
    /// The runner interface.
    /// </summary>
    public interface IRunner
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
        /// <see cref="IWebElement"/> and <see cref="IEnumerable{T}"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{T}"/>.
        /// </remarks>
        T Find<T>(IWebDriver driver, ISelector selector);
    }
}
