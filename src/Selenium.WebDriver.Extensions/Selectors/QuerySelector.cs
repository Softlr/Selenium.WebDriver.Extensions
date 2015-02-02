namespace Selenium.WebDriver.Extensions
{
    using System;

    /// <summary>
    /// The Selenium JavaScript query selector.
    /// </summary>
    public class QuerySelector : ISelector
    {
        /// <summary>
        /// The JavaScript to check if query selector is supported by the browser.
        /// </summary>
        private const string Script = "return typeof document.querySelectorAll === 'function';";

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
                return Script;
            }
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
