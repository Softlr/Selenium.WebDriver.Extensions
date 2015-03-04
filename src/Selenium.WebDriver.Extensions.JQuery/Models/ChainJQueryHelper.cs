namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// Additional methods for <see cref="JQuerySelector"/>.
    /// </summary>
    public class ChainJQueryHelper : JQueryHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainJQueryHelper"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="webElement">The web element.</param>
        public ChainJQueryHelper(IWebDriver driver, JQuerySelector selector, WebElement webElement = null)
            : base(driver, webElement)
        {
            this.Selector = selector;
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        public JQuerySelector Selector { get; private set; }

        /// <summary>
        /// Searches for DOM element using jQuery selector and gets the combined text contents of each element in the 
        /// set of matched elements, including their descendants, or set the text contents of the matched elements.
        /// </summary>
        /// <returns>
        /// The combined text contents of each element in the set of matched elements, including their descendants, or 
        /// set the text contents of the matched elements.
        /// </returns>
        public string Text()
        {
            return this.Find<string>("text()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the HTML contents of the first element in the set 
        /// of matched elements or set the HTML contents of every matched element.
        /// </summary>
        /// <returns>
        /// The HTML contents of the first element in the set of matched elements or set the HTML contents of every 
        /// matched element.
        /// </returns>
        public string Html()
        {
            return this.Find<string>("html()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of an attribute for the first element 
        /// in the set of matched elements.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to get.</param>
        /// <returns>The value of an attribute for the first element in the set of matched elements.</returns>
        public string Attribute(string attributeName)
        {
            return this.Find<string>("attr('" + attributeName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public bool? Property(string propertyName)
        {
            return this.Property<bool?>(propertyName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public T Property<T>(string propertyName)
        {
            if (!new[] { typeof(bool?), typeof(long?), typeof(string) }.Contains(typeof(T)))
            {
                throw new TypeArgumentException("Only bool?, long? and string types are supported", "T");
            }

            return this.Find<T>("prop('" + propertyName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current value of the first element in the set 
        /// of matched elements.
        /// </summary>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public string Value()
        {
            return this.Find<string>("val()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and get the value of a style property for the first 
        /// element in the set of matched elements or set one or more CSS properties for every matched element.
        /// </summary>
        /// <param name="propertyName">The CSS property name.</param>
        /// <returns>
        /// The value of a style property for the first element in the set of matched elements or set one or more CSS 
        /// properties for every matched element.
        /// </returns>
        public string Css(string propertyName)
        {
            return this.Find<string>("css('" + propertyName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements or set the width of every 
        /// matched element.
        /// </returns>
        public long? Width()
        {
            return this.Find<long?>("width()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements or set the height of 
        /// every matched element.
        /// </returns>
        public long? Height()
        {
            return this.Find<long?>("height()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner width (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <returns>
        /// The current computed inner width (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public long? InnerWidth()
        {
            return this.Find<long?>("innerWidth()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner height (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <returns>
        /// The current computed inner height (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public long? InnerHeight()
        {
            return this.Find<long?>("innerHeight()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public long? OuterWidth(bool includeMargin = false)
        {
            return this.Find<long?>("outerWidth(" + (includeMargin ? "true" : string.Empty) + ")");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public long? OuterHeight(bool includeMargin = false)
        {
            return this.Find<long?>("outerHeight(" + (includeMargin ? "true" : string.Empty) + ")");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the offset parent.
        /// </summary>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the offset 
        /// parent.
        /// </returns>
        public Position? Position()
        {
            var positionDict = this.Find<IDictionary<string, object>>("position()");
            if (positionDict == null || !positionDict.ContainsKey("top") || !positionDict.ContainsKey("left"))
            {
                return null;
            }

            var top = int.Parse(positionDict["top"].ToString(), CultureInfo.InvariantCulture);
            var left = int.Parse(positionDict["left"].ToString(), CultureInfo.InvariantCulture);
            return new Position(top, left);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the document.
        /// </summary>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the document.
        /// </returns>
        public Position? Offset()
        {
            var offsetDict = this.Find<IDictionary<string, object>>("offset()");
            if (offsetDict == null || !offsetDict.ContainsKey("top") || !offsetDict.ContainsKey("left"))
            {
                return null;
            }

            var top = int.Parse(offsetDict["top"].ToString(), CultureInfo.InvariantCulture);
            var left = int.Parse(offsetDict["left"].ToString(), CultureInfo.InvariantCulture);
            return new Position(top, left);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current horizontal position of the scroll bar
        /// for the first element in the set of matched elements or set the horizontal position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <returns>
        /// The current horizontal position of the scroll bar for the first element in the set of matched elements or 
        /// set the horizontal position of the scroll bar for every matched element.
        /// </returns>
        public long? ScrollLeft()
        {
            return this.Find<long?>("scrollLeft()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current vertical position of the scroll bar 
        /// for the first element in the set of matched elements or set the vertical position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <returns>
        /// The current vertical position of the scroll bar for the first element in the set of matched elements or 
        /// set the vertical position of the scroll bar for every matched element.
        /// </returns>
        public long? ScrollTop()
        {
            return this.Find<long?>("scrollTop()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public string Data(string key)
        {
            return this.Data<string>(key);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public T Data<T>(string key)
        {
            if (!new[] { typeof(bool?), typeof(long?), typeof(string) }.Contains(typeof(T)))
            {
                throw new TypeArgumentException("Only bool?, long? and string types are supported", "T");
            }

            return this.Find<T>("data('" + key + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the number of elements in the jQuery object.
        /// </summary>
        /// <returns>The number of elements in the jQuery object.</returns>
        public long Count()
        {
            return this.Find<long>("length");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the encoded set of form elements as a string 
        /// for submission.
        /// </summary>
        /// <returns>The encoded set of form elements as a string for submission.</returns>
        public string Serialized()
        {
            return this.Find<string>("serialize()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the set of form elements as a string representing
        /// encoded array of names and values.
        /// </summary>
        /// <returns>The encoded set of form elements as a string representing array of names and values.</returns>
        public string SerializedArray()
        {
            return this.Find<string>("serializeArray()", "JSON.stringify({0})");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and checks if any element of the result set has given class
        /// set.
        /// </summary>
        /// <param name="className">The class name.</param>
        /// <returns>The encoded set of form elements as a string representing array of names and values.</returns>
        public bool? HasClass(string className)
        {
            return this.Find<bool?>("hasClass('" + className + "')");
        }

        /// <summary>
        /// Performs a jQuery search on the <see cref="IWebDriver"/> using given <see cref="JQuerySelector"/> selector 
        /// and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="scriptFormat">The format string of the script to be invoked.</param>
        /// <param name="wrapperFormat">
        /// The wrapper format string for the purpose of wrap the jQuery selection result.
        /// </param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// Because of the limitations of the Selenium the only valid types are: <see cref="long"/>, 
        /// <see cref="Nullable{Long}"/>, <see cref="bool"/>, <see cref="Nullable"/>, <see cref="string"/>, 
        /// <see cref="IWebElement"/> and <see cref="IEnumerable{IWebElement}"/>.
        /// Selenium returns different types depending if element has been found or not. If there's a match a
        /// <see cref="ReadOnlyCollection{IWebElement}"/> is returned, but if there are no matches than it will return
        /// an empty <see cref="ReadOnlyCollection{T}"/>.
        /// </remarks>
        public T Find<T>(string scriptFormat, string wrapperFormat = null)
        {
            this.Driver.JQuery().Load();
            return ParseUtil.ParseResult<T>(this.ExecuteScript(this.Selector, scriptFormat, wrapperFormat));
        }

        /// <summary>
        /// Executes jQuery script.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="scriptFormat">The format string of the script to be invoked.</param>
        /// <param name="wrapperFormat">
        /// The wrapper format string for the purpose of wrap the jQuery selection result.
        /// </param>
        /// <returns>Result of invoking the script.</returns>
        private object ExecuteScript(
            JQuerySelector by,
            string scriptFormat,
            string wrapperFormat)
        {
            if (this.WebElement != null)
            {
                by = this.CreateSelector();
            }

            var script = by + "." + scriptFormat;
            if (wrapperFormat != null)
            {
                script = string.Format(CultureInfo.InvariantCulture, wrapperFormat, script);
            }

            script = "return " + script + ";";

            return this.Driver.ExecuteScript<object>(script);
        }

        /// <summary>
        /// Creates the jQuery selector limiting the scope of the search to descendants of current element.
        /// </summary>
        /// <returns>The jQuery selector limiting the scope of the search to descendants of current element.</returns>
        private JQuerySelector CreateSelector()
        {
            var rootSelector = new JQuerySelector(this.WebElement.Path, jQueryVariable: this.Selector.JQueryVariable);
            return new JQuerySelector(this.Selector.RawSelector, rootSelector, this.Selector.JQueryVariable);
        }
    }
}
