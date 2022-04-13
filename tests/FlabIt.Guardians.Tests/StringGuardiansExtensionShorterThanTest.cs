using System;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class StringGuardiansExtensionShorterThanTest : StringGuardiansExtensionTestBase
    {
        #region ThrowIfShorterThan

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            const int testLength = 0;

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            const int testLength = 0;

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            const int testLength = 0;

            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            const int testLength = 0;

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentLengthShorterThanException

        [TestCaseSource(nameof(StringsShorterThanLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_larger_than_length_exception_argumentName_and_message_should_match_default(string testValue, int testLength)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXShorterThanMessageWithParamName, DefaultArgumentName, typeof(string).FullName, testLength, testValue.Length);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentLengthShorterThanException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength), defaultMessage);
        }

        [TestCaseSource(nameof(StringsShorterThanLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_larger_than_length_with_custom_argumentName_exception_argumentName_should_match(string testValue, int testLength)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentLengthShorterThanException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(StringsShorterThanLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_larger_than_length_with_custom_message_exception_message_should_match(string testValue, int testLength)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentLengthShorterThanException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(StringsShorterThanLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_larger_than_length_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue, int testLength)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentLengthShorterThanException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentLengthShorterThanException

        #endregion Exception validation

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            const int testLength = 0;

            AssertThatThrows<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength, nameof(testValue)));
        }

        [TestCaseSource(nameof(NonNullStringsTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testValue.Length - 1));
        }

        [TestCaseSource(nameof(StringsShorterThanLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_shorter_than_given_length_should_throw_ArgumentLengthShorterThanException(string testValue, int testLength)
        {
            AssertThatThrows<ArgumentLengthShorterThanException>(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength));
        }

        [TestCaseSource(nameof(StringsLargerThanOrEqualToLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_not_shorter_than_given_length_should_not_throw(string testValue, int testLength)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength));
        }

        [TestCaseSource(nameof(StringsLargerThanOrEqualToLengthTestValuesSource))]
        public void When_calling_ThrowIfShorterThan_with_values_larger_than_or_equal_to_length_should_return_input_as_output(string testValue, int testLength)
        {
            AssertThatReturnsInputAsOutput(() => StringGuardiansExtension.ThrowIfShorterThan(testValue, testLength), testValue);
        }

        #endregion ThrowIfShorterThan
    }
}