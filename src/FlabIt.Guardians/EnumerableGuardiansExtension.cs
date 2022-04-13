using System;
using System.Collections;
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
    public static class EnumerableGuardiansExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNotEmpty(IEnumerable enumerable)
        {
            return enumerable.GetEnumerator().MoveNext();
        }

        private static string GetIsEmptyErrorMessage(string argumentName, Type argumentType)
        {
            return string.Format(CultureInfo.InvariantCulture, Resources.Exception_ArgumentOfTypeXEmptyMessageWithParamName, argumentName, argumentType.FullName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> when the specified <paramref name="argument"/> is null.
        /// Note that the argument will be enumerated if possible.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">The name of the argument that, when specified, will be used instead of the default one.</param>
        /// <param name="message">A custom message that, when specified, will be used instead of the default one.</param>
        /// <exception cref="ArgumentNullException">Raised when <paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentEmptyException">Raised when <paramref name="argument"/> is empty.</exception>
        /// <returns>The <paramref name="argument" /> when it is not null nor empty.</returns>
        [ContractAnnotation("argument:null => halt")]
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable ThrowIfNullOrEmpty(
            [System.Diagnostics.CodeAnalysis.NotNull, ValidatedNotNull] this IEnumerable? argument,
            [InvokerParameterName, CallerArgumentExpression("argument")] string? argumentName = null,
            string? message = null)
        {
            argument = argument.ThrowIfNull(argumentName, message);

            if (IsNotEmpty(argument))
                return argument;

            argumentName ??= nameof(argument);

            throw new ArgumentEmptyException(argumentName, message ?? GetIsEmptyErrorMessage(argumentName, argument.GetType()));
        }
    }
}