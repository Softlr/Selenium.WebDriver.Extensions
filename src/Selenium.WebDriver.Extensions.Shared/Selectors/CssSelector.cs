namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The CSS selector.
    /// </summary>
    public class CssSelector : QuerySelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CssSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a CSS selector.</param>
        public CssSelector(string selector)
            : base(selector)
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
