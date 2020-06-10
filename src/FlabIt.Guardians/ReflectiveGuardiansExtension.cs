using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using FlabIt.Guardians.Exceptions;
using FlabIt.Guardians.Properties;
using JetBrains.Annotations;

namespace FlabIt.Guardians
{
    /// <summary>
    /// A set of extension method guardians, or validation helper methods, that guard the calling code
    /// from unexpected inputs by stopping the code execution using reasonable exceptions.
    /// </summary>
    public static class ReflectiveGuardiansExtension
    {
        private static string GetIsNotOfTypeErrorMessage([NotNull] string argumentName, [CanBeNull] Type actualArgumentType, [NotNull] Type expectedArgumentType)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXIsNotOfTypeYMessageWithParamName, argumentName, actualArgumentType?.FullName, expectedArgumentType.FullName);
        }

        private static Exception ThrowArgumentIsNotOfType([NotNull] string argumentName, [CanBeNull] string message, [CanBeNull] Type argumentType, [NotNull] Type expectedType)
        {
            return new ArgumentIsNotOfTypeException(argumentName, message ?? GetIsNotOfTypeErrorMessage(argumentName, argumentType, expectedType), expectedType.FullName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentIsNotOfTypeException"/> when the value specified with <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.
        /// </summary>
        /// <typeparam name="TArgument">The expected type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentIsNotOfTypeException">Raised when <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.</exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotOfType<TArgument>(
            [NotNull] this object argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            if (argument is TArgument)
                return;

            argumentName = argumentName ?? nameof(argument);

            throw ThrowArgumentIsNotOfType(argumentName, message, argument?.GetType(), typeof(TArgument));
        }

        /// <summary>
        /// Returns a correctly typed instance of the value specified with <paramref name="argument"/> tests positive for the shape of <typeparamref name="TArgument"/>.
        /// Throws an <see cref="ArgumentIsNotOfTypeException"/> otherwise.
        /// </summary>
        /// <typeparam name="TArgument">The expected type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <returns>The <paramref name="argument"/>.</returns>
        /// <exception cref="ArgumentIsNotOfTypeException">Raised when <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.</exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static TArgument PassThroughNonNotOfType<TArgument>(
            [NotNull] this object argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            if (argument is TArgument value)
                return value;

            argumentName = argumentName ?? nameof(argument);

            throw ThrowArgumentIsNotOfType(argumentName, message, argument?.GetType(), typeof(TArgument));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentIsNotOfTypeException"/> when the value specified with <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.
        /// </summary>
        /// <typeparam name="TArgument">The expected type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentIsNotOfTypeException">Raised when <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.</exception>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNullOrNotOfType<TArgument>(
            [CanBeNull, ValidatedNotNull] this object argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            argument.ThrowIfNull(argumentName, message);

            if (argument is TArgument)
                return;

            argumentName = argumentName ?? nameof(argument);

            throw ThrowArgumentIsNotOfType(argumentName, message, argument.GetType(), typeof(TArgument));
        }

        /// <summary>
        /// Returns a correctly typed instance of the value specified with <paramref name="argument"/> tests positive for the shape of <typeparamref name="TArgument"/>.
        /// Throws an <see cref="ArgumentIsNotOfTypeException"/> otherwise.
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// </summary>
        /// <typeparam name="TArgument">The expected type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <returns>The <paramref name="argument"/>.</returns>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentIsNotOfTypeException">Raised when <paramref name="argument"/> tests negative for the shape of <typeparamref name="TArgument"/>.</exception>
        [ContractAnnotation("argument:notnull => notnull; argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static TArgument PassThroughNonNullNorNotOfType<TArgument>(
            [CanBeNull, ValidatedNotNull] this object argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            argument.ThrowIfNull(argumentName, message);

            if (argument is TArgument value)
                return value;

            argumentName = argumentName ?? nameof(argument);

            throw ThrowArgumentIsNotOfType(argumentName, message, argument.GetType(), typeof(TArgument));
        }
    }
}