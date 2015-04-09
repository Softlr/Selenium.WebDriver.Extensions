namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using OpenQA.Selenium;
    
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
        /// <exception cref="ArgumentNullException">Driver is null.</exception>
        public QuerySelectorHelper(IWebDriver driver, WebElement webElement = null)
            : base(driver, webElement)
        {
        }

        /// <summary>
        /// Checks if query selector is supported by the browser.
        /// </summary>
        /// <exception cref="QuerySelectorNotSupportedException">
        /// The query selector is not supported by the browser.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Driver is null.
        /// -or- Loader is null.</exception>
        /// <exception cref="ArgumentException">Script is empty.</exception>
        public void CheckSupport()
        {
            if (!this.Driver.CheckSelectorPrerequisites(new QuerySelectorLoader()))
            {
                throw new QuerySelectorNotSupportedException();
            }
        }
    }
}
