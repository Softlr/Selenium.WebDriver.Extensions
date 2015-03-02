namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The XPATH selector.
    /// </summary>
    public class XPathSelector : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XPathSelector"/> class.
        /// </summary>
        /// <param name="xpath">The XPATH to locate.</param>
        public XPathSelector(string xpath)
            : base(xpath)
        {
            if (xpath == null)
            {
                throw new ArgumentNullException("xpath");
            }

            this.Selector = @"(function(path) {
                return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null)
                    .singleNodeValue;
                })('" + xpath + "')";
        }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(JavaScriptRunner);
            }
        }
    }
}
