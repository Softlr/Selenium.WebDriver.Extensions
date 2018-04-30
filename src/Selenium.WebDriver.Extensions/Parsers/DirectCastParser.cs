namespace Selenium.WebDriver.Extensions.Parsers
{
    internal class DirectCastParser : ParserBase
    {
        public override TResult Parse<TResult>(object rawResult) => (TResult)rawResult;
    }
}