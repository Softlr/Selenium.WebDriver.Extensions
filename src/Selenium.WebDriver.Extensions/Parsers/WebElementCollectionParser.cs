namespace Selenium.WebDriver.Extensions.Parsers
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// The <see cref="T:OpenQA.Selenium.IWebElement" /> collection parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class WebElementCollectionParser : ParserBase, IWebElementCollectionParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) =>
            typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
            ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
            : Successor.Parse<TResult>(rawResult);
    }
}