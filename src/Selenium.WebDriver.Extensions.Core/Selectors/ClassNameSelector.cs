namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// The class name selector.
    /// </summary>
    public class ClassNameSelector : QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassNameSelector"/> class.
        /// </summary>
        /// <param name="name">A string containing a DOM element class name.</param>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Base element is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Base element is empty.
        /// </exception>
        public ClassNameSelector(string name)
            : base(ModifyName(name))
        {
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", 
            Justification = "False positive.")]
        public static bool operator ==(ClassNameSelector selector1, ClassNameSelector selector2)
        {
            if (ReferenceEquals(selector1, selector2))
            {
                return true;
            }

            if (((object)selector1 == null) || ((object)selector2 == null))
            {
                return false;
            }

            return selector1.Equals(selector2);
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are not equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ClassNameSelector selector1, ClassNameSelector selector2)
        {
            return !(selector1 == selector2);
        }

        /// <summary>
        /// Determines whether two object instances are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            var selector = (ClassNameSelector)obj;
            return this.RawSelector == selector.RawSelector && this.BaseElement == selector.BaseElement;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.RawSelector.GetHashCode() ^ this.BaseElement.GetHashCode();
        }

        /// <summary>
        /// Modifies the class name to be a proper query selector value.
        /// </summary>
        /// <param name="name">The class name.</param>
        /// <returns>The query selector value.</returns>
        private static string ModifyName(string name)
        {
            if (name == null)
            {
                return null;
            }

            if (name.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return "." + name;
        }
    }
}
