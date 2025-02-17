using Enumeration.Generator.Sample.Enumerations;
using Enumeration.Generator.Sample.Senders;

namespace Enumeration.Generator.Sample.Samples;

public class SendCommunicationSampleUsingGeneratedEnumerationDynamic
{
    private readonly IEmailSender _emailSender;
    private readonly IPushNotificationSender _pushNotificationSender;
    private readonly ISmsSender _smsSender;
    private readonly ICommunicationSender _communicationSender;

    public SendCommunicationSampleUsingGeneratedEnumerationDynamic(IEmailSender emailSender,
        IPushNotificationSender pushNotificationSender,
        ISmsSender smsSender,
        ICommunicationSender communicationSender)
    {
        _emailSender = emailSender;
        _pushNotificationSender = pushNotificationSender;
        _smsSender = smsSender;
        _communicationSender = communicationSender;
    }

    public string SendCommunication(string communicationType, string to, string message)
    {
        // If this code compiles, the CommunicationTypeDynamic enumeration dynamic was properly generated.
        var communicationTypeEnum = CommunicationTypeDynamic.GetFromValueOrNew(communicationType);
        
        var communicationSender = GetCommunicationSenderForCommunicationType(communicationTypeEnum);

        if (communicationSender is null)
        {
            SendMessage(communicationTypeEnum?.Value, to, message);
        }
        else
        {
            communicationSender.SendMessage(to, message);
        }

        return "Ok: Message sent successfully.";
    }
    
    private ISender? GetCommunicationSenderForCommunicationType(CommunicationTypeDynamic? communicationType)
    {
        // If this code compiles, the several CommunicationTypeDynamic enumeration members were properly generated.
        return communicationType switch
        {
            _ when communicationType == CommunicationTypeDynamic.Email => _emailSender,
            _ when communicationType == CommunicationTypeDynamic.PushNotification => _pushNotificationSender,
            _ when communicationType == CommunicationTypeDynamic.Sms => _smsSender,
            _ => null
        };
    }

    private void SendMessage(string? communicationType, string to, string message)
    {
        _communicationSender.SendMessage(communicationType, to, message);
    }
}