namespace Selenium.WebDriver.Extensions.Shared
{
    using System;

    /// <summary>
    /// The link text base selector.
    /// </summary>
    public abstract class LinkTextSelectorBase : NestableSelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTextSelectorBase"/> class.
        /// </summary>
        /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        protected LinkTextSelectorBase(string text, string baseElement = "document")
            : base(text, baseElement)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (baseElement == null)
            {
                throw new ArgumentNullException("baseElement");
            }
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
