using Enumeration.Mappers.Sample.Enumerations;
using Enumeration.Mappers.Sample.Samples.Mapperly.Models;
using PMart.Enumeration.Mappers;
using Riok.Mapperly.Abstractions;

namespace Enumeration.Mappers.Sample.Samples.Mapperly.Mappers;

/// <summary>
/// The Mapperly mapper to map from <see cref="SourceObject"/> to <see cref="DestinationObject"/>.
/// </summary>
[Mapper]
[UseStaticMapper(typeof(StringEnumerationMapper<CommunicationType>))]
[UseStaticMapper(typeof(EnumerationMapper<CommunicationType, OtherCommunicationType>))]
[UseStaticMapper(typeof(StringEnumerationDynamicMapper<CommunicationTypeDynamic>))]
[UseStaticMapper(typeof(EnumerationDynamicMapper<CommunicationTypeDynamic, OtherCommunicationTypeDynamic>))]
internal partial class SampleMapper
{
    public partial DestinationObject SourceToDestination(SourceObject sourceModel);
}