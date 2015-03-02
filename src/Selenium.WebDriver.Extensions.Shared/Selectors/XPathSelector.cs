namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The XPATH selector.
    /// </summary>
    public class XPathSelector : ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XPathSelector"/> class.
        /// </summary>
        /// <param name="xpath">The XPATH to locate.</param>
        public XPathSelector(string xpath)
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            this.RawSelector = xpath;
            this.Selector = @"(function(path) {
                return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null)
                    .singleNodeValue;
                })('" + xpath + "')";
        }

        /// <summary>
        /// Gets the query raw selector.
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
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(XPathSelector selector1, XPathSelector selector2)
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
        public static bool operator !=(XPathSelector selector1, XPathSelector selector2)
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

            var selector = (XPathSelector)obj;
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
