using PMart.Enumeration;

namespace Enumeration.JsonNet.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationType : Enumeration<CommunicationType>
{
    public static readonly CommunicationType Email = new("Email");

    public static readonly CommunicationType Sms = new("SMS");
    
    public static readonly CommunicationType PushNotification = new("PushNotification");

    private CommunicationType(string value) : base(value)
    {
    }
}