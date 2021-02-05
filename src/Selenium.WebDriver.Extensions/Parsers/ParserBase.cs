namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using static Softlr.Suppress;

    internal abstract class ParserBase : IParser
    {
        protected ParserBase(IParser successor = null) => Successor = successor;

        public IParser Successor { get; }

        [SuppressMessage(SONARQUBE, S4018)]
        public abstract TResult Parse<TResult>(object rawResult);
    }
}
