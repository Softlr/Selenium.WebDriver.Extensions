namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public class QuerySelector : ISelector
    {
        /// <summary>
        /// The JavaScript to check if query selector is supported by the browser.
        /// </summary>
        private const string DetectScriptCode = "return typeof document.querySelectorAll === 'function';";

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
            this.Selector = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.querySelectorAll('{1}')",
                this.BaseElement,
                selector.Replace('\'', '"'));
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
            this.Selector = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.length === 0 ? [] : {0}[0].querySelectorAll('{1}')",
                this.BaseSelector,
                selector.Replace('\'', '"'));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        protected QuerySelector()
        {
        }

        /// <summary>
        /// Gets the empty query selector.
        /// </summary>
        public static QuerySelector Empty
        {
            get
            {
                return new QuerySelector();
            }
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are ok; otherwise, <c>false</c>.
        /// </summary>
        public string CheckScript
        {
            get
            {
                return DetectScriptCode;
            }
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
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        public string LoadScript(params string[] args)
        {
            return null;
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
