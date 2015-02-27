namespace Selenium.WebDriver.Extensions.Shared
{
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
    }
}
