namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is <see langword="null"/> or an empty string.
        /// </summary>
        /// <param name="value">The string to test. </param>
        /// <returns>
        /// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (<c>""</c>);
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This method is a implementation for <see cref="IsNullOrWhiteSpace"/> for <see cref="string"/> for .NET 3.5.
        /// </remarks>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value?.Trim());
        }
    }
}
