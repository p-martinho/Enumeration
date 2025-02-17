using PMart.Enumeration.Generator.Attributes;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationTypeWithMembersAttributes
{
    [EnumerationMember("Email")]
    private static readonly string EmailCode = "Email";

    [EnumerationMember("Sms")]
    private static readonly string SmsCode = "SMS";
    
    [EnumerationMember("PushNotification")]
    private static readonly string PushNotificationCode = "PushNotification";
    
    [EnumerationIgnore]
    private static readonly string SomeFieldThatShouldBeIgnored = "SomeValue";
}