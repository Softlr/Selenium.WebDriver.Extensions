namespace Selenium.WebDriver.Extensions.Core
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
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return value == null || string.IsNullOrEmpty(value.Trim());
        }
    }
}
