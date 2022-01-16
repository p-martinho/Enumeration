using Enumeration.Sample.Enumerations;
using Enumeration.Sample.Senders;

namespace Enumeration.Sample.Samples;

public class SendCommunicationSampleUsingEnumerationDynamic
{
    private readonly ICommunicationSender _communicationSender;

    public SendCommunicationSampleUsingEnumerationDynamic(ICommunicationSender communicationSender)
    {
        _communicationSender = communicationSender;
    }

    public string SendCommunication(string communicationType, string message)
    {
        // Parse the string to an EnumerationDynamic.
        // It returns the enumeration with the value or a new instance of the enumeration if does not exist any enumeration declared with the value.
        var communicationTypeEnum = CommunicationTypeDynamic.GetFromValueOrNew(communicationType);
        
        // In this service, I don't care if the communication type is valid or not, if it is declared in the list of communication types.
        // I just need to parse it to use the Enumeration features (eg. type safety) and then redirect it to another service/API that will handle it (in this case, the ICommunicationSender).

        DoSomethingAboutTheCommunicationTypeDynamicEnumeration(communicationTypeEnum);

        SendMessage(communicationTypeEnum.Value, message);

        return "Ok: Message sent successfully.";
    }

    private void DoSomethingAboutTheCommunicationTypeDynamicEnumeration(CommunicationTypeDynamic communicationTypeDynamic)
    {
        // Check if the communication type is a new one or a known one.
        var isCommunicationTypeDeclared = CommunicationTypeDynamic
            .GetMembers()
            .Any(ct => ct == communicationTypeDynamic);

        if (isCommunicationTypeDeclared)
        {
            Console.WriteLine($"The communication type is a known type.");
        }
        else
        {
            Console.WriteLine($"The communication type is a unknown type.");
        }
    }

    private void SendMessage(string communicationType, string message)
    {
        _communicationSender.SendMessage(communicationType, message);
    }
}