namespace Enumeration.Sample.Senders;

/// <summary>
/// Interface for communication sender.
/// </summary>
public interface ISender
{
    void SendMessage(string to, string message);
}