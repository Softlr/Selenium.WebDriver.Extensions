namespace OpenQA.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium.Extensions;
    using OpenQA.Selenium.Internal;

    /// <summary>
    /// The selector base.
    /// </summary>
    /// <typeparam name="T">The type of the selector.</typeparam>
    public abstract class SelectorBase<T> : By
    {
        /// <summary>
        /// The script to get the DOM path.
        /// </summary>
        private const string FindDomPathScript = @"return (function(element) {
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
        /// Initializes a new instance of the <see cref="SelectorBase{T}"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected SelectorBase(string selector, T context)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", nameof(selector));
            }

            this.Context = context;
            this.RawSelector = selector;

            this.FindElementMethod = searchContext =>
            {
                var results = this.FindElements(searchContext);
                if (results.Count > 0)
                {
                    return results.First();
                }

                throw new NoSuchElementException("No element found for selector: " + this.RawSelector);
            };

            this.FindElementsMethod = searchContext =>
            {
                var driver = this.ResolveDriver(searchContext);

                this.LoadExternalLibrary(driver);
                var result = ParseUtil.ParseResult<IEnumerable<IWebElement>>(
                    driver.ExecuteScript<object>("return " + this.Selector + this.ResultResolver + ";"));
                return new ReadOnlyCollection<IWebElement>(result.ToList());
            };
        }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public virtual string RawSelector { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public virtual T Context { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public abstract string Selector { get; }

        /// <summary>
        /// Gets the result resolver string.
        /// </summary>
        protected virtual string ResultResolver => string.Empty;

        /// <summary>
        /// Loads the external library.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        protected abstract void LoadExternalLibrary(IWebDriver driver);

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <param name="contextSelector">The context selector.</param>
        /// <returns>The context.</returns>
        protected abstract T CreateContext(string contextSelector);

        /// <summary>
        /// Resolves the <see cref="IWebDriver"/>.
        /// </summary>
        /// <param name="searchContext">The search context.</param>
        /// <returns>The resolved <see cref="IWebDriver"/>.</returns>
        private IWebDriver ResolveDriver(ISearchContext searchContext)
        {
            var driver = searchContext as IWebDriver;
            if (driver != null)
            {
                return driver;
            }

            var driverWrapper = searchContext as IWrapsDriver;
            if (searchContext is IWebElement && driverWrapper != null)
            {
                // nested query
                driver = driverWrapper.WrappedDriver;
                var baseElementSelector = ((IJavaScriptExecutor)driver)
                    .ExecuteScript(FindDomPathScript, driverWrapper) as string;
                this.Context = this.CreateContext(baseElementSelector);
            }
            else
            {
                throw new NotSupportedException("Context is not a valid driver");
            }

            return driver;
        }
    }
}
