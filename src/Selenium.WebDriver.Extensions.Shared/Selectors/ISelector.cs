namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The selector interface.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Gets the selector.
        /// </summary>
        string Selector { get; }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        string CallFormatString { get; }
    }
}
