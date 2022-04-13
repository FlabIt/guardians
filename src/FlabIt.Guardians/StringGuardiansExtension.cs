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
    /// A set of extension method guardians, or validation helper methods, for strings that guard the calling code
    /// from unexpected inputs by stopping the code execution using reasonable exceptions.
    /// </summary>
    public static class StringGuardiansExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEmpty(string argument)
        {
            return argument.Length == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsShorterThan(string argument, int length)
        {
            return argument.Length < length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsLargerThan(string argument, int length)
        {
            return argument.Length > length;
        }

        private static bool IsOnlyWhitespaces(string argument)
        {
            if (argument.Length == 0)
                return false;

            for (var i = 0; i < argument.Length; i++)
            {
                if (!char.IsWhiteSpace(argument[i]))
                    return false;
            }

            return true;
        }

        private static string GetIsEmptyErrorMessage(string argumentName)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, argumentName, typeof(string).FullName);
        }

        private static string GetIsShorterThanErrorMessage(string argumentName, int expectedLength, int actualLength)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXShorterThanMessageWithParamName, argumentName, typeof(string).FullName, expectedLength, actualLength);
        }

        private static string GetIsLargerThanErrorMessage(string argumentName, int expectedLength, int actualLength)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXLargerThanMessageWithParamName, argumentName, typeof(string).FullName, expectedLength, actualLength);
        }

        private static string GetIsOnlyWhitespacesErrorMessage(string argumentName)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXOnlyWhitespaceMessageWithParamName, argumentName, typeof(string).FullName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentEmptyException"/> when the specified <paramref name="argument"/> is empty.
        /// For more information see <see cref="string.IsNullOrEmpty"/>.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentEmptyException">Raised when <paramref name="argument"/> is empty.</exception>
        /// <returns>The <paramref name="argument" /> when it is not null or empty.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static string ThrowIfNullOrEmpty(
            [System.Diagnostics.CodeAnalysis.NotNull, CanBeNull, ValidatedNotNull] this string? argument,
            [CanBeNull, InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            argument = argument.ThrowIfNull(argumentName, message);

            if (!IsEmpty(argument))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentEmptyException(argumentName, message ?? GetIsEmptyErrorMessage(argumentName));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentEmptyException"/> when the specified <paramref name="argument"/> is empty.
        /// Throws an <see cref="ArgumentWhitespaceException"/> when the specified <paramref name="argument"/> consists only of whitespaces.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentEmptyException">Raised when <paramref name="argument"/> is empty.</exception>
        /// <exception cref="ArgumentWhitespaceException">Raised when <paramref name="argument"/> consists only of whitespaces.</exception>
        /// <returns>The <paramref name="argument" /> when it is not null nor empty nor consists only of whitespaces.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static string ThrowIfNullOrEmptyOrWhitespace(
            [System.Diagnostics.CodeAnalysis.NotNull, CanBeNull, ValidatedNotNull] this string? argument,
            [CanBeNull, InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            return argument
                .ThrowIfNullOrEmpty(argumentName, message)
                .ThrowIfNullOrWhitespace(argumentName, message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentWhitespaceException"/> when the specified <paramref name="argument"/> consists only of whitespaces.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentWhitespaceException">Raised when <paramref name="argument"/> consists only of whitespaces.</exception>
        /// <returns>The <paramref name="argument" /> when it is not null nor consists only of whitespaces.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static string ThrowIfNullOrWhitespace(
            [System.Diagnostics.CodeAnalysis.NotNull, CanBeNull, ValidatedNotNull] this string? argument,
            [CanBeNull, InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            argument = argument.ThrowIfNull(argumentName, message);

            if (!IsOnlyWhitespaces(argument))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentWhitespaceException(argumentName, message ?? GetIsOnlyWhitespacesErrorMessage(argumentName));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentLengthShorterThanException"/> when the specified <paramref name="argument"/> is shorter than <paramref name="length"/>.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="length">The length threshold.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentLengthShorterThanException">Raised when <paramref name="argument"/> is shorter than <paramref name="length"/>.</exception>
        /// <returns>The <paramref name="argument" /> when it has the same or greater length than specified with <paramref name="length"/>.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static string ThrowIfShorterThan(
            [System.Diagnostics.CodeAnalysis.NotNull, NotNull, ValidatedNotNull] this string argument,
            int length,
            [CanBeNull, InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            argument = argument.ThrowIfNull(argumentName, message);

            if (!IsShorterThan(argument, length))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentLengthShorterThanException(argumentName, message ?? GetIsShorterThanErrorMessage(argumentName, length, argument.Length));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Throws an <see cref="ArgumentLengthLargerThanException"/> when the specified <paramref name="argument"/> is larger than <paramref name="length"/>.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="length">The length threshold.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentLengthLargerThanException">Raised when <paramref name="argument"/> is larger than <paramref name="length"/>.</exception>
        /// <returns>The <paramref name="argument" /> when it has the same or shorter length than specified with <paramref name="length"/>.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static string ThrowIfLargerThan(
            [System.Diagnostics.CodeAnalysis.NotNull, NotNull, ValidatedNotNull] this string argument,
            int length,
            [CanBeNull, InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            argument = argument.ThrowIfNull(argumentName, message);

            if (!IsLargerThan(argument, length))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentLengthLargerThanException(argumentName, message ?? GetIsLargerThanErrorMessage(argumentName, length, argument.Length));
        }
    }
}