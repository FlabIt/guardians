# FlabIt Guardians

[![license](https://img.shields.io/github/license/FlabIt/guardians)](https://github.com/FlabIt/guardians/)
[![status-ci](https://github.com/FlabIt/guardians/workflows/Continuous%20Integration/badge.svg)](https://github.com/FlabIt/guardians/)
[![status-cd](https://github.com/FlabIt/guardians/workflows/Continuous%20Delivery/badge.svg)](https://github.com/FlabIt/guardians/)
[![nuget-version](https://img.shields.io/nuget/v/FlabIt.Guardians.svg)](https://www.nuget.org/packages/FlabIt.Guardians/)
[![nuget-downloads](https://img.shields.io/nuget/dt/FlabIt.Guardians.svg)](https://www.nuget.org/packages/FlabIt.Guardians/)

**FlabIt Guardians** helps you to easily fulfill a fundamental part of OOP: protecting your code against invalid values.  
This MIT-licensed library is [easy to use](#usage) and offers [an abundance](#features) of [well tested](#unit-tests) guardians and still remains extremely [performant and lightweight](#benchmarks).

Using guardians and following the [Fail Fast principle](https://enterprisecraftsmanship.com/posts/fail-fast-principle/), you can easily find and fix many bugs early in development and ship products that are more stable and contain less bugs.

- [FlabIt Guardians](#flabit-guardians)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Examples](#examples)
  - [Features](#features)
    - [Generic Guardians](#generic-guardians)
    - [String Guardians](#string-guardians)
    - [Guid Guardians](#guid-guardians)
    - [Enumerable Guardians](#enumerable-guardians)
    - [Exceptions](#exceptions)
  - [Integration with ReSharper](#integration-with-resharper)
  - [Unit Tests](#unit-tests)
  - [Benchmarks](#benchmarks)
  - [Release Notes](#release-notes)

## Installation

**FlabIt Guardians** are available as a NuGet package.

It can be installed using:

- [Paket](https://fsprojects.github.io/Paket/)
- .NET CLI
- NuGet Package Manager
- ...

Install using **Paket:**

```bash
paket add FlabIt.Guardians --project <project>
```

Install using **.NET CLI:**

```bash
dotnet add package FlabIt.Guardians
```

Install using **NuGet Package Manager**:

```bash
Install-Package FlabIt.Guardians
```

Please refer to the [FlabIt.Guardians NuGet package page](https://www.nuget.org/packages/FlabIt.Guardians/) for further information.

## Usage

Guardians come as extension methods so you can use them both ways, just as you like:

```cs
using FlabIt.Guardians;

public void Bar(object argument)
{
    // Specify implicit as extension method ...
    argument.ThrowIfNull();

    // ... or explicitly ...
    GenericGuardiansExtension.ThrowIfNull(argument);
}
```

You can also validate a value and pass it into another method or use it directly after successful validation:

```cs
using FlabIt.Guardians;

public void Bar(object argument)
{
    // Specify implicit as extension method ...
    var safeValue = argument.ThrowIfNull();

    // ... or explicitly ...
    var safeValue = GenericGuardiansExtension.ThrowIfNull(argument);
}
```

For more detailed information, you can also supply the name of the invalid argument and / or supply a custom message that will be used instead of the default one.

This works for all `ThrowIf...` guardians:

```cs
using FlabIt.Guardians;

public void Bar(object argument)
{
  // Exception will contain default argument name and default message
    argument.ThrowIfNull();

    // Exception will contain custom argument name and default message
    argument.ThrowIfNull(nameof(argument));
    
    // Exception will contain default argument name and custom message
    argument.ThrowIfNull(message: "A custom message");

    // Exception will contain custom argument name and custom message
    argument.ThrowIfNull(nameof(argument), "A custom message");
}
```

### Examples

Here's an example how to **guard a method against an argument being null**:

```cs
using FlabIt.Guardians;

public class Foo
{
    public void Bar(object shouldNotBeNull)
    {
        // This will throw an <see cref="System.ArgumentNullException" /> with an appropriate message when
        // the argument 'shouldNotBeNull' is null.
        shouldNotBeNull.ThrowIfNull();

        // ... do some safe work with 'shouldNotBeNull' here ...
    }
}
```

Here's an example how to **guard a method against an argument being null, otherwise passing it through**:

```cs
using FlabIt.Guardians;

public class Foo
{
    // The argument 'shouldNotBeNull' will be passed through to the string.Format() method when it's not null.
    // Otherwise this will throw an <see cref="System.ArgumentNullException" /> with an appropriate message.
    public void Bar(object shouldNotBeNull) =>
        string.Format("A value: '{0}'", shouldNotBeNull.ThrowIfNull());
}
```

## Features

Guardians will prevent you from invalid argument values by throwing an appropriate exception for the given case.  
Otherwise, the input argument will be returned and code execution just continues.

All Guardians follow the same pattern:

Besides the arguments to be checked, they also accept two optional `string` arguments, `argumentName` and `message`.

- `argumentName`: When specified, will be used instead of the default argument name for the exception that might be thrown.
- `message`: When specified, will be used instead of the default message for the exception that might be thrown.

### Generic Guardians

These will help to protect you from invalid reference type values.

**ThrowIfNull**

```cs
someValue.ThrowIfNull();
```

### String Guardians

These will help to protect you from invalid `System.String` values.

**ThrowIfNullOrEmpty**

```cs
someStringValue.ThrowIfNullOrEmpty();
```

**ThrowIfNullOrEmptyOrWhitespace**

```cs
someStringValue.ThrowIfNullOrEmptyOrWhitespace();
```

**ThrowIfNullOrWhitespace**

```cs
someStringValue.ThrowIfNullOrWhitespace();
```

**ThrowIfShorterThan**

```cs
int length;
someStringValue.ThrowIfShorterThan(length);
```

**ThrowIfLargerThan**

```cs
int length;
someStringValue.ThrowIfLargerThan(length);
```

### Guid Guardians

These will help to protect you from invalid `System.Guid` values.

**ThrowIfEmpty**

```cs
someGuidValue.ThrowIfEmpty();
```

### Enumerable Guardians

These will help to protect you from invalid enumerable values.

**ThrowIfNullOrEmpty**

```cs
someEnumerableValue.ThrowIfNullOrEmpty();
```

### Exceptions

There are several different types of exceptions that might be thrown and that you can use, too.

- ArgumentEmptyException
- ArgumentLengthShorterThanException
- ArgumentLengthLargerThanException
- ArgumentWhitespaceException
- ...

## Integration with ReSharper

This package integrates very well with ReSharper since the library is fully annotated using the [JetBrains.Annotations NuGet package](https://www.nuget.org/packages/JetBrains.Annotations/).

> **Note**:
> Although there is currently a dependency on the JetBrains.Annotations package, it is planned to remove this package dependency in the near future.  
> However, this does not change the annotations at all. Those using ReSharper will continue to experience the same annotation support as before.

## Unit Tests

This library is extensively unit tested.

You can take a look at the source or inspect the latest test results on the [workflows page](https://github.com/FlabIt/guardians/actions?query=workflow%3A%22Continuous+Delivery%22).

## Benchmarks

You can take a look at the source or inspect the latest benchmark results on the [workflows page](https://github.com/FlabIt/guardians/actions?query=workflow%3A%22Continuous+Delivery%22).

## Release Notes

You can get information about changes in this project via the [RELEASE_NOTES](./RELEASE_NOTES.md) file.