namespace Selenium.WebDriver.Extensions.Parsers;

internal class DirectCastParser : ParserBase
{
    [SuppressMessage(SONARQUBE, S4018)]
    public override TResult Parse<TResult>(object rawResult) => (TResult)rawResult;
}
