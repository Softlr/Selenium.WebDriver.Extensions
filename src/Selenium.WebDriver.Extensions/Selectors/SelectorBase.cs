namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Internal;
    using PostSharp.Patterns.Contracts;

    /// <summary>
    /// The selector base.
    /// </summary>
    /// <typeparam name="TSelector">The type of the selector.</typeparam>
    public abstract class SelectorBase<TSelector> : OpenQA.Selenium.By, ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorBase{T}"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        protected SelectorBase([Required] string selector, TSelector context)
        {
            Context = context;
            RawSelector = selector;
            FindElementMethod = FindElementBySelector;
            FindElementsMethod = FindElementsBySelector;
        }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should
        /// return <see langword="true"/> if the prerequisites are met; otherwise, <see langword="false"/>.
        /// </summary>
        public abstract string CheckScript { get; }

        /// <summary>
        /// Gets the query raw selector.
        /// </summary>
        public string RawSelector { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public TSelector Context { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        public abstract string Selector { get; }

        /// <summary>
        /// Gets the result resolver string.
        /// </summary>
        protected virtual string ResultResolver => string.Empty;

        /// <summary>
        /// Parses the result of executed jQuery script.
        /// </summary>
        /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
        /// <param name="result">The result of jQuery script.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// IE is returning numbers as doubles, while other browsers return them as long. This method casts IE-doubles
        /// to long integer type.
        /// </remarks>
        internal static TResult ParseResult<TResult>(object result)
        {
            if (result == null)
            {
                return default(TResult);
            }

            if (typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && result.GetType() == typeof(ReadOnlyCollection<object>))
            {
                return (TResult)((ReadOnlyCollection<object>)result).Cast<IWebElement>();
            }

            if (result is double)
            {
                return (TResult)(object)(long?)(double)result;
            }

            return (TResult)result;
        }

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
        protected abstract TSelector CreateContext(string contextSelector);

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
            var driver = searchContext as IWebDriver;
            if (driver != null)
            {
                return driver;
            }

            var driverWrapper = searchContext as IWrapsDriver;
            if (!(searchContext is IWebElement) || driverWrapper == null)
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
