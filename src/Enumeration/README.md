# PMart.Enumeration

This is the core package to use the __Enumeration classes__ (more information in the [main page](../../README.md)).

It enables the strongly typed advantages, while using `string` enumerations.
It has, also, the possibility to create new enumerations at runtime (let's call it [Dynamic Enumerations](#dynamic-enumerations)).

Check all the available [features](#features).

# Installation

Install the NuGet package in your project.

Use your IDE or the command:
```bash
dotnet add package PMart.Enumeration
```

# Usage

An `Enumeration` is a class that holds a value of type `string`. Each `Enumeration` class should have declared one or more static instances to set the available enumeration members.

- Create a new enumeration class by extending `Enumeration<T>`, where `T` is the class itself.
- Add a private constructor, as in the bellow example.
- Create a `public static readonly` instance of the class for each enumeration member.

> Or you can use the [Generator](../Enumeration.Generator/README.md) in `PMart.Enumeration.Generator` package to generate the code for you!

Here is a [sample](../../samples/Enumeration.Sample/Enumerations/CommunicationType.cs) for communication types:

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

You can check some usage examples in the [samples](../../samples/Enumeration.Sample/Samples).

# Features

The Enumeration classes enables the several features described bellow.
For instance, you can add [behavior](#enumeration-with-behavior), and/or you can use [dynamic enumerations](#dynamic-enumerations) (created in runtime), etc.

## Value

It is the `string` value that the enumeration class holds:

```c#
CommunicationType.Email.Value; // returns "Email"
```

The `ToString()` method also returns the value:

```c#
CommunicationType.Email.ToString(); // returns "Email"
```

## GetMembers

Get all the enumerations from an enumeration class:

```c#
var allCommunicationTypes = CommunicationType.GetMembers(); // returns an IEnumerable<CommunicationType> with CommunicationType.Email, CommunicationType.Sms and CommunicationType.PushNotification
var communicationTypesCount = CommunicationType.GetMembers().Count(); // returns 3
```

The list of possible enumerations is a `Lazy` object behind the scene, and it is evaluated only if needed.

## GetValues

Get all the possible values of an enumeration class:

```c#
var allCommunicationTypeValues = CommunicationType.GetValues(); // returns an IEnumerable<string> with "Email", "SMS" and "PushNotification"
var communicationTypeValuesCount = CommunicationType.GetValues().Count(); // returns 3
```

## HasValue

Find out if there is any enumeration member with a specific value (__ignoring letters case__):

```c#
var hasValue = CommunicationType.HasValue("someUnknownValue"); // false
hasValue = CommunicationType.HasValue("Email"); // true
hasValue = CommunicationType.HasValue("EMAIL"); // true
```

## GetFromValueOrDefault

Get an enumeration instance from a `string` that matches the value of the enumeration (__ignoring letters case__), or `null` when there isn't any enumeration with that value:

```c#
// Parse the string to Enumeration:
var communicationType = CommunicationType.GetFromValueOrDefault("email"); // returns CommunicationType.Email

// Verify if exists an enumeration with the value (GetFromValueOrDefault returns null if there isn't any enumeration with the value).
var isValid = communicationType is not null; // true
```

__Note__: When there's instances with equivalent values (same value ignoring case), the `GetValueOrDefault` can return any of the instances (is nondeterministic). Therefore, enumeration members with equivalent values are not recommended.

```c#
// Let's imagine we have these two members:
// public static readonly CommunicationType Email = new("Email");
// public static readonly CommunicationType EmailWithDifferentCase = new("EMAIL"); // same value, different case (this is not recommended)

var emailType = CommunicationType.GetFromValueOrDefault("Email"); // this may return CommunicationType.Email or CommunicationType.EmailWithDifferentCase (they have equivalent values)
var isSame = ReferenceEquals(emailType, CommunicationType.Email); // sometimes is true, sometimes is false, is nondeterministic
var isEqual = emailType == EmailWithDifferentCase; // always true. Even if they are different instances, they are equal. Check the Equality section bellow.
```

## Equality

Two different instances of a type derived from `Enumeration` are equal if they are from the same enumeration type
and if the value of both is equivalent, __ignoring letters case__.

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
var isStringNotEqualToEnumeration = "email" != CommunicationType.Email; // false
isStringNotEqualToEnumeration = "EMAIL" != CommunicationType.Email; // false
```

## Switch

Since you have objects and not constant values (like in a `enum`), the `switch` statement can't be constructed the same way as for an `enum`, but you can, for example, use pattern matching [this way](../../samples/Enumeration.Sample/Samples/SendCommunicationSampleUsingEnumeration.cs):

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

## Enumeration with Behavior

We can add custom methods to the Enumeration class (it's an object, after all).

Here is a simple example, with a method `ParseMessage` and with a property `IsPhoneNumberRequired`:

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

We can also use inheritance to add specific behavior or properties for each enumeration member in an Enumeration class.
Check this [example](../../samples/Enumeration.Sample/Enumerations/CommunicationTypeWithBehaviour.cs), where the communication type has subclasses with a specific implementation of `ParseMessage()` and `IsPhoneNumberRequired`:

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

Instead of extending `Enumeration` class, you can extend the `EnumerationDynamic` class.
The `EnumerationDynamic` class extends the `Enumeration` class, therefore, it has the same features.
With this type, you will have an extra method that adds the possibility to create new `EnumerationDynamic` instances at runtime, if there isn't any enumeration member with a specific value.

To create an `EnumerationDynamic` is the same as `Enumeration`, but it requires a `public` empty constructor, in addition to the `private` constructor.

> You can use the [Generator](../Enumeration.Generator/README.md) in `PMart.Enumeration.Generator` package, that generates the code for you, and therefore you don't need to worry about the constructors.

Continuing with the communication types, here is an [example](../../samples/Enumeration.Sample/Enumerations/CommunicationTypeDynamic.cs) using `EnumerationDynamic`:

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

__Note:__ Instances created with equivalent values are equal (check section [Equality](#equality)), but different instances:

 ```c#
var a = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns a new instance of CommunicationTypeDynamic, with value = "someUnknownType"
var b = CommunicationTypeDynamic.GetFromValueOrNew("someUnknownType"); // returns another new instance of CommunicationTypeDynamic, with value = "someUnknownType"
var c = CommunicationTypeDynamic.GetFromValueOrNew("SOMEuNKNOWtTYPE"); // returns another new instance of CommunicationTypeDynamic, with value = "SOMEuNKNOWtTYPE"

var isAEqualToB = a == b; // true
var isAEqualToC = a == c; // true
var isBEqualToC = b == c; // true
var isASameInstanceThanB = ReferenceEquals(a, b); // false
var isASameInstanceThanC = ReferenceEquals(a, c); // false
var isBSameInstanceThanC = ReferenceEquals(b, c); // false
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

You can check the example [here](../../samples/Enumeration.Sample/Samples/SendCommunicationSampleUsingEnumerationDynamic.cs).

## Mapping

To map from a `Enumeration` or `EnumerationDynamic` to a `string`, it is very easy, as explained in the section [Features](#Value):

```c#
var stringValue = CommunicationType.Email.Value; // "Email"
// Or:
var stringValue = CommunicationType.Email.ToString(); // "Email"
```

To map from a `string` to a `Enumeration`, is also straightforward, as explained in the section [Features](#GetFromValueOrDefault):

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