using System;
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
    public class ReflectiveGuardiansExtensionNullOrNotOfTypeTest : ReflectiveGuardiansExtensionTestBase
    {
        #region ThrowIfNullOrNotOfType

        #region Exception validation

        #region ArgumentNullException

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_null_values_exception_argumentName_and_message_should_match_default(object testValue)
        {
            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentNullMessageWithParamName, nameof(testValue));

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentNullException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<object>(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_null_values_with_custom_argumentName_exception_argumentName_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentNullException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<object>(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_null_values_with_custom_message_exception_message_should_match(object testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentNullException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<object>(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NullValuesTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_null_values_with_custom_argumentName_and_custom_message_exception_properties_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentNullException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<object>(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentNullException

        #region ArgumentIsNotOfTypeException

        [TestCaseSource(nameof(NonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_values_not_of_expected_type_exception_argumentName_and_message_should_match_default(object testValue)
        {
            testValue.ThrowIfNull(nameof(testValue));

            var defaultMessage = string.Format(CultureInfo.InvariantCulture, FlabIt.Guardians.Properties.Resources.Exception_ArgumentOfTypeXIsNotOfTypeYMessageWithParamName, nameof(testValue), testValue.GetType().FullName, typeof(string).FullName);

            AssertThatExceptionParamNameAndMessageShouldMatchDefaultArgumentName<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue), defaultMessage, nameof(testValue));
        }

        [TestCaseSource(nameof(NonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_values_not_of_expected_type_with_custom_argumentName_exception_argumentName_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameShouldMatchCustomArgumentName<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue, testValueParamName), testValueParamName);
        }

        [TestCaseSource(nameof(NonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_values_not_of_expected_type_with_custom_message_exception_message_should_match(object testValue)
        {
            AssertThatExceptionMessageShouldMatchCustomMessage<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue, message: TestCustomExceptionMessage));
        }

        [TestCaseSource(nameof(NonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_values_not_of_expected_type_with_custom_argumentName_and_custom_message_exception_properties_should_match(object testValue)
        {
            const string testValueParamName = nameof(testValue);

            AssertThatExceptionParamNameAndMessageShouldMatch<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue, testValueParamName, TestCustomExceptionMessage), testValueParamName, TestCustomExceptionMessage);
        }

        #endregion ArgumentIsNotOfTypeException

        #endregion Exception validation

        #region Type Object

        [TestCaseSource(nameof(ObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_valid_values_for_desired_type_Object_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<object>(testValue));
        }

        #endregion Type Object

        #region Type String

        [TestCaseSource(nameof(StringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_valid_values_for_desired_type_String_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue));
        }

        [TestCaseSource(nameof(NonStringTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_invalid_values_for_desired_type_String_should_throw_ArgumentIsNotOfTypeException(object testValue)
        {
            AssertThatThrows<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<string>(testValue));
        }

        #endregion Type String

        #region Type IEnumerable<object>

        [TestCaseSource(nameof(IEnumerableOfObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_valid_values_for_desired_type_IEnumerableOfObject_should_not_throw(object testValue)
        {
            AssertThatDoesNotThrow(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<IEnumerable<object>>(testValue));
        }

        [TestCaseSource(nameof(NonIEnumerableOfObjectTypedTestValuesSource))]
        public void When_calling_ThrowIfNullOrNotOfType_with_invalid_values_for_desired_type_IEnumerableOfObject_should_throw_ArgumentIsNotOfTypeException(object testValue)
        {
            AssertThatThrows<ArgumentIsNotOfTypeException>(() => ReflectiveGuardiansExtension.ThrowIfNullOrNotOfType<IEnumerable<object>>(testValue));
        }

        #endregion Type IEnumerable<object>

        #endregion ThrowIfNullOrNotOfType
    }
}