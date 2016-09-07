namespace Selenium.WebDriver.Extensions.Parsers
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The base result parser.
    /// </summary>
    /// <typeparam name="TResult">The type of the result to be returned.</typeparam>
    internal abstract class ParserBase<TResult>
    {
        /// <summary>
        /// Gets or sets the successor parser.
        /// </summary>
        public ParserBase<TResult> Successor { get; set; }

        /// <summary>
        /// Parses the raw result.
        /// </summary>
        /// <param name="rawResult">The raw result to parse.</param>
        /// <returns>The parsed result.</returns>
        public abstract TResult Parse(object rawResult);
    }
}
