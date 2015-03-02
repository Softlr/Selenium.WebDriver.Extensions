namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The tag name selector.
    /// </summary>
    public class TagNameSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagNameSelector"/> class.
        /// </summary>
        /// <param name="tagName">A string containing a DOM tag name.</param>
        public TagNameSelector(string tagName)
            : base(tagName)
        {
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
