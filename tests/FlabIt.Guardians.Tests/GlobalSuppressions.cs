// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(category: "Naming", checkId: "CA1303:Do not pass literals as localized parameters", Justification = "We don't want to use localized resources here.")]
[assembly: SuppressMessage(category: "Naming", checkId: "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
[assembly: SuppressMessage(category: "Naming", checkId: "CA2201:Do not raise reserved exception types", Justification = "We'll just use this as a test exception.")]
[assembly: SuppressMessage(category: "Naming", checkId: "CA2208:Instantiate argument exceptions correctly", Justification = "We supply the correct parameter name for the test here.")]
[assembly: SuppressMessage(category: "ReSharper", checkId: "InvokeAsExtensionMethod", Justification = "We'll want to be explicit here to know what methods we actually run.")]
[assembly: SuppressMessage(category: "ReSharper", checkId: "RedundantExplicitArrayCreation", Justification = "We'll want to be explicit here to know what types we actually use.")]
[assembly: SuppressMessage(category: "ReSharper", checkId: "RedundantTypeSpecificationInDefaultExpression", Justification = "We'll want to be explicit here to know what types we actually use.")]
[assembly: SuppressMessage(category: "StyleCop.CSharp.ReadabilityRules", checkId: "SA1121:Use built-in type alias", Justification = "Necessary for defining test cases.")]
[assembly: SuppressMessage(category: "StyleCop.CSharp.ReadabilityRules", checkId: "SA1122:Use string.Empty for empty strings", Justification = "Necessary for defining test cases.")]