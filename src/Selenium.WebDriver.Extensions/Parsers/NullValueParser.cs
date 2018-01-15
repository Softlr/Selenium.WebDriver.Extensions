namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The <see langword="null"/> value parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    internal class NullValueParser : ParserBase, INullValueParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => rawResult == null
            ? default
            : Successor.Parse<TResult>(rawResult);
    }
}