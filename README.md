# PM.Enumeration

This set of libraries provide base classes to implement __Enumeration classes__.
It has, also, the possibility to create new Enumerations at runtime (let's call it dynamic enumeration).

##What are enumeration classes?

[Enumeration classes](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) are alternatives to Enum type in C#.
They enable features of an object-oriented language without the limitations of the Enum's.

They are useful, for instance, for business related enumerations on Domain-Driven Design (DDD).

##Packages

PM.Enumeration: The Enumeration class package.

PM.Enumeration.EFCore:

PM.Enumeration.JsonNet:

PM.Enumeration.SystemTextJson:

#Install

To install the Enumeration base classes:
```
Install-Package PM.Enumeration
```

To install support for EFCore:
```
Install-Package PM.Enumeration.EFCore
```

To install support for serialization (Json.NET):
```
Install-Package PM.Enumeration.JsonNet
```

To install support for serialization (System.Text.Json):
```
Install-Package PM.Enumeration.SystemTextJson
```

#Usage (TODO)

##EFCore Support (TODO)

##Json.NET Support (TODO)

##System.Text.Json Support (TODO)

#Disclaimer
While the Enumeration class is good alternative to Enum type, it is more complex and also .NET doesn't handle is as it handles Enum's (eg. Json serialization, model binding, etc.), requiring custom code.
Please, be aware that Enumeration class may not fit your needs.

#References

- [Microsoft Docs: Using enumeration classes instead of enum types](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types)
- [Jimmy Bogard: Enumeration Classes](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/)
- [Ardalis: Enum Alternatives in C#](https://ardalis.com/enum-alternatives-in-c)
- [Ardalis: SmartEnum](https://github.com/ardalis/SmartEnum)
- [Ankit Vijay: Enumeration Classes – DDD and beyond](https://ankitvijay.net/2020/06/12/series-enumeration-classes-ddd-and-beyond/)
- [eShopOnContainers: Enumeration.cs](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs)

##TODO
- Pipeline links
- Nuget links