namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The <see langword="null"/> value parser.
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class NullValueParser : ParserBase, INullValueParser
    {
        /// <inheritdoc/>
        public override TResult Parse<TResult>(object rawResult) => rawResult == null
            ? default(TResult)
            : Successor.Parse<TResult>(rawResult);
    }
}