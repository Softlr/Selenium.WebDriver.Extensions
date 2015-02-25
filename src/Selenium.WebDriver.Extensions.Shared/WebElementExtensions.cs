namespace Selenium.WebDriver.Extensions.Shared
{
    using System.Globalization;
    
    /// <summary>
    /// The web element extensions.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Gets the DOM path for the web element.
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <returns>The DOM path for the web element.</returns>
        public static string GetPath(this WebElement webElement)
        {
            const string FindDomPathScript = @"var getDomPath = function(el) {
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
             };";

            var selectorCallScript = string.Format(
                CultureInfo.InvariantCulture,
                webElement.Selector.CallFormatString,
                webElement.Selector.Selector,
                webElement.SelectorResultIndex);

            var script = string.Format(
                CultureInfo.InvariantCulture,
                "{0} return getDomPath({1});",
                FindDomPathScript,
                selectorCallScript);
            return webElement.WrappedDriver.ExecuteScript<string>(script);
        }
    }
}
