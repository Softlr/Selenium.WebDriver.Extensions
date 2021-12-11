namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium;
    using static Softlr.Suppress;

    [SuppressMessage(SONARQUBE, S3059)]
    internal class WebElementCollectionParser : ParserBase
    {
        public WebElementCollectionParser()
            : base(new LongParser())
        {
        }

        [SuppressMessage(SONARQUBE, S4018)]
        public override TResult Parse<TResult>(object rawResult) =>
            typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
                ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
                : Successor.Parse<TResult>(rawResult);
    }
}
