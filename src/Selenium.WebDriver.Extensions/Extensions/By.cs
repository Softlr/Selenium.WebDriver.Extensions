namespace Selenium.WebDriver.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using OpenQA.Selenium;

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

        /// <summary>
        /// Gets a mechanism to find elements by their CSS class.
        /// </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By ClassName(string classNameToFind) => OpenQA.Selenium.By.ClassName(classNameToFind);

        /// <summary>
        /// Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
        /// </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By CssSelector(string cssSelectorToFind) =>
            OpenQA.Selenium.By.CssSelector(cssSelectorToFind);

        /// <summary>
        /// Gets a mechanism to find elements by their ID.
        /// </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By Id(string idToFind) => OpenQA.Selenium.By.Id(idToFind);

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By LinkText(string linkTextToFind) => OpenQA.Selenium.By.LinkText(linkTextToFind);

        /// <summary>
        /// Gets a mechanism to find elements by their name.
        /// </summary>
        /// <param name="nameToFind">The name to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By Name(string nameToFind) => OpenQA.Selenium.By.Name(nameToFind);

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By PartialLinkText(string partialLinkTextToFind) =>
            OpenQA.Selenium.By.PartialLinkText(partialLinkTextToFind);

        /// <summary>
        /// Gets a mechanism to find elements by their tag name.
        /// </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By TagName(string tagNameToFind) => OpenQA.Selenium.By.TagName(tagNameToFind);

        /// <summary>
        /// Gets a mechanism to find elements by an XPath query. When searching within a <see cref="IWebElement"/>
        /// using xpath be aware that <see cref="IWebDriver"/> follows standard conventions: a search prefixed with
        /// <c>"//"</c> will search the entire document, not just the children of this current node. Use <c>".//"</c>
        /// to limit your search to the children of this <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "XPath")]
        public static new OpenQA.Selenium.By XPath(string xpathToFind) => OpenQA.Selenium.By.XPath(xpathToFind);
    }
}
