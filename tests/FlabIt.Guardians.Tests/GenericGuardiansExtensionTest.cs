using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class GenericGuardiansExtensionTest : GuardiansTestBase
    {
        public static IEnumerable NullValuesTestValuesSource()
        {
            yield return null;
            yield return default(object);
            yield return default(string);
            yield return default(List<object>);
        }

        public static IEnumerable NonNullValuesTestValuesSource()
        {
            yield return new object();
            yield return string.Empty;
            yield return " ";
            yield return "  ";
            yield return new List<object>();
            yield return (bool?)true;
            yield return (bool?)false;
            yield return DateTime.Now;
        }

        #region ThrowIfNull

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_null_values_exception_argumentName_and_message_should_match_default(object testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, nameof(testValue));

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_null_values_with_custom_argumentName_exception_argumentName_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_null_values_with_custom_message_exception_message_should_match(object testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #endregion Exception validation

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_null_values_should_throw_ArgumentNullException(object testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_non_null_values_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => GenericGuardiansExtension.ThrowIfNull(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_ThrowIfNull_with_non_null_values_should_return_input_as_output(object testValue)
        {
            AssertThatReturnsInputAsOutput(() => GenericGuardiansExtension.ThrowIfNull(testValue), testValue);
        }

        #endregion ThrowIfNull
    }
}