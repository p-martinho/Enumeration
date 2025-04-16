using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public static class MapToOtherCommunicationSample
{
    public static OtherCommunicationType? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
    {
        return OtherCommunicationType.GetFromValueOrDefault(communicationType.Value);
    }

    public static OtherCommunicationType? MapToOtherTypeOfEnumerationUsingExtensions(CommunicationType communicationType)
    {
        return communicationType.MapToEnumeration<CommunicationType, OtherCommunicationType>();
    }

    public static OtherCommunicationType MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
    {
        return EnumerationMapper<CommunicationType, OtherCommunicationType>.MapToEnumeration(communicationType);
    }
}