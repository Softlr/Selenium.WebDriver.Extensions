namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The base result parser.
    /// </summary>
    internal abstract class ParserBase : IParser
    {
        /// <inheritdoc/>
        public IParser Successor { get; set; }

        /// <inheritdoc/>
        public abstract TResult Parse<TResult>(object rawResult);
    }
}
