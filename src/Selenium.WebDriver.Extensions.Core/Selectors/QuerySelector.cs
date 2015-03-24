namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public class QuerySelector : NestableSelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <exception cref="ArgumentNullException">Selector is null or base element is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty or base element is empty.</exception>
        public QuerySelector(string selector, string baseElement = "document")
            : base(selector, baseElement)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (baseElement == null)
            {
                throw new ArgumentNullException("baseElement");
            }

            if (baseElement.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Base element cannot be empty", "baseElement");
            }

            this.Selector = this.BaseElement + ".querySelectorAll('" + selector.Replace('\'', '"') + "')";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <remarks>
        /// Because the <see cref="QuerySelector"/> operates always on collection of results, the new selector 
        /// generated on its base will be invoked on the first match of the base selector. There's also a check to 
        /// make sure that the base selector has actually return any results.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Selector is null or base element is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public QuerySelector(string selector, ISelector baseSelector)
            : base(selector, null)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (baseSelector == null)
            {
                throw new ArgumentNullException("baseSelector");
            }

            this.BaseSelector = baseSelector;
            this.Selector = this.BaseSelector + ".length === 0 ? [] : " + this.BaseSelector 
                + "[0].querySelectorAll('" + selector.Replace('\'', '"') + "')";
        }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(QuerySelectorRunner);
            }
        }

        /// <summary>
        /// Gets the base query selector for the query selector.
        /// </summary>
        public virtual ISelector BaseSelector { get; private set; }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
        public static bool operator ==(QuerySelector selector1, QuerySelector selector2)
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
        public static bool operator !=(QuerySelector selector1, QuerySelector selector2)
        {
            return !(selector1 == selector2);
        }

        /// <summary>
        /// Creates a new selector using given selector as a root.
        /// </summary>
        /// <param name="root">A web element to be used as a root.</param>
        /// <returns>A new selector.</returns>
        /// <exception cref="ArgumentNullException">Root element is null.</exception>
        public override ISelector Create(WebElement root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }

            var rootSelector = new QuerySelector(root.Path);
            return new QuerySelector(this.RawSelector, rootSelector);
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

            var selector = (QuerySelector)obj;
            if ((this.BaseSelector == null && selector.BaseSelector != null) 
                || (this.BaseSelector != null && selector.BaseSelector == null))
            {
                return false;
            }

            if (this.BaseSelector != null && selector.BaseSelector != null)
            {
                return this.RawSelector == selector.RawSelector && this.BaseElement == selector.BaseElement
                    && this.BaseSelector.GetType() == selector.BaseSelector.GetType()
                    && this.BaseSelector.Selector == selector.BaseSelector.Selector;   
            }

            return this.RawSelector == selector.RawSelector && this.BaseElement == selector.BaseElement;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.BaseSelector == null
                ? this.RawSelector.GetHashCode() ^ this.BaseElement.GetHashCode()
                : this.RawSelector.GetHashCode() ^ this.BaseSelector.GetHashCode();
        }
    }
}
