namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The <see cref="long"/> parser.
    /// </summary>
    /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
    internal class LongParser<TResult> : ParserBase<TResult>
    {
        /// <inheritdoc/>
        public override TResult Parse(object rawResult)
        {
            return rawResult is double ? (TResult)(object)(long?)(double)rawResult : Successor.Parse(rawResult);
        }
    }
}