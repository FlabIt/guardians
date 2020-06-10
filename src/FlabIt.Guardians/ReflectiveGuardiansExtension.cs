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
        private static string GetIsNotOfTypeErrorMessage(string argumentName, Type? actualArgumentType, Type expectedArgumentType)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXIsNotOfTypeYMessageWithParamName, argumentName, actualArgumentType?.FullName, expectedArgumentType.FullName);
        }

        private static Exception ThrowArgumentIsNotOfType(string argumentName, string? message, Type? argumentType, Type expectedType)
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
            this object? argument,
            [InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            string? message = null)
            where TArgument : class
        {
            if (argument is TArgument)
                return;

            argumentName ??= nameof(argument);

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
            [ValidatedNotNull] this object? argument,
            [InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            string? message = null)
            where TArgument : class
        {
            argument.ThrowIfNull(argumentName, message);

            if (argument is TArgument)
                return;

            argumentName ??= nameof(argument);

            throw ThrowArgumentIsNotOfType(argumentName, message, argument.GetType(), typeof(TArgument));
        }
    }
}