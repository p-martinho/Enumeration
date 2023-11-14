using Enumeration.Mappers.Sample.Enumerations;

namespace Enumeration.Mappers.Sample.Samples.Mapperly.Models;

public class DestinationObject
{
    public string CommunicationType { get; set; } = null!;

    public CommunicationType ToCommunicationType { get; set; } = null!;
    
    public string CommunicationTypeDynamic { get; set; } = null!;
    
    public CommunicationTypeDynamic ToCommunicationTypeDynamic { get; set; } = null!;
    
    public OtherCommunicationType ToOtherCommunicationType { get; set; } = null!;
    
    public OtherCommunicationTypeDynamic ToOtherCommunicationTypeDynamic { get; set; } = null!;
}