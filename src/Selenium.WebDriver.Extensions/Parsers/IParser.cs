namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using JetBrains.Annotations;
    using static Suppress;

    [PublicAPI]
    internal interface IParser
    {
        IParser Successor { get; }

        [SuppressMessage(SONARQUBE, S4018)]
        TResult Parse<TResult>(object rawResult);
    }
}
