namespace Selenium.WebDriver.Extensions
{
    /// <summary>
    /// The position of DOM element on a page.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="top">The top coordinate of DOM element position.</param>
        /// <param name="left">The left coordinate of DOM element position.</param>
        public Position(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }
        
        /// <summary>
        /// Gets the top coordinate of DOM element position.
        /// </summary>
        public int Top { get; private set; }

        /// <summary>
        /// Gets the left coordinate of a DOM element position.
        /// </summary>
        public int Left { get; private set; }
    }
}
