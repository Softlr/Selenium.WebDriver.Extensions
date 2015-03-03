namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The selector base.
    /// </summary>
    public abstract class SelectorBase : ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorBase"/> class.
        /// </summary>
        /// <param name="rawSelector">The raw selector.</param>
        protected SelectorBase(string rawSelector)
        {
            this.RawSelector = rawSelector;
        }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public abstract Type RunnerType { get; }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public virtual string RawSelector { get; private set; }

        /// <summary>
        /// Gets or sets the selector.
        /// </summary>
        public virtual string Selector { get; protected set; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        public virtual string CallFormatString
        {
            get
            {
                return "{0}[{1}]";
            }
        }

        /// <summary>
        /// Creates a new selector using given selector as a root.
        /// </summary>
        /// <param name="root">A web element to be used as a root.</param>
        /// <returns>A new selector.</returns>
        public abstract ISelector Create(WebElement root);

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
