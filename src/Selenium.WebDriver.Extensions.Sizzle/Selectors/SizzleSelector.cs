namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The Selenium selector for Sizzle.
    /// </summary>
    public class SizzleSelector : ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <remarks>
        /// Contrary to jQuery selectors, the <see cref="SizzleSelector"/> only works when single element
        /// is given as context. Therefore only the first match is added to the selector if the context parameters
        /// is used.
        /// </remarks>
        public SizzleSelector(
            string selector,
            SizzleSelector context = null)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            this.Context = context;
            this.Selector = "Sizzle('" + selector.Replace('\'', '"') + "'" 
                + (this.Context != null ? ", " + this.Context + "[0]" : string.Empty) + ")";
        }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public string Selector { get; private set; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        public string CallFormatString
        {
            get
            {
                return "{0}[{1}]";
            }
        }

        /// <summary>
        /// Gets the DOM Element or Document to use as context.
        /// </summary>
        public SizzleSelector Context { get; private set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Selector;
        }
    }
}
