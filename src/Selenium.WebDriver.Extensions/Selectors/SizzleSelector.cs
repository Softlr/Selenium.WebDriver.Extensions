namespace OpenQA.Selenium
{
    using OpenQA.Selenium.Extensions;

    /// <summary>
    /// Searches the DOM elements using Sizzle selector.
    /// </summary>
    public class SizzleSelector : SelectorBase<SizzleSelector>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        public SizzleSelector(string selector, SizzleSelector context = null)
            : base(selector, context)
        {
            this.Description = "By.SizzleSelector: " + this.RawSelector;
        }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        protected override string Selector
        {
            get
            {
                return "Sizzle('" + this.RawSelector.Replace('\'', '"') + "'"
                    + (this.Context != null ? ", " + this.Context.Selector + "[0]" : string.Empty) + ")";
            }
        }

        /// <summary>
        /// Loads the external library.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        protected override void LoadExternalLibrary(IWebDriver driver)
        {
            driver.LoadSizzle();
        }

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <param name="contextSelector">The context selector.</param>
        /// <returns>The context.</returns>
        protected override SizzleSelector CreateContext(string contextSelector)
        {
            return new SizzleSelector(contextSelector);
        }
    }
}
