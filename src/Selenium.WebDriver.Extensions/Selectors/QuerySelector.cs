namespace Selenium.WebDriver.Extensions
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
        public QuerySelector(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            this.Selector = "document.querySelectorAll('" + selector.Replace('\'', '"') + "')";
        }

        /// <summary>
        /// Gets the jQuery selector.
        /// </summary>
        public string Selector { get; private set; }

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
