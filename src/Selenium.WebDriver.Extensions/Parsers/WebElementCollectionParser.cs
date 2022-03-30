namespace Selenium.WebDriver.Extensions.Parsers;

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
