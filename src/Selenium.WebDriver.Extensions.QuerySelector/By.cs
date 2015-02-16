namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using JetBrains.Annotations;
    using QS = Selenium.WebDriver.Extensions.QuerySelector.QuerySelector;
    
    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/> to enable jQuery selector to be used.
    /// </summary>
    /// <remarks>
    /// This class shadows all of the static members of the <see cref="OpenQA.Selenium.By"/>. The reason for that is
    /// to avoid warnings that the code is accessing static members of the base class.
    /// </remarks>
    [UsedImplicitly]
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="QS"/> object the driver can use to find the elements.</returns>
        public static QuerySelector QuerySelector(string selector, string baseElement = "document")
        {
            return new QuerySelector(selector, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <returns>A <see cref="QS"/> object the driver can use to find the elements.</returns>
        public static QuerySelector QuerySelector(string selector, QuerySelector baseSelector)
        {
            return new QuerySelector(selector, baseSelector);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their CSS class.
        /// </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By ClassName(string classNameToFind)
        {
            return OpenQA.Selenium.By.ClassName(classNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
        /// </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By CssSelector(string cssSelectorToFind)
        {
            return OpenQA.Selenium.By.CssSelector(cssSelectorToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their ID.
        /// </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By Id(string idToFind)
        {
            return OpenQA.Selenium.By.Id(idToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By LinkText(string linkTextToFind)
        {
            return OpenQA.Selenium.By.LinkText(linkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their name.
        /// </summary>
        /// <param name="nameToFind">The name to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By Name(string nameToFind)
        {
            return OpenQA.Selenium.By.Name(nameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By PartialLinkText(string partialLinkTextToFind)
        {
            return OpenQA.Selenium.By.PartialLinkText(partialLinkTextToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by their tag name.
        /// </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By TagName(string tagNameToFind)
        {
            return OpenQA.Selenium.By.TagName(tagNameToFind);
        }

        /// <summary>
        /// Gets a mechanism to find elements by an XPath query. When searching within a WebElement using xpath be 
        /// aware that WebDriver follows standard conventions: a search prefixed with "//" will search the entire 
        /// document, not just the children of this current node.  Use ".//" to limit your search to the children of 
        /// this WebElement.
        /// </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="OpenQA.Selenium.By"/> object the driver can use to find the elements.</returns>
        public static new OpenQA.Selenium.By XPath(string xpathToFind)
        {
            return OpenQA.Selenium.By.XPath(xpathToFind);
        }
    }
}
