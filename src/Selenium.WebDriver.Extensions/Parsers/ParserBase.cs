namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    internal abstract class ParserBase : IParser
    {
        [SuppressMessage(Suppress.Category.CODE_CRACKER, Suppress.CodeCracker.CC0057)]
        protected ParserBase(IParser successor = null) => Successor = successor;

        public IParser Successor { get; }

        public abstract TResult Parse<TResult>(object rawResult);
    }
}