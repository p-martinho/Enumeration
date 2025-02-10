using PMart.Enumeration.Generator;

namespace Enumeration.Generator.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[Enumeration]
public partial class CommunicationType
{
    private static readonly string ValueForEmail = "Email";

    private static readonly string ValueForSms = "SMS";
    
    private static readonly string ValueForPushNotification = "PushNotification";
}