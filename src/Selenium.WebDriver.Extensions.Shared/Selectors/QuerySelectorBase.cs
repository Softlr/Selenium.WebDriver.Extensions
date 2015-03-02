namespace Selenium.WebDriver.Extensions.Shared
{
    using System;
    
    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public abstract class QuerySelectorBase : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelectorBase"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected QuerySelectorBase(string selector, string baseElement = "document")
            : base(selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (baseElement == null)
            {
                throw new ArgumentNullException("baseElement");
            }

            this.BaseElement = baseElement;
            this.Selector = this.BaseElement + ".querySelectorAll('" + selector.Replace('\'', '"') + "')";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelectorBase"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <remarks>
        /// Because the <see cref="QuerySelectorBase"/> operates always on collection of results, the new selector 
        /// generated on its base will be invoked on the first match of the base selector. There's also a check to 
        /// make sure that the base selector has actually return any results.
        /// </remarks>
        protected QuerySelectorBase(string selector, QuerySelectorBase baseSelector)
            : base(selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
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
        /// Gets the base element for the query selector.
        /// </summary>
        public string BaseElement { get; private set; }

        /// <summary>
        /// Gets the base query selector for the query selector.
        /// </summary>
        public QuerySelectorBase BaseSelector { get; private set; }

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

            var selector = (QuerySelectorBase)obj;
            return this.RawSelector == selector.RawSelector && this.BaseElement == selector.BaseElement 
                && this.BaseSelector == selector.BaseSelector;
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
