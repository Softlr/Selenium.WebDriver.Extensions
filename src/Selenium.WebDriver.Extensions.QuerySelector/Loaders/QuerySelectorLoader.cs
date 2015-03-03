namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The query selector loader.
    /// </summary>
    public class QuerySelectorLoader : ILoader
    {
        /// <summary>
        /// The JavaScript to check if query selector is supported by the browser.
        /// </summary>
        private const string DetectScriptCode = "return typeof document.querySelectorAll === 'function';";

        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        public Uri LibraryUri
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are ok; otherwise, <c>false</c>.
        /// </summary>
        public string CheckScript
        {
            get
            {
                return DetectScriptCode;
            }
        }

        /// <summary>
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        public string LoadScript(params string[] args)
        {
            return null;
        }
    }
}
