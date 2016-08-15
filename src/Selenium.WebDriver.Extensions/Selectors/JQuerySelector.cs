namespace OpenQA.Selenium
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using OpenQA.Selenium.Extensions;
    using Seterlund.CodeGuard;
    using static OpenQA.Selenium.JavaScriptSnippets;

    /// <summary>
    /// Searches the DOM elements using jQuery selector.
    /// </summary>
    public class JQuerySelector : SelectorBase<JQuerySelector>
    {
        private const string LibraryVariable = "window.jQuery";

        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
        public JQuerySelector(string selector)
            : this(selector, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JQuerySelector"/> class.
        /// </summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <param name="variable">A variable that has been assigned to jQuery.</param>
        /// <param name="chain">The jQuery method chain.</param>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- jQuery variable name is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- jQuery variable name is empty.
        /// </exception>
        public JQuerySelector(
            string selector, JQuerySelector context, string variable = "jQuery", string chain = null)
            : base(selector, context)
        {
            Guard.That(() => variable).IsNotNull().IsNotNullOrWhiteSpace();

            this.Variable = variable;
            this.CallChain = chain;
            this.Description = $"By.JQuerySelector: {this.RawSelector}";
        }

        /// <summary>
        /// Gets the empty selector.
        /// </summary>
        public static JQuerySelector Empty { get; } = new JQuerySelector("*");

        /// <inheritdoc/>
        public override Uri LibraryUri => new Uri("https://code.jquery.com/jquery-latest.min.js");

        /// <inheritdoc/>
        public override string CheckScript => CheckScriptCode(LibraryVariable);

        /// <summary>
        /// Gets the variable that has been assigned to jQuery.
        /// </summary>
        public virtual string Variable { get; }

        /// <inheritdoc/>
        public override string Selector => $"{this.Variable}('{this.RawSelector.Replace('\'', '"')}'"
            + (this.Context != null ? $", {this.Context.Selector}" : string.Empty) + ")"
            + (string.IsNullOrEmpty(this.CallChain) ? string.Empty : this.CallChain);

        /// <summary>
        /// Gets the result resolver string.
        /// </summary>
        protected override string ResultResolver => ".get()";

        /// <summary>
        /// Gets the jQuery call chain methods.
        /// </summary>
        private string CallChain { get; }

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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

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
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Context is null.
        /// </exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Add(string selector, JQuerySelector context)
        {
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();
            Guard.That(() => context).IsNotNull();

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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

            return this.Chain("addBack", selector);
        }

        /// <summary>
        /// Add the previous set of elements on the stack to the current set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <remarks>While this method is obsolete in jQuery 1.8+ we will support it.</remarks>
        public JQuerySelector AndSelf() => this.Chain("andSelf");

        /// <summary>
        /// Get the children of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Children(string selector = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

            return this.Chain("closest", selector);
        }

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">
        /// Selector is null.
        /// -or- Context is null.
        /// </exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Closest(string selector, JQuerySelector context)
        {
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();
            Guard.That(() => context).IsNotNull();

            return this.ChainWithContext("closest", selector, context);
        }

        /// <summary>
        /// Get the children of each element in the set of matched elements, including text and comment nodes.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Contents() => this.Chain("contents");

        /// <summary>
        /// End the most recent filtering operation in the current chain and return the set of matched elements to its
        /// previous state.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector End() => this.Chain("end");

        /// <summary>
        /// Reduce the set of matched elements to the one at the specified index.
        /// </summary>
        /// <param name="index">An integer indicating the 0-based position of the element.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Eq(int index) => this.Chain("eq", index.ToString(CultureInfo.InvariantCulture), true);

        /// <summary>
        /// Reduce the set of matched elements to those that match the selector or pass the function's test.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentNullException">Selector is null.</exception>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Filter(string selector)
        {
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

            return this.Chain("find", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to the first in the set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector First() => this.Chain("first");

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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

            return this.Chain("is", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to the final one in the set.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Last() => this.Chain("last");

        /// <summary>
        /// Get the immediately following sibling of each element in the set of matched elements. If a selector is
        /// provided, it retrieves the next sibling only if it matches that selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Next(string selector = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Filter is empty.
        /// </exception>
        public JQuerySelector NextUntil(string selector = null, string filter = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();
            Guard.That(() => filter).IsNullOrIsNotWhitespace();

            var data = HandleSelectorWithFilter(selector == null && filter != null ? string.Empty : selector, filter);
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
            Guard.That(() => selector).IsNotNull().IsNotNullOrWhiteSpace();

            return this.Chain("not", selector);
        }

        /// <summary>
        /// Get the closest ancestor element that is positioned.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector OffsetParent() => this.Chain("offsetParent");

        /// <summary>
        /// Get the parent of each element in the current set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <exception cref="ArgumentException">Selector is empty.</exception>
        public JQuerySelector Parent(string selector = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Filter is empty.
        /// </exception>
        public JQuerySelector ParentsUntil(string selector = null, string filter = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();
            Guard.That(() => filter).IsNullOrIsNotWhitespace();

            var data = HandleSelectorWithFilter(selector == null && filter != null ? string.Empty : selector, filter);
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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

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
        /// <exception cref="ArgumentException">
        /// Selector is empty.
        /// -or- Filter is empty.
        /// </exception>
        public JQuerySelector PrevUntil(string selector = null, string filter = null)
        {
            Guard.That(() => selector).IsNullOrIsNotWhitespace();
            Guard.That(() => filter).IsNullOrIsNotWhitespace();

            var data = HandleSelectorWithFilter(selector == null && filter != null ? string.Empty : selector, filter);
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
            Guard.That(() => selector).IsNullOrIsNotWhitespace();

            return this.Chain("siblings", selector);
        }

        /// <summary>
        /// Reduce the set of matched elements to a subset specified by a range of indexes.
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
                ? $"{start}, {end}"
                : start.ToString(CultureInfo.InvariantCulture);
            return this.Chain("slice", data, true);
        }

        /// <inheritdoc/>
        protected override void LoadExternalLibrary(IWebDriver driver) => driver.LoadJQuery();

        /// <inheritdoc/>
        protected override JQuerySelector CreateContext(string contextSelector) =>
            new JQuerySelector(contextSelector, null, this.Variable);

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
                    ? $"'{selector.Replace('\'', '"')}'"
                    : $"'{selector.Replace('\'', '"')}', '{filter.Replace('\'', '"')}'";
            }

            return data;
        }

        /// <summary>
        /// Chain a jQuery method to a selector.
        /// </summary>
        /// <param name="name">The jQuery method name.</param>
        /// <param name="selector">The jQuery method selector.</param>
        /// <param name="noWrap">
        /// <see langword="true"/> to not to wrap the selector into quotes; otherwise, <see langword="false"/>.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        private JQuerySelector Chain(string name, string selector = null, bool noWrap = false)
        {
            selector = selector == null
                ? string.Empty
                : (noWrap ? selector.Trim() : $"'{selector.Trim().Replace('\'', '"')}'");
            var callChain = string.IsNullOrEmpty(this.CallChain) ? string.Empty : this.CallChain;

            return new JQuerySelector(
                this.RawSelector,
                this.Context,
                this.Variable,
                $"{callChain}.{name}({selector})");
        }

        /// <summary>
        /// Chain a jQuery method to a selector.
        /// </summary>
        /// <param name="name">The jQuery method name.</param>
        /// <param name="selector">The jQuery method selector.</param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        private JQuerySelector ChainWithContext(string name, string selector, JQuerySelector context) =>
            new JQuerySelector(
                this.RawSelector,
                this.Context,
                this.Variable,
                $".{name}('{selector.Replace('\'', '"')}', {context.Selector})");
    }
}
