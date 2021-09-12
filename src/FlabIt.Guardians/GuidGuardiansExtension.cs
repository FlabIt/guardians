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
    /// A set of extension method guardians, or validation helper methods, for <see cref="Guid"/>s that guard the calling code
    /// from unexpected inputs by stopping the code execution using reasonable exceptions.
    /// </summary>
    public static class GuidGuardiansExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEmpty(Guid argument)
        {
            return argument.Equals(Guid.Empty);
        }

        private static string GetIsEmptyErrorMessage(string argumentName)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, argumentName, typeof(Guid).FullName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentEmptyException"/> when the specified <paramref name="argument"/> is equal to <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentEmptyException">Raised when <paramref name="argument"/> equals to <see cref="Guid.Empty"/>.</exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEmpty(
            this Guid argument,
            [CanBeNull, InvokerParameterName] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            if (!IsEmpty(argument))
                return;

            argumentName ??= nameof(argument);

            throw new ArgumentEmptyException(argumentName, message ?? GetIsEmptyErrorMessage(argumentName));
        }

        /// <summary>
        /// Returns the specified <paramref name="argument"/> when it is not equal to <see cref="Guid.Empty"/>. Throws an <see cref="ArgumentEmptyException"/> otherwise.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <returns>The <paramref name="argument"/>.</returns>
        /// <exception cref="ArgumentEmptyException">Raised when <paramref name="argument"/> equals to <see cref="Guid.Empty"/>.</exception>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid PassThroughNonEmpty(
            this Guid argument,
            [CanBeNull, InvokerParameterName] string? argumentName = null,
            [CanBeNull] string? message = null)
        {
            if (!IsEmpty(argument))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentEmptyException(argumentName, message ?? GetIsEmptyErrorMessage(argumentName));
        }
    }
}