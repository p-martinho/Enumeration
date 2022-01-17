using Enumeration.JsonNet.Sample.Enumerations;

namespace Enumeration.JsonNet.Sample.Models;

public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;
    
    public CommunicationType Type { get; set; } = null!;
}