namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// The class containing the extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified <paramref name="value"/> is <see langword="null"/> or an empty string.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>
        /// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (<c>""</c>);
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This method is the implementation of <see cref="IsNullOrWhiteSpace"/> compatible with .NET 3.5.
        /// </remarks>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrEmpty(value?.Trim());
    }
}
