namespace Selenium.WebDriver.Extensions
{
    using JetBrains.Annotations;
    using OpenQA.Selenium;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using static Softlr.Suppress;
    using static System.String;
    using static Validate;

    /// <summary>Searches the DOM elements using jQuery selector.</summary>
    /// <inheritdoc />
    [PublicAPI]
    public class JQuerySelector : SelectorBase<JQuerySelector>
    {
        private const string VARIABLE = "window.jQuery";
        private readonly string _chain;

        /// <summary>Initializes a new instance of the <see cref="JQuerySelector" /> class.</summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <remarks>
        /// This constructor cannot be merged with <see
        /// cref="M:Selenium.WebDriver.Extensions.JQuerySelector.#ctor(System.String,Selenium.WebDriver.Extensions.JQuerySelector,System.String,System.String)" />
        /// constructor as it is resolved by reflection.
        /// </remarks>
        [SuppressMessage("ReSharper", "InheritdocConsiderUsage")]
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global")]
        public JQuerySelector(string selector)
            : this(selector, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JQuerySelector" /> class.</summary>
        /// <param name="selector">A string containing a selector expression.</param>
        /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
        /// <param name="variable">A variable that has been assigned to jQuery.</param>
        /// <param name="chain">The jQuery method chain.</param>
        [SuppressMessage("ReSharper", "InheritdocConsiderUsage")]
        public JQuerySelector(string selector, JQuerySelector context, string variable = "jQuery", string chain = "")
            : base(selector, context)
        {
            _chain = NotNull(() => chain);
            Variable = Required(() => variable);
            Description = $"By.JQuerySelector: {RawSelector}";
        }

        /// <summary>Gets the empty selector.</summary>
        public static JQuerySelector Empty { get; } = new JQuerySelector("*");

        /// <inheritdoc />
        public override string CheckScript => JavaScriptSnippets.CheckScriptCode(VARIABLE);

        /// <inheritdoc />
        public override string Selector => $"{Variable}('{RawSelector.Replace('\'', '"')}'"
            + (Context != null ? $", {Context.Selector}" : string.Empty) + $"){_chain}";

        /// <summary>Gets the variable that has been assigned to jQuery.</summary>
        public virtual string Variable { get; }

        /// <inheritdoc />
        protected override string ResultResolver => ".get()";

        /// <summary>Adds elements to the set of matched elements.</summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to the set of matched
        /// elements.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Add(string selector) => Chain("add", Required(() => selector));

        /// <summary>Adds elements to the set of matched elements.</summary>
        /// <param name="selector">
        /// A string representing a selector expression to find additional elements to add to the set of matched
        /// elements.
        /// </param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Add(string selector, JQuerySelector context) =>
            ChainWithContext("add", Required(() => selector), NotNull(() => context));

        /// <summary>
        /// Add the previous set of elements on the stack to the current set, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to match the current set of elements against.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector AddBack(string selector = null) => Chain("addBack", NullOrNotEmpty(() => selector));

        /// <summary>Add the previous set of elements on the stack to the current set.</summary>
        /// <returns>The Selenium jQuery selector.</returns>
        /// <remarks>While this method is obsolete in jQuery 1.8+ we will support it.</remarks>
        public JQuerySelector AndSelf() => Chain("andSelf");

        /// <summary>
        /// Get the children of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Children(string selector = null) => Chain("children", NullOrNotEmpty(() => selector));

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Closest(string selector) => Chain("closest", Required(() => selector));

        /// <summary>
        /// For each element in the set, get the first element that matches the selector by testing the element itself
        /// and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <param name="context">The jQuery context selector.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Closest(string selector, JQuerySelector context) =>
            ChainWithContext("closest", Required(() => selector), NotNull(() => context));

        /// <summary>Get the children of each element in the set of matched elements, including text and comment nodes.</summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Contents() => Chain("contents");

        /// <summary>
        /// End the most recent filtering operation in the current chain and return the set of matched elements to its
        /// previous state.
        /// </summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector End() => Chain("end");

        /// <summary>Reduce the set of matched elements to the one at the specified index.</summary>
        /// <param name="index">An integer indicating the 0-based position of the element.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Eq(int index) => Chain("eq", index.ToString(CultureInfo.InvariantCulture), true);

        /// <summary>Reduce the set of matched elements to those that match the selector or pass the function's test.</summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Filter(string selector) => Chain("filter", Required(() => selector));

        /// <summary>
        /// Get the descendants of each element in the current set of matched elements, filtered by a selector, jQuery
        /// object, or element.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Find(string selector) => Chain("find", Required(() => selector));

        /// <summary>Reduce the set of matched elements to the first in the set.</summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector First() => Chain("first");

        /// <summary>
        /// Reduce the set of matched elements to those that have a descendant that matches the selector or DOM
        /// element.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Has(string selector) => Chain("has", Required(() => selector));

        /// <summary>
        /// Check the current matched set of elements against a selector, element, or jQuery object and return
        /// <see langword="true" /> if at least one of these elements matches the given arguments.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Is(string selector) => Chain("is", Required(() => selector));

        /// <summary>Reduce the set of matched elements to the final one in the set.</summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Last() => Chain("last");

        /// <summary>
        /// Get the immediately following sibling of each element in the set of matched elements. If a selector is
        /// provided, it retrieves the next sibling only if it matches that selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Next(string selector = null) => Chain("next", NullOrNotEmpty(() => selector));

        /// <summary>
        /// Get all following siblings of each element in the set of matched elements, optionally filtered by a
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector NextAll(string selector = null) => Chain("nextAll", NullOrNotEmpty(() => selector));

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
            var validatedSelector = NullOrNotEmpty(() => selector);
            var validatedFilter = NullOrNotEmpty(() => filter);
            var filteredSelector = validatedSelector == null && validatedFilter != null
                ? string.Empty
                : validatedSelector;
            return Chain("nextUntil", FilteredSelector(filteredSelector, validatedFilter), true);
        }

