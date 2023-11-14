using Enumeration.Mappers.Sample.Enumerations;

namespace Enumeration.Mappers.Sample.Samples.Mapperly.Models;

public class SourceObject
{
    public CommunicationType CommunicationType { get; set; } = null!;

    public string ToCommunicationType { get; set; } = null!;
    
    public CommunicationTypeDynamic CommunicationTypeDynamic { get; set; } = null!;
    
    public string ToCommunicationTypeDynamic { get; set; } = null!;
    
    public CommunicationType ToOtherCommunicationType { get; set; } = null!;
    
    public CommunicationTypeDynamic ToOtherCommunicationTypeDynamic { get; set; } = null!;
}