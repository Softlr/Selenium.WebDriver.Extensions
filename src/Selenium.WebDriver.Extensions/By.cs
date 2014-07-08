namespace Selenium.WebDriver.Extensions
{
    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/>.
    /// </summary>
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching jQuery selector.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns>A <see cref="JQuerySelector"/> object the driver can use to find the elements.</returns>
        public static JQuerySelector JQuerySelector(string selector)
        {
            return new JQuerySelector(selector);
        }
    }
}
