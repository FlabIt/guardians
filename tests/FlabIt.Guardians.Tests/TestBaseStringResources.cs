using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace FlabIt.Guardians.Tests
{
    public class TestBaseStringResources
    {
        private readonly IFormatProvider _formatProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBaseStringResources"/> class.
        /// </summary>
        /// <param name="formatProvider">The format provider used to format the resources.</param>
        public TestBaseStringResources(IFormatProvider formatProvider)
        {
            formatProvider.ThrowIfNull(nameof(formatProvider));

            _formatProvider = formatProvider;
        }

        protected string Format(string message, params object[] parameters)
        {
            return string.Format(_formatProvider, message, parameters);
        }

        [DebuggerStepThrough]
        public string ExpectedMessageToMatchExceptionMessage() =>
            Format(
                Properties.Resources.Test_ExpectedMessageToMatchExceptionMessage);

        [DebuggerStepThrough]
        public string ExpectedExceptionOfTypeXBecauseInvalidInput(Type type) =>
            Format(
                Properties.Resources.Test_ExpectedExceptionOfTypeXBecauseInvalidInput,
                type.PassThroughNonNull(nameof(type)).FullName);

        [DebuggerStepThrough]
        public string ExpectedInputParameterNameToMatchExceptionParameterName() =>
            Format(
                Properties.Resources.Test_ExpectedInputParameterNameToMatchExceptionParameterName);

        [DebuggerStepThrough]
        public string ExpectedOutputIsReferenceEqualToInput() =>
            Format(
                Properties.Resources.Test_ExpectedOutputIsReferenceEqualToInput);

        [DebuggerStepThrough]
        public string ExpectedOutputIsEqualToInput() =>
            Format(
                Properties.Resources.Test_ExpectedOutputIsEqualToInput);

        [DebuggerStepThrough]
        public string ExpectedNoExceptionBecauseValidInput() =>
            Format(
                Properties.Resources.Test_ExpectedNoExceptionBecauseValidInput);

        [DebuggerStepThrough]
        public string ExpectedTypeToBeMarkedWithAttributeOfType(Type type, Type attributeType) =>
            Format(
                Properties.Resources.Test_ExpectedTypeToBeMarkedWithAttributeOfType,
                type.PassThroughNonNull(nameof(type)).FullName,
                attributeType.PassThroughNonNull(nameof(attributeType)).FullName);

        [DebuggerStepThrough]
        public string ExpectedCustomExceptionsToFollowNamingConvention(string exceptionSuffix) =>
            Format(
                Properties.Resources.Test_ExpectedCustomExceptionsToFollowNamingConvention,
                exceptionSuffix.PassThroughNonNull(nameof(exceptionSuffix)));

        [DebuggerStepThrough]
        public string ExpectedExceptionOfTypeXToBeSerializedAndDeserializedCorrectly(Type type) =>
            Format(
                Properties.Resources.Test_ExpectedExceptionOfTypeXToBeSerializedAndDeserializedCorrectly,
                type.PassThroughNonNull(nameof(type)).FullName);

        [DebuggerStepThrough]
        public string ExpectedPropertyToBeSet(string propertyName) =>
            Format(
                Properties.Resources.Test_ExpectedPropertyToBeSet,
                propertyName.PassThroughNonNull(nameof(propertyName)));

        [DebuggerStepThrough]
        public string ExpectedPropertyToBeNotSet(string propertyName) =>
            Format(
                Properties.Resources.Test_ExpectedPropertyToBeNotSet,
                propertyName.PassThroughNonNull(nameof(propertyName)));

        [DebuggerStepThrough]
        public string ExpectedPropertyToMatch(string propertyName, [CanBeNull] object givenValue, [CanBeNull] object expectedValue) =>
            Format(
                Properties.Resources.Test_ExpectedPropertyToMatch,
                propertyName.PassThroughNonNullNorEmptyNorWhitespace(nameof(propertyName)),
                expectedValue,
                givenValue);
    }
}