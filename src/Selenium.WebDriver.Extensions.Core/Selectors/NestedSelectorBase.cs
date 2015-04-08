namespace Selenium.WebDriver.Extensions.Core
{
    /// <summary>
    /// The nested selector base.
    /// </summary>
    public abstract class NestedSelectorBase : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedSelectorBase"/> class.
        /// </summary>
        /// <param name="rawSelector">The raw selector.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected NestedSelectorBase(string rawSelector, string baseElement)
            : base(rawSelector)
        {
            this.BaseElement = baseElement;
        }

        /// <summary>
        /// Gets the base element for the query selector.
        /// </summary>
        public string BaseElement { get; private set; }
    }
}
