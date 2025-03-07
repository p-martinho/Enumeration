﻿namespace Enumeration.Generator.Sample.Senders;

/// <summary>
/// Interface for communication sender.
/// </summary>
public interface ICommunicationSender
{
    void SendMessage(string? communicationType, string to, string message);
}