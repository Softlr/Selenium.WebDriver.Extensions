namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The direct cast parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    internal class DirectCastParser : ParserBase, IDirectCastParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => (TResult)rawResult;
    }
}