using System;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class StringGuardiansExtensionNullOrEmptyTest : StringGuardiansExtensionTestBase
    {
        #region ThrowIfNullOrEmpty

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, typeof(string).FullName, testValue.Length);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(NonNullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_whitespace_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_should_throw_ArgumentEmptyException(string testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_non_empty_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        #endregion ThrowIfNullOrEmpty

        #region PassThroughNonNullNorEmpty

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_whitespace_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_should_throw_ArgumentEmptyException(string testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_non_empty_values_should_return_input_as_output(string testValue)
        {
            AssertThatReturnsInputAsOutput(() => StringGuardiansExtension.PassThroughNonNullNorEmpty(testValue), testValue);
        }

        #endregion PassThroughNonNullNorEmpty
    }
}