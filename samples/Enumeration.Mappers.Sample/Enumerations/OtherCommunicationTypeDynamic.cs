using PMart.Enumeration;

namespace Enumeration.Mappers.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class OtherCommunicationTypeDynamic : EnumerationDynamic<OtherCommunicationTypeDynamic>
{
    public static readonly OtherCommunicationTypeDynamic Email = new("Email");

    public static readonly OtherCommunicationTypeDynamic Sms = new("SMS");
    
    public static readonly OtherCommunicationTypeDynamic PushNotification = new("PushNotification");

    private OtherCommunicationTypeDynamic(string value) : base(value)
    {
    }

    public OtherCommunicationTypeDynamic()
    {
    }
}