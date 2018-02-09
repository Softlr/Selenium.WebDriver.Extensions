namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;

    /// <summary>
    /// The <see cref="T:OpenQA.Selenium.IWebElement" /> collection parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    internal class WebElementCollectionParser : ParserBase
    {
        public WebElementCollectionParser()
            : base(new LongParser())
        {
        }

        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) =>
            typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
            ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
            : Successor.Parse<TResult>(rawResult);
    }
}