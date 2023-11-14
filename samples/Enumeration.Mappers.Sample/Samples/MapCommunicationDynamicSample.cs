using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public class MapCommunicationDynamicSample
{
    public string MapCommunicationTypeToString(CommunicationTypeDynamic communicationType)
    {
        return communicationType.Value; // or: communicationType.ToString();
    }

    public CommunicationTypeDynamic? MapStringToCommunicationType(string communicationType)
    {
        return CommunicationTypeDynamic.GetFromValueOrNew(communicationType);
    }

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
}