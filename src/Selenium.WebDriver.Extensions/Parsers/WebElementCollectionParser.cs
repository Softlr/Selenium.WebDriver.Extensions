namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;

    /// <summary>
    /// The <see cref="IWebElement"/> collection parser.
    /// </summary>
    /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
    internal class WebElementCollectionParser<TResult> : ParserBase<TResult>
    {
        /// <inheritdoc/>
        public override TResult Parse(object rawResult)
        {
            return typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
                    ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
                    : Successor.Parse(rawResult);
        }
    }
}