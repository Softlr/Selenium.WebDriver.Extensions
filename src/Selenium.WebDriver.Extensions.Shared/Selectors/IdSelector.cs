namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The identifier selector.
    /// </summary>
    public class IdSelector : QuerySelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdSelector"/> class.
        /// </summary>
        /// <param name="id">A string containing a DOM element id.</param>
        public IdSelector(string id)
            : base("#" + id)
        {
        }
    }
}
