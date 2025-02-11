using PMart.Enumeration.Generator.Attributes;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration]
public partial class TestEnumerationWithIgnoreAttribute
{
    private static readonly string ValueForCodeA = "CodeA";
    
    [EnumerationIgnore]
    private static readonly string ValueForCodeB = "CodeB";
    
    [EnumerationIgnore]
    [EnumerationMember("CodeC")]
    private static readonly string CodeC = "CodeC";
    
    [EnumerationMember("CodeD")]
    [EnumerationIgnore]
    private static readonly string CodeD = "CodeD";
}