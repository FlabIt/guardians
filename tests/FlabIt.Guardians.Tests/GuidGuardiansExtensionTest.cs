using System;
using System.Collections.Generic;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class GuidGuardiansExtensionTest : GuardiansTestBase
    {
        public static IEnumerable<Guid> EmptyValuesTestValuesSource()
        {
            yield return Guid.Empty;
            yield return default(Guid);
            yield return Guid.Parse("00000000-0000-0000-0000-000000000000");
        }

        public static IEnumerable<Guid> NonEmptyValuesTestValuesSource()
        {
            yield return Guid.NewGuid();
        }

        #region ThrowIfEmpty

        #region Exception validation

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(Guid testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, typeof(Guid).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => GuidGuardiansExtension.ThrowIfEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(Guid testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => GuidGuardiansExtension.ThrowIfEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_empty_values_with_custom_message_exception_message_should_match(Guid testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => GuidGuardiansExtension.ThrowIfEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(Guid testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => GuidGuardiansExtension.ThrowIfEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_empty_values_should_throw_ArgumentEmptyException(Guid testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => GuidGuardiansExtension.ThrowIfEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfEmpty_with_non_empty_values_should_not_throw(Guid testValue)
        {
            AssertThatDoesNotThrow(() => GuidGuardiansExtension.ThrowIfEmpty(testValue));
        }

        #endregion ThrowIfEmpty

        #region PassThroughNonEmpty

        #region Exception validation

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(Guid testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, typeof(Guid).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(Guid testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_empty_values_with_custom_message_exception_message_should_match(Guid testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(Guid testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_empty_values_should_throw_ArgumentEmptyException(Guid testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_non_empty_values_should_not_throw(Guid testValue)
        {
            AssertThatDoesNotThrow(() => _ = GuidGuardiansExtension.PassThroughNonEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonEmpty_with_non_empty_values_should_return_input_as_output(Guid testValue)
        {
            AssertThatReturnsInputAsOutputForStruct(() => GuidGuardiansExtension.PassThroughNonEmpty(testValue), testValue);
        }

        #endregion PassThroughNonEmpty
    }
}