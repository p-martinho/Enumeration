[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![NuGet](https://img.shields.io/nuget/dt/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)
[![Build status](https://dev.azure.com/p-martinho/Enumeration/_apis/build/status/Enumeration-CI-CD)](https://dev.azure.com/p-martinho/Enumeration/_build/latest?definitionId=1)

# PMart.Enumeration

This set of libraries provide base classes to implement __Enumeration classes__, based on `string` values.
It enables the strongly typed advantages, while using `string` enumerations.

It has, also, the possibility to create new enumerations at runtime (let's call it [dynamic enumerations](#dynamic-enumerations)).

## What are Enumeration Classes?

[Enumeration classes](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types) are alternatives to [enum type in C#](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).
They enable features of an object-oriented language without the limitations of the `enum` type.

They are useful, for instance, for business related enumerations on Domain-Driven Design (DDD).

For more information, check the links on the section [References](#references).

## NuGet Packages

__PMart.Enumeration__: The Enumeration base classes.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.svg)](https://www.nuget.org/packages/PMart.Enumeration)

__PMart.Enumeration.EFCore__: The Entity Framework Core support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.EFCore.svg)](https://www.nuget.org/packages/PMart.Enumeration.EFCore)

__PMart.Enumeration.JsonNet__: The Json.NET support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.JsonNet.svg)](https://www.nuget.org/packages/PMart.Enumeration.JsonNet)

__PMart.Enumeration.SystemTextJson__: The System.Text.Json support for PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SystemTextJson.svg)](https://www.nuget.org/packages/PMart.Enumeration.SystemTextJson)

__PMart.Enumeration.SwaggerGen__: Support to generate Swagger documentation when using PMart.Enumeration.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.SwaggerGen.svg)](https://www.nuget.org/packages/PMart.Enumeration.SwaggerGen)

__PMart.Enumeration.Mappers__: Mappers and mapping extensions for Enumerations.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.Mappers.svg)](https://www.nuget.org/packages/PMart.Enumeration.Mappers)

__PMart.Enumeration.Generator__: A source generator for generating Enumeration classes from a few lines of code.
[![NuGet](https://img.shields.io/nuget/v/PMart.Enumeration.Generator.svg)](https://www.nuget.org/packages/PMart.Enumeration.Generator)

# Installation

Install one or more of the available NuGet packages:

```
Install-Package <package name>
```

# Usage

An `Enumeration` is a class that holds a value of type `string`. Each `Enumeration` class should have declared one or more static instances to set the available enumeration members.

- Create a new enumeration class by extending `Enumeration`.
- Add a private constructor, as in the example bellow.
- Create `public static readonly` instances for each enumeration member.

> Or you can use the [generator](#source-generator) in `PMart.Enumeration.Generator` package to generate the code for you!

Here is a [sample](./samples/Enumeration.Sample/Enumerations/CommunicationType.cs) for communication types:

```c#
using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationType : Enumeration<CommunicationType>
{
    public static readonly CommunicationType Email = new("Email");

    public static readonly CommunicationType Sms = new("SMS");
    
    public static readonly CommunicationType PushNotification = new("PushNotification");

    private CommunicationType(string value) : base(value)
    {
    }
}
```

Now, you can use it as an enumeration class, type safe, with all its advantages and [features](#features):

```c#
public bool IsToSendEmail(CommunicationType communicationType)
{
    return communicationType == CommunicationType.Email;
}
```

You can check some usage examples in the [samples](./samples/Enumeration.Sample/Samples).

## Features

The Enumeration classes enables the several features described bellow.

For instance, you can add [behaviour](#enumeration-with-behaviour), and/or you can use [dynamic enumerations](#dynamic-enumerations) (created in runtime), etc.

### Value

It is the `string` value that the enumeration class holds:

```c#
CommunicationType.Email.Value; // returns "Email"
```

The `ToString()` method also returns the value:

```c#
CommunicationType.Email.ToString(); // returns "Email"
```

### GetMembers

Get all the enumerations from an enumeration class:

```c#
var allCommunicationTypes = CommunicationType.GetMembers(); // returns an IEnumerable<CommunicationType> with CommunicationType.Email, CommunicationType.Sms and CommunicationType.PushNotification
var communicationTypesCount = CommunicationType.GetMembers().Count(); // returns 3
```

The list of possible enumerations is a `Lazy` object behind the scene, and it is evaluated only if needed.

### GetValues

Get all the possible values of an enumeration class:

```c#
var allCommunicationTypeValues = CommunicationType.GetValues(); // returns an IEnumerable<string> with "Email", "SMS" and "PushNotification"
var communicationTypeValuesCount = CommunicationType.GetValues().Count(); // returns 3
```

### HasValue

Find out if there is any enumeration with a specific value (__ignoring letters case__):

```c#
var hasValue = CommunicationType.HasValue("someUnknownValue"); // false
hasValue = CommunicationType.HasValue("Email"); // true
hasValue = CommunicationType.HasValue("EMAIL"); // true
```

### GetFromValueOrDefault

Get an enumeration instance from a `string` that matches the value of the enumeration (__ignoring letters case__), or `null` when there isn't any enumeration with that value:

```c#
// Parse the string to Enumeration:
var communicationType = CommunicationType.GetFromValueOrDefault("email"); // returns CommunicationType.Email

// Verify if exists an enumeration with the value (GetFromValueOrDefault returns null if there isn't any enumeration with the value).
var isValid = communicationType is not null; // true
```

__Note__: When there's instances with equivalent values (same value ignoring case), the `GetValueOrDefault` can return any of the instances (is nondeterministic). Therefore, enumerations members with equivalent values are not recommended.

```c#
// Let's imagine we have these two members:
// public static readonly CommunicationType Email = new("Email");
// public static readonly CommunicationType EmailWithDifferentCase = new("EMAIL"); // same value, different case (this is not recommended)

var emailType = CommunicationType.GetFromValueOrDefault("Email"); // this may return CommunicationType.Email or CommunicationType.EmailWithDifferentCase (they have equivalent values)
var isSame = ReferenceEquals(emailType, CommunicationType.Email); // sometimes is true, sometimes is false, is nondeterministic
var isEqual = emailType == EmailWithDifferentCase; // always true. Even if they are different instances, they are equal. Check the Equality section bellow.
```

### Equality

Two different instances of a type derived from `Enumeration` are equal if they are from the same enumeration type and if the value of both are equivalent, __ignoring letters case__.

```c#
// Let's imagine we have these two members:
// public static readonly CommunicationType Email = new("Email");
// public static readonly CommunicationType EmailWithDifferentCase = new("EMAIL"); // same value, different case (this is not recommended)

var isSame = ReferenceEquals(CommunicationType.Email, CommunicationType.EmailWithDifferentCase); // false (they are different instances)
var isEqual = CommunicationType.Email == CommunicationType.EmailWithDifferentCase; // true (they are different instances, but they have the same value, ignoring case)
```

It is also possible to test the equality between a `string` and an `Enumeration`. It also __ignores the letters case__. The `string` must be on the left side of the equality operator:

```c#
var isStringEqualToEnumeration = "email" == CommunicationType.Email; // true
isStringEqualToEnumeration = "EMAIL" == CommunicationType.Email; // true
```

### Switch

Since you have objects and not constant values (like in a `enum`), the `switch` statement can't be constructed the same way as for an `enum`, but you can, for example, use pattern matching [this way](./samples/Enumeration.Sample/Samples/SendCommunicationSampleUsingEnumeration.cs):

```c#
private ISender? GetCommunicationSenderForCommunicationType(CommunicationType communicationType)
{
    // A switch statement for pattern matching
    return communicationType switch
    {
        _ when communicationType == CommunicationType.Email => _emailSender,
        _ when communicationType == CommunicationType.PushNotification => _pushNotificationSender,
        _ when communicationType == CommunicationType.Sms => _smsSender,
        _ => null
    };
}
```

### Enumeration with Behaviour

We can add custom methods to the Enumeration class (it's an object, after all). A simple example, with a method `ParseMessage` and with a property `IsPhoneNumberRequired`:

```c#
using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationTypeWithBehaviour : Enumeration<CommunicationTypeWithBehaviour>
{
    public static readonly CommunicationTypeWithBehaviour Email = new("Email");

    public static readonly CommunicationTypeWithBehaviour Sms = new("SMS");

    public static readonly CommunicationTypeWithBehaviour PushNotification = new("PushNotification");

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public string ParseMessage(string message)
    {
        return $"Message parsed by the communication type {this}: {message}";
    }

    /// <summary>
    /// Gets a value indicating if this communication type requires phone number.
    /// </summary>
    /// <returns><c>true</c> if this communication type requires phone number; <c>false</c> otherwise.</returns>
    public bool IsPhoneNumberRequired => this switch
    {
        _ when this == Sms => true,
        _ when this == PushNotification => true,
        _ => false
    };

    private CommunicationTypeWithBehaviour(string value) : base(value)
    {
    }
}
```

We can also use inheritance to add specific behaviour or properties for each enumeration member in an enumeration class.
Check this [example](./samples/Enumeration.Sample/Enumerations/CommunicationTypeWithBehaviour.cs), where the communication type has subclasses with a specific implementation of `ParseMessage()` and `IsPhoneNumberRequired`:

```c#
using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public abstract class CommunicationTypeWithSpecificBehaviour : Enumeration<CommunicationTypeWithSpecificBehaviour>
{
    public static readonly CommunicationTypeWithSpecificBehaviour Email = new EmailType();

    public static readonly CommunicationTypeWithSpecificBehaviour Sms = new SmsType();
    
    public static readonly CommunicationTypeWithSpecificBehaviour PushNotification = new PushNotificationType();

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <remarks>Each communication type, implements its own way of parsing the message.</remarks>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public abstract string ParseMessage(string message);

    /// <summary>
    /// Gets a value indicating if this communication type requires phone number.
    /// </summary>
    /// <returns><c>true</c> if this communication type requires phone number; <c>false</c> otherwise.</returns>
    public abstract bool IsPhoneNumberRequired { get; }
    
    private CommunicationTypeWithSpecificBehaviour(string value) : base(value)
    {
    }

    private sealed class EmailType : CommunicationTypeWithSpecificBehaviour
    {
        public EmailType() : base("Email")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"<html>{message}</html>";
        }

        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => false;
    }
    
    private sealed class SmsType : CommunicationTypeWithSpecificBehaviour
    {
        public SmsType() : base("Sms")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"Message encoded for SMS: {message}";
        }
        
        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => true;
    }
    
    private sealed class PushNotificationType : CommunicationTypeWithSpecificBehaviour
    {
        public PushNotificationType() : base("PushNotification")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"Message encoded for push notification: {message}";
        }
        
        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => true;
    }
}
```

## Dynamic Enumerations

Instead of extending `Enumeration` class, you can extend the `EnumerationDynamic` class. The `EnumerationDynamic` class extends the `Enumeration` class, therefore it has the same features.
With this type, you will have an extra method that adds the possibility to create new `EnumerationDynamic` instances at runtime, if there isn't any enumeration member with a specific value.

To create an `EnumerationDynamic` is the same as `Enumeration`, but it requires a `public` empty constructor, in addition to the `private` constructor.

> You can use the [generator](#source-generator) in `PMart.Enumeration.Generator` package, that generates the code for you, and therefore you don't need to worry about the constructors.

Continuing with the communication types, here is an [example](./samples/Enumeration.Sample/Enumerations/CommunicationTypeDynamic.cs) using `EnumerationDynamic`:

```c#
using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationTypeDynamic : EnumerationDynamic<CommunicationTypeDynamic>
{
    public static readonly CommunicationTypeDynamic Email = new("Email");

    public static readonly CommunicationTypeDynamic Sms = new("SMS");
    
    public static readonly CommunicationTypeDynamic PushNotification = new("PushNotification");

    public CommunicationTypeDynamic()
    {
    }
    
    private CommunicationTypeDynamic(string value) : base(value)
    {
    }
}
```

Now, you can use the method `GetFromValueOrNew(string? value)`, that returns an instance of the enumeration type, or `null` if the provided value is `null`.
If there is an enumeration with the provided value (__ignoring letters case__), it will return that instance, else it will create a new instance with the provided value and return it (or `null` if the provided value is `null`).

```c#
var a = CommunicationTypeDynamic.GetFromValueOrNew("Email"); // returns CommunicationTypeDynamic.Email
var b = CommunicationTypeDynamic.GetFromValueOrNew("EMAIL"); // returns CommunicationTypeDynamic.Email
var c = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns new instance of CommunicationTypeDynamic, with value = "someUnknownType"
var d = CommunicationTypeDynamic.GetFromValueOrNew(null); // returns null

var aValue = a?.Value; // "Email"
var bValue = b?.Value; // "Email"
var cValue = c?.Value; // "someUnknownValue"
var dValue = d?.Value; // null
```

__Note:__ Instances with same value in different case are equal (check section [Equality](#equality)):

 ```c#
var a = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns a new instance of CommunicationTypeDynamic, with value = "someUnknownType"
var b = CommunicationTypeDynamic.GetFromValueOrNew("SOMEuNKNOWtTYPE"); // returns another new instance of CommunicationTypeDynamic, with value = "SOMEuNKNOWtTYPE"

var isAEqualToB = a == b; // true
var isASameInstanceThanB = ReferenceEquals(a, b); // false
```

__Note:__ when you create a new enumeration with `EnumerationDynamic`, that enumeration will not be added to the list of existent enumeration members:

 ```c#
var newCommunicationType = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns a new instance of CommunicationTypeDynamic, with value = "someUnknownType"

var existsTheNewTypeOnCommunicationTypes = CommunicationTypeDynamic
    .GetMembers()
    .Any(ct => ct == newCommunicationType); // false
```

### Why Dynamic Enumerations?

The `EnumerationDynamic` class can be useful when you want to accept values that are not in the declared enumerations or when you want to have the possibility to create new enumerations at runtime.

For example, an API __A__ sends data to API __B__ that then redirects the data to API __C__.
All these APIs use enumeration classes, but API __B__ don't care about the value, it just sends it to API __C__. So, using `EnumerationDynamic` on API __B__ you don't need to deploy API __B__ every time you had a new value to the enumeration on API __A__.
Other way, using `Enumeration` instead of `EnumerationDynamic`, you would need to update API __B__ in order to recognize the new enumeration member and send it to the API __C__.

Here is an [example](./samples/Enumeration.Sample/Samples/SendCommunicationSampleUsingEnumerationDynamic.cs):

 ```c#
public string SendCommunication(string communicationType, string to, string message)
{
    // Parse the string to an EnumerationDynamic.
    // It returns the enumeration with the value or a new instance of the enumeration if does not exist any enumeration declared with the value.
    var communicationTypeEnum = CommunicationTypeDynamic.GetFromValueOrNew(communicationType);
    
    // In this service, I don't care if the communication type is valid or not (if it is declared in the list of communication types).
    // I just need to parse it to use the Enumeration features (eg. type safety) and then redirect it to another service/API that will handle it.

    DoSomethingAboutTheCommunicationTypeDynamicEnumeration(communicationTypeEnum);
    
    _communicationSender.SendMessage(communicationTypeEnum?.Value, to, message);

    // ...
}
```

# EFCore Support

In EF Core, adding a property of type `Enumeration` or `EnumerationDynamic` to an entity requires to set the conversion in order to store the value of the enumeration on the database.
The NuGet package `PMart.Enumeration.EFCore` has the required converters, you just need to add them to your model configuration. Check this [sample](./samples/Enumeration.EFCore.Sample/DbContext/SampleDbContext.cs):

For this entity:

 ```c#
public class CommunicationRecord
{
    public Guid Id { get; set; }
    
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;

    public CommunicationType? Type { get; set; }

    public CommunicationTypeDynamic? TypeDynamic { get; set; }
}
```

You need to configure it on model creating this way on your `DbContext`:

 ```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<CommunicationRecord>(e =>
    {
        e.Property(p => p.Type)
            .HasConversion<EnumerationConverter<CommunicationType>>();

        e.Property(p => p.TypeDynamic)
            .HasConversion<EnumerationDynamicConverter<CommunicationTypeDynamic>>();
    });
}
```

An usage [sample](./samples/Enumeration.EFCore.Sample/Samples/CommunicationUsingEFCoreSample.cs):

```c#
public async Task<IEnumerable<CommunicationRecord>> GetCommunicationRecordsByType(CommunicationType communicationType)
{
    var records = await _context.CommunicationRecords
        .Where(r => r.Type == communicationType)
        .ToListAsync();

    return records;
}
```

> __Note:__ In a query, the case sensitivity is determined by the database provider.
E.g. if you save the record using an `EnumerationDynamic` with value `"Email"`, and then query the database using another instance of `EnumerationDynamic` with value `"EMAIL"`, it is possible you get no results, depending on the database.
> For example, __MS SQL Server__ is, by default, case-insensitive, so you would get the result.

# Json.NET Support

Using [Json.NET](https://www.newtonsoft.com), if you need to serialize/deserialize objects that contain properties of type `Enumeration`, without any converters, the enumeration property would act like a regular object.

For example, using this model:

```c#
public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;
    
    public CommunicationType Type { get; set; } = null!;
}
```

The JSON without any custom JSON converters would be like:

```json
{
  "sentAt": "0001-01-01",
  "to": "someone@email.com",
  "communicationType": {
    "value": "Email"
  }
}
```

Probably, you would like a JSON where the `CommunicationType` works like an `enum` or a `string` value:

```json
{
  "sentAt": "0001-01-01",
  "to": "someone@email.com",
  "communicationType": "Email"
}
```

For that, you just need to use the custom converters available on the NuGet package `PMart.Enumeration.JsonNet`.

An example where the converter is added by attribute:

```c#
public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;
    
    [JsonConverter(typeof(EnumerationConverter<CommunicationType>))]
    public CommunicationType Type { get; set; } = null!;
}
```

An example where the converter is added on the serializer converters:

```c#
public string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
{
    var json = JsonConvert.SerializeObject(communicationRecord, new EnumerationConverter<CommunicationType>());

    return json;
}
```

For enumerations of type `EnumerationDynamic`, you can use the generic converter `EnumerationDynamicConverter<T>`.

When you have several enumeration types that you would like to register globally, instead of registering all the converters of type `EnumerationConverter<T>` (or `EnumerationDynamicConverter<T>`), one for each enumeration type, you can use the non-generic converter `EnumerationConverter`.
This converter evaluates if the object is derived from `Enumeration` or `EnumerationDynamic` and handles it accordingly. It might be a little less performant.

```c#
public string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
{
    var json = JsonConvert.SerializeObject(communicationRecord, new EnumerationConverter());

    return json;
}
```

# System.Text.Json Support

Using `System.Text.Json`, if you need to serialize/deserialize objects that contain properties of type `Enumeration`, without any converters, the enumeration property would act like a regular object.

Again, for the same model example:

```c#
public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;
    
    public CommunicationType Type { get; set; } = null!;
}
```

The JSON without any custom JSON converters would be like:

```json
{
  "sentAt": "0001-01-01",
  "to": "someone@email.com",
  "communicationType": {
    "value": "Email"
  }
}
```

Probably, you would like a JSON where the `CommunicationType` works like a `enum` or a `string` value:

```json
{
  "sentAt": "0001-01-01",
  "to": "someone@email.com",
  "communicationType": "Email"
}
```

For that, you just need to use the JSON converter `EnumerationConverterFactory` available on the NuGet package `PMart.Enumeration.SystemTextJson`.

An example where the converter is added by attribute:

```c#
public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;
    
    [JsonConverter(typeof(EnumerationConverterFactory))]
    public CommunicationType Type { get; set; } = null!;
}
```

An example where the converter is added on the serializer options:

```c#
public string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
{
    var serializerOptions = GetSerializerOptions();

    var json = JsonSerializer.Serialize(communicationRecord, serializerOptions);

    return json;
}

private JsonSerializerOptions GetSerializerOptions()
{
    return new JsonSerializerOptions
    {
        Converters = { new EnumerationConverterFactory() }
    };
}
```

# Swagger Support

If you would like to add an enumeration property to a model from an API and would like to document it on Swagger like an `enum`, you should install the NuGet package `PMart.Enumeration.SwaggerGen` and add the schema filter `EnumerationSchemaFilter` to the Swagger options on your `Program.cs` (or `Startup.cs`), like in this [example](./samples/Enumeration.SwaggerGen.Sample/Program.cs):

```c#
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {Version = "v1", Title = "Sample API"});
    
    options.SchemaFilter<EnumerationSchemaFilter>();
});
```

Here's an example of the result:

![Swagger sample 1](./samples/Enumeration.SwaggerGen.Sample/Samples/Swagger-sample-1.png)

![Swagger sample 2](./samples/Enumeration.SwaggerGen.Sample/Samples/Swagger-sample-2.png)

# Mapping

## Map using built-in features

To map from a `Enumeration` or `EnumerationDynamic` to a `string`, it is very easy, as explained in the section [Features](#Value):

```c#
var stringValue = CommunicationType.Email.Value; // "Email"
// Or:
var stringValue = CommunicationType.Email.ToString(); // "Email"
```

To map from a `string` to a `Enumeration`, is also very easy, as explained in the section [Features](#GetFromValueOrDefault):

```c#
var enumeration = CommunicationType.GetFromValueOrDefault("Email"); // returns CommunicationType.Email
```

To benefit from the `EnumerationDynamic` features and map from a `string` to a `EnumerationDynamic`, as explained in the section [Dynamic Enumerations](#dynamic-enumerations), just use:

```c#
var enumeration = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns a new CommunicationTypeDynamic with value "someUnknownType"
```

To map between different types of `Enumeration` or `EnumerationDynamic`, you can do it like this for `Enumeration` types:

```c#
var enumeration = OtherCommunicationType.GetFromValueOrDefault(communicationType.Value);
```

Or like this for `EnumerationDynamic` types:

```c#
var enumeration = OtherCommunicationTypeDynamic.GetFromValueOrNew(communicationType.Value);
```

## Map using Extensions or Mappers

The NuGet package `PMart.Enumeration.Mappers` includes a set of [extensions](./src/Enumeration.Mappers/Extensions/EnumerationExtensions.cs) and [mappers](./src/Enumeration.Mappers) to help the mapping to/from `string` and between different types of `Enumeration` or `EnumerationDynamic`.
And they are prepared for `null` values.

Here is an [example](./samples/Enumeration.Mappers.Sample/Samples/MapCommunicationSample.cs) using the extensions and the mappers to map between `Enumeration` and `string`:

```c#
public string? MapCommunicationTypeToStringUsingExtensions(CommunicationType communicationType)
{
    return communicationType.MapToString();
}

public CommunicationType? MapStringToCommunicationTypeUsingExtensions(string communicationType)
{
    return communicationType.MapToEnumeration<CommunicationType>();
}

public string MapCommunicationTypeToStringUsingMapper(CommunicationType communicationType)
{
    return StringEnumerationMapper<CommunicationType>.MapToString(communicationType);
}

public CommunicationType MapStringToCommunicationTypeUsingMapper(string communicationType)
{
    return StringEnumerationMapper<CommunicationType>.MapToEnumeration(communicationType);
}
```

Here is an [example](./samples/Enumeration.Mappers.Sample/Samples/MapCommunicationDynamicSample.cs) using the extensions and the mappers to map between `EnumerationDynamic` and `string`:

```c#
public string? MapCommunicationTypeToStringUsingExtensions(CommunicationTypeDynamic communicationType)
{
    return communicationType.MapToString();
}

public CommunicationTypeDynamic? MapStringToCommunicationTypeUsingExtensions(string communicationType)
{
    return communicationType.MapToEnumerationDynamic<CommunicationTypeDynamic>();
}

public string MapCommunicationTypeToStringUsingMapper(CommunicationTypeDynamic communicationType)
{
    return StringEnumerationDynamicMapper<CommunicationTypeDynamic>.MapToString(communicationType);
}

public CommunicationTypeDynamic MapStringToCommunicationTypeUsingMapper(string communicationType)
{
    return StringEnumerationDynamicMapper<CommunicationTypeDynamic>.MapToEnumerationDynamic(communicationType);
}
```

To map between different types of `Enumeration`, you can follow this [example](./samples/Enumeration.Mappers.Sample/Samples/MapToOtherCommunicationSample.cs):

```c#
public OtherCommunicationType? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
{
    return OtherCommunicationType.GetFromValueOrDefault(communicationType.Value);
}

public OtherCommunicationType? MapToOtherTypeOfEnumerationUsingExtensions(CommunicationType communicationType)
{
    // Usage: ...MapToEnumeration<the source type, the destination type>();
    return communicationType.MapToEnumeration<CommunicationType, OtherCommunicationType>();
}

public OtherCommunicationType MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
{
    // Usage: EnumerationMapper<the source type, the destination type>.MapToEnumeration(...);
    return EnumerationMapper<CommunicationType, OtherCommunicationType>.MapToEnumeration(communicationType);
}
```

And finally, to map between different types of `Enumeration` where the destination is an `EnumerationDynamic`, you can follow this [example](./samples/Enumeration.Mappers.Sample/Samples/MapToOtherCommunicationDynamicSample.cs):

```c#
public OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
{
    return OtherCommunicationTypeDynamic.GetFromValueOrNew(communicationType.Value);
}

public OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumerationUsingExtensions(
    CommunicationType communicationType)
{
    // Usage: ...MapToEnumerationDynamic<the source type, the destination type>();
    return communicationType.MapToEnumerationDynamic<CommunicationType, OtherCommunicationTypeDynamic>();
}

public OtherCommunicationTypeDynamic MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
{
    // Usage: EnumerationDynamicMapper<the source type, the destination type>.MapToEnumerationDynamic(...);
    return EnumerationDynamicMapper<CommunicationType, OtherCommunicationTypeDynamic>.MapToEnumerationDynamic(
        communicationType);
}
```

## Using Mapperly

The [Mapperly](https://github.com/riok/mapperly) is a source generator for generating object mappings. To map objects that have properties of type `Enumeration` or `EnumerationDynamic` with __Mapperly__, you need to implement the mapping in the object mapper.

The NuGet package `PMart.Enumeration.Mappers` provides a set of [mappers](./src/Enumeration.Mappers) that can be used in __Mapperly__ mappers, without the need to implement manually the mapping.

In this example, we have a source object that is mapped to a destination object, which requires mapping from `Enumeration` to `string` (from `CommunicationType` to `string`) and between different types of `Enumeration` (from `CommunicationType` to `OtherCommunicationType`):

```c#
public class SourceObject
{
    public CommunicationType CommunicationType { get; set; } = null!;
    
    public CommunicationType OtherCommunicationType { get; set; } = null!;
}

public class DestinationObject
{
    public string CommunicationType { get; set; } = null!;
    
    public OtherCommunicationType OtherCommunicationType { get; set; } = null!;
}
```

For this example, we need to create a __Mapperly__ mapper, and we can use the [mappers](./src/Enumeration.Mappers) as [external mappings](https://mapperly.riok.app/docs/configuration/user-implemented-methods/#use-external-mappings), using the attribute `[UseStaticMapper]`:

```c#
// ...
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mappers.Sample.Samples.Mapperly.Mappers;

[Mapper]
[UseStaticMapper(typeof(StringEnumerationMapper<CommunicationType>))]
[UseStaticMapper(typeof(EnumerationMapper<CommunicationType, OtherCommunicationType>))]
internal partial class SampleMapper
{
    public partial DestinationObject SourceToDestination(SourceObject sourceModel);
}
```

For enumerations of type `EnumerationDynamic`, you can use the mappers [`StringEnumerationDynamicMapper`](./src/Enumeration.Mappers/StringEnumerationDynamicMapper.cs) and [`EnumerationDynamicMapper`](./src/Enumeration.Mappers/EnumerationDynamicMapper.cs).

You can check the sample [here](./samples/Enumeration.Mappers.Sample/Samples/Mapperly).

# Source Generator
TODO

# Disclaimer
While the enumeration class is a good alternative to `enum` type, it is more complex and also .NET doesn't handle it as it handles `enum` (e.g. JSON des/serialization, model binding, etc.), requiring custom code.
Please, be aware that enumeration class may not fit your needs.

# References

- [Microsoft Docs: Using enumeration classes instead of enum types](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types)
- [Jimmy Bogard: Enumeration Classes](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/)
- [Ardalis: Enum Alternatives in C#](https://ardalis.com/enum-alternatives-in-c)
- [Ardalis: SmartEnum](https://github.com/ardalis/SmartEnum)
- [Ankit Vijay: Enumeration Classes – DDD and beyond](https://ankitvijay.net/2020/06/12/series-enumeration-classes-ddd-and-beyond/)
- [Ankit Vijay: Enumeration](https://github.com/ankitvijay/Enumeration)
- [eShopOnContainers: Enumeration.cs](https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs)
