namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The tag name selector.
    /// </summary>
    public class TagNameSelector : QuerySelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CssSelector"/> class.
        /// </summary>
        /// <param name="tagName">A string containing a DOM tag name.</param>
        public TagNameSelector(string tagName)
            : base(tagName)
        {
        }
    }
}
