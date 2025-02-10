using Enumeration.Generator.Sample.Enumerations;
using Enumeration.Generator.Sample.Senders;

namespace Enumeration.Generator.Sample.Samples;

public class SendCommunicationSampleUsingGeneratedEnumerationWithBehaviour
{
    private readonly ICommunicationSender _communicationSender;

    public SendCommunicationSampleUsingGeneratedEnumerationWithBehaviour(ICommunicationSender communicationSender)
    {
        _communicationSender = communicationSender;
    }

    public string SendCommunication(string communicationType, string to, string message)
    {
        // If this code compiles, the CommunicationTypeWithBehaviour enumeration was properly generated.
        var communicationTypeEnum = CommunicationTypeWithBehaviour.GetFromValueOrDefault(communicationType);
        
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