using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public static class MapCommunicationSample
{
    public static string MapCommunicationTypeToString(CommunicationType communicationType)
    {
        return communicationType.Value; // or: communicationType.ToString();
    }

    public static CommunicationType? MapStringToCommunicationType(string communicationType)
    {
        return CommunicationType.GetFromValueOrDefault(communicationType);
    }

    public static string? MapCommunicationTypeToStringUsingExtensions(CommunicationType communicationType)
    {
        return communicationType.MapToString();
    }

    public static CommunicationType? MapStringToCommunicationTypeUsingExtensions(string communicationType)
    {
        return communicationType.MapToEnumeration<CommunicationType>();
    }

    public static string MapCommunicationTypeToStringUsingMapper(CommunicationType communicationType)
    {
        return StringEnumerationMapper<CommunicationType>.MapToString(communicationType);
    }

    public static CommunicationType MapStringToCommunicationTypeUsingMapper(string communicationType)
    {
        return StringEnumerationMapper<CommunicationType>.MapToEnumeration(communicationType);
    }
}