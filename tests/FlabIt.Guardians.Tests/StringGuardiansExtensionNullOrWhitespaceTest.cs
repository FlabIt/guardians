using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod", Justification = "We'll want to be explicit here to know what methods we actually run.")]
    public class StringGuardiansExtensionNullOrWhitespaceTest : StringGuardiansExtensionTestBase
    {
        #region ThrowIfNullOrWhitespace

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentWhitespaceException

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_whitespace_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXOnlyWhitespaceMessageWithParamName, DefaultArgumentName, typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_whitespace_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_whitespace_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_whitespace_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentWhitespaceException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_empty_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_only_whitespace_values_should_throw_ArgumentWhitespaceException(string testValue)
        {
            AssertThatThrows<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrWhitespace_with_non_only_whitespace_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrWhitespace(testValue));
        }

        #endregion ThrowIfNullOrWhitespace

        #region PassThroughNonNullNorWhitespace

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentWhitespaceException

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_whitespace_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXOnlyWhitespaceMessageWithParamName, DefaultArgumentName, typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentWhitespaceException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_whitespace_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentWhitespaceException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_whitespace_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentWhitespaceException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_whitespace_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentWhitespaceException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentWhitespaceException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_empty_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_non_whitespace_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_whitespace_values_should_throw_ArgumentWhitespaceException(string testValue)
        {
            AssertThatThrows<ArgumentWhitespaceException>(() => _ = StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_PassThroughNonNullNorWhitespace_with_non_whitespace_values_should_return_input_as_output(string testValue)
        {
            AssertThatReturnsInputAsOutput(() => StringGuardiansExtension.PassThroughNonNullNorWhitespace(testValue), testValue);
        }

        #endregion PassThroughNonNullNorWhitespace
    }
}