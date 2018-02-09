namespace Selenium.WebDriver.Extensions.Parsers
{
    using JetBrains.Annotations;

    /// <summary>
    /// The parser interface.
    /// </summary>
    [PublicAPI]
    internal interface IParser
    {
        /// <summary>
        /// Gets the successor parser.
        /// </summary>
        IParser Successor { get; }

        /// <summary>
        /// Parses the raw result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
        /// <param name="rawResult">The raw result to parse.</param>
        /// <returns>The parsed result.</returns>
        TResult Parse<TResult>(object rawResult);
    }
}