using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    public abstract class ReflectiveGuardiansExtensionTestBase : GuardiansTestBase
    {
        public static IEnumerable NullValuesTestValuesSource()
        {
            yield return null;
            yield return default(object);
            yield return default(string);
            yield return default(List);
        }

        public static IEnumerable NonNullValuesTestValuesSource()
        {
            yield return new object();
            yield return string.Empty;
            yield return " ";
            yield return "  ";
            yield return new List();
            yield return (bool?)true;
            yield return (bool?)false;
            yield return DateTime.Now;
        }

        public static IEnumerable StringTypedTestValuesSource()
        {
            yield return string.Empty;
            yield return " ";
        }

        public static IEnumerable NonStringTypedTestValuesSource()
        {
            yield return new object();
            yield return 1;
            yield return true;
        }

        public static IEnumerable ObjectTypedTestValuesSource()
        {
            yield return new object();
            yield return " ";
            yield return new List();
        }

        public static IEnumerable IEnumerableOfObjectTypedTestValuesSource()
        {
            yield return new List<object>();
            yield return new List<string>();
        }

        public static IEnumerable NonIEnumerableOfObjectTypedTestValuesSource()
        {
            yield return new List<int>();
            yield return true;
        }
    }
}