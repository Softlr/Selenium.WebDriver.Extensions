namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using Selenium.WebDriver.Extensions.Shared;

    /// <summary>
    /// The class name selector.
    /// </summary>
    public class ClassNameSelector : QuerySelector.QuerySelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassNameSelector"/> class.
        /// </summary>
        /// <param name="name">A string containing a DOM element class name.</param>
        public ClassNameSelector(string name)
            : base("." + name)
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
