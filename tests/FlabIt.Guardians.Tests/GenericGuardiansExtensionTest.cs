using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod", Justification = "We'll want to be explicit here to know what methods we actually run.")]
    [SuppressMessage("ReSharper", "RedundantTypeSpecificationInDefaultExpression", Justification = "We'll want to be explicit here to know what types we actually use.")]
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
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => GenericGuardiansExtension.ThrowIfNull(testValue), defaultMessage);
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

        #region PassThroughNonNull

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_null_values_exception_argumentName_and_message_should_match_default(object testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_null_values_with_custom_argumentName_exception_argumentName_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_null_values_with_custom_message_exception_message_should_match(object testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #endregion Exception validation

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_null_values_should_throw_ArgumentNullException(object testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_non_null_values_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => _ = GenericGuardiansExtension.PassThroughNonNull(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNull_with_non_null_values_should_return_input_as_output(object testValue)
        {
            AssertThatReturnsInputAsOutput(() => GenericGuardiansExtension.PassThroughNonNull(testValue), testValue);
        }

        #endregion PassThroughNonNull
    }
}