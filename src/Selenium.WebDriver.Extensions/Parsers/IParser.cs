namespace Selenium.WebDriver.Extensions.Parsers
{
    using JetBrains.Annotations;

    [PublicAPI]
    internal interface IParser
    {
        IParser Successor { get; }

        TResult Parse<TResult>(object rawResult);
    }
}
