[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![NuGet](https://img.shields.io/nuget/dt/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![Build status](https://dev.azure.com/p-martinho/Enumeration/_apis/build/status/Enumeration-CI-CD)](https://dev.azure.com/p-martinho/Enumeration/_build/latest?definitionId=1)

# PMart.Enumeration

This set of libraries provide base classes to implement __Enumeration classes__, based on string values.
It enables the strongly typed advantages, while using string enumerations.

It has, also, the possibility to create new Enumerations at runtime (let's call it dynamic enumerations).

## What are enumeration classes?

[Enumeration classes](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) are alternatives to [enum type in C#](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).
They enable features of an object-oriented language without the limitations of the Enum's.

They are useful, for instance, for business related enumerations on Domain-Driven Design (DDD).

## NuGet Packages

__PMart.Enumeration__: The Enumeration base classes.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)

__PMart.Enumeration.EFCore__: The Entity Framework Core support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.EFCore.svg)](https://www.nuget.org/packages/PMart.Enumeration.EFCore)

__PMart.Enumeration.JsonNet__: The Json.NET support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.JsonNet.svg)](https://www.nuget.org/packages/PMart.Enumeration.JsonNet)

__PMart.Enumeration.SystemTextJson__: The System.Text.Json support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SystemTextJson.svg)](https://www.nuget.org/packages/PMart.Enumeration.SystemTextJson)

__PMart.Enumeration.SwaggerGen__: PMart.Enumeration support to generate Swagger documentation as enum type.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SwaggerGen.svg)](https://www.nuget.org/packages/PMart.Enumeration.SwaggerGen)

# Installation

Install one or more of the available NuGet packages:

```
Install-Package <package name>
```

# Usage (TODO)

dynamic, switch, if

## EFCore Support (TODO)

## Json.NET Support (TODO)

## System.Text.Json Support (TODO)

## Swagger Support (TODO)

# Disclaimer
While the Enumeration class is a good alternative to Enum type, it is more complex and also .NET doesn't handle is as it handles Enum's (eg. Json serialization, model binding, etc.), requiring custom code.
Please, be aware that Enumeration class may not fit your needs.

# References

- [Microsoft Docs: Using enumeration classes instead of enum types](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types)
- [Jimmy Bogard: Enumeration Classes](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/)
- [Ardalis: Enum Alternatives in C#](https://ardalis.com/enum-alternatives-in-c)
- [Ardalis: SmartEnum](https://github.com/ardalis/SmartEnum)
- [Ankit Vijay: Enumeration Classes – DDD and beyond](https://ankitvijay.net/2020/06/12/series-enumeration-classes-ddd-and-beyond/)
- [eShopOnContainers: Enumeration.cs](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs)

# TODO
- Finish README
- Sample