namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The Selenium selector for Sizzle.
    /// </summary>
    public class SizzleSelector : SelectorBase
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
            : base(selector)
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
        /// Gets the DOM Element or Document to use as context.
        /// </summary>
        public SizzleSelector Context { get; private set; }

        /// <summary>
        /// Determines whether two object instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            var selector = (SizzleSelector)obj;
            return this.RawSelector == selector.RawSelector && this.Context == selector.Context;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Context == null
                ? this.RawSelector.GetHashCode()
                : this.RawSelector.GetHashCode() ^ this.Context.GetHashCode();
        }
    }
}
