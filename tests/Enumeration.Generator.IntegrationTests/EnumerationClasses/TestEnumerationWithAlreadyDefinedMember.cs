using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.IntegrationTests.EnumerationClasses;

[Enumeration]
public partial class TestEnumerationWithAlreadyDefinedMember
{
    public static readonly TestEnumerationWithAlreadyDefinedMember CodeA = new("CodeA");
}