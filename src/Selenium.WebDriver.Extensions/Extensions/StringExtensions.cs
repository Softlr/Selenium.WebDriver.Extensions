namespace OpenQA.Selenium.Extensions
{
    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is <c>null</c> or an empty string.
        /// </summary>
        /// <param name="value">The string to test. </param>
        /// <returns>
        /// <c>true</c> if the value parameter is <c>null</c> or an empty string (<c>""</c>); otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method is a implementation for <c>IsNullOrWhiteSpace</c> for <see cref="string"/> for .NET 3.5.
        /// </remarks>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value?.Trim());
        }
    }
}
