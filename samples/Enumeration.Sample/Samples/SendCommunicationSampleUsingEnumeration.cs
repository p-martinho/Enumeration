using Enumeration.Sample.Enumerations;
using Enumeration.Sample.Senders;

namespace Enumeration.Sample.Samples;

public class SendCommunicationSampleUsingEnumeration
{
    private readonly IEmailSender _emailSender;
    private readonly IPushNotificationSender _pushNotificationSender;
    private readonly ISmsSender _smsSender;

    public SendCommunicationSampleUsingEnumeration(IEmailSender emailSender,
        IPushNotificationSender pushNotificationSender,
        ISmsSender smsSender)
    {
        _emailSender = emailSender;
        _pushNotificationSender = pushNotificationSender;
        _smsSender = smsSender;
    }

    public string SendCommunication(string communicationType, string message)
    {
        // Parse the string to Enumeration:
        var communicationTypeEnum = CommunicationType.GetFromValueOrDefault(communicationType);
        
        // Validate the value: verify if it is a valid value...
        var isCommunicationTypeValid = CommunicationType.HasValue(communicationType);
        
        // ... Or verify if exists an enumeration with the value (GetFromValueOrDefault returns null if there isn't any enumeration with the value).
        isCommunicationTypeValid = communicationTypeEnum != null;

        if (!isCommunicationTypeValid)
        {
            return "Bad request: invalid communication type.";
        }

        // Now, I can use the communication type as an Enumeration, with all of its advantages and features.
        var communicationSender = GetCommunicationSenderForCommunicationType(communicationTypeEnum);

        if (communicationSender == null)
        {
            return "Error: Communication type is not supported.";
        }

        communicationSender.SendMessage(message);

        return "Ok: Message sent successfully.";
    }

    private ISender? GetCommunicationSenderForCommunicationType(CommunicationType communicationType)
    {
        // A switch statement for pattern matching
        return communicationType switch
        {
            var type when type == CommunicationType.Email => _emailSender,
            var type when type == CommunicationType.PushNotification => _pushNotificationSender,
            var type when type == CommunicationType.Sms => _smsSender,
            _ => null
        };
    }
}