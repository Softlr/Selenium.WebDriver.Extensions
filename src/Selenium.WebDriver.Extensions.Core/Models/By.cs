namespace Selenium.WebDriver.Extensions.Core
{
    using System;
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
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>
        /// A <see cref="Selenium.WebDriver.Extensions.Core.QuerySelector"/> object the driver can use to find the
        /// elements.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static QuerySelector QuerySelector(string selector, string baseElement = "document")
        {
            return new QuerySelector(selector, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <returns>
        /// A <see cref="Selenium.WebDriver.Extensions.Core.QuerySelector"/> object the driver can use to find the
        /// elements.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public static QuerySelector QuerySelector(string selector, ISelector baseSelector)
        {
            return new QuerySelector(selector, baseSelector);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their CSS class.
        /// </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="ClassNameSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new ClassNameSelector ClassName(string classNameToFind)
        {
            return new ClassNameSelector(classNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
        /// </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="CssSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new CssSelector CssSelector(string cssSelectorToFind)
        {
            return new CssSelector(cssSelectorToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their ID.
        /// </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>An <see cref="IdSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new IdSelector Id(string idToFind)
        {
            return new IdSelector(idToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="LinkTextSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Text is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Text is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new LinkTextSelector LinkText(string linkTextToFind)
        {
            return new LinkTextSelector(linkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="LinkTextSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Text is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Text is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static LinkTextSelector LinkText(string linkTextToFind, string baseElement)
        {
            return new LinkTextSelector(linkTextToFind, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their name.
        /// </summary>
        /// <param name="nameToFind">The name to find.</param>
        /// <returns>A <see cref="NameSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new NameSelector Name(string nameToFind)
        {
            return new NameSelector(nameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="PartialLinkTextSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Text is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Text is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new PartialLinkTextSelector PartialLinkText(string partialLinkTextToFind)
        {
            return new PartialLinkTextSelector(partialLinkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="LinkTextSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Text is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Text is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static PartialLinkTextSelector PartialLinkText(string partialLinkTextToFind, string baseElement)
        {
            return new PartialLinkTextSelector(partialLinkTextToFind, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their tag name.
        /// </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="TagNameSelector"/> selector object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public static new TagNameSelector TagName(string tagNameToFind)
        {
            return new TagNameSelector(tagNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by an XPath query. When searching within a WebElement using xpath be
        /// aware that WebDriver follows standard conventions: a search prefixed with "//" will search the entire
        /// document, not just the children of this current node.  Use ".//" to limit your search to the children of
        /// this WebElement.
        /// </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="XPathSelector"/> object the driver can use to find the elements.</returns>
        /// <exception cref="ArgumentNullException">XPATH is null.</exception>
        /// <exception cref="ArgumentException">XPATH is empty.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "XPath")]
        public static new XPathSelector XPath(string xpathToFind)
        {
            return new XPathSelector(xpathToFind);
        }
    }
}
