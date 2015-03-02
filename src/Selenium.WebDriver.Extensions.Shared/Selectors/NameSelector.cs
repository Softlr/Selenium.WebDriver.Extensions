namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The name selector.
    /// </summary>
    public class NameSelector : QuerySelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameSelector"/> class.
        /// </summary>
        /// <param name="name">A string containing a DOM element class name.</param>
        public NameSelector(string name)
            : base("[name='" + name + "']")
        {
        }
    }
}
