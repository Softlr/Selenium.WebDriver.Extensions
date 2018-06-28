namespace Selenium.WebDriver.Extensions
{
    using System;

    internal static class JavaScriptSnippets
    {
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
            stack = stack.slice(1);
            return stack.join(' > ');
        })(arguments[0]);";

        public static string CheckScriptCode(string variable) => $@"(function(value) {{
            'use strict';
            return typeof value === 'function';
        }})({variable})";

        public static string LoadScriptCode(Uri url) => $@"(function(source) {{
            'use strict';
            var script = document.createElement('script');
            script.src = source;
            document.getElementsByTagName('body')[0].appendChild(script);
        }})('{url}')";
    }
}
