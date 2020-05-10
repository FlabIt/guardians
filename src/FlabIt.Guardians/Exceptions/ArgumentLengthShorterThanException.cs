using System;
using System.Runtime.Serialization;

namespace FlabIt.Guardians.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a value with a length shorter than a given length is passed to a method that does not accept it as a valid argument.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    [Serializable]
    public class ArgumentLengthShorterThanException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException"/> class.
        /// </summary>
        public ArgumentLengthShorterThanException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentLengthShorterThanException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentLengthShorterThanException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException"/> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentLengthShorterThanException(string paramName, string message)
            : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentLengthShorterThanException(string paramName, string message, Exception innerException)
            : base(message, paramName, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentLengthShorterThanException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected ArgumentLengthShorterThanException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}