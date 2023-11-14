using Enumeration.Mappers.Sample.Samples.Mapperly.Mappers;
using Enumeration.Mappers.Sample.Samples.Mapperly.Models;

namespace Enumeration.Mappers.Sample.Samples.Mapperly;

public class MapWithMapperlySample
{
    private readonly SampleMapper _mapper = new SampleMapper();

    /// <summary>
    /// Maps from <see cref="SourceObject"/> to <see cref="DestinationObject"/>.
    /// </summary>
    /// <param name="source">The source object.</param>
    /// <returns>The mapped object.</returns>
    public DestinationObject MapObject(SourceObject source)
    {
        return _mapper.SourceToDestination(source);
    }
}