using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    public abstract class GuardiansTestBase : TestBase
    {
        protected const string TestCustomExceptionMessage = "Please provide a valid value.";

        protected void AssertThatThrows<TException>(TestDelegate assertThat)
            where TException : ArgumentException
        {
            assertThat.ThrowIfNull();

            Assert.Throws<TException>(assertThat, TestBaseStringResources.ExpectedExceptionOfTypeXBecauseInvalidInput(typeof(TException)));
        }

        protected void AssertThatDoesNotThrow(TestDelegate assertThat)
        {
            assertThat.ThrowIfNull();

            Assert.DoesNotThrow(assertThat, TestBaseStringResources.ExpectedNoExceptionBecauseValidInput());
        }

        protected void AssertThatReturnsInputAsOutput<T>(Func<T> assertThat, object testValue)
        {
            assertThat.ThrowIfNull();

            var output = assertThat();

            Assert.AreEqual(testValue, output, TestBaseStringResources.ExpectedOutputIsEqualToInput());
            Assert.IsTrue(ReferenceEquals(testValue, output), TestBaseStringResources.ExpectedOutputIsReferenceEqualToInput());
        }

        protected void AssertThatReturnsInputAsOutputForStruct<T>(Func<T> assertThat, object testValue)
            where T : struct
        {
            assertThat.ThrowIfNull();

            var output = assertThat();

            Assert.AreEqual(testValue, output, TestBaseStringResources.ExpectedOutputIsEqualToInput());
        }

        protected void AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<TException>(
            TestDelegate assertThat, string defaultMessage, string argumentName)
            where TException : ArgumentException
        {
            assertThat.ThrowIfNull();
            defaultMessage.ThrowIfNull();
            argumentName.ThrowIfNull();

            var exception = Assert.Throws<TException>(assertThat, TestBaseStringResources.ExpectedExceptionOfTypeXBecauseInvalidInput(typeof(TException)));

            Assert.IsTrue(exception.Message.Contains(defaultMessage, StringComparison.CurrentCulture), TestBaseStringResources.ExpectedMessageToMatchExceptionMessage());
            Assert.AreEqual(argumentName, exception.ParamName, TestBaseStringResources.ExpectedInputParameterNameToMatchExceptionParameterName());
        }

        protected void AssertThatExceptionParamNameShouldMatchCustomArgumentName<TException>(TestDelegate assertThat, string customArgumentName)
            where TException : ArgumentException
        {
            assertThat.ThrowIfNull();

            var exception = Assert.Throws<TException>(assertThat, TestBaseStringResources.ExpectedExceptionOfTypeXBecauseInvalidInput(typeof(TException)));

            Assert.AreEqual(customArgumentName, exception.ParamName, TestBaseStringResources.ExpectedInputParameterNameToMatchExceptionParameterName());
        }

        protected void AssertThatExceptionMessageShouldMatchCustomMessage<TException>(TestDelegate assertThat)
            where TException : Exception
        {
            assertThat.ThrowIfNull();

            var exception = Assert.Throws<TException>(assertThat, TestBaseStringResources.ExpectedExceptionOfTypeXBecauseInvalidInput(typeof(TException)));

            Assert.That(exception.Message.Contains(TestCustomExceptionMessage, StringComparison.InvariantCultureIgnoreCase), TestBaseStringResources.ExpectedMessageToMatchExceptionMessage());
        }

        protected void AssertThatExceptionParamNameAndMessageShouldMatch<TException>(TestDelegate assertThat, [CanBeNull] string customArgumentName, string expectedMessage)
            where TException : ArgumentException
        {
            assertThat.ThrowIfNull();
            expectedMessage.ThrowIfNull();

            var exception = Assert.Throws<TException>(assertThat, TestBaseStringResources.ExpectedExceptionOfTypeXBecauseInvalidInput(typeof(TException)));

            Assert.AreEqual(customArgumentName, exception.ParamName, TestBaseStringResources.ExpectedInputParameterNameToMatchExceptionParameterName());
            Assert.That(exception.Message.Contains(expectedMessage, StringComparison.InvariantCultureIgnoreCase), TestBaseStringResources.ExpectedMessageToMatchExceptionMessage());
        }
    }
}