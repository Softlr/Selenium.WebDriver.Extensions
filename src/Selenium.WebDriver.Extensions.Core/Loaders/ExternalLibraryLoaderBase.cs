namespace Selenium.WebDriver.Extensions.Core
{
    /// <summary>
    /// The external library loader base.
    /// </summary>
    public abstract class ExternalLibraryLoaderBase : LoaderBase
    {
        /// <summary>
        /// The JavaScript to load jQuery.
        /// </summary>
        protected const string LoadScriptCode = @"(function(src) {
            'use strict';
            var script = document.createElement('script');
            script.src = src;
            document.getElementsByTagName('body')[0].appendChild(script);
        })";
    }
}
