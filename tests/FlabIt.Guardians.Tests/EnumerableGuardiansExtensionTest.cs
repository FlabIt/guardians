using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using FlabIt.Guardians.Exceptions;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod", Justification = "We'll want to be explicit here to know what methods we actually run.")]
    [SuppressMessage("ReSharper", "RedundantExplicitArrayCreation", Justification = "We'll want to be explicit here to know what types we actually use.")]
    public class EnumerableGuardiansExtensionTest : GuardiansTestBase
    {
        public static IEnumerable NullValuesTestValuesSource()
        {
            yield return null;

            yield return default(ICollection);
            yield return default(IReadOnlyCollection<int>);
            yield return default(IEnumerable);
            yield return default(IList);
            yield return default(IDictionary);

            yield return default(Array);
            yield return default(ArrayList);
        }

        public static IEnumerable NonNullValuesTestValuesSource()
        {
            yield return new int[] { 1, 2 };
            yield return new double[] { 1, 2 };
            yield return new List<object>() { new object() };
        }

        public static IEnumerable EmptyValuesTestValuesSource()
        {
            yield return Array.Empty<int>();
            yield return new List<int>();
            yield return new List<float>();
        }

        public static IEnumerable NonEmptyValuesTestValuesSource()
        {
            yield return new List<int>() { 1 };
            yield return new List<object>() { new object() };
            yield return new int[] { 1, 2 };
        }

        #region ThrowIfNullOrEmpty

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_exception_argumentName_and_message_should_match_default(IEnumerable testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_argumentName_exception_argumentName_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_message_exception_message_should_match(IEnumerable testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(IEnumerable testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, testValue.GetType().FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_message_exception_message_should_match(IEnumerable testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_null_values_should_throw_ArgumentNullException(IEnumerable testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_non_null_values_should_not_throw(IEnumerable testValue)
        {
            AssertThatDoesNotThrow(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_empty_values_should_throw_ArgumentEmptyException(IEnumerable testValue)
        {
            AssertThatThrows<ArgumentEmptyException>(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_non_empty_values_should_not_throw(IEnumerable testValue)
        {
            AssertThatDoesNotThrow(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrEmpty_with_non_empty_values_should_return_input_as_output(IEnumerable testValue)
        {
            AssertThatReturnsInputAsOutput(() => EnumerableGuardiansExtension.ThrowIfNullOrEmpty(testValue), testValue);
        }

        #endregion ThrowIfNullOrEmpty

        #region PassThroughNonNullNorEmpty

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_exception_argumentName_and_message_should_match_default(IEnumerable testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, DefaultArgumentName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_argumentName_exception_argumentName_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_message_exception_message_should_match(IEnumerable testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentEmptyException

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_exception_argumentName_and_message_should_match_default(IEnumerable testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, DefaultArgumentName, testValue.GetType().FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentEmptyException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue), defaultMessage);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_argumentName_exception_argumentName_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentEmptyException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_message_exception_message_should_match(IEnumerable testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentEmptyException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(EmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_empty_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(IEnumerable testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentEmptyException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentEmptyException

        #endregion Exception validation

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_null_values_should_throw_ArgumentNullException(IEnumerable testValue)
        {
            AssertThatThrows<ArgumentNullException>(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(NonNullValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_non_null_values_should_not_throw(IEnumerable testValue)
        {
            AssertThatDoesNotThrow(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_non_empty_values_should_not_throw(IEnumerable testValue)
        {
            AssertThatDoesNotThrow(() => _ = EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue));
        }

        [TestCaseSource(nameof(NonEmptyValuesTestValuesSource))]
        public void When_calling_PassThroughNonNullNorEmpty_with_non_empty_values_should_return_input_as_output(IEnumerable testValue)
        {
            AssertThatReturnsInputAsOutput(() => EnumerableGuardiansExtension.PassThroughNonNullNorEmpty(testValue), testValue);
        }

        #endregion PassThroughNonNullNorEmpty
    }
}