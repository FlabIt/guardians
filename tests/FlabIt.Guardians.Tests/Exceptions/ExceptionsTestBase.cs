using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using FlabIt.Guardians.Exceptions;
using JetBrains.Annotations;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests.Exceptions
{
    public abstract class ExceptionsTestBase : TestBase
    {
        protected const string TestParameterName = "testParameterName";

        protected const string TestExceptionMessage = "Test message";

        protected const string TestInnerExceptionMessage = "Test inner message";

        /// <summary>
        /// A list of distinct assembly identifier types.
        /// That means for each assembly we consider to test, there's exactly one type from that assembly referenced here.
        /// </summary>
        private static readonly Type[] _distinctAssemblyIdentifierTypes =
        {
            typeof(GenericGuardiansExtension),
        };

        /// <summary>
        /// Gets all exception types.
        /// </summary>
        /// <returns>An enumerable of all exception types.</returns>
        protected static IEnumerable<Type> GetAllExceptionTypes()
        {
            foreach (var exceptionTypes in GetAssembliesToTest().Select(assembly => GetExceptionTypesFrom(assembly.GetTypes())))
            {
                foreach (var exceptionType in exceptionTypes)
                {
                    yield return exceptionType;
                }
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Exception"/> that can be used as an inner exception for tests.
        /// </summary>
        /// <returns>A new instance of <see cref="Exception"/>.</returns>
        protected static Exception CreateTestInnerException()
        {
            return new Exception(message: TestInnerExceptionMessage);
        }

        /// <summary>
        /// Gets all assemblies that tests should run against.
        /// </summary>
        /// <returns>An enumerable of assemblies that tests should run against.</returns>
        protected static IEnumerable<Assembly> GetAssembliesToTest()
        {
            foreach (var typeToIdentifyAssembly in _distinctAssemblyIdentifierTypes)
            {
                var assembly = Assembly.GetAssembly(typeToIdentifyAssembly);

                assembly.ThrowIfNull(nameof(assembly), $"Could not resolve assembly for type '{typeToIdentifyAssembly.FullName}'.");

                yield return assembly;
            }
        }

        /// <summary>
        /// Returns only types that are considered as exception types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>An enumerable of types considered as exception types.</returns>
        protected static IEnumerable<Type> GetExceptionTypesFrom(IEnumerable<Type> types)
        {
            return types.Where(type => DerivesFrom(type, typeof(Exception)));
        }

        /// <summary>
        /// Determines whether <paramref name="type"/> derives from <paramref name="derivesFrom"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="derivesFrom">The derives from.</param>
        /// <returns><c>True</c> when <paramref name="type"/> derives from <paramref name="derivesFrom"/>, otherwise <c>false</c>.</returns>
        protected static bool DerivesFrom(Type type, Type derivesFrom)
        {
            type.ThrowIfNull(nameof(type));
            derivesFrom.ThrowIfNull(nameof(derivesFrom));

            if (type.BaseType == null)
                return false;

            if (type.BaseType == derivesFrom)
                return true;

            return DerivesFrom(type.BaseType, derivesFrom);
        }

        /// <summary>
        /// Determines whether <paramref name="type"/> is marked with attribute of type <paramref name="attributeType"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns><c>True</c>, when <paramref name="type"/> is marked with attribute of type <paramref name="attributeType"/>, otherwise <c>false</c>.</returns>
        protected static bool TypeIsMarkedWithAttribute(Type type, Type attributeType)
        {
            type.ThrowIfNull(nameof(type));
            attributeType.ThrowIfNull(nameof(attributeType));

            return type.CustomAttributes.Any(attribute => attribute.AttributeType == attributeType);
        }

        /// <summary>
        /// Serializes and then deserializes the given exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The exception.</param>
        /// <returns>The deserialized exception.</returns>
        protected static TException SerializeAndDeserializeException<TException>(TException exception)
        {
            var formatter = new BinaryFormatter();
            using var stream = new MemoryStream();

#pragma warning disable SYSLIB0011 // Type or member is obsolete
            formatter.Serialize(serializationStream: stream, graph: exception);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

            stream.Seek(offset: 0, SeekOrigin.Begin);

#pragma warning disable SYSLIB0011 // Type or member is obsolete
            return (TException)formatter.Deserialize(serializationStream: stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        }

        protected void AssertArgumentExceptionWithDefaultValuesSerializesCorrectly<TException>(TException exception)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasSomeMessage(e);

                    AssertHasNoParamName(e);

                    AssertHasNoInnerException(e);
                });
        }

        protected void AssertArgumentExceptionWithMessageSerializesCorrectly<TException>(TException exception, string testMessage)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasNoParamName(e);

                    AssertHasNoInnerException(e);
                });
        }

        protected void AssertArgumentExceptionWithParamNameAndMessageSerializesCorrectly<TException>(TException exception, string testMessage, string testParamName)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));
            testParamName.ThrowIfNull(nameof(testParamName));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasCorrectParamName(e, testParamName);

                    AssertHasNoInnerException(e);
                });
        }

        protected void AssertArgumentExceptionWithMessageAndInnerExceptionSerializesCorrectly<TException>(TException exception, string testMessage, Exception testInnerException)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));
            testInnerException.ThrowIfNull(nameof(testInnerException));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasNoParamName(e);

                    AssertHasCorrectInnerException(e, testInnerException);
                });
        }

        protected void AssertArgumentExceptionWithParamNameAndMessageAndInnerExceptionSerializesCorrectly<TException>(TException exception, string testMessage, string testParamName, Exception testInnerException)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));
            testMessage.ThrowIfNull(nameof(testMessage));
            testInnerException.ThrowIfNull(nameof(testInnerException));

            AssertArgumentExceptionSerializesCorrectly(
                exception,
                e =>
                {
                    AssertHasCorrectMessage(e, testMessage);

                    AssertHasCorrectParamName(e, testParamName);

                    AssertHasCorrectInnerException(e, testInnerException);
                });
        }

        protected void AssertHasCorrectMessage(Exception e, string expectedMessage)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNotNull(e.Message, TestBaseStringResources.ExpectedPropertyToBeSet(nameof(e.Message)));
            Assert.IsTrue(e.Message.Contains(expectedMessage, StringComparison.InvariantCulture), TestBaseStringResources.ExpectedPropertyToMatch(nameof(e.Message), e.Message, expectedMessage));
        }

        protected void AssertHasSomeMessage(Exception e)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNotNull(e.Message, TestBaseStringResources.ExpectedPropertyToBeSet(nameof(e.Message)));
        }

        protected void AssertHasCorrectParamName(ArgumentException e, string expectedParameterName)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNotNull(e.ParamName, TestBaseStringResources.ExpectedPropertyToBeSet(nameof(e.ParamName)));
            Assert.AreEqual(e.ParamName, expectedParameterName, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e.ParamName), e.ParamName, expectedParameterName));
        }

        protected void AssertHasNoParamName(ArgumentException e)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNull(e.ParamName, TestBaseStringResources.ExpectedPropertyToBeNotSet(nameof(e.ParamName)));
        }

        protected void AssertHasCorrectInnerException(Exception e, Exception expectedInnerException)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNotNull(e.InnerException, TestBaseStringResources.ExpectedPropertyToBeSet(nameof(e.InnerException)));
            AssertExceptionsEqual(e.InnerException, expectedInnerException);
        }

        protected void AssertHasNoInnerException(Exception e)
        {
            e.ThrowIfNull(nameof(e));

            Assert.IsNull(e.InnerException, TestBaseStringResources.ExpectedPropertyToBeNotSet(nameof(e.InnerException)));
        }

        protected void AssertExceptionsEqual([CanBeNull, ValidatedNotNull] Exception e, [CanBeNull, ValidatedNotNull] Exception expectedException)
        {
            if (e is null && expectedException is null)
                return;

            Assert.IsFalse(e is null && !(expectedException is null));
            Assert.IsFalse(!(e is null) && expectedException is null);

            Assert.AreEqual(e.StackTrace, expectedException.StackTrace, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e.StackTrace), e.StackTrace, expectedException.StackTrace));
            Assert.AreEqual(e.Message, expectedException.Message, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e), e.Message, expectedException.Message));
            Assert.AreEqual(e.Source, expectedException.Source, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e), e.Source, expectedException.Source));
            Assert.AreEqual(e.InnerException, expectedException.InnerException, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e), e.InnerException, expectedException.InnerException));
            Assert.AreEqual(e.Data, expectedException.Data, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e), e.Data, expectedException.Data));
            Assert.AreEqual(e.HResult, expectedException.HResult, TestBaseStringResources.ExpectedPropertyToMatch(nameof(e), e.HResult, expectedException.HResult));
        }

        protected void AssertArgumentExceptionSerializesCorrectly<TException>(TException exception, Action<TException> assertExceptionState)
            where TException : ArgumentException
        {
            exception.ThrowIfNull(nameof(exception));
            assertExceptionState.ThrowIfNull(nameof(assertExceptionState));

            assertExceptionState(exception);

            string exceptionToString = exception.ToString();

            exception = SerializeAndDeserializeException(exception);

            assertExceptionState(exception);

            Assert.AreEqual(exceptionToString, exception.ToString(), TestBaseStringResources.ExpectedExceptionOfTypeXToBeSerializedAndDeserializedCorrectly(typeof(ArgumentEmptyException)));
        }
    }
}