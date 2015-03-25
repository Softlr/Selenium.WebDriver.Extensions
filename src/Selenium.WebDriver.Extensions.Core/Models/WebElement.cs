namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Globalization;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    
    /// <summary>
    /// Wrapper on the Selenium <see cref="IWebElement"/> that adds support for selector storage on element level.
    /// </summary>
    public class WebElement : IWebElement
    {
        /// <summary>
        /// The script to get the DOM path.
        /// </summary>
        private const string FindDomPathScript = @"(function(element) {
            'use strict';
            var stack = [], siblingsCount, siblingIndex, i, sibling;
            while (element.parentNode !== null) {
                siblingsCount = 0;
                siblingIndex = 0;
                for (i = 0; i < element.parentNode.childNodes.length; i += 1) {
                    sibling = element.parentNode.childNodes[i];
                    if (sibling.nodeName === element.nodeName) {
                        if (sibling === element) {
                            siblingIndex = siblingsCount;
                        }
                        siblingsCount += 1;
                    }
                }
                if (element.hasAttribute('id') && element.id !== '') {
                    stack.unshift(element.nodeName.toLowerCase() + '#' + element.id);
                } else if (siblingsCount > 1) {
                    stack.unshift(element.nodeName.toLowerCase() + ':eq(' + siblingIndex + ')');
                } else {
                    stack.unshift(element.nodeName.toLowerCase());
                }
                element = element.parentNode;
            }
            stack = stack.slice(1); // removes the html element
            return stack.join(' > ');
        })";

        /// <summary>
        /// The script to get the XPATH.
        /// </summary>
        private const string FindXPathScript = @"(function(element) { 
            'use strict';
            var allNodes = document.getElementsByTagName('*'),
                segments = [],
                uniqueIdCount,
                i,
                sibling,
                part;
            for (null; element && element.nodeType === 1; element = element.parentNode) {
                if (element.hasAttribute('id')) {
                    uniqueIdCount = 0;
                    for (i = 0; i < allNodes.length; i += 1) {
                        if (allNodes[i].hasAttribute('id') && allNodes[i].id === element.id) {
                            uniqueIdCount += 1;
                        }
                        if (uniqueIdCount > 1) {
                            break;
                        }
                    }
                    if (uniqueIdCount === 1) {
                        segments.unshift('id(""' + element.getAttribute('id') + '"")');
                        return segments.join('/');
                    }
                    part = element.localName.toLowerCase() + '[@id=""' + element.getAttribute('id') + '""]';
                    segments.unshift(part);
                } else if (element.hasAttribute('class')) {
                    part = element.localName.toLowerCase()
                        + '[@class=""' + element.getAttribute('class') + '""]';
                    segments.unshift(part);
                } else {
                    for (i = 1, sibling = element.previousSibling; sibling;
                            sibling = sibling.previousSibling) {
                        if (sibling.localName === element.localName) {
                            i += 1;
                        }
                    }
                    segments.unshift(element.localName.toLowerCase() + '[' + i + ']');
                }
            }
            return segments.length ? '/' + segments.join('/') : null;
        })";

        /// <summary>
        /// The DOM path.
        /// </summary>
        private string domPath;

        /// <summary>
        /// The XPATH.
        /// </summary>
        private string xpath;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WebElement"/> class.
        /// </summary>
        /// <param name="webElement">The inner web element.</param>
        /// <param name="selector">The selector used to locate the web element.</param>
        /// <param name="selectorResultIndex">
        /// The index number of the selector result collection that corresponds with the web element. Used when 
        /// selector returns multiple matches to identify the particular match.
        /// </param>
        /// <exception cref="ArgumentNullException">Web element is null or selector is null.</exception>
        public WebElement(IWebElement webElement, ISelector selector, int selectorResultIndex = 0)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            this.InnerElement = webElement;
            this.Selector = selector;
            this.SelectorResultIndex = selectorResultIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElement"/> class.
        /// </summary>
        /// <remarks>This constructor is only used for testing purposes.</remarks>
        // ReSharper disable once UnusedMember.Global
        internal WebElement()
        {
        }

        /// <summary>
        /// Gets the inner element.
        /// </summary>
        protected virtual IWebElement InnerElement { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public virtual ISelector Selector { get; private set; }

        /// <summary>
        /// Gets the selector result index.
        /// </summary>
        protected virtual int SelectorResultIndex { get; private set; }

        /// <summary>
        /// Gets the DOM path for the web element.
        /// </summary>
        public string Path
        {
            get
            {
                return this.domPath ?? (this.domPath = this.FindPath(FindDomPathScript));
            }
        }

        /// <summary>
        /// Gets the XPATH for the web element.
        /// </summary>
        public string XPath
        {
            get
            {
                return this.xpath ?? (this.xpath = this.FindPath(FindXPathScript));
            }
        }

        /// <summary>
        /// Gets the <see cref="IWebDriver"/> used to find this element.
        /// </summary>
        public virtual IWebDriver WrappedDriver
        {
            get
            {
                return ((IWrapsDriver)this.InnerElement).WrappedDriver;
            }
        }

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public virtual string TagName
        {
            get
            {
                return this.InnerElement.TagName;
            }
        }

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace 
        /// collapsed.
        /// </summary>
        public virtual string Text
        {
            get
            {
                return this.InnerElement.Text;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled.
        /// </summary>
        public virtual bool Enabled
        {
            get
            {
                return this.InnerElement.Enabled;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public virtual bool Selected
        {
            get
            {
                return this.InnerElement.Selected;
            }
        }

        /// <summary>
        /// Gets a <see cref="Point"/> object containing the coordinates of the upper-left corner of this element 
        /// relative to the upper-left corner of the page.
        /// </summary>
        public virtual Point Location
        {
            get
            {
                return this.InnerElement.Location;
            }
        }

        /// <summary>
        /// Gets a <see cref="Size"/> object containing the height and width of this element.
        /// </summary>
        public virtual Size Size
        {
            get
            {
                return this.InnerElement.Size;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.
        /// </summary>
        public virtual bool Displayed
        {
            get
            {
                return this.InnerElement.Displayed;
            }
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching <see cref="IWebElement"/> on the current context.</returns>
        public virtual IWebElement FindElement(OpenQA.Selenium.By by)
        {
            return this.InnerElement.FindElement(by);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement">IWebElements</see> within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>
        /// A <see cref="ReadOnlyCollection{IWebElement}"/> of all <see cref="IWebElement">WebElements</see>
        /// matching the current criteria, or an empty list if nothing matches.
        /// </returns>
        public virtual ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By by)
        {
            return this.InnerElement.FindElements(by);
        }

        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public virtual void Clear()
        {
            this.InnerElement.Clear();
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text">The text to type into the element.</param>
        public virtual void SendKeys(string text)
        {
            this.InnerElement.SendKeys(text);
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public virtual void Submit()
        {
            this.InnerElement.Submit();
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public virtual void Click()
        {
            this.InnerElement.Click();
        }

        /// <summary>
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value. Returns a <see langword="null"/> if the value is not set.</returns>
        public virtual string GetAttribute(string attributeName)
        {
            return this.InnerElement.GetAttribute(attributeName);
        }

        /// <summary>
        /// Gets the value of a CSS property of this element.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>The value of the specified CSS property.</returns>
        public virtual string GetCssValue(string propertyName)
        {
            return this.InnerElement.GetCssValue(propertyName);
        }

        /// <summary>
        /// Searches for DOM element using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="selector">The Selenium query selector.</param>
        /// <returns>The first DOM element matching given query selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        public WebElement FindElement(ISelector selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            return this.WrappedDriver.FindElement(selector.Create(this));
        }

        /// <summary>
        /// Searches for DOM elements using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="selector">The Selenium query selector.</param>
        /// <returns>The DOM elements matching given query selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        public ReadOnlyCollection<WebElement> FindElements(ISelector selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            return this.WrappedDriver.FindElements(selector.Create(this));
        }

        /// <summary>
        /// Gets the DOM path for the web element.
        /// </summary>
        /// <param name="findScript">The script to be run on order to find the path.</param>
        /// <returns>The DOM path for the web element.</returns>
        private string FindPath(string findScript)
        {
            var selectorCallScript = string.Format(
                CultureInfo.InvariantCulture,
                this.Selector.CallFormatString,
                this.Selector.Selector,
                this.SelectorResultIndex);

            var script = "return " + findScript + "(" + selectorCallScript + ");";
            return this.WrappedDriver.ExecuteScript<string>(script);
        }
    }
}
