namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OpenQA.Selenium;

    /// <summary>
    /// The parse utility.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Util")]
    public static class ParseUtil
    {
        /// <summary>
        /// Parses the result of executed jQuery script.
        /// </summary>
        /// <typeparam name="T">The type of the result to be returned.</typeparam>
        /// <param name="result">The result of jQuery script.</param>
        /// <returns>Parsed result of invoking the script.</returns>
        /// <remarks>
        /// IE is returning numbers as doubles, while other browsers return them as long. This method casts IE-doubles
        /// to long integer type.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// An element in the sequence cannot be cast to type <typeparamref name="T" />.
        /// </exception>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static T ParseResult<T>(object result)
        {
            if (result == null)
            {
                return default(T);
            }

            if (typeof(T) == typeof(IEnumerable<IWebElement>)
                && result.GetType() == typeof(ReadOnlyCollection<object>))
            {
                result = ((ReadOnlyCollection<object>)result).Cast<IWebElement>();
            }

            if (result is double)
            {
                result = (long?)(double)result;
            }

            return (T)result;
        }
    }
}
