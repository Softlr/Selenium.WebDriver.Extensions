namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium;

    /// <summary>
    /// The <see cref="IWebElement"/> collection parser.
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class WebElementCollectionParser : ParserBase, IWebElementCollectionParser
    {
        /// <inheritdoc/>
        public override TResult Parse<TResult>(object rawResult)
        {
            return typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
                    ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
                    : Successor.Parse<TResult>(rawResult);
        }
    }
}