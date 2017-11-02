namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The direct cast parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class DirectCastParser : ParserBase, IDirectCastParser
    {
        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => (TResult)rawResult;
    }
}
