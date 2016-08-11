namespace OpenQA.Selenium.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;

    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/> additional selectors to be used.
    /// </summary>
    /// <remarks>
    /// This class shadows all of the static members of the <see cref="OpenQA.Selenium.By"/>. The reason for that is
    /// to replace the type of the returned selectors to further expand their possibilities.
    /// </remarks>
    [UsedImplicitly]
    public class By : Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching jQuery selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery selector to use as context.</param>
        /// <param name="variable">A variable that has been assigned to jQuery.</param>
        /// <returns>A <see cref="JQuerySelector"/> object the driver can use to find the elements.</returns>
        public static JQuerySelector JQuerySelector(
            string selector, JQuerySelector context = null, string variable = "jQuery") =>
            new JQuerySelector(selector, context, variable);

        /// <summary>
        /// Gets a mechanism to find elements matching Sizzle selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or Sizzle selector to use as context.</param>
        /// <returns>A <see cref="JQuerySelector"/> object the driver can use to find the elements.</returns>
        public static SizzleSelector SizzleSelector(string selector, SizzleSelector context = null) =>
            new SizzleSelector(selector, context);
    }
}
