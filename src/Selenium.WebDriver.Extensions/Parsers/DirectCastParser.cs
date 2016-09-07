namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The direct cast parser.
    /// </summary>
    /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
    internal class DirectCastParser<TResult> : ParserBase<TResult>
    {
        /// <inheritdoc/>
        public override TResult Parse(object rawResult)
        {
            return (TResult)rawResult;
        }
    }
}