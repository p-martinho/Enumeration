using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public static class MapToOtherCommunicationDynamicSample
{
    public static OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
    {
        return OtherCommunicationTypeDynamic.GetFromValueOrNew(communicationType.Value);
    }

    public static OtherCommunicationTypeDynamic? MapToOtherTypeOfEnumerationUsingExtensions(
        CommunicationType communicationType)
    {
        return communicationType.MapToEnumerationDynamic<CommunicationType, OtherCommunicationTypeDynamic>();
    }

    public static OtherCommunicationTypeDynamic MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
    {
        return EnumerationDynamicMapper<CommunicationType, OtherCommunicationTypeDynamic>.MapToEnumerationDynamic(
            communicationType);
    }
}