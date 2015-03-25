namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The query selector loader.
    /// </summary>
    public class QuerySelectorLoader : LoaderBase
    {
        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        public override Uri LibraryUri
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are met; otherwise, <c>false</c>.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
        public override string CheckScript
        {
            get
            {
                return DetectScriptCode + "(document.querySelectorAll)";
            }
        }

        /// <summary>
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        public override string LoadScript(params string[] args)
        {
            return null;
        }
    }
}
