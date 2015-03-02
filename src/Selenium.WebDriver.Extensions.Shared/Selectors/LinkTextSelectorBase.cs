namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The link text base selector.
    /// </summary>
    public abstract class LinkTextSelectorBase : ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTextSelectorBase"/> class.
        /// </summary>
        /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected LinkTextSelectorBase(string text, string baseElement = "document")
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (baseElement == null)
            {
                throw new ArgumentNullException("baseElement");
            }

            this.BaseElement = baseElement;
            this.RawSelector = text;
        }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public string RawSelector { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public string Selector { get; protected set; }

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
        /// Gets the base element for the query selector.
        /// </summary>
        public string BaseElement { get; private set; }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(LinkTextSelectorBase selector1, LinkTextSelectorBase selector2)
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
        public static bool operator !=(LinkTextSelectorBase selector1, LinkTextSelectorBase selector2)
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

            var selector = (LinkTextSelectorBase)obj;
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
