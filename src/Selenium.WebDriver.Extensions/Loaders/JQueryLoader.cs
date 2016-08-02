namespace OpenQA.Selenium.Loaders
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// The jQuery loader.
    /// </summary>
    public class JQueryLoader : ExternalLibraryLoaderBase
    {
        /// <inheritdoc/>
        [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
        public override Uri LibraryUri => new Uri("https://code.jquery.com/jquery-latest.min.js");

        /// <inheritdoc/>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly")]
        public override string CheckScript => $"{DetectScriptCode}(window.jQuery)";

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Arguments array is null.</exception>
        /// <exception cref="LoaderException">No URI given as first parameter.</exception>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly")]
        public override string LoadScript(string url)
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
