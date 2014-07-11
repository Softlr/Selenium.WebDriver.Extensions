namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Checks if jQuery is loaded and loads it if needed.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="version">The version of jQuery to load if it's not already loaded on the tested page.</param>
        /// <param name="timeout">The timeout value for the jQuery load.</param>
        public static void LoadJQuery(this IWebDriver driver, string version = "latest", TimeSpan? timeout = null)
        {
            var javaScriptDriver = (IJavaScriptExecutor)driver;

            const string CheckScript = "return typeof window.jQuery !== 'function'";
            var exists = (bool)javaScriptDriver.ExecuteScript(CheckScript);
            if (exists)
            {
                return;
            }

            var path = string.Format(
                CultureInfo.InvariantCulture,
                "jq.src = '//code.jquery.com/jquery-{0}.min.js';",
                version);
            var loadScript = string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}{2}",
                "var jq = document.createElement('script');",
                path,
                "document.getElementsByTagName('head')[0].appendChild(jq);");
            javaScriptDriver.ExecuteScript(loadScript);
            var wait = new WebDriverWait(driver, timeout ?? TimeSpan.FromSeconds(3));
            wait.Until(d => javaScriptDriver.ExecuteScript(CheckScript));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The DOM elements matching given jQuery selector.</returns>
        public static IWebElement FindElement(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<IWebElement>(by, "return {0}.get(0);");
            if (result == null)
            {
                throw new NoSuchElementException("No element found with jQuery command: " + by.Selector);
            }

            return result;
        }

        /// <summary>
        /// Searches for DOM element using jQuery selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The first DOM element matching given jQuery selector</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<ReadOnlyCollection<IWebElement>>(by, "return {0}.get();");
            return result ?? new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        /// <summary>
        /// Searches for DOM element using jQuery selector and gets the combined text contents of each element in the 
        /// set of matched elements, including their descendants, or set the text contents of the matched elements.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The combined text contents of each element in the set of matched elements, including their descendants, or 
        /// set the text contents of the matched elements.
        /// </returns>
        public static string FindText(
            this IWebDriver driver,
            JQuerySelector by)
        {
            return driver.Find<string>(by, "return {0}.text();");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the HTML contents of the first element in the set 
        /// of matched elements or set the HTML contents of every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The HTML contents of the first element in the set of matched elements or set the HTML contents of every 
        /// matched element.
        /// </returns>
        public static string FindHtml(
            this IWebDriver driver,
            JQuerySelector by)
        {
            return driver.Find<string>(by, "return {0}.html();");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of an attribute for the first element 
        /// in the set of matched elements.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="attributeName">The name of the attribute to get.</param>
        /// <returns>The value of an attribute for the first element in the set of matched elements.</returns>
        public static string FindAttribute(
            this IWebDriver driver,
            JQuerySelector by,
            string attributeName)
        {
            var formatString = string.Format(CultureInfo.InvariantCulture, "return {{0}}.attr('{0}');", attributeName);
            return driver.Find<string>(by, formatString);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the value of a property for the first element in 
        /// the set of matched elements.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public static string FindProperty(
            this IWebDriver driver,
            JQuerySelector by,
            string propertyName)
        {
            var formatString = string.Format(CultureInfo.InvariantCulture, "return {{0}}.prop('{0}');", propertyName);
            return driver.Find<string>(by, formatString);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current value of the first element in the set 
        /// of matched elements.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public static string FindValue(
            this IWebDriver driver,
            JQuerySelector by)
        {
            return driver.Find<string>(by, "return {0}.val();");
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and get the value of a style property for the first 
        /// element in the set of matched elements or set one or more CSS properties for every matched element.
        /// </summary>
        /// <typeparam name="T">The type of the value returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="propertyName">The CSS property name.</param>
        /// <returns>
        /// The value of a style property for the first element in the set of matched elements or set one or more CSS 
        /// properties for every matched element.
        /// </returns>
        public static T FindCss<T>(
            this IWebDriver driver,
            JQuerySelector by,
            string propertyName) where T : class
        {
            var formatString = string.Format(CultureInfo.InvariantCulture, "return {{0}}.css('{0}');", propertyName);
            return driver.Find<T>(by, formatString);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements or set the width of every 
        /// matched element.
        /// </returns>
        public static int FindWidth(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.width();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements or set the width of every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements or set the height of 
        /// every matched element.
        /// </returns>
        public static int FindHeight(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.height();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner width (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner width (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public static int FindInnerWidth(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.innerWidth();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed inner height (including 
        /// padding but not border) for the first element in the set of matched elements or set the inner width of 
        /// every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current computed inner height (including padding but not border) for the first element in the set of 
        /// matched elements or set the inner width of every matched element.
        /// </returns>
        public static int FindInnerHeight(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.innerHeight();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed width for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed width for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public static int FindOuterWidth(
            this IWebDriver driver,
            JQuerySelector by,
            bool includeMargin = false)
        {
            var formatString = string.Format(
                CultureInfo.InvariantCulture,
                "return {{0}}.outerWidth({0});",
                includeMargin ? "true" : string.Empty);
            var result = driver.Find<string>(by, formatString);
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current computed height for the first element 
        /// in the set of matched elements, including padding and border.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="includeMargin">
        /// A flag indicating whether to include the element's margin in the calculation.
        /// </param>
        /// <returns>
        /// The current computed height for the first element in the set of matched elements, including padding and 
        /// border.
        /// </returns>
        public static int FindOuterHeight(
            this IWebDriver driver,
            JQuerySelector by,
            bool includeMargin = false)
        {
            var formatString = string.Format(
                CultureInfo.InvariantCulture,
                "return {{0}}.outerHeight({0});",
                includeMargin ? "true" : string.Empty);
            var result = driver.Find<string>(by, formatString);
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the offset parent.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the offset 
        /// parent.
        /// </returns>
        public static Position FindPosition(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var top = driver.Find<string>(by, "return {0}.position().top;");
            var left = driver.Find<string>(by, "return {0}.position().left;");
            return new Position(
                int.Parse(top, CultureInfo.InvariantCulture), 
                int.Parse(left, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current coordinates of the first element in 
        /// the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current coordinates of the first element in the set of matched elements, relative to the document.
        /// </returns>
        public static Position FindOffset(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var top = driver.Find<string>(by, "return {0}.offset().top;");
            var left = driver.Find<string>(by, "return {0}.offset().left;");
            return new Position(
                int.Parse(top, CultureInfo.InvariantCulture),
                int.Parse(left, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current horizontal position of the scroll bar
        /// for the first element in the set of matched elements or set the horizontal position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current horizontal position of the scroll bar for the first element in the set of matched elements or 
        /// set the horizontal position of the scroll bar for every matched element.
        /// </returns>
        public static int FindScrollLeft(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.scrollLeft();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and gets the current vertical position of the scroll bar 
        /// for the first element in the set of matched elements or set the vertical position of the scroll bar for 
        /// every matched element.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <returns>
        /// The current vertical position of the scroll bar for the first element in the set of matched elements or 
        /// set the vertical position of the scroll bar for every matched element.
        /// </returns>
        public static int FindScrollTop(
            this IWebDriver driver,
            JQuerySelector by)
        {
            var result = driver.Find<string>(by, "return {0}.scrollTop();");
            return int.Parse(result, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Searches for DOM elements using jQuery selector and returns the value at the named data store for the 
        /// first element in the jQuery collection, as set by <c>data(name, value)</c> or by an HTML5 data-* 
        /// attribute.
        /// </summary>
        /// <typeparam name="T">The type of the value returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="key">The name of the data stored.</param>
        /// <returns>
        /// The value at the named data store for the first element in the jQuery collection, as set by 
        /// <c>data(name, value)</c> or by an HTML5 data-* attribute.
        /// </returns>
        public static T FindData<T>(
            this IWebDriver driver,
            JQuerySelector by,
            string key) where T : class
        {
            var formatString = string.Format(CultureInfo.InvariantCulture, "return {{0}}.data('{0}');", key);
            return driver.Find<T>(by, formatString);
        }

        /// <summary>
        /// Performs a jQuery search on the <see cref="IWebDriver"/> using given <see cref="JQuerySelector"/> selector 
        /// and script format string.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="by">The Selenium jQuery selector.</param>
        /// <param name="scriptFormat">The format string of the script to be invoked.</param>
        /// <returns>Result of invoking the script.</returns>
        private static T Find<T>(this IWebDriver driver, JQuerySelector by, string scriptFormat) where T : class 
        {
            if (by == null)
            {
                throw new ArgumentNullException("by");
            }

            driver.LoadJQuery();

            var javaScriptDriver = (IJavaScriptExecutor)driver;
            var script = string.Format(CultureInfo.InvariantCulture, scriptFormat, by.Selector);
            return javaScriptDriver.ExecuteScript(script) as T;
        }
    }
}
