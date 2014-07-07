namespace SeleniumHelpers
{
    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/>.
    /// </summary>
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Returns the jQuery Selenium selector.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns>The selenium selector.</returns>
        public static JQuerySelector JQuerySelector(string selector)
        {
            return new JQuerySelector(selector);
        }
    }
}
