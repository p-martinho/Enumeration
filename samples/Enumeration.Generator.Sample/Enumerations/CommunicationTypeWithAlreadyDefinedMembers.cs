using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationTypeWithAlreadyDefinedMembers
{
    public static readonly CommunicationTypeWithAlreadyDefinedMembers Email = new("Email");

    public static readonly CommunicationTypeWithAlreadyDefinedMembers Sms = new("SMS");
    
    public static readonly CommunicationTypeWithAlreadyDefinedMembers PushNotification = new("PushNotification");
}