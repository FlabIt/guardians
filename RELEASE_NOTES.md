# Release Notes

## v0.10

### Features

* Remove Benchmarks (questionable results and a lot of maintenance overhead)

## v0.9

### Features

* Targeting for .NET 6.0
* Remove PassThrough... guardians as announced in v0.8
* Automatically determine correct argument name for exception message in case none is given
* Updated JetBrains.Annotations package to 2021.3.0

## v0.8

### Features

* Enabled nullable reference types
* Marked PassThrough... guardians as obsolete as their ThrowIf... counterpart now is able to return validated input arguments.  
**Note**: All PassThrough... guardians will be removed in upcoming versions!

## v0.7

### Features

* Set target framework to .Net 5.0
* Updated NuGet packages

## v0.6

### Features

* Adding description for NuGet package
* Improved exception code documentation
* Improved and added more tests
* Adding default value for argument names for Enumerable Guardians

### Fixes

* Fix default exception message in Enumerable Guardians would show wrong argument type

## v0.5

### Features

* Adding default value for argument names
* Adding tests for exceptions
* Added new String Guardian ThrowIfNullOrEmptyOrWhitespace
* Added ArgumentWhitespaceException exception
* ! Removed ArgumentEmptyOrWhitespaceException

## v0.4

### Features

* Faster and safer null checks using pattern matching
* Added benchmarks
* Shipping documentation

## v0.3

### Features

* Added Enumerable Guardians
* Added more tests

## v0.2

### Features

* Added new String Guardian IsLargerThan
* Added more tests
* Marked PassThrough methods return values with JetBrains.Annotations.NotNullAttribute

## v0.1

### Features

* Initial Release
