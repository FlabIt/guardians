using System.Diagnostics.CodeAnalysis;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests.Exceptions
{
    [TestFixture]
    [SuppressMessage(category: "Naming", checkId: "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
    [SuppressMessage(category: "Naming", checkId: "CA1303:Do not pass literals as localized parameters", Justification = "We don't want to use localized resources here.")]
    [SuppressMessage(category: "Naming", checkId: "CA2208:Instantiate argument exceptions correctly", Justification = "We supply the correct parameter name for the test here.")]
    public class ArgumentEmptyExceptionTest : ExceptionsTestBase
    {
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
    }
}