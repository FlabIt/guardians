using System;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class StringGuardiansExtensionLargerThanTest : StringGuardiansExtensionTestBase
    {
        #region ThrowIfLargerThan

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_null_values_exception_argumentName_and_message_should_match_default(string testValue)
        {
            const int testLength = 0;

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength), defaultMessage);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_null_values_with_custom_argumentName_exception_argumentName_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            const int testLength = 0;

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_null_values_with_custom_message_exception_message_should_match(string testValue)
        {
            const int testLength = 0;

            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue)
        {
            const string testValueParamName = nameof(testValue);
            const int testLength = 0;

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentLengthLargerThanException

        [TestCaseSource(nameof(StringsLargerThanLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_larger_than_length_exception_argumentName_and_message_should_match_default(string testValue, int testLength)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXLargerThanMessageWithParamName, DefaultArgumentName, typeof(string).FullName, testLength, testValue.Length);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentLengthLargerThanException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength), defaultMessage);
        }

        [TestCaseSource(nameof(StringsLargerThanLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_larger_than_length_with_custom_argumentName_exception_argumentName_should_match(string testValue, int testLength)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentLengthLargerThanException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(StringsLargerThanLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_larger_than_length_with_custom_message_exception_message_should_match(string testValue, int testLength)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentLengthLargerThanException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(StringsLargerThanLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_larger_than_length_with_custom_argumentName_and_custom_message_exception_properties_should_match(string testValue, int testLength)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentLengthLargerThanException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentLengthLargerThanException

        #endregion Exception validation

        [TestCaseSource(nameof(NonNullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_non_null_values_should_not_throw(string testValue)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testValue.Length + 1));
        }

        [TestCaseSource(nameof(NullStringsTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_null_values_should_throw_ArgumentNullException(string testValue)
        {
            const int testLength = 0;

            AssertThatThrows<ArgumentNullException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength));
        }

        [TestCaseSource(nameof(StringsLargerThanLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_larger_than_given_length_should_throw_ArgumentLengthLargerThanException(string testValue, int testLength)
        {
            AssertThatThrows<ArgumentLengthLargerThanException>(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength));
        }

        [TestCaseSource(nameof(StringsShorterThanOrEqualToLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_not_larger_than_given_length_should_not_throw(string testValue, int testLength)
        {
            AssertThatDoesNotThrow(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength));
        }

        [TestCaseSource(nameof(StringsShorterThanOrEqualToLengthTestValuesSource))]
        public void When_calling_ThrowIfLargerThan_with_values_shorter_than_or_equal_to_length_should_return_input_as_output(string testValue, int testLength)
        {
            AssertThatReturnsInputAsOutput(() => StringGuardiansExtension.ThrowIfLargerThan(testValue, testLength), testValue);
        }

        #endregion ThrowIfLargerThan
    }
}