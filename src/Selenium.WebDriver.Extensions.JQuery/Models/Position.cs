namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;

    /// <summary>
    /// The position of DOM element on a page.
    /// </summary>
    public struct Position : IEquatable<Position>
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
        /// Initializes a new instance of the <see cref="Position"/> struct.
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

        /// <summary>
        /// Checks if two objects are equal.
        /// </summary>
        /// <param name="position1">The first object to be checked.</param>
        /// <param name="position2">The second object to be checked.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Position position1, Position position2)
        {
            return position1.Equals(position2);
        }

        /// <summary>
        /// Checks if two objects are not equal.
        /// </summary>
        /// <param name="position1">The first object to be checked.</param>
        /// <param name="position2">The second object to be checked.</param>
        /// <returns><c>true</c> if the objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Position position1, Position position2)
        {
            return !position1.Equals(position2);
        }    

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is Position && this.Equals((Position)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Position other)
        {
            return this.Top == other.Top && this.Left == other.Left;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Top.GetHashCode() ^ this.Left.GetHashCode();
        }
    }
}
