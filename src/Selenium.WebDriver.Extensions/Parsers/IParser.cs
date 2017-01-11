namespace Selenium.WebDriver.Extensions.Parsers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The parser interface.
    /// </summary>
    internal interface IParser
    {
        /// <summary>
        /// Gets or sets the successor parser.
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
        IParser Successor { get; set; }

        /// <summary>
        /// Parses the raw result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
        /// <param name="rawResult">The raw result to parse.</param>
        /// <returns>The parsed result.</returns>
        TResult Parse<TResult>(object rawResult);
    }
}