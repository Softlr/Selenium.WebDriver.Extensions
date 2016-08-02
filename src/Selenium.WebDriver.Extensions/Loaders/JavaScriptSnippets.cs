namespace OpenQA.Selenium.Loaders
{
    /// <summary>
    /// The external library loader base.
    /// </summary>
    internal static class JavaScriptSnippets
    {
        /// <summary>
        /// The JavaScript to load jQuery.
        /// </summary>
        public const string LoadScriptCode = @"(function(source) {
            'use strict';
            var script = document.createElement('script');
            script.src = source;
            document.getElementsByTagName('body')[0].appendChild(script);
        })";

        /// <summary>
        /// The JavaScript to check if query selector is supported by the browser.
        /// </summary>
        public const string DetectScriptCode = @"(function(value) {
            'use strict';
            return typeof value === 'function';
        })";
    }
}
