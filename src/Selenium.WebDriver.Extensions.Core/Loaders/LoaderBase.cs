namespace Selenium.WebDriver.Extensions.Core
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

        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        public abstract Uri LibraryUri { get; }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are met; otherwise, <c>false</c>.
        /// </summary>
        public abstract string CheckScript { get; }

        /// <summary>
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        public abstract string LoadScript(params string[] args);
    }
}
