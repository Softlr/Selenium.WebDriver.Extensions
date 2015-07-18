namespace OpenQA.Selenium
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenQA.Selenium.Extensions;

    /// <summary>
    /// Searches the DOM elements using jQuery selector.
    /// </summary>
    public class JQuerySelector : SelectorBase<JQuerySelector>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        [SuppressMessage("ReSharper", "RedundantOverload.Global")]
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
        public JQuerySelector(string selector)
            : this(selector, null, "jQuery")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <param name="variable">A variable that has been assigned to jQuery.</param>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- jQuery variable name is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- jQuery variable name is empty.
        /// </exception>
        public JQuerySelector(string selector, JQuerySelector context, string variable)
            : base(selector, context)
        {
            if (variable == null)
            {
                throw new ArgumentNullException("variable");
            }

            if (variable.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("jQuery variable cannot be empty", "variable");
            }

            this.Variable = variable;
            this.Description = "By.JQuerySelector: " + this.RawSelector;
        }

        /// <summary>
        /// Gets the variable that has been assigned to jQuery.
        /// </summary>
        public virtual string Variable { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        protected override string Selector
        {
            get
            {
                return this.Variable + "('" + this.RawSelector.Replace('\'', '"') + "'"
                    + (this.Context != null ? ", " + this.Context.Selector : string.Empty) + ")";
            }
        }

        /// <summary>
        /// Gets the result resolver string.
        /// </summary>
        protected override string ResultResolver
        {
            get { return ".get()"; }
        }

        /// <summary>
        /// Loads the external library.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        protected override void LoadExternalLibrary(IWebDriver driver)
        {
            driver.LoadJQuery();
        }

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <param name="contextSelector">The context selector.</param>
        /// <returns>The context.</returns>
        protected override JQuerySelector CreateContext(string contextSelector)
        {
            return new JQuerySelector(contextSelector, null, this.Variable);
        }
    }
}
