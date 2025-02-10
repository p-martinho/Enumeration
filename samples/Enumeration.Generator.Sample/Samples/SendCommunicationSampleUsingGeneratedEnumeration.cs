using Enumeration.Generator.Sample.Enumerations;
using Enumeration.Generator.Sample.Senders;

namespace Enumeration.Generator.Sample.Samples;

public class SendCommunicationSampleUsingGeneratedEnumeration
{
    private readonly IEmailSender _emailSender;
    private readonly IPushNotificationSender _pushNotificationSender;
    private readonly ISmsSender _smsSender;

    public SendCommunicationSampleUsingGeneratedEnumeration(IEmailSender emailSender,
        IPushNotificationSender pushNotificationSender,
        ISmsSender smsSender)
    {
        _emailSender = emailSender;
        _pushNotificationSender = pushNotificationSender;
        _smsSender = smsSender;
    }

    public string SendCommunication(string communicationType, string to, string message)
    {
        // If this code compiles, the CommunicationType enumeration was properly generated.
        var communicationTypeEnum = CommunicationType.GetFromValueOrDefault(communicationType);
        
        var communicationSender = GetCommunicationSenderForCommunicationType(communicationTypeEnum);

        if (communicationSender == null)
        {
            return "Error: Communication type is not supported.";
        }

        communicationSender.SendMessage(to, message);

        return "Ok: Message sent successfully.";
    }

    private ISender? GetCommunicationSenderForCommunicationType(CommunicationType? communicationType)
    {
        // If this code compiles, the several CommunicationType enumeration members were properly generated.
        return communicationType switch
        {
            _ when communicationType == CommunicationType.Email => _emailSender,
            _ when communicationType == CommunicationType.PushNotification => _pushNotificationSender,
            _ when communicationType == CommunicationType.Sms => _smsSender,
            _ => null
        };
    }
}