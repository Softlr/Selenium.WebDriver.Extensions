namespace OpenQA.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The selector inteface.
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Gets the default URI of the external library.
        /// </summary>
        Uri LibraryUri { get; }

        /// <summary>
        /// Gets the JavaScript to check if the prerequisites for the selector call have been met. The script should
        /// return <see langword="true"/> if the prerequisites are met; otherwise, <see langword="false"/>.
        /// </summary>
        string CheckScript { get; }
    }
}
