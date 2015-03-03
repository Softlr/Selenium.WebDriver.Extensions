namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The selector base.
    /// </summary>
    public abstract class NestableSelectorBase : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestableSelectorBase"/> class.
        /// </summary>
        /// <param name="rawSelector">The raw selector.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected NestableSelectorBase(string rawSelector, string baseElement)
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
