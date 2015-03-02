namespace Selenium.WebDriver.Extensions.Sizzle
{
    using JetBrains.Annotations;
    
    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/> additional selectors to be used.
    /// </summary>
    /// <remarks>
    /// This class shadows all of the static members of the <see cref="OpenQA.Selenium.By"/>. The reason for that is
    /// to replace the type of the returned selectors to further expand their possibilities.
    /// </remarks>
    [UsedImplicitly]
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching Sizzle selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <returns>A <see cref="SizzleSelector"/> object the driver can use to find the elements.</returns>
        public static SizzleSelector SizzleSelector(
            string selector,
            SizzleSelector context = null)
        {
            return new SizzleSelector(selector, context);
        }
    }
}
