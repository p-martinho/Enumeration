using Enumeration.SystemTextJson.Sample.Enumerations;

namespace Enumeration.SystemTextJson.Sample.Models;

public class CommunicationRecord
{
    public string To { get; set; }
    
    public CommunicationType Type { get; set; }
}