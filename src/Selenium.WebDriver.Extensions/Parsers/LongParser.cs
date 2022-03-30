namespace Selenium.WebDriver.Extensions.Parsers;

[SuppressMessage(SONARQUBE, S3059)]
internal class LongParser : ParserBase
{
    public LongParser()
        : base(new DirectCastParser())
    {
    }

    [SuppressMessage(SONARQUBE, S4018)]
    public override TResult Parse<TResult>(object rawResult) =>
        rawResult is double d ? (TResult)(object)(long?)d : Successor.Parse<TResult>(rawResult);
}
