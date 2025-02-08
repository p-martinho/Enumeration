using PMart.Enumeration.Generator;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration]
public partial class TestEnumerationWithMembersToIgnore
{
    private static readonly string ValueForCodeA = "CodeA";
    
    // Should be ignored: don't have ValueFor prefix nor EnumerationMemberAttribute.
    private static readonly string CodeB = "CodeB";
    
    // Should be ignored: is not private.
    public static readonly string ValueForCodeC = "CodeC";
    
    // Should be ignored: is not readonly.
    private static string ValueForCodeD = "CodeD";
    
    // Should be ignored: is not static.
    private readonly string ValueForCodeE = "CodeE";
    
    // Should be ignored: is not static readonly.
    private const string ValueForCodeF = "CodeF";
}