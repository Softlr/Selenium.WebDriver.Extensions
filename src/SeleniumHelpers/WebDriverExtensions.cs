namespace SeleniumHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Web driver extensions.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Searches for DOM elements using jQuery selector.
        /// </summary>
        /// <param name="driver">The Selenium web driver.</param>
        /// <param name="selector">The jQuery selector.</param>
        /// <param name="version">The version of jQuery to load if it's not already loaded on the tested page.</param>
        /// <returns>The DOM elements matching given jQuery selector.</returns>
        public static IEnumerable<IWebElement> FindElementsByJQuerySelector(
            this IWebDriver driver, 
            string selector,
            string version = "1.11.0")
        {
            var javaScriptDriver = (IJavaScriptExecutor)driver;
            const string CheckScript = "return typeof window.jQuery !== 'function'";
            var exists = (bool)javaScriptDriver.ExecuteScript(CheckScript);
            if (exists)
            {
                var path = string.Format(
                    CultureInfo.InvariantCulture,
                    "jq.src = '//ajax.googleapis.com/ajax/libs/jquery/{0}/jquery.min.js';", 
                    version); 
                var loadScript = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}{1}{2}", 
                    "var jq = document.createElement('script');",
                    path,
                    "document.getElementsByTagName('head')[0].appendChild(jq);");
                javaScriptDriver.ExecuteScript(loadScript);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                wait.Until(d =>
                {
                    return ((IJavaScriptExecutor)d).ExecuteScript(CheckScript);
                });
            }

            var script = string.Format(CultureInfo.InvariantCulture, "return jQuery('{0}').get();", selector);
            return (IEnumerable<IWebElement>)javaScriptDriver.ExecuteScript(script);
        }
    }
}
