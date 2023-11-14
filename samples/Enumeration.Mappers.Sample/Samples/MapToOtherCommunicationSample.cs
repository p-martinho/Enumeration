using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public class MapToOtherCommunicationSample
{
    public OtherCommunicationType? MapToOtherTypeOfEnumeration(CommunicationType communicationType)
    {
        return OtherCommunicationType.GetFromValueOrDefault(communicationType.Value);
    }

    public OtherCommunicationType? MapToOtherTypeOfEnumerationUsingExtensions(CommunicationType communicationType)
    {
        return communicationType.MapToEnumeration<CommunicationType, OtherCommunicationType>();
    }

    public OtherCommunicationType MapToOtherTypeOfEnumerationTypeUsingMapper(CommunicationType communicationType)
    {
        return EnumerationMapper<CommunicationType, OtherCommunicationType>.MapToEnumeration(communicationType);
    }
}