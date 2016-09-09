namespace Selenium.WebDriver.Extensions
{
    /// <summary>
    /// The selector inteface.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should
        /// return <see langword="true"/> if the prerequisites are met; otherwise, <see langword="false"/>.
        /// </summary>
        string CheckScript { get; }
    }
}
