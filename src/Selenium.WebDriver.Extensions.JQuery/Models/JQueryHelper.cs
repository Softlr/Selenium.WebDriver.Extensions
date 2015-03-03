namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// Additional methods for <see cref="JQuerySelector"/>.
    /// </summary>
    public class JQueryHelper : HelperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQueryHelper"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="webElement">The web element.</param>
        public JQueryHelper(IWebDriver driver, WebElement webElement = null)
            : base(driver, webElement)
        {
        }

        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="version">
        /// The version of jQuery to load if it's not already loaded on the tested page. It must be the full version
        /// number matching one of the versions at <see href="https://code.jquery.com/jquery"/>. The default value will
        /// get the latest stable version.
        /// </param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(string version = "latest", TimeSpan? timeout = null)
        {
            this.Driver.LoadExternalLibrary(
                new JQueryLoader(),
                new Uri("https://code.jquery.com/jquery-" + version + ".min.js"),
                timeout);
        }

        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="jQueryUri">The URI of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        /// <remarks>
        /// If jQuery is already loaded on a page this method will do nothing, even if the loaded version and version
        /// requested by invoking this method have different versions.
        /// </remarks>
        public void Load(Uri jQueryUri, TimeSpan? timeout = null)
        {
            this.Driver.LoadExternalLibrary(new JQueryLoader(), jQueryUri, timeout);
        }

        /// <summary>
        /// Searches for DOM element using jQuery selector and gets the combined text contents of each element in the 
        /// set of matched elements, including their descendants, or set the text contents of the matched elements.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The combined text contents of each element in the set of matched elements, including their descendants, or 
        /// set the text contents of the matched elements.
        /// </returns>
        public string Text(JQuerySelector by)
        {
            return this.Find<string>(by, "text()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the HTML contents of the first element in the set 
        /// of matched elements or set the HTML contents of every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The HTML contents of the first element in the set of matched elements or set the HTML contents of every 
        /// matched element.
        /// </returns>
        public string Html(JQuerySelector by)
        {
            return this.Find<string>(by, "html()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of an attribute for the first element 
        /// in the set of matched elements.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="attributeName">The name of the attribute to get.</param>
        /// <returns>The value of an attribute for the first element in the set of matched elements.</returns>
        public string Attribute(JQuerySelector by, string attributeName)
        {
            return this.Find<string>(by, "attr('" + attributeName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public bool? Property(JQuerySelector by, string propertyName)
        {
            return this.Property<bool?>(by, propertyName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public T Property<T>(JQuerySelector by, string propertyName)
        {
            if (!new[] { typeof(bool?), typeof(long?), typeof(string) }.Contains(typeof(T)))
            {
                throw new TypeArgumentException("Only bool?, long? and string types are supported", "T");
            }

            return this.Find<T>(by, "prop('" + propertyName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current value of the first element in the set 
        /// of matched elements.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public string Value(JQuerySelector by)
        {
            return this.Find<string>(by, "val()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and get the value of a style property for the first 
        /// element in the set of matched elements or set one or more CSS properties for every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The CSS property name.</param>
        /// <returns>
        /// The value of a style property for the first element in the set of matched elements or set one or more CSS 
        /// properties for every matched element.
        /// </returns>
        public string Css(JQuerySelector by, string propertyName)
        {
            return this.Find<string>(by, "css('" + propertyName + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements or set the width of every 
        /// matched element.
        /// </returns>
        public long? Width(JQuerySelector by)
        {
            return this.Find<long?>(by, "width()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements or set the height of 
        /// every matched element.
        /// </returns>
        public long? Height(JQuerySelector by)
        {
            return this.Find<long?>(by, "height()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner width (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner width (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public long? InnerWidth(JQuerySelector by)
        {
            return this.Find<long?>(by, "innerWidth()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner height (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner height (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public long? InnerHeight(JQuerySelector by)
        {
            return this.Find<long?>(by, "innerHeight()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public long? OuterWidth(JQuerySelector by, bool includeMargin = false)
        {
            return this.Find<long?>(by, "outerWidth(" + (includeMargin ? "true" : string.Empty) + ")");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public long? OuterHeight(JQuerySelector by, bool includeMargin = false)
        {
            return this.Find<long?>(by, "outerHeight(" + (includeMargin ? "true" : string.Empty) + ")");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the offset parent.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the offset 
        /// parent.
        /// </returns>
        public Position? Position(JQuerySelector by)
        {
            var positionDict = this.Find<IDictionary<string, object>>(by, "position()");
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
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the document.
        /// </returns>
        public Position? Offset(JQuerySelector by)
        {
            var offsetDict = this.Find<IDictionary<string, object>>(by, "offset()");
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
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current horizontal position of the scroll bar for the first element in the set of matched elements or 
        /// set the horizontal position of the scroll bar for every matched element.
        /// </returns>
        public long? ScrollLeft(JQuerySelector by)
        {
            return this.Find<long?>(by, "scrollLeft()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current vertical position of the scroll bar 
        /// for the first element in the set of matched elements or set the vertical position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current vertical position of the scroll bar for the first element in the set of matched elements or 
        /// set the vertical position of the scroll bar for every matched element.
        /// </returns>
        public long? ScrollTop(JQuerySelector by)
        {
            return this.Find<long?>(by, "scrollTop()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public string Data(JQuerySelector by, string key)
        {
            return this.Data<string>(by, key);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public T Data<T>(JQuerySelector by, string key)
        {
            if (!new[] { typeof(bool?), typeof(long?), typeof(string) }.Contains(typeof(T)))
            {
                throw new TypeArgumentException("Only bool?, long? and string types are supported", "T");
            }

            return this.Find<T>(by, "data('" + key + "')");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the number of elements in the jQuery object.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The number of elements in the jQuery object.</returns>
        public long Count(JQuerySelector by)
        {
            return this.Find<long>(by, "length");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the encoded set of form elements as a string 
        /// for submission.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The encoded set of form elements as a string for submission.</returns>
        public string Serialized(JQuerySelector by)
        {
            return this.Find<string>(by, "serialize()");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the set of form elements as a string representing
        /// encoded array of names and values.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The encoded set of form elements as a string representing array of names and values.</returns>
        public string SerializedArray(JQuerySelector by)
        {
            return this.Find<string>(by, "serializeArray()", "JSON.stringify({0})");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and checks if any element of the result set has given class
        /// set.
        /// </summary>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="className">The class name.</param>
        /// <returns>The encoded set of form elements as a string representing array of names and values.</returns>
        public bool? HasClass(JQuerySelector by, string className)
        {
            return this.Find<bool?>(by, "hasClass('" + className + "')");
        }

        /// <summary>
        /// Performs a jQuery search on the <see cref="IWebDriver"/> using given <see cref="JQuerySelector"/> selector 
        /// and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="by">The Selenium jQuery selector.</param>
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
        public T Find<T>(JQuerySelector by,
            string scriptFormat,
            string wrapperFormat = null)
        {
            this.Driver.JQuery().Load();
            return ParseUtil.ParseResult<T>(this.ExecuteScript(by, scriptFormat, wrapperFormat));
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
                by = this.CreateSelector(by);
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
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The jQuery selector limiting the scope of the search to descendants of current element.</returns>
        private JQuerySelector CreateSelector(JQuerySelector by)
        {
            var rootSelector = new JQuerySelector(this.WebElement.Path, jQueryVariable: by.JQueryVariable);
            return new JQuerySelector(by.RawSelector, rootSelector, by.JQueryVariable);
        }
    }
}
