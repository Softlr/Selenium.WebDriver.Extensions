namespace OpenQA.Selenium.Loaders
{
    /// <summary>
    /// The external library loader base.
    /// </summary>
    internal static class Constants
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
    }
}
