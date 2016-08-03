namespace OpenQA.Selenium
{
    /// <summary>
    /// The external library loader base.
    /// </summary>
    internal static class JavaScriptSnippets
    {
        /// <summary>
        /// Gets the JavaScript to load jQuery.
        /// </summary>
        public static string LoadScriptCode { get; } = @"(function(source) {
            'use strict';
            var script = document.createElement('script');
            script.src = source;
            document.getElementsByTagName('body')[0].appendChild(script);
        })";

        /// <summary>
        /// Gets the JavaScript to check if query selector is supported by the browser.
        /// </summary>
        public static string DetectScriptCode { get; } = @"(function(value) {
            'use strict';
            return typeof value === 'function';
        })";

        /// <summary>
        /// Gets the script to get the DOM path.
        /// </summary>
        public static string FindDomPathScript { get; } = @"return (function(element) {
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
            })(arguments[0]);";
    }
}
