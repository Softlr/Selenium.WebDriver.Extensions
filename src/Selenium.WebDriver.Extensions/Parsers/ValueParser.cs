namespace Selenium.WebDriver.Extensions.Parsers
{
    internal class ValueParser : ParserBase
    {
        public ValueParser()
            : base(new NullValueParser())
        {
        }

        public override TResult Parse<TResult>(object rawResult) => Successor.Parse<TResult>(rawResult);
    }
}
