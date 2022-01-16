using PMart.Enumeration;
using PMart.Enumeration.SwaggerGen;
using Swashbuckle.AspNetCore.Annotations;

namespace Enumeration.SwaggerGen.Sample.Enumerations;

/// <summary>
/// The communication type enumeration.
/// </summary>
[SwaggerSchemaFilter(typeof(EnumerationSchemaFilter))]
public class CommunicationType : Enumeration<CommunicationType>
{
    public static readonly CommunicationType Email = new("Email");

    public static readonly CommunicationType Sms = new("SMS");
    
    public static readonly CommunicationType PushNotification = new("PushNotification");

    private CommunicationType(string value) : base(value)
    {
    }
}