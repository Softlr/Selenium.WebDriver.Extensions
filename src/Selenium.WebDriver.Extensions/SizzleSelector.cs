namespace Selenium.WebDriver.Extensions;

/// <summary>Searches the DOM elements using Sizzle selector.</summary>
/// <inheritdoc />
public class SizzleSelector : SelectorBase<SizzleSelector>
{
    private const string VARIABLE = "window.Sizzle";

    /// <summary>Initializes a new instance of the <see cref="SizzleSelector" /> class.</summary>
    /// <param name="selector">A string containing a selector expression.</param>
    /// <remarks>
    /// This constructor cannot be merged with <see cref="SizzleSelector(string,SizzleSelector)" /> constructor as it
    /// is resolved by reflection.
    /// </remarks>
    public SizzleSelector(string selector)
        : this(selector, null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="SizzleSelector" /> class.</summary>
    /// <param name="selector">A string containing a selector expression.</param>
    /// <param name="context">A DOM Element, Document, or jQuery to use as context.</param>
    public SizzleSelector(string selector, SizzleSelector context)
        : base(selector, context) => Description = $"By.SizzleSelector: {RawSelector}";

    /// <summary>Gets the empty selector.</summary>
    public static SizzleSelector Empty { get; } = new SizzleSelector("*");

    /// <inheritdoc />
    public override string CheckScript => CheckScriptCode(VARIABLE);

    /// <inheritdoc />
    public override string Selector => $"Sizzle('{RawSelector.Replace('\'', '"')}'"
        + (Context != null ? $", {Context.Selector}[0]" : string.Empty) + ")";

    /// <inheritdoc />
    protected override SizzleSelector CreateContext(string contextSelector) => new(contextSelector);

    /// <inheritdoc />
    protected override void LoadExternalLibrary(IWebDriver driver) => driver.LoadSizzle();
}
