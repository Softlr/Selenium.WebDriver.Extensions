namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The <see cref="long"/> parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class LongParser : ParserBase, ILongParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => rawResult is double
            ? (TResult)(object)(long?)(double)rawResult
            : Successor.Parse<TResult>(rawResult);
    }
}