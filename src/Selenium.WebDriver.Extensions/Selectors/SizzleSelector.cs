namespace OpenQA.Selenium
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Extensions;
    using static OpenQA.Selenium.JavaScriptSnippets;

    /// <summary>
    /// Searches the DOM elements using Sizzle selector.
    /// </summary>
    public class SizzleSelector : SelectorBase<SizzleSelector>
    {
        private const string LibraryVariable = "window.Sizzle";

        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
        public SizzleSelector(string selector)
            : this(selector, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        public SizzleSelector(string selector, SizzleSelector context)
            : base(selector, context)
        {
            this.Description = $"By.SizzleSelector: {this.RawSelector}";
        }

        /// <summary>
        /// Gets the empty selector.
        /// </summary>
        public static SizzleSelector Empty { get; } = new SizzleSelector("*");

        /// <inheritdoc/>
        public override Uri LibraryUri => new Uri("https://cdnjs.cloudflare.com/ajax/libs/sizzle/2.0.0/sizzle.min.js");

        /// <inheritdoc/>
        public override string CheckScript => CheckScriptCode(LibraryVariable);

        /// <inheritdoc/>
        public override string Selector => $"Sizzle('{this.RawSelector.Replace('\'', '"')}'"
            + (this.Context != null ? $", {this.Context.Selector}[0]" : string.Empty) + ")";

        /// <inheritdoc/>
        protected override void LoadExternalLibrary(IWebDriver driver) => driver.LoadSizzle();

        /// <inheritdoc/>
        protected override SizzleSelector CreateContext(string contextSelector) => new SizzleSelector(contextSelector);
    }
}
