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
        /// Sets the inner text for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="text">The text to be set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Text(string text)
        {
            this.Set("text('" + text + "')");
            return this;
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
        /// Sets the inner HTML for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="htmlString">The HTML string to be set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Html(string htmlString)
        {
            this.Set("html('" + htmlString + "')");
            return this;
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
        /// Sets the attribute value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to set.</param>
        /// <param name="attributeValue">The value of the attribute to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Attribute(string attributeName, string attributeValue)
        {
            this.Set("attr('" + attributeName + "', '" + attributeValue + "')");
            return this;
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
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, string propertyValue)
        {
            this.Set("prop('" + propertyName + "', '" + propertyValue + "')");
            return this;
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, short propertyValue)
        {
            return this.Property(propertyName, Convert.ToDecimal(propertyValue));
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, int propertyValue)
        {
            return this.Property(propertyName, Convert.ToDecimal(propertyValue));
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, long propertyValue)
        {
            return this.Property(propertyName, Convert.ToDecimal(propertyValue));
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, float propertyValue)
        {
            return this.Property(propertyName, Convert.ToDecimal(propertyValue));
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, double propertyValue)
        {
            return this.Property(propertyName, Convert.ToDecimal(propertyValue));
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, decimal propertyValue)
        {
            this.Set("prop('" + propertyName + "', " + propertyValue + ")");
            return this;
        }

        /// <summary>
        /// Sets the property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="propertyValue">The value of the property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Property(string propertyName, bool propertyValue)
        {
            this.Set("prop('" + propertyName + "', " + (propertyValue ? "true" : "false") + ")");
            return this;
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
        /// Sets the value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Value(string value)
        {
            this.Set("val('" + value + "')");
            return this;
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
        /// Sets the CSS property value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to set.</param>
        /// <param name="propertyValue">The value of the CSS property to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Value(string propertyName, string propertyValue)
        {
            this.Set("css('" + propertyName + "', '" + propertyValue + "')");
            return this;
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
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(short value)
        {
            return this.Width(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(int value)
        {
            return this.Width(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(long value)
        {
            return this.Width(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(float value)
        {
            return this.Width(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(double value)
        {
            return this.Width(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Width(decimal value)
        {
            this.Set("width(" + value + ")");
            return this;
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
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(short value)
        {
            return this.Height(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(int value)
        {
            return this.Height(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(long value)
        {
            return this.Height(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(float value)
        {
            return this.Height(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(double value)
        {
            return this.Height(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Height(decimal value)
        {
            this.Set("height(" + value + ")");
            return this;
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
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(short value)
        {
            return this.InnerWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(int value)
        {
            return this.InnerWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(long value)
        {
            return this.InnerWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(float value)
        {
            return this.InnerWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(double value)
        {
            return this.InnerWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerWidth(decimal value)
        {
            this.Set("innerWidth(" + value + ")");
            return this;
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
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(short value)
        {
            return this.InnerHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(int value)
        {
            return this.InnerHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(long value)
        {
            return this.InnerHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(float value)
        {
            return this.InnerHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(double value)
        {
            return this.InnerHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the inner height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the inner height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper InnerHeight(decimal value)
        {
            this.Set("innerHeight(" + value + ")");
            return this;
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
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(short value)
        {
            return this.OuterWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(int value)
        {
            return this.OuterWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(long value)
        {
            return this.OuterWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(float value)
        {
            return this.OuterWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(double value)
        {
            return this.OuterWidth(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer width value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer width to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterWidth(decimal value)
        {
            this.Set("outerWidth(" + value + ")");
            return this;
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
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(short value)
        {
            return this.OuterHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(int value)
        {
            return this.OuterHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(long value)
        {
            return this.OuterHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(float value)
        {
            return this.OuterHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(double value)
        {
            return this.OuterHeight(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the outer height value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the outer height to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper OuterHeight(decimal value)
        {
            this.Set("outerHeight(" + value + ")");
            return this;
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
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(short value)
        {
            return this.ScrollLeft(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(int value)
        {
            return this.ScrollLeft(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(long value)
        {
            return this.ScrollLeft(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(float value)
        {
            return this.ScrollLeft(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(double value)
        {
            return this.ScrollLeft(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll left value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll left to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollLeft(decimal value)
        {
            this.Set("scrollLeft(" + value + ")");
            return this;
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
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(short value)
        {
            return this.ScrollTop(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(int value)
        {
            return this.ScrollTop(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(long value)
        {
            return this.ScrollTop(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(float value)
        {
            return this.ScrollTop(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(double value)
        {
            return this.ScrollTop(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the scroll top value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="value">The value of the scroll top to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ScrollTop(decimal value)
        {
            this.Set("scrollTop(" + value + ")");
            return this;
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
        /// Sets the data value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, string value)
        {
            this.Set("data('" + key + "', '" + value + "')");
            return this;
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, short value)
        {
            return this.Data(key, Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, int value)
        {
            return this.Data(key, Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, long value)
        {
            return this.Data(key, Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, float value)
        {
            return this.Data(key, Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, double value)
        {
            return this.Data(key, Convert.ToDecimal(value));
        }

        /// <summary>
        /// Sets the data value for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, decimal value)
        {
            this.Set("data('" + key + "', " + value + ")");
            return this;
        }

        /// <summary>
        /// Removes the data for the given key for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper RemoveData(string key)
        {
            this.Set("removeData('" + key + ")");
            return this;
        }

        /// <summary>
        /// Sets the data value for all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="key">The name of the data stored.</param>
        /// <param name="value">The value of the data to set.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Data(string key, bool value)
        {
            this.Set("data('" + key + "', " + (value ? "true" : "false") + ")");
            return this;
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
        /// Adds the given class to all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="className">The name of the class to add.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper AddClass(string className)
        {
            this.Set("addClass('" + className + "')");
            return this;
        }

        /// <summary>
        /// Removes the given class to all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="className">The name of the class to remove.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper RemoveClass(string className)
        {
            this.Set("removeClass('" + className + "')");
            return this;
        }

        /// <summary>
        /// Toggles the given class to all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="className">The name of the class to toggle.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ToggleClass(string className)
        {
            this.Set("toggleClass('" + className + "')");
            return this;
        }

        /// <summary>
        /// Toggles the given class to all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <param name="className">The name of the class to toggle.</param>
        /// <param name="state">The value to determine whether the class should be added or removed.</param>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper ToggleClass(string className, bool state)
        {
            this.Set("toggleClass('" + className + "', " + (state ? "true" : "false") + ")");
            return this;
        }

        /// <summary>
        /// Shows all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Show()
        {
            this.Set("show()");
            return this;
        }

        /// <summary>
        /// Hides all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Hide()
        {
            this.Set("hide()");
            return this;
        }

        /// <summary>
        /// Toggles all elements matching current <see cref="JQuerySelector"/>.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper Toggle()
        {
            this.Set("toggle()");
            return this;
        }

        /// <summary>
        /// Shows all elements matching current <see cref="JQuerySelector"/> with sliding motion.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper SlideDown()
        {
            this.Set("slideDown()");
            return this;
        }

        /// <summary>
        /// Hides all elements matching current <see cref="JQuerySelector"/> with sliding motion.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper SlideUp()
        {
            this.Set("slideUp()");
            return this;
        }

        /// <summary>
        /// Toggles all elements matching current <see cref="JQuerySelector"/> with sliding motion.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper SlideToggle()
        {
            this.Set("slideToggle()");
            return this;
        }

        /// <summary>
        /// Shows all elements matching current <see cref="JQuerySelector"/> by fading them to opaque.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper FadeIn()
        {
            this.Set("fadeIn()");
            return this;
        }

        /// <summary>
        /// Hides all elements matching current <see cref="JQuerySelector"/> by fading them to transparent.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper FadeOut()
        {
            this.Set("fadeOut()");
            return this;
        }

        /// <summary>
        /// Shows all elements matching current <see cref="JQuerySelector"/> by fading them to opaque.
        /// </summary>
        /// <returns>The instance of <see cref="ChainJQueryHelper"/> to allow setter chaining.</returns>
        public ChainJQueryHelper FadeToggle()
        {
            this.Set("fadeToggle()");
            return this;
        }

        /// <summary>
        /// Performs a jQuery search on the <see cref="IWebDriver"/> using current <see cref="JQuerySelector"/> 
        /// selector and script format string.
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
        /// Performs a jQuery value set operation on the <see cref="IWebDriver"/> using current 
        /// <see cref="JQuerySelector"/> selector.
        /// </summary>
        /// <param name="script">The script to be executed in order to set the value.</param>
        public void Set(string script)
        {
            this.Driver.JQuery().Load();
            this.ExecuteScript(this.Selector, script, null);
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
