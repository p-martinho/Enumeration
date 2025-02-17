using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration]
public partial class TestEnumerationWithMemberAttribute
{
    [EnumerationMember("MemberCodeA")]
    private static readonly string CodeA = "CodeA";
    
    [EnumerationMember("MemberCodeB")]
    private static readonly string ValueForCodeB = "CodeB";
}