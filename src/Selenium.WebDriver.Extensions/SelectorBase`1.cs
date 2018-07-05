namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using Selenium.WebDriver.Extensions.Parsers;
    using static Softlr.Suppress;
    using static System.String;
    using static Validate;

    /// <summary>
    /// The selector base.
    /// </summary>
    /// <typeparam name="TSelector">The type of the selector.</typeparam>
    /// <inheritdoc cref="ISelector" />
    public abstract class SelectorBase<TSelector> : OpenQA.Selenium.By, ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorBase{T}"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">The context.</param>
        [SuppressMessage("ReSharper", "InheritdocConsiderUsage")]
        protected SelectorBase(string selector, TSelector context)
        {
            Context = context;
            RawSelector = Required(() => selector);
            FindElementMethod = FindElementBySelector;
            FindElementsMethod = FindElementsBySelector;
        }

        /// <inheritdoc />
        public abstract string CheckScript { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public TSelector Context { get; private set; }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public string RawSelector { get; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public abstract string Selector { get; }

        /// <summary>
        /// Gets the result resolver string.
        /// </summary>
        protected virtual string ResultResolver => Empty;

        [SuppressMessage(SONARQUBE, S4018)]
        internal static TResult ParseResult<TResult>(object result) => new ValueParser().Parse<TResult>(result);

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <param name="contextSelector">The context selector.</param>
        /// <returns>The context.</returns>
        protected abstract TSelector CreateContext(string contextSelector);

        /// <summary>
        /// Loads the external library.
        /// </summary>
        /// <param name="driver">The web driver.</param>
        protected abstract void LoadExternalLibrary(IWebDriver driver);

        private IWebElement FindElementBySelector(ISearchContext searchContext)
        {
            var results = FindElementsBySelector(searchContext);
            if (results.Count > 0)
            {
                return results.First();
            }

            throw new NoSuchElementException($"No element found for selector: {RawSelector}");
        }

        private ReadOnlyCollection<IWebElement> FindElementsBySelector(ISearchContext searchContext)
        {
            var driver = ResolveDriver(searchContext);

            LoadExternalLibrary(driver);
            var result = ParseResult<IEnumerable<IWebElement>>(driver.ExecuteScript<object>(
                $"return {Selector}{ResultResolver};"));
            return new ReadOnlyCollection<IWebElement>(result.ToList());
        }

        private IWebDriver ResolveDriver(ISearchContext searchContext)
        {
            if (searchContext is IWebDriver driver)
            {
                return driver;
            }

            if (!(searchContext is IWebElement) || !(searchContext is IWrapsDriver driverWrapper))
            {
                throw new NotSupportedException("Context is not a valid driver");
            }

            // nested query
            driver = driverWrapper.WrappedDriver;
            var baseElementSelector = ((IJavaScriptExecutor)driver)
                .ExecuteScript(JavaScriptSnippets.FindDomPathScript, driverWrapper) as string;
            Context = CreateContext(baseElementSelector);

            return driver;
        }
    }
}
