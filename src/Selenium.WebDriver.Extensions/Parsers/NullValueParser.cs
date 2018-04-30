namespace Selenium.WebDriver.Extensions.Parsers
{
    internal class NullValueParser : ParserBase
    {
        public NullValueParser()
            : base(new WebElementCollectionParser())
        {
        }

        public override TResult Parse<TResult>(object rawResult) => rawResult == null
            ? default
            : Successor.Parse<TResult>(rawResult);
    }
}