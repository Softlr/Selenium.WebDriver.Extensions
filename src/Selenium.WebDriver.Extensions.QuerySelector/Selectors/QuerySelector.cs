namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public class QuerySelector : QuerySelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        public QuerySelector(string selector, string baseElement = "document")
            : base(selector, baseElement)
        {
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
            : base(selector, baseSelector)
        {
        }
    }
}
