namespace Selenium.WebDriver.Extensions.Parsers;

internal interface IParser
{
    IParser Successor { get; }

    [SuppressMessage(SONARQUBE, S4018)]
    TResult Parse<TResult>(object rawResult);
}
