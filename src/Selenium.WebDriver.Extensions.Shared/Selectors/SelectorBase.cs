namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The selector base.
    /// </summary>
    public abstract class SelectorBase : ISelector
    {
        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public string RawSelector { get; protected set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public string Selector { get; protected set; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        public virtual string CallFormatString
        {
            get
            {
                return "{0}[{1}]";
            }
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SelectorBase selector1, SelectorBase selector2)
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
        public static bool operator !=(SelectorBase selector1, SelectorBase selector2)
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

            var selector = (SelectorBase)obj;
            return this.RawSelector == selector.RawSelector;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.RawSelector.GetHashCode();
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
