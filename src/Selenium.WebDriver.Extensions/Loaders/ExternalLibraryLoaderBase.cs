namespace OpenQA.Selenium.Loaders
{
    /// <summary>
    /// The external library loader base.
    /// </summary>
    public abstract class ExternalLibraryLoaderBase : LoaderBase
    {
        /// <summary>
        /// The JavaScript to load jQuery.
        /// </summary>
        protected const string LoadScriptCode = @"(function(source) {
            'use strict';
            var script = document.createElement('script');
            script.src = source;
            document.getElementsByTagName('body')[0].appendChild(script);
        })";
    }
}
