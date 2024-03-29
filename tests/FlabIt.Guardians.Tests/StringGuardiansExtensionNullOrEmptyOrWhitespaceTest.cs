﻿using System;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class StringGuardiansExtensionNullOrEmptyOrWhitespaceTest : StringGuardiansExtensionTestBase
    {
        #region ThrowIfNullOrEmptyOrWhitespace

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, nameof(testValue));

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_empty_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull();

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, nameof(testValue), typeof(string).FullName, testValue.Length);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_empty_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #region ArgumentWhitespaceException

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_whitespace_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            testValue.ThrowIfNull();

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXOnlyWhitespaceMessageWithParamName, nameof(testValue), typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_whitespace_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_whitespace_values_with_custom_message_exception_message_should_match(string testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_whitespace_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentWhitespaceException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(EmptyStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_empty_values_should_throw_ArgumentEmptyException(string testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_non_empty_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(OnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_only_whitespace_values_should_throw_ArgumentWhitespaceException(string testValue)
        {
            AssertThatThrows<ArgumentWhitespaceException>(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_non_only_whitespace_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue));
        }

        [TestCaseSource(nameof(NonOnlyWhitespaceStringsTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmptyOrWhitespace_with_non_whitespace_values_should_return_input_as_output(string testValue)
        {
            AssertThatReturnsInputAsOutput(() => StringGuardiansExtension.ThrowIfNullOrEmptyOrWhitespace(testValue), testValue);
        }

        #endregion ThrowIfNullOrEmptyOrWhitespace
    }
}