using PMart.Enumeration;

namespace Enumeration.Mappers.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class OtherCommunicationType : Enumeration<OtherCommunicationType>
{
    public static readonly OtherCommunicationType Email = new("Email");

    public static readonly OtherCommunicationType Sms = new("SMS");
    
    public static readonly OtherCommunicationType PushNotification = new("PushNotification");

    private OtherCommunicationType(string value) : base(value)
    {
    }
}