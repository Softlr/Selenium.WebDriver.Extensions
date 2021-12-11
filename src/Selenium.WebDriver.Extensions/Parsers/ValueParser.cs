namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    [SuppressMessage(SONARQUBE, S3059)]
    internal class ValueParser : ParserBase
    {
        public ValueParser()
            : base(new NullValueParser())
        {
        }

        [SuppressMessage(SONARQUBE, S4018)]
        public override TResult Parse<TResult>(object rawResult) => Successor.Parse<TResult>(rawResult);
    }
}
