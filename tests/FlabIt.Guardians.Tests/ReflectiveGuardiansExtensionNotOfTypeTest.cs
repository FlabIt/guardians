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
    [SuppressMessage("ReSharper", "RedundantTypeSpecificationInDefaultExpression", Justification = "We'll want to be explicit here to know what types we actually use.")]
    public class ReflectiveGuardiansExtensionNotOfTypeTest : ReflectiveGuardiansExtensionTestBase
    {
        public static IEnumerable NullOrNonStringTypedTestValuesSource()
        {
            yield return new object();
            yield return 1;
            yield return true;
            yield return null;
            yield return default(string);
        }

        public static IEnumerable NullOrNonIEnumerableOfObjectTypedTestValuesSource()
        {
            yield return new List<int>();
            yield return true;
        }

        #region ThrowIfNotOfType

        #region Exception validation

        #region ArgumentIsNotOfTypeException

        [TestCaseSource(nameof(NullOrNonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_values_not_of_expected_type_exception_argumentName_and_message_should_match_default(object testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXIsNotOfTypeYMessageWithParamName, nameof(testValue), testValue?.GetType().FullName, typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(NullOrNonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_values_not_of_expected_type_with_custom_argumentName_exception_argumentName_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullOrNonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_values_not_of_expected_type_with_custom_message_exception_message_should_match(object testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullOrNonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_values_not_of_expected_type_with_custom_argumentName_and_custom_message_exception_properties_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentIsNotOfTypeException

        #endregion Exception validation

        #region Type Object

        [TestCaseSource(nameof(ObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_valid_values_for_desired_type_Object_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<object>(testValue));
        }

        #endregion Type Object

        #region Type String

        [TestCaseSource(nameof(StringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_valid_values_for_desired_type_String_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue));
        }

        [TestCaseSource(nameof(NullOrNonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_invalid_values_for_desired_type_String_should_throw_ArgumentIsNotOfTypeException(object testValue)
        {
            AssertThatThrows<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<string>(testValue));
        }

        #endregion Type String

        #region Type IEnumerable<object>

        [TestCaseSource(nameof(IEnumerableOfObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_valid_values_for_desired_type_IEnumerableOfObject_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<IEnumerable<object>>(testValue));
        }

        [TestCaseSource(nameof(NullOrNonIEnumerableOfObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNotOfType_with_invalid_values_for_desired_type_IEnumerableOfObject_should_throw_ArgumentIsNotOfTypeException(object testValue)
        {
            AssertThatThrows<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNotOfType<IEnumerable<object>>(testValue));
        }

        #endregion Type IEnumerable<object>

        #endregion ThrowIfNotOfType
    }
}