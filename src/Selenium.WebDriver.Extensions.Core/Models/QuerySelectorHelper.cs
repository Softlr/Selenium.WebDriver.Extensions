namespace Selenium.WebDriver.Extensions.Core
{
    using OpenQA.Selenium;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// Additional methods for <see cref="QuerySelector"/>.
    /// </summary>
    public class QuerySelectorHelper : HelperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuerySelectorHelper"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="webElement">The web element.</param>
        public QuerySelectorHelper(IWebDriver driver, WebElement webElement = null)
            : base(driver, webElement)
        {
        }

        /// <summary>
        /// Checks if query selector is supported by the browser.
        /// </summary>
        public void CheckSupport()
        {
            if (!this.Driver.CheckSelectorPrerequisites(new QuerySelectorLoader()))
            {
                throw new QuerySelectorNotSupportedException();
            }
        }
    }
}
