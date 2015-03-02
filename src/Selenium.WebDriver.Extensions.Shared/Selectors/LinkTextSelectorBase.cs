namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The link text base selector.
    /// </summary>
    public abstract class LinkTextSelectorBase : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTextSelectorBase"/> class.
        /// </summary>
        /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected LinkTextSelectorBase(string text, string baseElement = "document")
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (baseElement == null)
            {
                throw new ArgumentNullException("baseElement");
            }

            this.BaseElement = baseElement;
            this.RawSelector = text;
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

            var selector = (LinkTextSelectorBase)obj;
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
