using PMart.Enumeration;

namespace Enumeration.Mappers.Tests.EnumerationClasses;

internal class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));
    
    public static readonly TestEnumeration CodeB = new(nameof(CodeB));

    private TestEnumeration(string value) : base(value)
    {
    }
}