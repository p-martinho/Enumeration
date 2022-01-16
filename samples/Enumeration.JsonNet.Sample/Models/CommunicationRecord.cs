using Enumeration.JsonNet.Sample.Enumerations;

namespace Enumeration.JsonNet.Sample.Models;

public class CommunicationRecord
{
    public string To { get; set; }
    
    public CommunicationType Type { get; set; }
}