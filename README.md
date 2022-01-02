# PM.Enumeration

This set of libraries provide base classes to implement __Enumeration classes__, based on string values.
It enables the strongly typed advantages, while using string enumerations.

It has, also, the possibility to create new Enumerations at runtime (let's call it dynamic enumeration).

## What are enumeration classes?

[Enumeration classes](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) are alternatives to [enum type in C#](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).
They enable features of an object-oriented language without the limitations of the Enum's.

They are useful, for instance, for business related enumerations on Domain-Driven Design (DDD).

## Packages

__PM.Enumeration__: The Enumeration base classes.

__PM.Enumeration.EFCore__: The Entity Framework Core support for PM.Enumeration.

__PM.Enumeration.JsonNet__: The Json.NET support for PM.Enumeration.

__PM.Enumeration.SystemTextJson__: The System.Text.Json support for PM.Enumeration.

# Install

Install one or more of the NuGet packages:

__PM.Enumeration__:

__PM.Enumeration.EFCore__:

__PM.Enumeration.JsonNet__:

__PM.Enumeration.SystemTextJson__:

# Usage (TODO)

## EFCore Support (TODO)

## Json.NET Support (TODO)

## System.Text.Json Support (TODO)

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

## TODO
- README
- Test on API/Backend/Database
- Publish NuGet (pipeline)
- Pipeline links
- Nuget links
- Sample