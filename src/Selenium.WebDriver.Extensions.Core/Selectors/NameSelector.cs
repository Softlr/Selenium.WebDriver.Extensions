namespace Selenium.WebDriver.Extensions.Core
{
    /// <summary>
    /// The name selector.
    /// </summary>
    public class NameSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassNameSelector"/> class.
        /// </summary>
        /// <param name="name">A string containing a DOM element class name.</param>
        public NameSelector(string name)
            : base("[name='" + name + "']")
        {
        }
    }
}
