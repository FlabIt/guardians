using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    public abstract class StringGuardiansExtensionTestBase : GuardiansTestBase
    {
        public static IEnumerable<string> NullStringsTestValuesSource()
        {
            yield return null;
            yield return default(string);
        }

        public static IEnumerable NonNullStringsTestValuesSource()
        {
            return NonEmptyNonWhitespaceCharacters()
                .Concat(EmptyStrings())
                .Concat(WhitespaceStrings())
                .Concat(NonOnlyWhitespaceStrings());
        }

        public static IEnumerable EmptyStringsTestValuesSource()
        {
            return EmptyStrings();
        }

        public static IEnumerable NonEmptyStringsTestValuesSource()
        {
            return NonEmptyNonWhitespaceCharacters()
                .Concat(WhitespaceStrings())
                .Concat(NonOnlyWhitespaceStrings());
        }

        public static IEnumerable OnlyWhitespaceStringsTestValuesSource()
        {
            return WhitespaceStrings();
        }

        public static IEnumerable NonOnlyWhitespaceStringsTestValuesSource()
        {
            return NonOnlyWhitespaceStrings();
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

        private static IEnumerable<string> NonEmptyNonWhitespaceCharacters()
        {
            yield return "0";
            yield return "A";
            yield return "Aa";
        }

        private static IEnumerable<string> EmptyStrings()
        {
            yield return "";
            yield return string.Empty;
            yield return String.Empty;
            yield return "1".Remove(0, 1);
        }

        private static IEnumerable<string> WhitespaceStrings()
        {
            yield return ' '.ToString(CultureInfo.InvariantCulture);
            yield return " ";
            yield return "  ";
            yield return "   ";
        }

        private static IEnumerable<string> NonOnlyWhitespaceStrings()
        {
            yield return "a";
            yield return "0";
            yield return ".   ";
            yield return " .  ";
            yield return "  . ";
            yield return "   .";
        }
    }
}