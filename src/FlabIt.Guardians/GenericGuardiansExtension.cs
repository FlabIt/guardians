using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using FlabIt.Guardians.Properties;
using JetBrains.Annotations;

namespace FlabIt.Guardians
{
    /// <summary>
    /// A set of extension method guardians, or validation helper methods, that guard the calling code
    /// from unexpected inputs by stopping the code execution using reasonable exceptions.
    /// </summary>
    public static class GenericGuardiansExtension
    {
        private static string GetIsNullErrorMessage(string argumentName)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentNullMessageWithParamName, argumentName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// </summary>
        /// <typeparam name="TArgument">The type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<TArgument>(
            [CanBeNull, NoEnumeration, ValidatedNotNull] this TArgument argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            if (!(argument is null))
                return;

            argumentName ??= nameof(argument);

            throw new ArgumentNullException(argumentName, message ?? GetIsNullErrorMessage(argumentName));
        }

        /// <summary>
        /// Returns the specified <paramref name="argument"/> when it is not null. Throws an <see cref="ArgumentNullException"/> otherwise.
        /// </summary>
        /// <typeparam name="TArgument">The type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <returns>The <paramref name="argument"/>.</returns>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        [ContractAnnotation("argument:notnull => notnull; argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [NotNull]
        public static TArgument PassThroughNonNull<TArgument>(
            [CanBeNull, NoEnumeration, ValidatedNotNull] this TArgument argument,
            [CanBeNull, InvokerParameterName] string argumentName = null,
            [CanBeNull] string message = null)
            where TArgument : class
        {
            if (!(argument is null))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentNullException(argumentName, message ?? GetIsNullErrorMessage(argumentName));
        }
    }
}