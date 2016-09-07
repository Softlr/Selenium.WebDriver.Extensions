namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The direct cast parser.
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class DirectCastParser : ParserBase, IDirectCastParser
    {
        /// <inheritdoc/>
        public override TResult Parse<TResult>(object rawResult)
        {
            return (TResult)rawResult;
        }
    }
}