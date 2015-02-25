namespace Selenium.WebDriver.Extensions.Shared
{
    using System.Collections.ObjectModel;
    using System.Drawing;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    /// <summary>
    /// Wrapper on the Selenium <see cref="RemoteWebElement"/> that adds support for selector storage on element level.
    /// </summary>
    public class WebElement : IWebElement
    {
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
        public string TagName
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
        public string Text
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
        public bool Enabled
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
        public bool Selected
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
        public Point Location
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
        public Size Size
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
        public bool Displayed
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
        public IWebElement FindElement(By by)
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
        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return this.InnerElement.FindElements(by);
        }

        /// <summary>
        /// Clears the content of this element.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public void Clear()
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
        public void SendKeys(string text)
        {
            this.InnerElement.Clear();
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public void Submit()
        {
            this.InnerElement.Submit();
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
#if !NET35
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        public void Click()
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
        public string GetAttribute(string attributeName)
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
        public string GetCssValue(string propertyName)
        {
            return this.InnerElement.GetCssValue(propertyName);
        }
    }
}
