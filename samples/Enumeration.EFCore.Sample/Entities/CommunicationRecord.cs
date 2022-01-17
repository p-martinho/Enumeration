using Enumeration.EFCore.Sample.Enumerations;

namespace Enumeration.EFCore.Sample.Entities;

public class CommunicationRecord
{
    public Guid Id { get; set; }
    
    public DateTime SentAt { get; set; }
    
    public string To { get; set; } = null!;

    public CommunicationType? Type { get; set; }

    public CommunicationTypeDynamic? TypeDynamic { get; set; }
}