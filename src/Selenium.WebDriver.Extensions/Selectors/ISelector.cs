namespace Selenium.WebDriver.Extensions
{
    /// <summary>
    /// The selector interface.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should 
        /// return <c>true</c> if the prerequisites are ok; otherwise, <c>false</c>.
        /// </summary>
        string CheckScript { get; }
    }
}
