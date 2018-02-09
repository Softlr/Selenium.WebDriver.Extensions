namespace Selenium.WebDriver.Extensions.Parsers
{
    /// <summary>
    /// The <see langword="null"/> value parser.
    /// </summary>
    /// <inheritdoc cref="ParserBase" />
    internal class ValueParser : ParserBase
    {
        public ValueParser()
            : base(new NullValueParser())
        {
        }

        /// <inheritdoc cref="ParserBase.Parse{TResult}" />
        public override TResult Parse<TResult>(object rawResult) => Successor.Parse<TResult>(rawResult);
    }
}