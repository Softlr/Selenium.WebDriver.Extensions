namespace Selenium.WebDriver.Extensions.QuerySelector
{
    using JetBrains.Annotations;
    using QS = Selenium.WebDriver.Extensions.QuerySelector.QuerySelector;
    
    /// <summary>
    /// Extends the selenium <see cref="OpenQA.Selenium.By"/> additional selectors to be used.
    /// </summary>
    /// <remarks>
    /// This class shadows all of the static members of the <see cref="OpenQA.Selenium.By"/>. The reason for that is
    /// to replace the type of the returned selectors to further expand their possibilities.
    /// </remarks>
    [UsedImplicitly]
    public class By : OpenQA.Selenium.By
    {
        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        /// <returns>A <see cref="QS"/> object the driver can use to find the elements.</returns>
        public static QuerySelector QuerySelector(string selector, string baseElement = "document")
        {
            return new QuerySelector(selector, baseElement);
        }

        /// <summary>
        /// Gets a mechanism to find elements matching JavaScript query selector.
        /// </summary>
        /// <param name="selector">A string containing a selector expression</param>
        /// <param name="baseSelector">A query selector on which defines a base element for the new selector.</param>
        /// <returns>A <see cref="QS"/> object the driver can use to find the elements.</returns>
        public static QuerySelector QuerySelector(string selector, QuerySelector baseSelector)
        {
            return new QuerySelector(selector, baseSelector);
        }
    }
}
