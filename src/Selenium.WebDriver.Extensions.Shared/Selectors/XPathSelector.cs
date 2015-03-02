namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The XPATH selector.
    /// </summary>
    public class XPathSelector : ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XPathSelector"/> class.
        /// </summary>
        /// <param name="xpath">The XPATH to locate.</param>
        public XPathSelector(string xpath)
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            this.RawSelector = xpath;
            this.Selector = @"(function(path) {
                return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null)
                    .singleNodeValue;
                })('" + xpath + "')";
        }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public string RawSelector { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public string Selector { get; private set; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        public string CallFormatString
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
