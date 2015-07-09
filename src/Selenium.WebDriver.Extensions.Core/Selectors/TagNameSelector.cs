namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The tag name selector.
    /// </summary>
    public class TagNameSelector : QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagNameSelector"/> class.
        /// </summary>
        /// <param name="tagName">A string containing a DOM tag name.</param>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public TagNameSelector(string tagName)
            : base(tagName)
        {
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
        public static bool operator ==(TagNameSelector selector1, TagNameSelector selector2)
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
        public static bool operator !=(TagNameSelector selector1, TagNameSelector selector2)
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

            var selector = (TagNameSelector)obj;
            return this.RawSelector == selector.RawSelector && this.BaseElement == selector.BaseElement;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.RawSelector.GetHashCode() ^ this.BaseElement.GetHashCode();
        }
    }
}
