namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using System.Collections.ObjectModel;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Searches for DOM element using jQuery selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The first DOM element matching given jQuery selector</returns>
        public static WebElement FindElement(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElement(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector limiting the scope of the search to descendants of current 
        /// element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The DOM elements matching given jQuery selector.</returns>
        public static ReadOnlyCollection<WebElement> FindElements(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindElements(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM element using jQuery selector and gets the combined text contents of each element in the 
        /// set of matched elements, including their descendants, or set the text contents of the matched elements.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The combined text contents of each element in the set of matched elements, including their descendants, or 
        /// set the text contents of the matched elements.
        /// </returns>
        public static string FindText(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindText(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the HTML contents of the first element in the set 
        /// of matched elements or set the HTML contents of every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The HTML contents of the first element in the set of matched elements or set the HTML contents of every 
        /// matched element.
        /// </returns>
        public static string FindHtml(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindHtml(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of an attribute for the first element 
        /// in the set of matched elements.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="attributeName">The name of the attribute to get.</param>
        /// <returns>The value of an attribute for the first element in the set of matched elements.</returns>
        public static string FindAttribute(
            this WebElement webElement,
            JQuerySelector by,
            string attributeName)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindAttribute(webElement.CreateSelector(by), attributeName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public static bool? FindProperty(
            this WebElement webElement,
            JQuerySelector by,
            string propertyName)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindProperty<bool?>(webElement.CreateSelector(by), propertyName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <typeparam name="T">The type of the value to be returned.</typeparam>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public static T FindProperty<T>(
            this WebElement webElement,
            JQuerySelector by,
            string propertyName)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindProperty<T>(webElement.CreateSelector(by), propertyName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current value of the first element in the set 
        /// of matched elements.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public static string FindValue(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindValue(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and get the value of a style property for the first 
        /// element in the set of matched elements or set one or more CSS properties for every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The CSS property name.</param>
        /// <returns>
        /// The value of a style property for the first element in the set of matched elements or set one or more CSS 
        /// properties for every matched element.
        /// </returns>
        public static string FindCss(
            this WebElement webElement,
            JQuerySelector by,
            string propertyName)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindCss(webElement.CreateSelector(by), propertyName);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements or set the width of every 
        /// matched element.
        /// </returns>
        public static long? FindWidth(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindWidth(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements or set the height of 
        /// every matched element.
        /// </returns>
        public static long? FindHeight(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindHeight(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner width (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner width (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public static long? FindInnerWidth(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindInnerWidth(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner height (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner height (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public static long? FindInnerHeight(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindInnerHeight(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public static long? FindOuterWidth(
            this WebElement webElement,
            JQuerySelector by,
            bool includeMargin = false)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindOuterWidth(webElement.CreateSelector(by), includeMargin);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public static long? FindOuterHeight(
            this WebElement webElement,
            JQuerySelector by,
            bool includeMargin = false)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindOuterHeight(webElement.CreateSelector(by), includeMargin);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the offset parent.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the offset 
        /// parent.
        /// </returns>
        public static Position? FindPosition(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindPosition(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the document.
        /// </returns>
        public static Position? FindOffset(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindOffset(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current horizontal position of the scroll bar
        /// for the first element in the set of matched elements or set the horizontal position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current horizontal position of the scroll bar for the first element in the set of matched elements or 
        /// set the horizontal position of the scroll bar for every matched element.
        /// </returns>
        public static long? FindScrollLeft(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindScrollLeft(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current vertical position of the scroll bar 
        /// for the first element in the set of matched elements or set the vertical position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current vertical position of the scroll bar for the first element in the set of matched elements or 
        /// set the vertical position of the scroll bar for every matched element.
        /// </returns>
        public static long? FindScrollTop(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindScrollTop(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public static string FindData(
            this WebElement webElement,
            JQuerySelector by,
            string key)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindData(webElement.CreateSelector(by), key);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public static T FindData<T>(
            this WebElement webElement,
            JQuerySelector by,
            string key)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindData<T>(webElement.CreateSelector(by), key);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the number of elements in the jQuery object.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The number of elements in the jQuery object.</returns>
        public static long FindCount(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindCount(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the encoded set of form elements as a string 
        /// for submission.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The encoded set of form elements as a string for submission.</returns>
        public static string FindSerialized(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindSerialized(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the set of form elements as a string representing
        /// encoded array of names and values.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The encoded set of form elements as a string representing array of names and values.</returns>
        public static string FindSerializedArray(
            this WebElement webElement,
            JQuerySelector by)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException("webElement");
            }

            return webElement.WrappedDriver.FindSerializedArray(webElement.CreateSelector(by));
        }

        /// <summary>
        /// Creates the jQuery selector limiting the scope of the search to descendants of current element.
        /// </summary>
        /// <param name="webElement">The web element to base the search on.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The jQuery selector limiting the scope of the search to descendants of current element.</returns>
        private static JQuerySelector CreateSelector(this WebElement webElement, JQuerySelector by)
        {
            var path = webElement.GetPath();
            var rootSelector = new JQuerySelector(path, jQueryVariable: by.JQueryVariable);
            return new JQuerySelector(by.RawSelector, rootSelector, by.JQueryVariable);
        }
    }
}
