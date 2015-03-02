namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The tag name selector.
    /// </summary>
    public class TagNameSelector : QuerySelectorBase
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
