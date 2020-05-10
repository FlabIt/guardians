using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:Use built-in type alias", Justification = "Necessary for defining test cases.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:Use string.Empty for empty strings", Justification = "Necessary for defining test cases.")]
    [SuppressMessage("ReSharper", "StringLiteralTypo", Justification = "We're constructing test cases here.")]
    [SuppressMessage("ReSharper", "RedundantTypeSpecificationInDefaultExpression", Justification = "We're constructing test cases here.")]
    public abstract class StringGuardiansExtensionTestBase : GuardiansTestBase
    {
        public static IEnumerable<string> NullStringsTestValuesSource()
        {
            yield return null;
            yield return default(string);
        }

        public static IEnumerable<string> NonNullStringsTestValuesSource()
        {
            yield return " ";
            yield return "0";
            yield return "A";
            yield return "Aa";
        }

        public static IEnumerable EmptyStringsTestValuesSource()
        {
            yield return "";
            yield return string.Empty;
            yield return String.Empty;
            yield return "1".Remove(0, 1);
        }

        public static IEnumerable NonEmptyStringsTestValuesSource()
        {
            yield return " ";
            yield return "0";
            yield return "A";
            yield return "Aa";
        }

        public static IEnumerable OnlyWhitespaceStringsTestValuesSource()
        {
            yield return ' '.ToString(CultureInfo.InvariantCulture);
            yield return " ";
            yield return "  ";
            yield return "   ";
        }

        public static IEnumerable NonOnlyWhitespaceStringsTestValuesSource()
        {
            yield return "a";
            yield return "0";
            yield return "   .";
            yield return ".   ";
        }

        public static IEnumerable StringsShorterThanLengthTestValuesSource()
        {
            yield return new TestCaseData(string.Empty, 1);
            yield return new TestCaseData("a", 2);
            yield return new TestCaseData("0", 3);
            yield return new TestCaseData("-", 4);
            yield return new TestCaseData(" ", 2);
            yield return new TestCaseData("asd", 5);
            yield return new TestCaseData("asd", 7);
            yield return new TestCaseData("asd", 8);
            yield return new TestCaseData("asd", 10);
            yield return new TestCaseData("Test", 10);
        }

        public static IEnumerable StringsLargerThanOrEqualToLengthTestValuesSource()
        {
            yield return new TestCaseData(string.Empty, -1);
            yield return new TestCaseData(string.Empty, 0);
            yield return new TestCaseData("0", 0);
            yield return new TestCaseData("-", 0);
            yield return new TestCaseData(" ", 0);
            yield return new TestCaseData(" ", 1);
            yield return new TestCaseData("a", 0);
            yield return new TestCaseData("aa", 0);
            yield return new TestCaseData("asd", 2);
            yield return new TestCaseData("asd", 3);
            yield return new TestCaseData("Test", 3);
            yield return new TestCaseData("asdasd", 5);
            yield return new TestCaseData("asdasdasdasd", 8);
        }

        public static IEnumerable StringsLargerThanLengthTestValuesSource()
        {
            yield return new TestCaseData(string.Empty, -1);
            yield return new TestCaseData("0", 0);
            yield return new TestCaseData("-", 0);
            yield return new TestCaseData(" ", 0);
            yield return new TestCaseData("a", 0);
            yield return new TestCaseData("aa", 0);
            yield return new TestCaseData("asd", 2);
            yield return new TestCaseData("asdf", 3);
            yield return new TestCaseData("Test", 3);
            yield return new TestCaseData("asdasd", 5);
            yield return new TestCaseData("asdasdasdasd", 8);
        }

        public static IEnumerable StringsShorterThanOrEqualToLengthTestValuesSource()
        {
            yield return new TestCaseData(string.Empty, 0);
            yield return new TestCaseData(string.Empty, 1);
            yield return new TestCaseData("a", 1);
            yield return new TestCaseData("a", 2);
            yield return new TestCaseData("0", 3);
            yield return new TestCaseData("-", 4);
            yield return new TestCaseData(" ", 2);
            yield return new TestCaseData("asd", 3);
            yield return new TestCaseData("asd", 5);
            yield return new TestCaseData("asd", 7);
            yield return new TestCaseData("asd", 8);
            yield return new TestCaseData("asd", 10);
            yield return new TestCaseData("Test", 4);
            yield return new TestCaseData("Test", 10);
        }
    }
}