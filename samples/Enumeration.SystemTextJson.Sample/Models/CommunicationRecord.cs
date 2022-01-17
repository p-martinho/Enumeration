using Enumeration.SystemTextJson.Sample.Enumerations;

namespace Enumeration.SystemTextJson.Sample.Models;

public class CommunicationRecord
{
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;

    public CommunicationType Type { get; set; } = null!;
}