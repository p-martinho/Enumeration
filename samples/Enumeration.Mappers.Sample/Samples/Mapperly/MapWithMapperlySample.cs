using Enumeration.Mappers.Sample.Samples.Mapperly.Mappers;
using Enumeration.Mappers.Sample.Samples.Mapperly.Models;

namespace Enumeration.Mappers.Sample.Samples.Mapperly;

public static class MapWithMapperlySample
{
    private static readonly SampleMapper Mapper = new();

    /// <summary>
    /// Maps from <see cref="SourceObject"/> to <see cref="DestinationObject"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <returns>The mapped object.</returns>
    public static DestinationObject MapObject(SourceObject source)
    {
        return Mapper.SourceToDestination(source);
    }
}