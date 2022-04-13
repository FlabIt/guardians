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
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.<br />
        /// When <paramref name="argument" /> is not null, it will be returned.
        /// </summary>
        /// <typeparam name="TArgument">The type of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <returns>The <paramref name="argument" /> when it is not null.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TArgument ThrowIfNull<TArgument>(
            [System.Diagnostics.CodeAnalysis.NotNull, NoEnumeration, ValidatedNotNull] this TArgument? argument,
            [InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            string? message = null)
            where TArgument : class
        {
            if (argument is not null)
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentNullException(argumentName, message ?? GetIsNullErrorMessage(argumentName));
        }
    }
}