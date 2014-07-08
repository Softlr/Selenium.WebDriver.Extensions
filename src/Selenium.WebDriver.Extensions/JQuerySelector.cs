namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The Selenium selector for jQuery.
    /// </summary>
    public class JQuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">The jQuery selector.</param>
        /// <param name="append">
        /// <c>true</c> if the new object is created based on existing selector; otherwise, <c>false</c>.
        /// </param>
        public JQuerySelector(string selector, bool append = false)
        {
            this.Selector = append
                ? selector
                : string.Format(CultureInfo.InvariantCulture, "jQuery('{0}')", selector);
        }

        /// <summary>
        /// Gets or sets the jQuery selector.
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Adds elements to the set of matched elements.
        /// </summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to the set of matched 
        /// elements.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Add(string selector)
        {
            return this.Chain("add", selector);
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to match the current set of elements against.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector AddBack(string selector = null)
        {
            return this.Chain("addBack", selector);
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector AndSelf()
        {
            return this.Chain("andSelf");
        }

        /// <summary>
        /// Get the children of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Children(string selector = null)
        {
            return this.Chain("children", selector);
        }

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself 
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Closest(string selector)
        {
            return this.Chain("closest", selector);
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
        public JQuerySelector Filter(string selector)
        {
            return this.Chain("filter", selector);
        }

        /// <summary>
        /// Get the descendants of each element in the current set of matched elements, filtered by a selector, jQuery 
        /// object, or element.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Find(string selector)
        {
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
        public JQuerySelector Has(string selector)
        {
            return this.Chain("has", selector);
        }

        /// <summary>
        /// Check the current matched set of elements against a selector, element, or jQuery object and return true if 
        /// at least one of these elements matches the given arguments.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Is(string selector)
        {
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
        public JQuerySelector Next(string selector = null)
        {
            return this.Chain("next", selector);
        }

        /// <summary>
        /// Get all following siblings of each element in the set of matched elements, optionally filtered by a 
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector NextAll(string selector = null)
        {
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
        public JQuerySelector NextUntil(string selector = null, string filter = null)
        {
            var data = HandleSelectorWithFilter(selector, filter);
            return this.Chain("nextUntil", data, true);
        }

        /// <summary>
        /// Remove elements from the set of matched elements.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression, a DOM element, or an array of elements to match against the set.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Not(string selector = null)
        {
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
        public JQuerySelector Parent(string selector = null)
        {
            return this.Chain("parent", selector);
        }

        /// <summary>
        /// Get the ancestors of each element in the current set of matched elements, optionally filtered by a 
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Parents(string selector = null)
        {
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
        public JQuerySelector ParentsUntil(string selector = null, string filter = null)
        {
            var data = HandleSelectorWithFilter(selector, filter); 
            return this.Chain("parentsUntil", data, true);
        }

        /// <summary>
        /// Get the immediately preceding sibling of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Prev(string selector = null)
        {
            return this.Chain("prev", selector);
        }

        /// <summary>
        /// Get all preceding siblings of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector PrevAll(string selector = null)
        {
            return this.Chain("prevAll", selector);
        }

        /// <summary>
        /// Get all preceding siblings of each element up to but not including the element matched by the selector, DOM node, or jQuery object.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to indicate where to stop matching preceding sibling elements.</param>
        /// <param name="filter">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector PrevUntil(string selector = null, string filter = null)
        {
            var data = HandleSelectorWithFilter(selector, filter);
            return this.Chain("prevUntil", data, true);
        }

        /// <summary>
        /// Get the siblings of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Siblings(string selector = null)
        {
            return this.Chain("siblings", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to a subset specified by a range of indices.
        /// </summary>
        /// <param name="start">An integer indicating the 0-based position at which the elements begin to be selected. If negative, it indicates an offset from the end of the set.</param>
        /// <param name="end">An integer indicating the 0-based position at which the elements stop being selected. If negative, it indicates an offset from the end of the set. If omitted, the range continues until the end of the set.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Slice(int start, int? end = null)
        {
            var data = start.ToString(CultureInfo.InvariantCulture);
            if (end.HasValue)
            {
                data = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}, {1}",
                    start,
                    end.Value);
            }

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
            if (!string.IsNullOrWhiteSpace(selector))
            {
                if (string.IsNullOrWhiteSpace(filter))
                {
                    data = string.Format(CultureInfo.InvariantCulture, "'{0}'", selector);
                }
                else
                {
                    data = string.Format(CultureInfo.InvariantCulture, "'{0}', '{1}'", selector, filter);
                }
            }

            return data;
        }

        /// <summary>
        /// Chain a jQuery method to a selector.
        /// </summary>
        /// <param name="name">The jQuery method name.</param>
        /// <param name="selector">The jQuery method selector.</param>
        /// <param name="dontWrap">
        /// <c>true</c> to not to wrap the selector into quotes; otherwise, <c>false</c>.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        private JQuerySelector Chain(string name, string selector = null, bool dontWrap = false)
        {
            selector = string.IsNullOrWhiteSpace(selector)
                ? string.Empty
                : (dontWrap ? selector.Trim() : string.Format(CultureInfo.InvariantCulture, "'{0}'", selector.Trim()));

            var newSelector = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.{1}({2})",
                this.Selector,
                name,
                selector);
            return new JQuerySelector(newSelector, true);
        }
    }
}
