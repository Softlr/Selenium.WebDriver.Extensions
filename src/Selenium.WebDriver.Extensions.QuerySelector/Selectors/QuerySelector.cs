namespace Selenium.WebDriver.Extensions.QuerySelector.Selectors
{
    using System;
    
    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public class QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        public QuerySelector(string selector, string baseElement = "document")
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
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <remarks>
        /// Because the <see cref="QuerySelector"/> operates always on collection of results, the new selector 
        /// generated on its base will be invoked on the first match of the base selector. There's also a check to make
        /// sure that the base selector has actually return any results.
        /// </remarks>
        public QuerySelector(string selector, QuerySelector baseSelector)
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
        /// Gets the query selector.
        /// </summary>
        public string Selector { get; private set; }

        /// <summary>
        /// Gets the base element for the query selector.
        /// </summary>
        public string BaseElement { get; private set; }

        /// <summary>
        /// Gets the base query selector for the query selector.
        /// </summary>
        public QuerySelector BaseSelector { get; private set; }

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
