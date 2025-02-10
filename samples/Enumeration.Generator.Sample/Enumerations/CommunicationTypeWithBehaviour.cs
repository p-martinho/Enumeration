using PMart.Enumeration.Generator;

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationTypeWithBehaviour
{
    public static readonly CommunicationTypeWithBehaviour Email = new EmailType();

    public static readonly CommunicationTypeWithBehaviour Sms = new SmsType();
    
    public static readonly CommunicationTypeWithBehaviour PushNotification = new PushNotificationType();
    
    private static readonly string ValueForOther = "Other";

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <remarks>Each communication type, implements its own way of parsing the message.</remarks>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public virtual string ParseMessage(string message) => message;

    private sealed class EmailType : CommunicationTypeWithBehaviour
    {
        public EmailType() : base("Email")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"<html>{message}</html>";
        }
    }
    
    private sealed class SmsType : CommunicationTypeWithBehaviour
    {
        public SmsType() : base("Sms")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"Message encoded for SMS: {message}";
        }
    }
    
    private sealed class PushNotificationType : CommunicationTypeWithBehaviour
    {
        public PushNotificationType() : base("PushNotification")
        {
        }
        
        /// <inheritdoc />
        public override string ParseMessage(string message)
        {
            return $"Message encoded for push notification: {message}";
        }
    }
}