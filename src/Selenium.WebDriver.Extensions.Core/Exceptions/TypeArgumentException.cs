namespace Selenium.WebDriver.Extensions.Core
{
    using System;
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    /// <summary>
    /// The exception that is thrown when one of the type arguments provided to a method is not valid.
    /// </summary>
    [Serializable]
#if !NET35
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
    public class TypeArgumentException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class.
        /// </summary>
        [UsedImplicitly]
        public TypeArgumentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class with a specified error 
        /// message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        [UsedImplicitly]
        public TypeArgumentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null 
        /// reference, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        [UsedImplicitly]
        public TypeArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class with a specified error message 
        /// and the name of the type parameter that causes this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="typeParameterName">The name of the type parameter that caused the current exception.</param>
        public TypeArgumentException(string message, string typeParameterName)
            : base(message, typeParameterName)
        {    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class with a specified error 
        /// message, the type parameter name, and a reference to the inner exception that is the cause of this 
        /// exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="typeParameterName">The name of the parameter that caused the current exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the innerException parameter is not a null 
        /// reference, the current exception is raised in a catch block that handles the inner exception.
        /// </param>
        [UsedImplicitly]
        public TypeArgumentException(string message, string typeParameterName, Exception innerException)
            : base(message, typeParameterName, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeArgumentException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected TypeArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
