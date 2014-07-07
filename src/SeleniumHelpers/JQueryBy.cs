namespace SeleniumHelpers
{
    /// <summary>
    /// The Selenium selector for jQuery.
    /// </summary>
    public class JQueryBy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQueryBy"/> class.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        public JQueryBy(string selector)
        {
            this.Selector = selector;
        }

        /// <summary>
        /// Gets or sets the jQuery selector.
        /// </summary>
        public string Selector { get; set; }
    }
}
