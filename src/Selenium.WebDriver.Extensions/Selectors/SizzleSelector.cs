﻿namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// The Selenium selector for Sizzle.
    /// </summary>
    public class SizzleSelector : ISelector
    {
        /// <summary>
        /// The JavaScript to check if Sizzle has been loaded.
        /// </summary>
        private const string DetectScriptCode = "return typeof window.Sizzle === 'function';";

        /// <summary>
        /// The JavaScript to check if Sizzle has been loaded.
        /// </summary>
        private const string LoadScriptCode = "var sizzle = document.createElement('script');sizzle.src = '{0}';" +
            "document.getElementsByTagName('body')[0].appendChild(sizzle);";

        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <remarks>
        /// Contrary to <see cref="JQuerySelector"/>, the <see cref="SizzleSelector"/> only works when single element
        /// is given as context. Therefore only the first match is added to the selector if the context parameters
        /// is used.
        /// </remarks>
        public SizzleSelector(
            string selector,
            SizzleSelector context = null)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            this.Context = context;
            this.Selector = "Sizzle('" + selector.Replace('\'', '"') + "'" 
                + (this.Context != null ? ", " + this.Context + "[0]" : string.Empty) + ")";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        protected SizzleSelector()
        {
        }

        /// <summary>
        /// Gets the empty Sizzle selector.
        /// </summary>
        public static SizzleSelector Empty
        {
            get
            {
                return new SizzleSelector();
            }
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are ok; otherwise, <c>false</c>.
        /// </summary>
        public string CheckScript
        {
            get
            {
                return DetectScriptCode;
            }
        }

        /// <summary>
        /// Gets the jQuery selector.
        /// </summary>
        public string Selector { get; private set; }

        /// <summary>
        /// Gets the DOM Element or Document to use as context.
        /// </summary>
        public SizzleSelector Context { get; private set; }

        /// <summary>
        /// Gets the JavaScript to load the prerequisites for the selector.
        /// </summary>
        /// <param name="args">Load script arguments.</param>
        /// <returns>The JavaScript code to load the prerequisites for the selector.</returns>
        public string LoadScript(params string[] args)
        {
            Debug.Assert(args.Length > 0, "No Sizzle URI given");

            return string.Format(LoadScriptCode, args.First());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.Selector;
        }
    }
}
