namespace Selenium.WebDriver.Extensions.JQuery
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using Selenium.WebDriver.Extensions.Core;

    /// <summary>
    /// The Selenium selector for jQuery.
    /// </summary>
    public class JQuerySelector : SelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <param name="jQueryVariable">A variable that has been assigned to jQuery.</param>
        /// <exception cref="ArgumentNullException">Selector is null or jQuery variable name is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty or jQuery variable name is empty.</exception>
        public JQuerySelector(
            string selector,
            JQuerySelector context = null,
            string jQueryVariable = "jQuery")
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

            if (jQueryVariable == null)
            {
                throw new ArgumentNullException("jQueryVariable");
            }

            if (jQueryVariable.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("jQuery variable cannot be empty", "jQueryVariable");
            }

            this.Context = context;
            this.JQueryVariable = jQueryVariable;
            this.Selector = this.JQueryVariable + "('" + selector.Replace('\'', '"') + "'"
                + (this.Context != null ? ", " + this.Context : string.Empty) + ")";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        private JQuerySelector()
            : base(null)
        {
        }

        /// <summary>
        /// Gets the call format string.
        /// </summary>
        /// <remarks>This value is used to execute selector while determining the DOM path of the result.</remarks>
        public override string CallFormatString
        {
            get
            {
                return this.JQueryVariable + "({0}).get({1})";
            }
        }

        /// <summary>
        /// Gets the DOM Element, Document, or jQuery to use as context.
        /// </summary>
        public virtual JQuerySelector Context { get; private set; }

        /// <summary>
        /// Gets the variable that has been assigned to jQuery.
        /// </summary>
        public virtual string JQueryVariable { get; private set; }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(JQueryRunner);
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
        public static bool operator ==(JQuerySelector selector1, JQuerySelector selector2)
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
        public static bool operator !=(JQuerySelector selector1, JQuerySelector selector2)
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

            var rootSelector = new JQuerySelector(root.Path);
            var jquerySelector = root.Selector as JQuerySelector;
            return jquerySelector != null
                ? new JQuerySelector(this.RawSelector, rootSelector, jquerySelector.JQueryVariable) 
                : new JQuerySelector(this.RawSelector, rootSelector);
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

            var selector = (JQuerySelector)obj;
            return this.RawSelector == selector.RawSelector && this.JQueryVariable == selector.JQueryVariable 
                && this.Context == selector.Context;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Context == null 
                ? this.RawSelector.GetHashCode() ^ this.JQueryVariable.GetHashCode() 
                : this.RawSelector.GetHashCode() ^ this.JQueryVariable.GetHashCode() ^ this.Context.GetHashCode();
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to the set of matched 
        /// elements.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Add(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("add", selector);
        }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to the set of matched 
        /// elements.
        /// </param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null or context is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Add(string selector, JQuerySelector context)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return this.ChainWithContext("add", selector, context);
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to match the current set of elements against.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector AddBack(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("addBack", selector);
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <remarks>While this method is obsolete in jQuery 1.8+ we will support it.</remarks>
        public JQuerySelector AndSelf()
        {
            return this.Chain("andSelf");
        }

        /// <summary>
        /// Get the children of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Children(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("children", selector);
        }

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself 
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Closest(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("closest", selector);
        }

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself 
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null or context is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Closest(string selector, JQuerySelector context)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return this.ChainWithContext("closest", selector, context);
        }

        /// <summary>
        /// Get the children of each element in the set of matched elements, including text and comment nodes.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Contents()
        {
            return this.Chain("contents");
        }

        /// <summary>
        /// End the most recent filtering operation in the current chain and return the set of matched elements to its 
        /// previous state.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector End()
        {
            return this.Chain("end");
        }

        /// <summary>
        /// Reduce the set of matched elements to the one at the specified index.
        /// </summary>
        /// <param name="index">An integer indicating the 0-based position of the element.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Eq(int index)
        {
            return this.Chain("eq", index.ToString(CultureInfo.InvariantCulture), true);
        }

        /// <summary>
        /// Reduce the set of matched elements to those that match the selector or pass the function's test.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Filter(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("filter", selector);
        }

        /// <summary>
        /// Get the descendants of each element in the current set of matched elements, filtered by a selector, jQuery 
        /// object, or element.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Find(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("find", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to the first in the set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector First()
        {
            return this.Chain("first");
        }

        /// <summary>
        /// Reduce the set of matched elements to those that have a descendant that matches the selector or DOM 
        /// element.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Has(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("has", selector);
        }

        /// <summary>
        /// Check the current matched set of elements against a selector, element, or jQuery object and return true if 
        /// at least one of these elements matches the given arguments.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Is(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("is", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to the final one in the set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Last()
        {
            return this.Chain("last");
        }

        /// <summary>
        /// Get the immediately following sibling of each element in the set of matched elements. If a selector is 
        /// provided, it retrieves the next sibling only if it matches that selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Next(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("next", selector);
        }

        /// <summary>
        /// Get all following siblings of each element in the set of matched elements, optionally filtered by a 
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector NextAll(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("nextAll", selector);
        }

        /// <summary>
        /// Get all following siblings of each element up to but not including the element matched by the selector, 
        /// DOM node, or jQuery object passed.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to indicate where to stop matching following sibling elements.
        /// </param>
        /// <param name="filter">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty or filter is empty.</exception>
        public JQuerySelector NextUntil(string selector = null, string filter = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (filter != null && filter.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Filter cannot be empty", "filter");
            }

            if (selector == null && filter != null)
            {
                selector = string.Empty;
            }

            var data = HandleSelectorWithFilter(selector, filter);
            return this.Chain("nextUntil", data, true);
        }

        /// <summary>
        /// Remove elements from the set of matched elements.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression, a DOM element, or an array of elements to match against the 
        /// set.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Not(string selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            if (selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("not", selector);
        }

        /// <summary>
        /// Get the closest ancestor element that is positioned.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector OffsetParent()
        {
            return this.Chain("offsetParent");
        }

        /// <summary>
        /// Get the parent of each element in the current set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Parent(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("parent", selector);
        }

        /// <summary>
        /// Get the ancestors of each element in the current set of matched elements, optionally filtered by a 
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Parents(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("parents", selector);
        }

        /// <summary>
        /// Get the ancestors of each element in the current set of matched elements, up to but not including the 
        /// element matched by the selector, DOM node, or jQuery object.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to indicate where to stop matching ancestor elements.
        /// </param>
        /// <param name="filter">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty or filter is empty.</exception>
        public JQuerySelector ParentsUntil(string selector = null, string filter = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (filter != null && filter.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Filter cannot be empty", "filter");
            }

            if (selector == null && filter != null)
            {
                selector = string.Empty;
            }

            var data = HandleSelectorWithFilter(selector, filter);
            return this.Chain("parentsUntil", data, true);
        }

        /// <summary>
        /// Get the immediately preceding sibling of each element in the set of matched elements, optionally filtered 
        /// by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Prev(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("prev", selector);
        }

        /// <summary>
        /// Get all preceding siblings of each element in the set of matched elements, optionally filtered by a 
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector PrevAll(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("prevAll", selector);
        }

        /// <summary>
        /// Get all preceding siblings of each element up to but not including the element matched by the selector, 
        /// DOM node, or jQuery object.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to indicate where to stop matching preceding sibling elements.
        /// </param>
        /// <param name="filter">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty or filter is empty.</exception>
        public JQuerySelector PrevUntil(string selector = null, string filter = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            if (filter != null && filter.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Filter cannot be empty", "filter");
            }

            if (selector == null && filter != null)
            {
                selector = string.Empty;
            }

            var data = HandleSelectorWithFilter(selector, filter);
            return this.Chain("prevUntil", data, true);
        }

        /// <summary>
        /// Get the siblings of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Siblings(string selector = null)
        {
            if (selector != null && selector.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Selector cannot be empty", "selector");
            }

            return this.Chain("siblings", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to a subset specified by a range of indices.
        /// </summary>
        /// <param name="start">
        /// An integer indicating the 0-based position at which the elements begin to be selected. If negative, it 
        /// indicates an offset from the end of the set.
        /// </param>
        /// <param name="end">
        /// An integer indicating the 0-based position at which the elements stop being selected. If negative, it 
        /// indicates an offset from the end of the set. If omitted, the range continues until the end of the set.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Slice(int start, int? end = null)
        {
            var data = end.HasValue
                ? start + ", " + end
                : start.ToString(CultureInfo.InvariantCulture);
            return this.Chain("slice", data, true);
        }

        /// <summary>
        /// Handles the selector with filter scenario by generating the proper chained function arguments.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>Chained function arguments string generated based on given selector and filter.</returns>
        private static string HandleSelectorWithFilter(string selector = null, string filter = null)
        {
            var data = string.Empty;
            if (selector != null)
            {
                data = string.IsNullOrEmpty(filter) 
                    ? "'" + selector + "'"
                    : "'" + selector + "', '" + filter + "'";
            }

            return data;
        }

        /// <summary>
        /// Chain a jQuery method to a selector.
        /// </summary>
        /// <param name="name">The jQuery method name.</param>
        /// <param name="selector">The jQuery method selector.</param>
        /// <param name="noWrap">
        /// <c>true</c> to not to wrap the selector into quotes; otherwise, <c>false</c>.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        private JQuerySelector Chain(string name, string selector = null, bool noWrap = false)
        {
            selector = selector == null ? string.Empty : (noWrap ? selector.Trim() : "'" + selector.Trim() + "'");

            return new JQuerySelector
                       {
                           Selector = this.Selector + "." + name + "(" + selector + ")",
                           Context = this.Context,
                           JQueryVariable = this.JQueryVariable
                       };
        }

        /// <summary>
        /// Chain a jQuery method to a selector.
        /// </summary>
        /// <param name="name">The jQuery method name.</param>
        /// <param name="selector">The jQuery method selector.</param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        private JQuerySelector ChainWithContext(string name, string selector, JQuerySelector context)
        {
            return new JQuerySelector
            {
                Selector = this.Selector + "." + name + "('" + selector + "', " + context + ")",
                Context = this.Context,
                JQueryVariable = this.JQueryVariable
            };
        }
    }
}
