namespace Selenium.WebDriver.Extensions.Sizzle
{
    using JetBrains.Annotations;
    using Selenium.WebDriver.Extensions.Shared;

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

        /// <summary>
        /// Gets a mechanism to find elements by their CSS class.
        /// </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="ClassNameSelector"/> object the driver can use to find the elements.</returns>
        public static new ClassNameSelector ClassName(string classNameToFind)
        {
            return Shared.By.ClassName(classNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
        /// </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="CssSelector"/> object the driver can use to find the elements.</returns>
        public static new CssSelector CssSelector(string cssSelectorToFind)
        {
            return Shared.By.CssSelector(cssSelectorToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their ID.
        /// </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>An <see cref="IdSelector"/> object the driver can use to find the elements.</returns>
        public static new IdSelector Id(string idToFind)
        {
            return Shared.By.Id(idToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="LinkTextSelector"/> object the driver can use to find the elements.</returns>
        public static new LinkTextSelector LinkText(string linkTextToFind)
        {
            return Shared.By.LinkText(linkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="LinkTextSelector"/> object the driver can use to find the elements.</returns>
        public static LinkTextSelector LinkText(string linkTextToFind, string baseElement)
        {
            return Shared.By.LinkText(linkTextToFind, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their name.
        /// </summary>
        /// <param name="nameToFind">The name to find.</param>
        /// <returns>A <see cref="NameSelector"/> object the driver can use to find the elements.</returns>
        public static new NameSelector Name(string nameToFind)
        {
            return Shared.By.Name(nameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="PartialLinkTextSelector"/> object the driver can use to find the elements.</returns>
        public static new PartialLinkTextSelector PartialLinkText(string partialLinkTextToFind)
        {
            return Shared.By.PartialLinkText(partialLinkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="PartialLinkTextSelector"/> object the driver can use to find the elements.</returns>
        public static PartialLinkTextSelector PartialLinkText(string partialLinkTextToFind, string baseElement)
        {
            return Shared.By.PartialLinkText(partialLinkTextToFind, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their tag name.
        /// </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="TagNameSelector"/> selector object the driver can use to find the elements.</returns>
        public static new TagNameSelector TagName(string tagNameToFind)
        {
            return Shared.By.TagName(tagNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by an XPath query. When searching within a WebElement using xpath be 
        /// aware that WebDriver follows standard conventions: a search prefixed with "//" will search the entire 
        /// document, not just the children of this current node.  Use ".//" to limit your search to the children of 
        /// this WebElement.
        /// </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="XPathSelector"/> object the driver can use to find the elements.</returns>
        public static new XPathSelector XPath(string xpathToFind)
        {
            return Shared.By.XPath(xpathToFind);
        }
    }
}
