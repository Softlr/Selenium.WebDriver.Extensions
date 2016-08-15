namespace OpenQA.Selenium
{
    using System;
    using Seterlund.CodeGuard;

    /// <summary>
    /// The external library loader base.
    /// </summary>
    internal static class JavaScriptSnippets
    {
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

        /// <summary>
        /// Gets the JavaScript to load jQuery.
        /// </summary>
        /// <param name="url">The script URL.</param>
        /// <returns>The JavaScrpt to load URL.</returns>
        public static string LoadScriptCode(Uri url)
        {
            Guard.That(() => url).IsNotNull();

            const string Script = @"(function(source) {
                'use strict';
                var script = document.createElement('script');
                script.src = source;
                document.getElementsByTagName('body')[0].appendChild(script);
            })";
            return $"{Script}('{url}')";
        }

        /// <summary>
        /// Gets the JavaScript to test if library variable is defined.
        /// </summary>
        /// <param name="variable">The library variable to test.</param>
        /// <returns>The JavaScrpt to test if library variable is defined.</returns>
        public static string CheckScriptCode(string variable)
        {
            Guard.That(() => variable).IsNotNull();

            const string Script = @"(function(value) {
                'use strict';
                return typeof value === 'function';
            })";
            return $"{Script}({variable})";
        }
    }
}
