using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests.Exceptions
{
    [TestFixture]
    public class ArgumentEmptyExceptionTest : ExceptionsTestBase
    {
        #region Default Constructors

        [Test]
        public void When_serializing_exception_with_default_values_should_deserialize_correctly()
        {
            var exception = new ArgumentEmptyException();

            AssertArgumentExceptionWithDefaultValuesSerializesCorrectly(exception);
        }

        [Test]
        public void When_serializing_exception_with_message_should_deserialize_correctly()
        {
            var exception = new ArgumentEmptyException(TestExceptionMessage);

            AssertArgumentExceptionWithMessageSerializesCorrectly(exception, TestExceptionMessage);
        }

        [Test]
        public void When_serializing_exception_with_paramName_and_message_should_deserialize_correctly()
        {
            var exception = new ArgumentEmptyException(paramName: TestParameterName, message: TestExceptionMessage);

            AssertArgumentExceptionWithParamNameAndMessageSerializesCorrectly(exception, TestExceptionMessage, TestParameterName);
        }

        [Test]
        public void When_serializing_exception_with_message_and_innerException_should_deserialize_correctly()
        {
            var testInnerException = CreateTestInnerException();

            var exception = new ArgumentEmptyException(message: TestExceptionMessage, innerException: testInnerException);

            AssertArgumentExceptionWithMessageAndInnerExceptionSerializesCorrectly(exception, TestExceptionMessage, testInnerException);
        }

        [Test]
        public void When_serializing_exception_with_paramName_and_message_and_innerException_should_deserialize_correctly()
        {
            var testInnerException = CreateTestInnerException();

            var exception = new ArgumentEmptyException(paramName: TestParameterName, message: TestExceptionMessage, innerException: testInnerException);

            AssertArgumentExceptionWithParamNameAndMessageAndInnerExceptionSerializesCorrectly(exception, TestExceptionMessage, TestParameterName, testInnerException);
        }

        #endregion Default Constructors
    }
}