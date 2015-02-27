namespace Selenium.WebDriver.Extensions.Core
{
    /// <summary>
    /// The CSS selector.
    /// </summary>
    public class CssSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CssSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a CSS selector.</param>
        public CssSelector(string selector)
            : base(selector)
        {
        }
    }
}
