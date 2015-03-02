namespace Selenium.WebDriver.Extensions.Core
{
    /// <summary>
    /// The link text selector.
    /// </summary>
    public class LinkTextSelector : LinkTextSelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTextSelector"/> class.
        /// </summary>
        /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        public LinkTextSelector(string text, string baseElement = "document")
            : base(text, baseElement)
        {
            this.Selector = @"(function(text, baseElem) {
                var l = baseElem.querySelectorAll(':link');
                for (var i = 0; i < l.length; i++) { 
                    if (l[i].innerText === text) { 
                        return l[i]; 
                    } 
                }
                return null;
            })('" + text + "', " + this.BaseElement + ");";
        }
    }
}
