using PMart.Enumeration;

namespace Enumeration.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
public abstract class CommunicationTypeWithSpecificBehaviour : Enumeration<CommunicationTypeWithSpecificBehaviour>
{
    public static readonly CommunicationTypeWithSpecificBehaviour Email = new EmailType();

    public static readonly CommunicationTypeWithSpecificBehaviour Sms = new SmsType();
    
    public static readonly CommunicationTypeWithSpecificBehaviour PushNotification = new PushNotificationType();

    /// <summary>
    /// Parses the message.
    /// </summary>
    /// <remarks>Each communication type, implements its own way of parsing the message.</remarks>
    /// <param name="message">The message content.</param>
    /// <returns>The parsed message.</returns>
    public abstract string ParseMessage(string message);

    /// <summary>
    /// Gets a value indicating if this communication type requires phone number.
    /// </summary>
    /// <returns><c>true</c> if this communication type requires phone number; <c>false</c> otherwise.</returns>
    public abstract bool IsPhoneNumberRequired { get; }
    
    private CommunicationTypeWithSpecificBehaviour(string value) : base(value)
    {
    }

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

        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => false;
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
        
        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => true;
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
        
        /// <inheritdoc />
        public override bool IsPhoneNumberRequired => true;
    }
}