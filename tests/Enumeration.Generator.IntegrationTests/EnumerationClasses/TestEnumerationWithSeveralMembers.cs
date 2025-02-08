using PMart.Enumeration.Generator;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration]
public partial class TestEnumerationWithSeveralMembers
{
    private static readonly string ValueForCodeA = "CodeA";
    private static readonly string ValueForCodeB = "CodeB";
    [EnumerationMember("CodeC")]
    private static readonly string CodeCa = "CodeC";
    
    // not readonly, member to ignore
    private static string ValueForCodeD = "CodeD";
}