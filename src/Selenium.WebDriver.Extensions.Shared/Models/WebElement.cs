namespace Selenium.WebDriver.Extensions.Shared
{
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Globalization;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Wrapper on the Selenium <see cref="RemoteWebElement"/> that adds support for selector storage on element level.
    /// </summary>
    public class WebElement : IWebElement
    {
        /// <summary>
        /// The script to get the DOM path.
        /// </summary>
        private const string FindDomPathScript = @"(function(el) {
            var stack = [];
            while (el.parentNode != null) {
                var sibCount = 0;
                var sibIndex = 0;
                for (var i = 0; i < el.parentNode.childNodes.length; i++) {
                    var sib = el.parentNode.childNodes[i];
                    if (sib.nodeName == el.nodeName) {
                        if (sib === el) {
                            sibIndex = sibCount;
                        }
                        sibCount++;
                    }
                }
                if (el.hasAttribute('id') && el.id != ''){
                    stack.unshift(el.nodeName.toLowerCase() + '#' + el.id);
                } else if (sibCount > 1) {
                    stack.unshift(el.nodeName.toLowerCase() + ':eq(' + sibIndex + ')');
                } else {
                    stack.unshift(el.nodeName.toLowerCase());
                }
                el = el.parentNode;
            }

            stack = stack.slice(1); // removes the html element
            return stack.join(' > ');
        })";

        /// <summary>
        /// The script to get the XPATH.
        /// </summary>
        private const string FindXPathScript = @"(function(el) { 
            var allNodes = document.getElementsByTagName('*'); 
            var segs = [];
            for(; el && el.nodeType == 1; el = el.parentNode) 
            { 
                if(el.hasAttribute('id')) { 
                    var uniqueIdCount = 0; 
                    for (var i = 0; i < allNodes.length; i++) { 
                        if (allNodes[i].hasAttribute('id') && allNodes[i].id == el.id) {
                            uniqueIdCount++; 
                        }
                        if (uniqueIdCount > 1) {
                            break; 
                        }
                    }
                
                    if (uniqueIdCount == 1) { 
                        segs.unshift('id(""' + el.getAttribute('id') + '"")'); 
                        return segs.join('/'); 
                    } else { 
                        segs.unshift(el.localName.toLowerCase() + '[@id=""' + el.getAttribute('id') + '""]'); 
                    } 
                } else if (el.hasAttribute('class')) { 
                    segs.unshift(el.localName.toLowerCase() + '[@class=""' + el.getAttribute('class') + '""]'); 
                } else { 
                    for (var i = 1, sib = el.previousSibling; sib; sib = sib.previousSibling) { 
                        if (sib.localName == el.localName) {
                            i++; 
                        }
                    }; 
                    segs.unshift(el.localName.toLowerCase() + '[' + i + ']'); 
                }
            }
            return segs.length ? '/' + segs.join('/') : null; 
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
        public WebElement(IWebElement webElement, ISelector selector, int selectorResultIndex = 0)
        {
            this.InnerElement = webElement;
            this.Selector = selector;
            this.SelectorResultIndex = selectorResultIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElement"/> class.
        /// </summary>
        internal WebElement()
        {
        }

        /// <summary>
        /// Gets the inner element.
        /// </summary>
        public virtual IWebElement InnerElement { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public virtual ISelector Selector { get; private set; }

        /// <summary>
        /// Gets the selector result index.
        /// </summary>
        public virtual int SelectorResultIndex { get; private set; }

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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual IWebDriver WrappedDriver
        {
            get
            {
                return ((RemoteWebElement)this.InnerElement).WrappedDriver;
            }
        }

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual IWebElement FindElement(By by)
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
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return this.InnerElement.FindElements(by);
        }

        /// <summary>
        /// Clears the content of this element.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual void Clear()
        {
            this.InnerElement.Clear();
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text">The text to type into the element.</param>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual void SendKeys(string text)
        {
            this.InnerElement.Clear();
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual void Submit()
        {
            this.InnerElement.Submit();
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual void Click()
        {
            this.InnerElement.Click();
        }

        /// <summary>
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value. Returns a <see langword="null"/> if the value is not set.</returns>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual string GetAttribute(string attributeName)
        {
            return this.InnerElement.GetAttribute(attributeName);
        }

        /// <summary>
        /// Gets the value of a CSS property of this element.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>The value of the specified CSS property.</returns>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public virtual string GetCssValue(string propertyName)
        {
            return this.InnerElement.GetCssValue(propertyName);
        }

        /// <summary>
        /// Searches for DOM element using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="by">The Selenium query selector.</param>
        /// <returns>The first DOM element matching given query selector</returns>
        public WebElement FindElement(ISelector by)
        {
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            return this.WrappedDriver.FindElement(by.Create(this));
        }

        /// <summary>
        /// Searches for DOM elements using query selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="by">The Selenium query selector.</param>
        /// <returns>The DOM elements matching given query selector.</returns>
        public ReadOnlyCollection<WebElement> FindElements(ISelector by)
        {
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            return this.WrappedDriver.FindElements(by.Create(this));
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
