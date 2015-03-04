namespace Selenium.WebDriver.Extensions.Core
{
    using OpenQA.Selenium;

    /// <summary>
    /// The helper base.
    /// </summary>
    public abstract class HelperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelperBase"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="webElement">The web element.</param>
        protected HelperBase(IWebDriver driver, WebElement webElement = null)
        {
            this.Driver = driver;
            this.WebElement = webElement;
        }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Gets the web element.
        /// </summary>
        public WebElement WebElement { get; private set; }
    }
}
