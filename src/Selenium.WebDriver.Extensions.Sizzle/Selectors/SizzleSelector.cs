namespace Selenium.WebDriver.Extensions.Sizzle
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Selenium.WebDriver.Extensions.Core;
    
    /// <summary>
    /// The Selenium selector for Sizzle.
    /// </summary>
    public class SizzleSelector : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SizzleSelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <remarks>
        /// Contrary to jQuery selectors, the <see cref="SizzleSelector"/> only works when single element
        /// is given as context. Therefore only the first match is added to the selector if the context parameters
        /// is used.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public SizzleSelector(
            string selector,
            SizzleSelector context = null)
            : base(selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            this.Context = context;
            this.Selector = "Sizzle('" + selector.Replace('\'', '"') + "'" 
                + (this.Context != null ? ", " + this.Context + "[0]" : string.Empty) + ")";
        }

        /// <summary>
        /// Gets the DOM Element or Document to use as context.
        /// </summary>
        public virtual SizzleSelector Context { get; private set; }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(SizzleRunner);
            }
        }

        /// <summary>
        /// Compares two selectors and returns <c>true</c> if they are equal.
        /// </summary>
        /// <param name="selector1">The first selector to compare.</param>
        /// <param name="selector2">The second selector to compare.</param>
        /// <returns><c>true</c> if the selectors are equal; otherwise, <c>false</c>.</returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly",
            Justification = "False positive.")]
        public static bool operator ==(SizzleSelector selector1, SizzleSelector selector2)
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
        public static bool operator !=(SizzleSelector selector1, SizzleSelector selector2)
        {
            return !(selector1 == selector2);
        }

        /// <summary>
        /// Creates a new selector using given selector as a root.
        /// </summary>
        /// <param name="root">A web element to be used as a root.</param>
        /// <returns>A new selector.</returns>
        /// <exception cref="ArgumentNullException">Root element is null.</exception>
        public override ISelector Create(WebElement root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }

            var rootSelector = new SizzleSelector(root.Path);
            return new SizzleSelector(this.RawSelector, rootSelector);
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

            var selector = (SizzleSelector)obj;
            return this.RawSelector == selector.RawSelector && this.Context == selector.Context;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Context == null
                ? this.RawSelector.GetHashCode()
                : this.RawSelector.GetHashCode() ^ this.Context.GetHashCode();
        }
    }
}
