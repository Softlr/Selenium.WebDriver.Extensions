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

            var selector = (NestableSelectorBase)obj;
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
