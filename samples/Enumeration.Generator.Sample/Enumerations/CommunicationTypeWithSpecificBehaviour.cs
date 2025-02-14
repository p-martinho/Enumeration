using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationTypeWithSpecificBehaviour
{
    public static readonly CommunicationTypeWithSpecificBehaviour Email = new EmailType();

    public static readonly CommunicationTypeWithSpecificBehaviour Sms = new SmsType();
    
    public static readonly CommunicationTypeWithSpecificBehaviour PushNotification = new PushNotificationType();
    
    private static readonly string ValueForOther = "Other";

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <remarks>Each communication type, implements its own way of parsing the message.</remarks>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public virtual string ParseMessage(string message) => message;

    private sealed class EmailType : CommunicationTypeWithSpecificBehaviour
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
    
    private sealed class SmsType : CommunicationTypeWithSpecificBehaviour
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
    
    private sealed class PushNotificationType : CommunicationTypeWithSpecificBehaviour
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