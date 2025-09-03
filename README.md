[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![NuGet](https://img.shields.io/nuget/dt/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![Build status](https://dev.azure.com/p-martinho/Enumeration/_apis/build/status/Enumeration-CI-CD)](https://dev.azure.com/p-martinho/Enumeration/_build/latest?definitionId=1)

# PMart.Enumeration

This set of libraries provides base classes to implement __Enumeration classes__, based on `string` values.
It enables the strongly typed advantages, while using `string` enumerations.

It has, also, the possibility to create new enumerations at runtime (let's call it [Dynamic Enumerations](./src/Enumeration/README.md#dynamic-enumerations)).

## What are Enumeration Classes?

[Enumeration classes](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) are alternatives to [enum type in C#](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).
They enable features of an object-oriented language without the limitations of the `enum` type.

They are useful, for instance, for business related enumerations on Domain-Driven Design (DDD).

For more information about __Enumeration classes__, check the links on the section [References](#references).

## NuGet Packages

[__PMart.Enumeration__](./src/Enumeration/README.md): The Enumeration base classes.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)

[__PMart.Enumeration.EFCore__](./src/Enumeration.EFCore/README.md): The __Entity Framework Core__ support for `PMart.Enumeration`.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.EFCore.svg)](https://www.nuget.org/packages/PMart.Enumeration.EFCore)

[__PMart.Enumeration.JsonNet__](./src/Enumeration.JsonNet/README.md): The __Newtonsoft Json.NET__ support for `PMart.Enumeration`.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.JsonNet.svg)](https://www.nuget.org/packages/PMart.Enumeration.JsonNet)

[__PMart.Enumeration.SystemTextJson__](./src/Enumeration.SystemTextJson/README.md): The __System.Text.Json__ support for `PMart.Enumeration`.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SystemTextJson.svg)](https://www.nuget.org/packages/PMart.Enumeration.SystemTextJson)

[__PMart.Enumeration.SwaggerGen__](./src/Enumeration.SwaggerGen/README.md): Support to generate __Swagger__ documentation when using `PMart.Enumeration`.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SwaggerGen.svg)](https://www.nuget.org/packages/PMart.Enumeration.SwaggerGen)

[__PMart.Enumeration.Mappers__](./src/Enumeration.Mappers/README.md): Mappers and mapping extensions for Enumerations (includes mapper for __Mapperly__).
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.Mappers.svg)](https://www.nuget.org/packages/PMart.Enumeration.Mappers)

[__PMart.Enumeration.Generator__](./src/Enumeration.Generator/README.md): A source generator to generate __Enumeration classes__ from few lines of code.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.Generator.svg)](https://www.nuget.org/packages/PMart.Enumeration.Generator)

# Installation

Install one or more of the available NuGet packages in your project.

Use your IDE or the command:
```bash
dotnet add package <PACKAGE_NAME>
```

# Usage

Read the documentation of the core package `PMart.Enumeration` [here](./src/Enumeration/README.md), to learn how to use the `Enumeration` and `EnumerationDynamic` classes.

# EFCore Support

In EF Core, adding a property of type `Enumeration` or `EnumerationDynamic` to an entity requires setting the conversion to store the value of the enumeration on the database.
The NuGet package `PMart.Enumeration.EFCore` has the required converters, you just need to add them to your model configuration.

Read the documentation for the package `PMart.Enumeration.EFCore` [here](./src/Enumeration.EFCore/README.md).

# Newtonsoft Json.NET Support

Using [Newtonsoft Json.NET](https://www.newtonsoft.com), if you need to serialize/deserialize objects that contain properties of type `Enumeration` or `EnumerationDynamic`, without any converters, the enumeration property would act like a regular object.
The NuGet package `PMart.Enumeration.JsonNet` has the required converters to serialize the __Enumeration classes__ like an `enum` or a `string` value.

Read the documentation for the package `PMart.Enumeration.JsonNet` [here](./src/Enumeration.JsonNet/README.md).

# System.Text.Json Support

Using `System.Text.Json`, if you need to serialize/deserialize objects that contain properties of type `Enumeration` or `EnumerationDynamic`, without any converters, the enumeration property would act like a regular object.
The NuGet package `PMart.Enumeration.SystemTextJson` has the required converters to serialize the __Enumeration classes__ like an `enum` or a `string` value.

Read the documentation for the package `PMart.Enumeration.SystemTextJson` [here](./src/Enumeration.SystemTextJson/README.md).

# Swagger Support

In an API with __Swagger__, if you would like to document on an enumeration property like an `enum`,  you should use the NuGet package `PMart.Enumeration.SwaggerGen`.

Read the documentation for the package `PMart.Enumeration.SwaggerGen` [here](./src/Enumeration.SwaggerGen/README.md).

# Mapping

To map between __Enumeration classes__ or between __Enumeration classes__ and `string`, you can use built-in features, like explained in the section [Features](./src/Enumeration/README.md#mapping).

Anyway, the NuGet package `PMart.Enumeration.Mappers` includes a set of [extensions](./src/Enumeration.Mappers/Extensions/EnumerationExtensions.cs) and [mappers](./src/Enumeration.Mappers) to help the mapping to/from `string` and between different types of `Enumeration` or `EnumerationDynamic`.

They are useful, for instance, to add support for mappers like [Mapperly](https://github.com/riok/mapperly) (check how to map enumeration classes with __Mapperly__ [here](./src/Enumeration.Mappers/README.md#using-mapperly)).

Read the documentation for the package `PMart.Enumeration.Mappers` [here](./src/Enumeration.Mappers/README.md).

# Enumeration Generator

Creating a new __Enumeration class__ is a little bit verbose.
Therefore, the package `PMart.Enumeration.Generator` was added to help on that. It is an [incremental generator](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md).

Read the documentation for the package `PMart.Enumeration.Generator` [here](./src/Enumeration.Generator/README.md).

# Disclaimer
While the __Enumeration class__ is a good alternative to `enum` type, it is more complex and also .NET doesn't handle it as it handles `enum` (e.g. JSON des/serialization, model binding, etc.), requiring custom code.
Please be aware that __Enumeration class__ may not fit your needs.

# References
- Enumeration Classes:
  - [Microsoft Docs: Using enumeration classes instead of enum types](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types)
  - [Jimmy Bogard: Enumeration Classes](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes)
  - [Ardalis: Enum Alternatives in C#](https://ardalis.com/enum-alternatives-in-c)
  - [Ardalis: SmartEnum](https://github.com/ardalis/SmartEnum)
  - [Ankit Vijay: Enumeration Classes – DDD and beyond](https://ankitvijay.net/2020/06/12/series-enumeration-classes-ddd-and-beyond)
  - [Ankit Vijay: Enumeration](https://github.com/ankitvijay/Enumeration)
  - [eShopOnContainers: Enumeration.cs](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs)
- Incremental Generators:
  - [Roslyn Documentation: Incremental Generators](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.md)
  - [Roslyn Documentation: Incremental Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/incremental-generators.cookbook.md)
  - [Andrew Lock: Creating a source generator](https://andrewlock.net/series/creating-a-source-generator)
  - [Andrew Lock: NetEscapades.EnumGenerators](https://github.com/andrewlock/NetEscapades.EnumGenerators)