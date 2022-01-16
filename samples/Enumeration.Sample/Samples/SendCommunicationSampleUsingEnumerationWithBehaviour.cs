﻿using Enumeration.Sample.Enumerations;
using Enumeration.Sample.Senders;

namespace Enumeration.Sample.Samples;

public class SendCommunicationSampleUsingEnumerationWithBehaviour
{
    private readonly ICommunicationSender _communicationSender;

    public SendCommunicationSampleUsingEnumerationWithBehaviour(ICommunicationSender communicationSender)
    {
        _communicationSender = communicationSender;
    }

    public string SendCommunication(string communicationType, string message)
    {
        var communicationTypeEnum = CommunicationTypeWithBehaviour.GetFromValueOrDefault(communicationType);
        
        if (communicationTypeEnum is null)
        {
            return "Bad request: invalid communication type.";
        }

        // The enumeration has behaviour and each communication type implements its own way of parsing the message.
        var parsedMessage = communicationTypeEnum.ParseMessage(message);
        
        _communicationSender.SendMessage(communicationTypeEnum.Value, parsedMessage);

        return "Ok: Message sent successfully.";
    }
}