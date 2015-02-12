namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    /// <summary>
    /// The exception that is thrown when external library loading failes.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ExternalLibraryLoadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalLibraryLoadException"/> class.
        /// </summary>
        [UsedImplicitly]
        public ExternalLibraryLoadException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalLibraryLoadException"/> class with a specified error 
        /// message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [UsedImplicitly]
        public ExternalLibraryLoadException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalLibraryLoadException"/> class with a specified error 
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null 
        /// reference, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        [UsedImplicitly]
        public ExternalLibraryLoadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalLibraryLoadException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ExternalLibraryLoadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
