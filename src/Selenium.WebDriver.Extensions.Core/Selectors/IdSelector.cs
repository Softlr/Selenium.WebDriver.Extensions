namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The identifier selector.
    /// </summary>
    public class IdSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdSelector"/> class.
        /// </summary>
        /// <param name="id">A string containing a DOM element id.</param>
        public IdSelector(string id)
            : base("#" + id)
        {
        }

        /// <summary>
        /// Gets the type of the runner.
        /// </summary>
        public override Type RunnerType
        {
            get
            {
                return typeof(JavaScriptRunner);
            }
        }
    }
}
