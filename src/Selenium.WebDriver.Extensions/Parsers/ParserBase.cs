namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;
    using static Suppress.Category;
    using static Suppress.CodeCracker;

    /// <summary>
    /// The base result parser.
    /// </summary>
    /// <inheritdoc />
    internal abstract class ParserBase : IParser
    {
        [SuppressMessage(CODE_CRACKER, CC0057)]
        protected ParserBase(IParser successor = null) => Successor = successor;

        /// <inheritdoc/>
        public IParser Successor { get; }

        /// <inheritdoc/>
        public abstract TResult Parse<TResult>(object rawResult);
    }
}