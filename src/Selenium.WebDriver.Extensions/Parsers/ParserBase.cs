namespace Selenium.WebDriver.Extensions.Parsers;

internal abstract class ParserBase : IParser
{
    protected ParserBase(IParser successor = null) => Successor = successor;

    public IParser Successor { get; }

    [SuppressMessage(SONARQUBE, S4018)]
    public abstract TResult Parse<TResult>(object rawResult);
}
