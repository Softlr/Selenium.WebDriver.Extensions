namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The <see langword="null"/> value parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class NullValueParser : ParserBase, INullValueParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => rawResult == null
            ? default(TResult)
            : Successor.Parse<TResult>(rawResult);
    }
}
