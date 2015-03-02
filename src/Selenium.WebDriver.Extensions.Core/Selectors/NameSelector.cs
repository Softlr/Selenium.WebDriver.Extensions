namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The name selector.
    /// </summary>
    public class NameSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameSelector"/> class.
        /// </summary>
        /// <param name="name">A string containing a DOM element class name.</param>
        public NameSelector(string name)
            : base("[name='" + name + "']")
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
