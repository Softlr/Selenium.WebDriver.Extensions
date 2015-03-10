namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Selenium.WebDriver.Extensions.Core;
    
    /// <summary>
    /// The Sizzle loader.
    /// </summary>
    public class SizzleLoader : ExternalLibraryLoaderBase
    {
        /// <summary>
        /// The JavaScript to check if Sizzle has been loaded.
        /// </summary>
        protected const string DetectScriptCode = "return typeof window.Sizzle === 'function';";

        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        public override Uri LibraryUri
        {
            get
            {
                return new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js");
            }
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are ok; otherwise, <c>false</c>.
        /// </summary>
        public override string CheckScript
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
        public override string LoadScript(params string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            if (args.Length == 0)
            {
                throw new LoaderException("No Sizzle URI given");
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}('{1}')", LoadScriptCode, args.First());
        }
    }
}
