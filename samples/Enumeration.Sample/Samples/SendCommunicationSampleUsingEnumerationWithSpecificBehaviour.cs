using Enumeration.Sample.Enumerations;
using Enumeration.Sample.Senders;

namespace Enumeration.Sample.Samples;

public class SendCommunicationSampleUsingEnumerationWithSpecificBehaviour
{
    private readonly ICommunicationSender _communicationSender;

    public SendCommunicationSampleUsingEnumerationWithSpecificBehaviour(ICommunicationSender communicationSender)
    {
        _communicationSender = communicationSender;
    }

    public string SendCommunication(string communicationType, string to, string message)
    {
        var communicationTypeEnum = CommunicationTypeWithSpecificBehaviour.GetFromValueOrDefault(communicationType);
        
        if (communicationTypeEnum is null)
        {
            return "Bad request: invalid communication type.";
        }

        // The enumeration has behaviour and each communication type implements its own way of parsing the message.
        var parsedMessage = communicationTypeEnum.ParseMessage(message);
        
        _communicationSender.SendMessage(communicationTypeEnum.Value, to, parsedMessage);

        return "Ok: Message sent successfully.";
    }
}