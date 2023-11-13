using Enumeration.Mappers.Sample.Enumerations;
using PMart.Enumeration.Mappers;
using PMart.Enumeration.Mappers.Extensions;

namespace Enumeration.Mappers.Sample.Samples;

public class MapCommunicationSample
{
    public string MapCommunicationTypeToString(CommunicationType communicationType)
    {
        return communicationType.Value; // or: communicationType.ToString();
    }
    
    public CommunicationType? MapStringToCommunicationType(string communicationType)
    {
        return CommunicationType.GetFromValueOrDefault(communicationType);
    }
    
    public string? MapCommunicationTypeToStringUsingExtensions(CommunicationType communicationType)
    {
        return communicationType.MapToString();
    }
    
    public CommunicationType? MapStringToCommunicationTypeUsingExtensions(string communicationType)
    {
        return communicationType.MapToEnumeration<CommunicationType>();
    }
    
    public string MapCommunicationTypeToStringUsingMapper(CommunicationType communicationType)
    {
        return StringEnumerationMapper<CommunicationType>.MapToString(communicationType);
    }
    
    public CommunicationType MapStringToCommunicationTypeUsingMapper(string communicationType)
    {
        return StringEnumerationMapper<CommunicationType>.MapToEnumeration(communicationType);
    }
}