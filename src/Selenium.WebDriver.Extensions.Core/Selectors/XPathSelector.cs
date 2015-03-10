namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// The XPATH selector.
    /// </summary>
    public class XPathSelector : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XPathSelector"/> class.
        /// </summary>
        /// <param name="xpath">The XPATH to locate.</param>
        public XPathSelector(string xpath)
            : base(xpath)
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            this.Selector = @"(function(path) {
                'use strict';
                var elements = document.evaluate(path, document, null, XPathResult.ANY_TYPE, null),
                    results = [],
                    element = elements.iterateNext();
                while (element !== null) {
                    results.push(element);
                    element = elements.iterateNext();
                }
                return results;
            })('" + xpath + "')";
        }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(JavaScriptRunner);
            }
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
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

            var separator = root.XPath.EndsWith("/", StringComparison.OrdinalIgnoreCase)
                || this.RawSelector.StartsWith("/", StringComparison.OrdinalIgnoreCase)
                    ? string.Empty
                    : "/";
            var xpath = root.XPath + separator + this.RawSelector;
            return new XPathSelector(xpath);
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
    }
}
