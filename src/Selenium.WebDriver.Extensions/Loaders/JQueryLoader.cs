namespace OpenQA.Selenium.Loaders
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using static OpenQA.Selenium.JavaScriptSnippets;

    /// <summary>
    /// The jQuery loader.
    /// </summary>
    public class JQueryLoader : ILoader
    {
        /// <inheritdoc/>
        [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
        public Uri LibraryUri => new Uri("https://code.jquery.com/jquery-latest.min.js");

        /// <inheritdoc/>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly")]
        public string CheckScript => $"{DetectScriptCode}(window.jQuery)";

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Arguments array is null.</exception>
        /// <exception cref="ArgumentException">No URI given.</exception>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly")]
        public string LoadScript(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (url.Length == 0)
            {
                throw new ArgumentException("URL must not be empty", nameof(url));
            }

            return $"{LoadScriptCode}('{url}')";
        }
    }
}
