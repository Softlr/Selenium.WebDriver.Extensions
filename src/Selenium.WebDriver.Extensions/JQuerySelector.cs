namespace Selenium.WebDriver.Extensions
{
    /// <summary>
    /// The Selenium selector for jQuery.
    /// </summary>
    public class JQuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        public JQuerySelector(string selector)
        {
            this.Selector = selector;
        }

        /// <summary>
        /// Gets or sets the jQuery selector.
        /// </summary>
        public string Selector { get; set; }
    }
}