        /// <summary>Remove elements from the set of matched elements.</summary>
        /// <param name="selector">
        /// A string containing a selector expression, a DOM element, or an array of elements to match against the set.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Not(string selector) => Chain("not", Required(() => selector));

        /// <summary>Get the closest ancestor element that is positioned.</summary>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector OffsetParent() => Chain("offsetParent");

        /// <summary>
        /// Get the parent of each element in the current set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Parent(string selector = null) => Chain("parent", NullOrNotEmpty(() => selector));

        /// <summary>
        /// Get the ancestors of each element in the current set of matched elements, optionally filtered by a
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Parents(string selector = null) => Chain("parents", NullOrNotEmpty(() => selector));

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
            var validatedSelector = NullOrNotEmpty(() => selector);
            var validatedFilter = NullOrNotEmpty(() => filter);
            var filteredSelector = validatedSelector == null && validatedFilter != null
                ? string.Empty
                : validatedSelector;
            return Chain("parentsUntil", FilteredSelector(filteredSelector, validatedFilter), true);
        }

        /// <summary>
        /// Get the immediately preceding sibling of each element in the set of matched elements, optionally filtered
        /// by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Prev(string selector = null) => Chain("prev", NullOrNotEmpty(() => selector));

        /// <summary>
        /// Get all preceding siblings of each element in the set of matched elements, optionally filtered by a
        /// selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector PrevAll(string selector = null) => Chain("prevAll", NullOrNotEmpty(() => selector));

        /// <summary>
        /// Get all preceding siblings of each element up to but not including the element matched by the selector,
        /// DOM node, or jQuery object.
        /// </summary>
        /// <param name="selector">
        /// A string containing a selector expression to indicate where to stop matching preceding sibling elements.
        /// </param>
        /// <param name="filter">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector PrevUntil(string selector = null, string filter = null)
        {
            var validatedSelector = NullOrNotEmpty(() => selector);
            var validatedFilter = NullOrNotEmpty(() => filter);
            var filteredSelector = validatedSelector == null && validatedFilter != null
                ? string.Empty
                : validatedSelector;
            return Chain("prevUntil", FilteredSelector(filteredSelector, validatedFilter), true);
        }

        /// <summary>
        /// Get the siblings of each element in the set of matched elements, optionally filtered by a selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression to match elements against.</param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Siblings(string selector = null) => Chain("siblings", NullOrNotEmpty(() => selector));

        /// <summary>Reduce the set of matched elements to a subset specified by a range of indexes.</summary>
        /// <param name="start">
        /// An integer indicating the 0-based position at which the elements begin to be selected. If negative, it
        /// indicates an offset from the end of the set.
        /// </param>
        /// <param name="end">
        /// An integer indicating the 0-based position at which the elements stop being selected. If negative, it
        /// indicates an offset from the end of the set. If omitted, the range continues until the end of the set.
        /// </param>
        /// <returns>The Selenium jQuery selector.</returns>
        public JQuerySelector Slice(int start, int? end = null) =>
            Chain("slice", end.HasValue ? $"{start}, {end}" : start.ToString(CultureInfo.InvariantCulture), true);

        /// <inheritdoc />
        protected override JQuerySelector CreateContext(string contextSelector) =>
            new JQuerySelector(contextSelector, null, Variable);

        /// <inheritdoc />
        protected override void LoadExternalLibrary(IWebDriver driver) => driver.LoadJQuery();

        [SuppressMessage(SONARQUBE, S3358)]
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static string FilteredSelector(string selector = null, string filter = null) =>
            selector != null
                ? IsNullOrEmpty(filter)
                    ? $"'{selector.Replace('\'', '"')}'"
                    : $"'{selector.Replace('\'', '"')}', '{filter.Replace('\'', '"')}'"
                : string.Empty;

        [SuppressMessage(SONARQUBE, S3358)]
        private static string GetSelectorString(string selector, bool noWrap = false) =>
            selector == null
                ? string.Empty
                : noWrap
                    ? selector.Trim()
                    : $"'{selector.Trim().Replace('\'', '"')}'";

        private JQuerySelector Chain(string name, string selector = null, bool noWrap = false) =>
            new JQuerySelector(
                RawSelector,
                Context,
                Variable,
                $"{_chain}.{name}({GetSelectorString(selector, noWrap)})");

        [SuppressMessage(SONARQUBE, S3242)]
        private JQuerySelector ChainWithContext(string name, string selector, JQuerySelector context) =>
            new JQuerySelector(
                RawSelector,
                Context,
                Variable,
                $".{name}('{selector.Replace('\'', '"')}', {context.Selector})");
    }
}
