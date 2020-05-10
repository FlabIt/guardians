using System;

namespace FlabIt.Guardians
{
    /// <summary>
    /// This attribute will help tell the analyzer (rule CA1062) that the parameters decorized with this will
    /// definitively be checked for null references before being used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class ValidatedNotNullAttribute : Attribute
    {
    }
}