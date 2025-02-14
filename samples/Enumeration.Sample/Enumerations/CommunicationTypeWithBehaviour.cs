using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public class CommunicationTypeWithBehaviour : Enumeration<CommunicationTypeWithBehaviour>
{
    public static readonly CommunicationTypeWithBehaviour Email = new("Email");

    public static readonly CommunicationTypeWithBehaviour Sms = new("SMS");

    public static readonly CommunicationTypeWithBehaviour PushNotification = new("PushNotification");

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

    private CommunicationTypeWithBehaviour(string value) : base(value)
    {
    }
}