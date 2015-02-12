namespace Selenium.WebDriver.Extensions.Models
{
    /// <summary>
    /// The position of DOM element on a page.
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// The top coordinate of DOM element position.
        /// </summary>
        private readonly int top;

        /// <summary>
        /// The left coordinate of DOM element position.
        /// </summary>
        private readonly int left;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="top">The top coordinate of DOM element position.</param>
        /// <param name="left">The left coordinate of DOM element position.</param>
        public Position(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        /// <summary>
        /// Gets the top coordinate of DOM element position.
        /// </summary>
        public int Top
        {
            get
            {
                return this.top;
            }
        }

        /// <summary>
        /// Gets the left coordinate of a DOM element position.
        /// </summary>
        public int Left
        {
            get
            {
                return this.left;
            }
        }
    }
}
