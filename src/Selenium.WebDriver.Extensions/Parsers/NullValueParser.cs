namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The <see langword="null"/> value parser.
    /// </summary>
    /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
    internal class NullValueParser<TResult> : ParserBase<TResult>
    {
        /// <inheritdoc/>
        public override TResult Parse(object rawResult)
        {
            return rawResult == null ? default(TResult) : Successor.Parse(rawResult);
        }
    }
}