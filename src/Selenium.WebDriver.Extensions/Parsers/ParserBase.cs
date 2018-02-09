namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The base result parser.
    /// </summary>
    /// <inheritdoc />
    internal abstract class ParserBase : IParser
    {
        protected ParserBase(IParser successor = null) => Successor = successor;

        /// <inheritdoc/>
        public IParser Successor { get; }

        /// <inheritdoc/>
        public abstract TResult Parse<TResult>(object rawResult);
    }
}