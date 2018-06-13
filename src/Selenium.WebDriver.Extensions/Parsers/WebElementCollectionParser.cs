namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using OpenQA.Selenium;

    internal class WebElementCollectionParser : ParserBase
    {
        public WebElementCollectionParser()
            : base(new LongParser())
        {
        }

        public override TResult Parse<TResult>(object rawResult) =>
            typeof(TResult) == typeof(IEnumerable<IWebElement>)
                && rawResult.GetType() == typeof(ReadOnlyCollection<object>)
            ? (TResult)((ReadOnlyCollection<object>)rawResult).Cast<IWebElement>()
            : Successor.Parse<TResult>(rawResult);
    }
}
