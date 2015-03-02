namespace Selenium.WebDriver.Extensions.Shared
{
    /// <summary>
    /// The partial link text selector.
    /// </summary>
    public class PartialLinkTextSelector : LinkTextSelectorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartialLinkTextSelector"/> class.
        /// </summary>
         /// <param name="text">The link text.</param>
        /// <param name="baseElement">
        /// A string defining the base element on which base element the selector should be invoked.
        /// </param>
        public PartialLinkTextSelector(string text, string baseElement = "document")
            : base(text, baseElement)
        {
            this.Selector = @"(function(text, baseElem) {
                var l = baseElem.querySelectorAll(':link');
                for (var i = 0; i < l.length; i++) { 
                    if (l[i].innerText.indexOf(text) !== -1) { 
                        return l[i]; 
                    } 
                }
                return null;
            })('" + text + "', " + this.BaseElement + ");";
        }
    }
}
