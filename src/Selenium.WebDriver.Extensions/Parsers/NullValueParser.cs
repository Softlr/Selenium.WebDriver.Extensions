namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    [SuppressMessage(SONARQUBE, S3059)]
    internal class NullValueParser : ParserBase
    {
        public NullValueParser()
            : base(new WebElementCollectionParser())
        {
        }

        [SuppressMessage(SONARQUBE, S4018)]
        public override TResult Parse<TResult>(object rawResult) =>
            rawResult == null ? default : Successor.Parse<TResult>(rawResult);
    }
}
