using System;
using System.Runtime.Serialization;

namespace FlabIt.Guardians.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a value that is not of the expected type is passed to a method that does not accept it as a valid argument.
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    [Serializable]
    public class ArgumentIsNotOfTypeException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        public ArgumentIsNotOfTypeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentIsNotOfTypeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentIsNotOfTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentIsNotOfTypeException(string paramName, string message)
            : base(message, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="expectedFullyQualifiedType">The type the parameter was expected to be.</param>
        public ArgumentIsNotOfTypeException(string paramName, string message, string? expectedFullyQualifiedType)
            : base(message, paramName)
        {
            ExpectedType = expectedFullyQualifiedType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentIsNotOfTypeException(string paramName, string message, Exception innerException)
            : base(message, paramName, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="expectedTypeName">The type the parameter was expected to be.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentIsNotOfTypeException(string paramName, string message, string? expectedTypeName, Exception innerException)
            : base(message, paramName, innerException)
        {
            ExpectedType = expectedTypeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentIsNotOfTypeException" /> class.
        /// </summary>
        /// <param name="serializationInfo">The serialization information.</param>
        /// <param name="streamingContext">The streaming context.</param>
        protected ArgumentIsNotOfTypeException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            serializationInfo.ThrowIfNull(nameof(serializationInfo));

            ExpectedType = serializationInfo.GetString(nameof(ExpectedType));
        }

        /// <summary>
        /// Gets or sets the expected type.
        /// </summary>
        /// <value>
        /// The expected type.
        /// </value>
        public string? ExpectedType { get; protected set; }

        /// <summary>
        /// Sets the <see cref="System.Runtime.Serialization.SerializationInfo"></see> object with the parameter name and additional exception information.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">Gets thrown when <paramref name="info"/> is null.</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(ExpectedType), ExpectedType);

            base.GetObjectData(info, context);
        }
    }
}