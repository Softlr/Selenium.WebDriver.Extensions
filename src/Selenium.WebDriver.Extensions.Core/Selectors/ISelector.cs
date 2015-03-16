namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    
    /// <summary>
    /// The selector interface.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        Type RunnerType { get; }

        /// <summary>
        /// Gets the raw selector.
        /// </summary>
        string RawSelector { get; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        string Selector { get; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        string CallFormatString { get; }

        /// <summary>
        /// Creates a new selector using given selector as a root.
        /// </summary>
        /// <param name="root">A web element to be used as a root.</param>
        /// <returns>A new selector.</returns>
        ISelector Create(WebElement root);
    }
}
