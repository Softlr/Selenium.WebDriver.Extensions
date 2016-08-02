namespace OpenQA.Selenium.Loaders
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using static OpenQA.Selenium.Loaders.Constants;

    /// <summary>
    /// The Sizzle loader.
    /// </summary>
    public class SizzleLoader : LoaderBase
    {
        /// <inheritdoc/>
        [SuppressMessage("ReSharper", "ExceptionNotDocumentedOptional")]
        public override Uri LibraryUri => new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js");

        /// <inheritdoc/>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly")]
        public override string CheckScript => $"{DetectScriptCode}(window.Sizzle)";

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Arguments array is null.</exception>
        /// <exception cref="ArgumentException">No URI given.</exception>
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
