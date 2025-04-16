# PMart.Enumeration.Mappers

This is a package with mapping extensions and mappers for the __Enumeration classes__ (more information in the [main page](../../README.md)).

# Installation

Add the package to your project:
```bash
dotnet add package PMart.Enumeration.Mappers
```

# Usage

To map between __Enumeration classes__ or between __Enumeration classes__ and `string`, you can use built-in features, like explained in the section [Features](../Enumeration/README.md#mapping).

Anyway, the NuGet package `PMart.Enumeration.Mappers` includes a set of [extensions](./Extensions/EnumerationExtensions.cs) and [mappers](./src/Enumeration.Mappers) to help the mapping to/from `string` and between different types of `Enumeration` or `EnumerationDynamic`.
And they are prepared for `null` values.

Here is an [example](../../samples/Enumeration.Mappers.Sample/Samples/MapCommunicationSample.cs) using the extensions and the mappers to map between `Enumeration` and `string`:

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

Here is an [example](../../samples/Enumeration.Mappers.Sample/Samples/MapCommunicationDynamicSample.cs) using the extensions and the mappers to map between `EnumerationDynamic` and `string`:

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

To map between different types of `Enumeration`, you can follow this [example](../../samples/Enumeration.Mappers.Sample/Samples/MapToOtherCommunicationSample.cs):

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

And finally, to map between different types of `Enumeration` where the destination is an `EnumerationDynamic`, you can follow this [example](../../samples/Enumeration.Mappers.Sample/Samples/MapToOtherCommunicationDynamicSample.cs):

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

The NuGet package `PMart.Enumeration.Mappers` provides a set of mappers that can be used in __Mapperly__ mappers, without the need to implement the mapping manually.

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

For this example, we need to create a __Mapperly__ mapper, and we can use the mappers as [external mappings](https://mapperly.riok.app/docs/configuration/user-implemented-methods/#use-external-mappings), using the attribute `[UseStaticMapper]`:

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

For enumerations of type `EnumerationDynamic`, you can use the mappers [`StringEnumerationDynamicMapper`](./StringEnumerationDynamicMapper.cs) and [`EnumerationDynamicMapper`](./EnumerationDynamicMapper.cs).

You can check the sample [here](../../samples/Enumeration.Mappers.Sample/Samples/Mapperly).