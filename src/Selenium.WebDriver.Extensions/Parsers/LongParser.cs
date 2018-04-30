namespace Selenium.WebDriver.Extensions.Parsers
{
    internal class LongParser : ParserBase
    {
        public LongParser()
            : base(new DirectCastParser())
        {
        }

        public override TResult Parse<TResult>(object rawResult) => rawResult is double d
            ? (TResult)(object)(long?)d
            : Successor.Parse<TResult>(rawResult);
    }
}