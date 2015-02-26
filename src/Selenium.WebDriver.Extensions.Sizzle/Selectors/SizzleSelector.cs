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
            this.RawSelector = selector;
            this.Selector = "Sizzle('" + selector.Replace('\'', '"') + "'" 
                + (this.Context != null ? ", " + this.Context + "[0]" : string.Empty) + ")";
        }

        /// <summary>
        /// Gets the raw selector.
        /// </summary>
        public string RawSelector { get; private set; }

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
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SizzleSelector selector1, SizzleSelector selector2)
        {
            if (ReferenceEquals(selector1, selector2))
            {
                return true;
            }

            if (((object)selector1 == null) || ((object)selector2 == null))
            {
                return false;
            }

            return selector1.Equals(selector2);
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are not equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(SizzleSelector selector1, SizzleSelector selector2)
        {
            return !(selector1 == selector2);
        }

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
