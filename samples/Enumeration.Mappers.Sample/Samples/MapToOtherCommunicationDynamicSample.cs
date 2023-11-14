using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public class MapToOtherCommunicationDynamicSample
{
    public OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
    {
        return OtherCommunicationTypeDynamic.GetFromValueOrNew(communicationType.Value);
    }

    public OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumerationUsingExtensions(
        CommunicationType communicationType)
    {
        return communicationType.MapToEnumerationDynamic<CommunicationType, OtherCommunicationTypeDynamic>();
    }

    public OtherCommunicationTypeDynamic MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
    {
        return EnumerationDynamicMapper<CommunicationType, OtherCommunicationTypeDynamic>.MapToEnumerationDynamic(
            communicationType);
    }
}