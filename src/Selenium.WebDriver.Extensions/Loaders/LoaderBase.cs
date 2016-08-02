namespace OpenQA.Selenium.Loaders
{
    using System;

    /// <summary>
    /// The external library loader base.
    /// </summary>
    public abstract class LoaderBase : ILoader
    {
        /// <summary>
        /// The JavaScript to check if query selector is supported by the browser.
        /// </summary>
        protected const string DetectScriptCode = @"(function(value) {
            'use strict';
            return typeof value === 'function';
        })";

        /// <inheritdoc/>
        public abstract Uri LibraryUri { get; }

        /// <inheritdoc/>
        public abstract string CheckScript { get; }

        /// <inheritdoc/>
        public abstract string LoadScript(string url);
    }
}
