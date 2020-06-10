using System;
using System.Diagnostics.CodeAnalysis;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests.Exceptions
{
    [TestFixture]
    [SuppressMessage(category: "Naming", checkId: "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
    [SuppressMessage(category: "Naming", checkId: "CA1303:Do not pass literals as localized parameters", Justification = "We don't want to use localized resources here.")]
    [SuppressMessage(category: "Naming", checkId: "CA2208:Instantiate argument exceptions correctly", Justification = "We supply the correct parameter name for the test here.")]
    public class ArgumentIsNotOfTypeExceptionTest : ExceptionsTestBase
    {
        #region Default Constructors

        [Test]
        public void When_serializing_exception_with_default_values_should_deserialize_correctly()
        {
            var exception = new ArgumentIsNotOfTypeException();

            AssertArgumentExceptionWithDefaultValuesSerializesCorrectly(exception);
        }

        [Test]
        public void When_serializing_exception_with_message_should_deserialize_correctly()
        {
            var exception = new ArgumentIsNotOfTypeException(TestExceptionMessage);

            AssertArgumentExceptionWithMessageSerializesCorrectly(exception, TestExceptionMessage);
        }

        [Test]
        public void When_serializing_exception_with_paramName_and_message_should_deserialize_correctly()
        {
            var exception = new ArgumentIsNotOfTypeException(paramName: TestParameterName, message: TestExceptionMessage);

            AssertArgumentExceptionWithParamNameAndMessageSerializesCorrectly(exception, TestExceptionMessage, TestParameterName);
        }

        [Test]
        public void When_serializing_exception_with_message_and_innerException_should_deserialize_correctly()
        {
            var testInnerException = CreateTestInnerException();

            var exception = new ArgumentIsNotOfTypeException(message: TestExceptionMessage, innerException: testInnerException);

            AssertArgumentExceptionWithMessageAndInnerExceptionSerializesCorrectly(exception, TestExceptionMessage, testInnerException);
        }

        [Test]
        public void When_serializing_exception_with_paramName_and_message_and_innerException_should_deserialize_correctly()
        {
            var testInnerException = CreateTestInnerException();

            var exception = new ArgumentIsNotOfTypeException(paramName: TestParameterName, message: TestExceptionMessage, innerException: testInnerException);

            AssertArgumentExceptionWithParamNameAndMessageAndInnerExceptionSerializesCorrectly(exception, TestExceptionMessage, TestParameterName, testInnerException);
        }

        #endregion Default Constructors

        [Test]
        public void When_serializing_exception_with_paramName_and_message_and_expectedType_should_deserialize_correctly()
        {
            var testExpectedType = typeof(Exception).FullName;

            var exception = new ArgumentIsNotOfTypeException(paramName: TestParameterName, message: TestExceptionMessage, expectedFullyQualifiedType: testExpectedType);

            AssertArgumentExceptionWithParamNameAndMessageAndExpectedTypeSerializesCorrectly(exception, TestExceptionMessage, TestParameterName, testExpectedType);
        }

        [Test]
        public void When_serializing_exception_with_paramName_and_message_and_expectedType_and_innerException_should_deserialize_correctly()
        {
            var testExpectedType = typeof(Exception).FullName;
            var testInnerException = CreateTestInnerException();

            var exception = new ArgumentIsNotOfTypeException(paramName: TestParameterName, message: TestExceptionMessage, expectedTypeName: testExpectedType, innerException: testInnerException);

            AssertArgumentExceptionWithParamNameAndMessageAndExpectedTypeAndInnerExceptionSerializesCorrectly(exception, TestExceptionMessage, TestParameterName, testExpectedType, testInnerException);
        }

        protected void AssertArgumentExceptionWithParamNameAndMessageAndExpectedTypeSerializesCorrectly<TException>(TException exception, string testMessage, string testParamName, string expectedTypeName)
            where TException : ArgumentIsNotOfTypeException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));
            expectedTypeName.ThrowIfNull(nameof(expectedTypeName));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasCorrectParamName(e, testParamName);

                    AssertHasNoInnerException(e);

                    AssertHasCorrectExpectedType(e, expectedTypeName);
                });
        }

        protected void AssertArgumentExceptionWithParamNameAndMessageAndExpectedTypeAndInnerExceptionSerializesCorrectly<TException>(TException exception, string testMessage, string testParamName, string expectedTypeName, Exception testInnerException)
            where TException : ArgumentIsNotOfTypeException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));
            expectedTypeName.ThrowIfNull(nameof(expectedTypeName));
            testInnerException.ThrowIfNull(nameof(testInnerException));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasCorrectParamName(e, testParamName);

                    AssertHasCorrectInnerException(e, testInnerException);

                    AssertHasCorrectExpectedType(e, expectedTypeName);
                });
        }

        protected void AssertHasCorrectExpectedType(ArgumentIsNotOfTypeException e, string expectedExpectedTypeName)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNotNull(e.ExpectedType, TestBaseStringResources.ExpectedPropertyToBeSet(nameof(e.ExpectedType)));
            Assert.AreEqual(e.ExpectedType, expectedExpectedTypeName, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e.ExpectedType), e.ExpectedType, expectedExpectedTypeName));
        }
    }
}