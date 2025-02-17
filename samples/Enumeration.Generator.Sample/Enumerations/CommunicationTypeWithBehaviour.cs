using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationTypeWithBehaviour
{
    private static readonly string ValueForEmail = "Email";

    private static readonly string ValueForSms = "SMS";

    private static readonly string ValueForPushNotification = "PushNotification";

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public string ParseMessage(string message)
    {
        return $"Message parsed by the communication type {this}: {message}";
    }

    /// <summary>
    /// Gets a value indicating if this communication type requires phone number.
    /// </summary>
    /// <returns><c>true</c> if this communication type requires phone number; <c>false</c> otherwise.</returns>
    public bool IsPhoneNumberRequired => this switch
    {
        _ when this == Sms => true,
        _ when this == PushNotification => true,
        _ => false
    };
}