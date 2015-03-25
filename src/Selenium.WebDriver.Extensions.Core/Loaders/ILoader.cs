namespace Selenium.WebDriver.Extensions.Core
{
    using System;

    /// <summary>
    /// The loader interface.
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        Uri LibraryUri { get; }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are met; otherwise, <c>false</c>.
        /// </summary>
        string CheckScript { get; }

        /// <summary>
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        string LoadScript(params string[] args);
    }
}
