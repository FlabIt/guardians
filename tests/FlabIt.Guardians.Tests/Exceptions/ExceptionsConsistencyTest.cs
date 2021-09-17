using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests.Exceptions
{
    [TestFixture]
    public class ExceptionsConsistencyTest : ExceptionsTestBase
    {
        /// <summary>
        /// A test case source that contains all types inheriting <see cref="System.Exception"/>.
        /// </summary>
        /// <returns>An enumerable of test case data.</returns>
        public static IEnumerable<Type> AllAssembliesTestCaseSource()
        {
            return GetAllExceptionTypes();
        }

        [TestCaseSource(nameof(AllAssembliesTestCaseSource))]
        public void All_exception_types_must_be_marked_with_SerializableAttribute(Type exceptionTestType)
        {
            exceptionTestType.ThrowIfNull(nameof(exceptionTestType));

            var serializableAttributeType = typeof(SerializableAttribute);

            Assert.IsTrue(TypeIsMarkedWithAttribute(exceptionTestType, serializableAttributeType), TestBaseStringResources.ExpectedTypeToBeMarkedWithAttributeOfType(exceptionTestType, serializableAttributeType));
        }

        [TestCaseSource(nameof(AllAssembliesTestCaseSource))]
        public void All_exception_types_must_follow_exception_naming_conventions(Type exceptionTestType)
        {
            exceptionTestType.ThrowIfNull(nameof(exceptionTestType));

            const string exceptionSuffix = "Exception";

            Assert.IsTrue(exceptionTestType.Name.EndsWith(exceptionSuffix, StringComparison.Ordinal), TestBaseStringResources.ExpectedCustomExceptionsToFollowNamingConvention(exceptionSuffix));
        }
    }
}