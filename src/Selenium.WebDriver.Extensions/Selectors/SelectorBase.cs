namespace OpenQA.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium.Extensions;
    using OpenQA.Selenium.Internal;
    using Seterlund.CodeGuard;
    using static OpenQA.Selenium.JavaScriptSnippets;

    /// <summary>
    /// The selector base.
    /// </summary>
    /// <typeparam name="TSelector">The type of the selector.</typeparam>
    public abstract class SelectorBase<TSelector> : By, ISelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorBase{T}"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected SelectorBase(string selector, TSelector context)
        {
            Guard.That(() => selector).IsNotNull();

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

                throw new NoSuchElementException($"No element found for selector: {this.RawSelector}");
            };

            this.FindElementsMethod = searchContext =>
            {
                var driver = this.ResolveDriver(searchContext);

                this.LoadExternalLibrary(driver);
                var result = ParseResult<IEnumerable<IWebElement>>(
                    driver.ExecuteScript<object>($"return {this.Selector}{this.ResultResolver};"));
                return new ReadOnlyCollection<IWebElement>(result.ToList());
            };
        }

        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        public abstract Uri LibraryUri { get; }

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
                result = ((ReadOnlyCollection<object>)result).Cast<IWebElement>();
            }

            if (result is double)
            {
                result = (long?)(double)result;
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
