namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// The partial link text selector.
    /// </summary>
    public class PartialLinkTextSelector : LinkTextSelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialLinkTextSelector"/> class.
        /// </summary>
         /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        public PartialLinkTextSelector(string text, string baseElement = "document")
            : base(text, baseElement)
        {
            this.Selector = @"(function(text, baseElem) {
                var links = baseElem.querySelectorAll(':link');
                var results = [];
                for (var i = 0; i < l.length; i++) { 
                    if (links[i].innerText.indexOf(text) !== -1) { 
                        results.push(links[i]); 
                    } 
                }
                return results;
            })('" + text + "', " + this.BaseElement + ");";
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
        public static bool operator ==(PartialLinkTextSelector selector1, PartialLinkTextSelector selector2)
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
        public static bool operator !=(PartialLinkTextSelector selector1, PartialLinkTextSelector selector2)
        {
            return !(selector1 == selector2);
        }

        /// <summary>
        /// Creates a new selector using given selector as a root.
        /// </summary>
        /// <param name="root">A web element to be used as a root.</param>
        /// <returns>A new selector.</returns>
        public override ISelector Create(WebElement root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }

            var rootSelector = new QuerySelector(root.Path);
            return new PartialLinkTextSelector(this.RawSelector, rootSelector.Selector);
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

            var selector = (PartialLinkTextSelector)obj;
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
