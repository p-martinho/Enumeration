using PMart.Enumeration;

namespace Enumeration.SwaggerGen.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationType : Enumeration<CommunicationType>
{
    /// <summary>
    /// The email type.
    /// </summary>
    public static readonly CommunicationType Email = new("Email");

    /// <summary>
    /// The SMS type.
    /// </summary>
    public static readonly CommunicationType Sms = new("SMS");
    
    /// <summary>
    /// The Push Notification type.
    /// </summary>
    public static readonly CommunicationType PushNotification = new("PushNotification");

    private CommunicationType(string value) : base(value)
    {
    }
}