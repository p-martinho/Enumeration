using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public static class MapCommunicationDynamicSample
{
    public static string MapCommunicationTypeToString(CommunicationTypeDynamic communicationType)
    {
        return communicationType.Value; // or: communicationType.ToString();
    }

    public static CommunicationTypeDynamic? MapStringToCommunicationType(string communicationType)
    {
        return CommunicationTypeDynamic.GetFromValueOrNew(communicationType);
    }

    public static string? MapCommunicationTypeToStringUsingExtensions(CommunicationTypeDynamic communicationType)
    {
        return communicationType.MapToString();
    }

    public static CommunicationTypeDynamic? MapStringToCommunicationTypeUsingExtensions(string communicationType)
    {
        return communicationType.MapToEnumerationDynamic<CommunicationTypeDynamic>();
    }

    public static string MapCommunicationTypeToStringUsingMapper(CommunicationTypeDynamic communicationType)
    {
        return StringEnumerationDynamicMapper<CommunicationTypeDynamic>.MapToString(communicationType);
    }

    public static CommunicationTypeDynamic MapStringToCommunicationTypeUsingMapper(string communicationType)
    {
        return StringEnumerationDynamicMapper<CommunicationTypeDynamic>.MapToEnumerationDynamic(communicationType);
    }
}