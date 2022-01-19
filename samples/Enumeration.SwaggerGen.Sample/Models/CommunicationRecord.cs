using Enumeration.SwaggerGen.Sample.Enumerations;

namespace Enumeration.SwaggerGen.Sample.Models;

/// <summary>
/// The communication record.
/// </summary>
public class CommunicationRecord
{
    /// <summary>
    /// The date when the communication was sent.
    /// </summary>
    public DateTime SentAt { get; set; }
    
    /// <summary>
    /// The destination of the communication.
    /// </summary>
    public string To { get; set; } = null!;
    
    /// <summary>
    /// The communication type.
    /// </summary>
    public CommunicationType Type { get; set; } = null!;
}